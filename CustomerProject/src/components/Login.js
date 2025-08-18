import axios from 'axios';
import { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';

const API = 'https://localhost:7060/api/Customers';

export default function Login() {
  const nav = useNavigate();
  const [frm, setFrm] = useState({ uname: '', pwd: '' });
  const [msg, setMsg] = useState('');

  const h = e => setFrm({ ...frm, [e.target.name]: e.target.value });

  const submit = () => {
    setMsg('');
    axios.get(`${API}/auth/${frm.uname}/${frm.pwd}`)
         .then(r => {
           if (r.data === 1) {
             localStorage.setItem('uname', frm.uname);
             nav('/home');
           } else setMsg('Invalid username or password');
         });
  };

  return (
    <div className="center-col" style={{ height: '100vh' }}>
      <div className="card">
        <h2 style={{ textAlign: 'center', marginBottom: 12 }}>Customer Login</h2>

        <label>Username</label>
        <input className="field" name="uname" onChange={h} placeholder="Enter username" />

        <label>Password</label>
        <input className="field" name="pwd" type="password" onChange={h} placeholder="Enter password" />

        <button className="btn" onClick={submit}>Sign In</button>

        {msg && <div style={{ color: '#e11d48', fontSize: 13, marginTop: 8, textAlign: 'center' }}>{msg}</div>}

        <Link className="link" to="/register">New User, Register here?</Link>
      </div>
    </div>
  );
}
