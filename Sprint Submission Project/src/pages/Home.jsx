import Hero from "../components/Hero";
import { Link } from "react-router-dom";

export default function Home(){
  return (
    <>
      <Hero/>
      <div className="container" style={{textAlign:"center", marginTop:"2rem"}}>
        <h2>Plan your perfect trip</h2>
        <p className="subtitle">Real hotels, real rooms, real-time availability.</p>
        <Link className="btn" to="/hotels" style={{marginTop:"1rem"}}>Browse Hotels</Link>
      </div>
    </>
  );
}
