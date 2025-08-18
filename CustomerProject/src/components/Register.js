import axios from 'axios';
import { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';

const API = 'https://localhost:7069/api/Customers';

export default function Register() {
  const nav   = useNavigate();                 // now we’ll really use it
  const blank = {
    name:'', uname:'', pwd:'', cpwd:'',
    city:'', state:'', email:'', mobile:''
  };
  const [f,setF]   = useState(blank);
  const [msg,setMsg] = useState('');

  const h = e => setF({ ...f, [e.target.name]: e.target.value });

  const save = () => {
    setMsg('');
    if (f.pwd !== f.cpwd) { setMsg('Passwords do not match'); return; }

    axios.post(API,{
      custName:     f.name,
      custUserName: f.uname,
      custPassword: f.pwd,
      city:         f.city,
      state:        f.state,
      email:        f.email,
      mobileNo:     f.mobile
    })
    .then(() => {
      setMsg('Customer registered 🎉');
      setF(blank);

      /* redirect to login after 1 s so the user sees the success banner */
      setTimeout(()=> nav('/'), 1000);
    })
    .catch(() => setMsg('Username already taken or server error'));
  };

  return (
     <div className="center-col" style={{ padding:'40px 0' }}> 
      <div className="card" style={{ maxWidth:380 }}>
        <h2 style={{ textAlign:'center', marginBottom:12 }}>Register Customer</h2>

        {msg && (
          <div style={{
            background: msg.includes('🎉') ? '#d1fae5' : '#fee2e2',
            color:       msg.includes('🎉') ? '#065f46' : '#991b1b',
            padding:8, borderRadius:6, marginBottom:14,
            textAlign:'center', fontSize:14
          }}>{msg}</div>
        )}

        <label>Full Name</label>
        <input className="field" name="name"   value={f.name}   onChange={h} placeholder="Full name"/>

        <label>Username</label>
        <input className="field" name="uname"  value={f.uname}  onChange={h} placeholder="Choose username"/>

        <label>Password</label>
        <input className="field" name="pwd"    type="password" value={f.pwd}   onChange={h} placeholder="Password"/>

        <label>Confirm Password</label>
        <input className="field" name="cpwd"   type="password" value={f.cpwd}  onChange={h} placeholder="Confirm"/>

        <label>City</label>
        <input className="field" name="city"   value={f.city}   onChange={h} placeholder="City (optional)"/>

        <label>State</label>
        <input className="field" name="state"  value={f.state}  onChange={h} placeholder="State (optional)"/>

        <label>Email Address</label>
        <input className="field" name="email"  value={f.email}  onChange={h} placeholder="Email (optional)"/>

        <label>Mobile Number</label>
        <input className="field" name="mobile" value={f.mobile} onChange={h} placeholder="Mobile (optional)"/>

        <button className="btn" onClick={save}>Register</button>
        <Link className="link" to="/">Back to login</Link>
      </div>
    </div>
  );
}
