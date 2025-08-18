import { Link, useNavigate } from 'react-router-dom';

export default function NavBar() {
  const nav = useNavigate();
  const logout = () => { localStorage.removeItem('uname'); nav('/'); };

  return (
      <nav className="navbar">
        <Link to="/home">Home</Link>
        <Link to="/searchid">Search By ID</Link>
        <Link to="/searchuser">Search By Name</Link>
        <Link to="/showall">Show All</Link>            {/* ← restore this */}
        <Link to="/add">Add Customer</Link>
        <Link to="/menu">Menu</Link>
        <Link to="/vendors">Vendors</Link>
        <Link to="/orders">My Orders</Link>
        <span style={{flex:1}} />
        <a href="#logout" onClick={logout}>Log-out</a>
      </nav>
  );
}
