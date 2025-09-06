import { useEffect, useState } from "react";
import { useParams, useNavigate, useLocation } from "react-router-dom";
import api from "../api/client";
import Spinner from "../components/Spinner";
import { useAuth } from "../auth/AuthContext";
import toast from "react-hot-toast";

export default function HotelDetails() {
  const { id } = useParams();
  const [hotel, setHotel] = useState(null);
  const [rooms, setRooms] = useState([]);
  const [dates, setDates] = useState({ in: "", out: "" });
  const [busy, setBusy] = useState(false);
  const { user } = useAuth();
  const nav = useNavigate();
  const loc = useLocation();

  // ✅ Restore dates + auto-book after login
  useEffect(() => {
    if (loc.state?.dates) setDates(loc.state.dates);

    if (loc.state?.bookNow && user) {
      book(loc.state.bookNow, true);
    }
  }, [loc.state, user]);

  // ✅ Fetch hotel once
  useEffect(() => {
    (async () => {
      try {
        const hotelsRes = await api.get("/Hotels");
        const hotelsArray = Array.isArray(hotelsRes.data)
          ? hotelsRes.data
          : hotelsRes.data?.data || [];

        const foundHotel = hotelsArray.find((h) => h.id === parseInt(id));
        if (!foundHotel) {
          setHotel(null);
          setRooms([]);
          return;
        }

        const hImg =
          foundHotel.imageUrl ||
          `https://source.unsplash.com/1400x420/?hotel,resort&sig=${id}`;

        setHotel({ ...foundHotel, imageUrl: hImg });
      } catch (err) {
        console.error("Error fetching hotel:", err);
        setHotel(null);
      }
    })();
  }, [id]);

  // ✅ Fetch rooms whenever hotel or dates change
  useEffect(() => {
    if (!hotel) return;

    (async () => {
      try {
        let url = `/Rooms/by-hotel/${id}`;
        if (dates.in && dates.out) {
          url += `?checkIn=${dates.in}&checkOut=${dates.out}`;
        }

        const roomsRes = await api.get(url);
        const roomsArray = Array.isArray(roomsRes.data)
          ? roomsRes.data
          : roomsRes.data?.data || [];

        const filteredRooms = roomsArray.map((rm, i) => ({
          ...rm,
          imageUrl:
            rm.imageUrl ||
            `https://source.unsplash.com/600x400/?hotel-room&sig=${i}`,
        }));

        setRooms(filteredRooms);
      } catch (err) {
        console.error("Error fetching rooms:", err);
        setRooms([]);
      }
    })();
  }, [id, hotel, dates]);

  // ✅ Booking function
  const book = async (roomId, auto = false) => {
    if (!user) {
      nav("/login", { state: { from: `/hotels/${id}`, dates, bookNow: roomId } });
      return;
    }

    if (!dates.in || !dates.out) {
      if (!auto) toast.error("Select check-in and check-out dates");
      return;
    }

    try {
      setBusy(true);
      const { data } = await api.post("/Booking", {
        roomId,
        checkInDate: new Date(dates.in).toISOString(),
        checkOutDate: new Date(dates.out).toISOString(),
      });

      console.log("Booking API response:", data);

      const bookingId =
        data.id || data.bookingId || data.data?.id || data.data?.bookingId;

      if (!bookingId) {
        toast.error("Booking created but no ID returned");
        return;
      }

      toast.success("Room reserved. Proceed to payment.");
      nav(`/pay/${bookingId}`);
    } catch (e) {
      console.error("Booking error:", e.response?.data || e.message);
      toast.error(e?.response?.data?.message || "Booking failed");
    } finally {
      setBusy(false);
    }
  };

  if (!hotel) return <Spinner />;

  return (
    <div style={{ marginTop: "1.2rem" }}>
      {/* Hotel Info */}
      <div className="card">
        <img src={hotel.imageUrl} alt={hotel.name} />
        <div className="card-body">
          <h2 style={{ margin: "0 0 .3rem" }}>{hotel.name}</h2>
          <div className="subtitle">
            {hotel.address} — {hotel.city}, {hotel.country}
          </div>
        </div>
      </div>

      {/* Date Selectors */}
      <div className="card" style={{ marginTop: "1rem", padding: "1rem" }}>
        <div
          style={{
            display: "flex",
            gap: "1rem",
            flexWrap: "wrap",
            alignItems: "end",
          }}
        >
          <div>
            <label className="subtitle">Check-in</label>
            <input
              className="input"
              type="date"
              value={dates.in}
              onChange={(e) => setDates((s) => ({ ...s, in: e.target.value }))}
            />
          </div>
          <div>
            <label className="subtitle">Check-out</label>
            <input
              className="input"
              type="date"
              value={dates.out}
              onChange={(e) => setDates((s) => ({ ...s, out: e.target.value }))}
            />
          </div>
        </div>
      </div>

      {/* Rooms */}
      <h3 className="section-title">Available Rooms</h3>
      <div className="grid cols-3">
        {rooms.length ? (
          rooms.map((r) => (
            <div key={r.id} className="card">
              <img src={r.imageUrl} alt={r.type} />
              <div className="card-body">
                <div
                  style={{
                    display: "flex",
                    justifyContent: "space-between",
                    alignItems: "center",
                  }}
                >
                  <strong>
                    {r.type} — #{r.roomNumber}
                  </strong>
                  {r.isAvailable ? (
                    <span className="badge">Available</span>
                  ) : (
                    <span
                      className="badge"
                      style={{ background: "#fee2e2", color: "#991b1b" }}
                    >
                      Unavailable
                    </span>
                  )}
                </div>
                <div style={{ margin: ".5rem 0 1rem" }}>
                  ₹ {Number(r.price).toLocaleString()}
                </div>
                <button
                  className="btn"
                  disabled={!r.isAvailable || busy}
                  onClick={() => book(r.id)}
                >
                  {r.isAvailable ? "Book" : "Not available"}
                </button>
              </div>
            </div>
          ))
        ) : (
          <p>No rooms found for this hotel.</p>
        )}
      </div>
    </div>
  );
}
