import { useState } from "react";
import { useAuth } from "../auth/AuthContext";
import { useNavigate, useLocation, Link } from "react-router-dom";
import toast from "react-hot-toast";

export default function Login() {
  const { login, loading } = useAuth();
  const nav = useNavigate();
  const loc = useLocation();
  const [form, setForm] = useState({ email: "", password: "" });

  const submit = async (e) => {
    e.preventDefault();
    try {
      const res = await login(form.email, form.password);

      if (res.ok) {
        const user = res.user;

        // ✅ restore previous location (with dates + bookNow)
        const redirectTo = loc.state?.from || 
          (user?.role === "Admin" ? "/admin" : "/hotels");

        toast.success(
          user?.role === "Admin" ? "Welcome Admin!" : "Welcome Guest!"
        );

        // ✅ pass the state back (dates, bookNow)
        nav(redirectTo, { replace: true, state: loc.state });
      } else {
        toast.error(res.message || "Login failed");
      }
    } catch (err) {
      console.error("Login error:", err);
      toast.error("Login failed");
    }
  };

  return (
    <div
      className="hero"
      style={{
        backgroundImage:
          'url("https://images.unsplash.com/photo-1521747116042-5a810fda9664?crop=entropy&cs=tinysrgb&fit=max&ixid=MnwzNjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&q=80&w=1080")',
        backgroundSize: "cover",
        backgroundPosition: "center",
        height: "100vh",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      <div className="inner">
        <div className="container" style={{ maxWidth: "450px" }}>
          <form
            onSubmit={submit}
            className="form-box"
            style={{
              width: "100%",
              background: "rgba(255, 255, 255, 0.85)",
              padding: "2rem",
              borderRadius: "8px",
              boxShadow: "0 10px 20px rgba(0, 0, 0, 0.1)",
            }}
          >
            <h2 style={{ marginTop: 0, color: "#3498db", textAlign: "center" }}>
              Login
            </h2>
            <p
              className="subtitle"
              style={{
                textAlign: "center",
                marginTop: "-0.4rem",
                color: "#555",
              }}
            >
              Access booking & payments
            </p>

            <div style={{ marginTop: "1rem" }}>
              <input
                className="input"
                type="email"
                placeholder="Email"
                value={form.email}
                onChange={(e) => setForm({ ...form, email: e.target.value })}
                required
                style={{
                  width: "100%",
                  padding: "0.8rem",
                  borderRadius: "5px",
                  border: "1px solid #ddd",
                  marginBottom: "1rem",
                }}
              />
            </div>
            <div style={{ marginTop: "1rem" }}>
              <input
                className="input"
                type="password"
                placeholder="Password"
                value={form.password}
                onChange={(e) =>
                  setForm({ ...form, password: e.target.value })
                }
                required
                style={{
                  width: "100%",
                  padding: "0.8rem",
                  borderRadius: "5px",
                  border: "1px solid #ddd",
                  marginBottom: "1rem",
                }}
              />
            </div>
            <button
              className="btn"
              style={{
                marginTop: "1.5rem",
                width: "100%",
                background: "#3498db",
                color: "#fff",
                padding: "0.8rem",
                borderRadius: "5px",
                border: "none",
                cursor: "pointer",
                fontSize: "16px",
                fontWeight: "bold",
                transition: "background-color 0.3s ease",
              }}
              disabled={loading}
            >
              {loading ? "Signing in…" : "Login"}
            </button>

            <p style={{ marginTop: "1rem", textAlign: "center", fontSize: "14px" }}>
              New here?{" "}
              <Link
                to="/register"
                style={{
                  color: "#e67e22",
                  fontWeight: "500",
                  textDecoration: "none",
                }}
              >
                Create an account
              </Link>
            </p>
          </form>
        </div>
      </div>
    </div>
  );
}
