import { useState } from "react";
import { useAuth } from "../auth/AuthContext";
import { useNavigate, useLocation, Link } from "react-router-dom";
import toast from "react-hot-toast";

export default function Register() {
  const { register, loading } = useAuth();
  const nav = useNavigate();
  const loc = useLocation();
  const [form, setForm] = useState({ name: "", email: "", password: "" });

  // ✅ carry booking context forward (hotel, dates, roomId)
  const from = loc.state?.from || "/";
  const dates = loc.state?.dates || null;
  const bookNow = loc.state?.bookNow || null;

  const submit = async (e) => {
    e.preventDefault();
    try {
      const res = await register(form.name, form.email, form.password);

      if (res.ok) {
        toast.success("Account created! Please login.");
        // ✅ redirect to login and preserve booking info
        nav("/login", { state: { from, dates, bookNow } });
      } else {
        toast.error(res.message || "Registration failed");
      }
    } catch (err) {
      console.error("Register error:", err);
      toast.error("Registration failed");
    }
  };

  return (
    <div
      className="hero"
      style={{
        backgroundImage:
          'url("https://images.unsplash.com/photo-1505691938895-1758d7feb511?auto=format&fit=crop&w=1600&q=80")',
      }}
    >
      <div className="inner">
        <div
          className="container"
          style={{ display: "flex", justifyContent: "center" }}
        >
          <form
            onSubmit={submit}
            className="form-box"
            style={{ width: "460px", background: "rgba(255,255,255,.98)" }}
          >
            <h2 style={{ marginTop: 0, color: "var(--brand)" }}>
              Create Account
            </h2>
            <p className="subtitle" style={{ marginTop: "-.4rem" }}>
              Book and pay securely
            </p>

            <div style={{ marginTop: "1rem" }}>
              <input
                className="input"
                placeholder="Full name"
                value={form.name}
                onChange={(e) => setForm({ ...form, name: e.target.value })}
                required
              />
            </div>
            <div style={{ marginTop: "1rem" }}>
              <input
                className="input"
                placeholder="Email"
                type="email"
                value={form.email}
                onChange={(e) => setForm({ ...form, email: e.target.value })}
                required
              />
            </div>
            <div style={{ marginTop: "1rem" }}>
              <input
                className="input"
                placeholder="Password"
                type="password"
                value={form.password}
                onChange={(e) =>
                  setForm({ ...form, password: e.target.value })
                }
                required
              />
            </div>

            <button
              className="btn"
              style={{ marginTop: "1.2rem", width: "100%" }}
              disabled={loading}
            >
              {loading ? "Creating…" : "Register"}
            </button>

            {/* 👇 if already registered, go to login */}
            <p style={{ marginTop: "1rem", textAlign: "center" }}>
              Already have an account?{" "}
              <Link
                to="/login"
                state={{ from, dates, bookNow }} // ✅ keep booking page + dates + room
                style={{ color: "#2563eb", fontWeight: "500" }}
              >
                Login
              </Link>
            </p>
          </form>
        </div>
      </div>
    </div>
  );
}
