import { useEffect, useState } from "react";
import api from "../api/client";
import Spinner from "../components/Spinner";
import { Link } from "react-router-dom";

export default function Hotels() {
  const [hotels, setHotels] = useState(null);
  const [q, setQ] = useState("");

  useEffect(() => {
    (async () => {
      try {
        const res = await api.get("/Hotels"); // ✅ call API
        const hotelsArray = res.data.data;   // ✅ unwrap `data`
        const withImg = hotelsArray.map((h, i) => ({
          ...h,
          imageUrl:
            h.imageUrl ||
            `https://source.unsplash.com/800x600/?hotel,${encodeURIComponent(
              h.city || "resort"
            )}&sig=${i}`,
        }));
        setHotels(withImg);
      } catch (err) {
        console.error("Failed to fetch hotels", err);
      }
    })();
  }, []);

  if (!hotels) return <Spinner />;

  const filtered = q
    ? hotels.filter((h) =>
        (h.name + " " + (h.city || "") + " " + (h.country || ""))
          .toLowerCase()
          .includes(q.toLowerCase())
      )
    : hotels;

  return (
    <div
      style={{
        background: "linear-gradient(to right, #6a11cb, #2575fc)", // Gradient background
        padding: "2rem 0", // Add padding around the content
        minHeight: "100vh",
      }}
    >
      <div className="container">
        <div className="card" style={{ padding: "1rem", marginBottom: "1.5rem" }}>
          <input
            className="input"
            placeholder="Search by name/city/country…"
            value={q}
            onChange={(e) => setQ(e.target.value)}
            style={{
              width: "100%",
              padding: "0.8rem",
              borderRadius: "8px",
              border: "1px solid #ddd",
              backgroundColor: "#fff",
              boxShadow: "0 4px 10px rgba(0, 0, 0, 0.1)",
            }}
          />
        </div>
        <div className="grid cols-3" style={{ gap: "1.5rem" }}>
          {filtered.map((h) => (
            <div
              key={h.id}
              className="card"
              style={{
                backgroundColor: "#fff",
                boxShadow: "0 6px 18px rgba(0, 0, 0, 0.1)",
                borderRadius: "8px",
                overflow: "hidden",
                transition: "transform 0.3s ease",
              }}
              onMouseEnter={(e) => e.target.style.transform = "scale(1.05)"}
              onMouseLeave={(e) => e.target.style.transform = "scale(1)"}
            >
              <img
                src={h.imageUrl}
                alt={h.name}
                style={{
                  width: "100%",
                  height: "200px",
                  objectFit: "cover",
                  transition: "transform 0.5s ease-in-out",
                }}
              />
              <div className="card-body" style={{ padding: "1rem" }}>
                <h3 style={{ margin: "0 0 0.25rem" }}>{h.name}</h3>
                <div className="subtitle" style={{ marginBottom: "0.4rem", color: "#555" }}>
                  {h.city}, {h.country}
                </div>
                <p style={{ minHeight: "2.2em", color: "#334155" }}>
                  {h.address}
                </p>
                <Link
                  className="btn"
                  to={`/hotels/${h.id}`}
                  style={{
                    display: "inline-block",
                    padding: "0.6rem 1.2rem",
                    backgroundColor: "#2575fc",
                    color: "#fff",
                    borderRadius: "5px",
                    textAlign: "center",
                    textDecoration: "none",
                    marginTop: "1rem",
                    transition: "background-color 0.3s ease",
                  }}
                >
                  View Rooms
                </Link>
              </div>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
}
