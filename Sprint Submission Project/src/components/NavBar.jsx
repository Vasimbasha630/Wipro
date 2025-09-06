import { Link, NavLink } from "react-router-dom";
import { useAuth } from "../auth/AuthContext";

export default function NavBar() {
  const auth = useAuth();
  const { user, logout } = auth || {}; // safe destructure

  return (
    <header className="header">
      <div
        className="container"
        style={{
          display: "flex",
          alignItems: "center",
          justifyContent: "space-between",
          padding: ".9rem 1rem",
        }}
      >
        <Link className="brand" to="/" style={{ color: "#3498db", fontWeight: "800" }}>
          StayFinder
        </Link>
        <nav className="nav">
          <NavLink
            to="/hotels"
            activeStyle={{
              color: "#fbbf24", // gold when active
              fontWeight: "700",
            }}
            style={{
              color: "#3498db", // blue color for Hotels
              margin: "0 1rem",
            }}
          >
            Hotels
          </NavLink>
          {user && (
            <NavLink
              to="/me/bookings"
              activeStyle={{
                color: "#fbbf24", // gold when active
                fontWeight: "700",
              }}
              style={{
                color: "#7f8c8d", // muted gray for My Bookings
                margin: "0 1rem",
              }}
            >
              My Bookings
            </NavLink>
          )}
          {user?.role === "Admin" && (
            <NavLink
              to="/admin"
              activeStyle={{
                color: "#fbbf24", // gold when active
                fontWeight: "700",
              }}
              style={{
                color: "#7f8c8d", // muted gray for Admin
                margin: "0 1rem",
              }}
            >
              Admin
            </NavLink>
          )}
          {!user ? (
            <>
              <NavLink
                to="/login"
                activeStyle={{
                  color: "#fbbf24", // gold when active
                  fontWeight: "700",
                }}
                style={{
                  color: "#2ecc71", // green color for Login
                  margin: "0 1rem",
                }}
              >
                Login
              </NavLink>
              <NavLink
                to="/register"
                activeStyle={{
                  color: "#fbbf24", // gold when active
                  fontWeight: "700",
                }}
                style={{
                  color: "#e67e22", // orange color for Register
                  margin: "0 1rem",
                }}
              >
                Register
              </NavLink>
            </>
          ) : (
            <button
              className="btn secondary"
              onClick={logout}
              style={{
                backgroundColor: "#e74c3c", // red for logout
                color: "#fff",
                padding: "0.7rem 1rem",
                border: "none",
                borderRadius: "0.7rem",
                cursor: "pointer",
              }}
            >
              Logout
            </button>
          )}
        </nav>
      </div>
    </header>
  );
}
