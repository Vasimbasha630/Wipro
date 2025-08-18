import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

/*  Full-screen splash shown for 3 s, then routes to /login  */
export default function Intro() {
  const nav = useNavigate();

  /* auto-redirect */
  useEffect(() => {
    const t = setTimeout(() => nav('/login'), 3000);   // 3-second pause
    return () => clearTimeout(t);
  }, [nav]);

  return (
    <div className="intro">
      <h1>Demo video of CMS application</h1>
      <div className="byline">Submitted by<br />Basha</div>
    </div>
  );
}
