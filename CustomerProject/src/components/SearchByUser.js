import axios from 'axios';
import { useState } from 'react';
import NavBar from './NavBar';

const CUSTOMER_API = 'https://localhost:7060/api/Customers/byusername';
const WALLET_API   = 'https://localhost:7060/api/Wallets/bycustomer';

export default function SearchByUser() {
  const [uname,   setUname]   = useState('');
  const [cust,    setCust]    = useState(null);
  const [wallets, setWallets] = useState([]);
  const [err,     setErr]     = useState('');
  const [loading, setLoading] = useState(false);

  /* ── fetch customer + wallets ───────────────────────────── */
  const search = () => {
    setErr(''); setCust(null); setWallets([]); setLoading(true);
    if (!uname) { setErr('Please enter a username.'); setLoading(false); return; }

    axios.get(`${CUSTOMER_API}/${uname}`)
         .then(r => { setCust(r.data); return axios.get(`${WALLET_API}/${r.data.custId}`); })
         .then(r => setWallets(r.data))
         .catch(()=> setErr('No user found'))
         .finally(()=> setLoading(false));
  };

  /* initials for avatar */
  const initials = cust?.custName?.match(/\b\w/g)?.join('').slice(0,2).toLowerCase() || '?';

  return (
    <>
      <NavBar />

      <div className="center-col" style={{ marginTop: 20 }}>
        {/* ── search bar ──────────────────────────────── */}
        <div className="card" style={{ maxWidth: 650, width:'95%' }}>
          <h3 style={{ textAlign:'center', marginBottom:18 }}>Search Customer by Name</h3>
          <div style={{ display:'flex', gap:12 }}>
            <input
              className="field"
              style={{ flex:1 }}
              value={uname}
              onChange={e=>setUname(e.target.value)}
              placeholder="Enter username"
            />
            <button className="btn" style={{ width:120 }} onClick={search} disabled={loading}>
              {loading ? 'Searching…' : 'Search'}
            </button>
          </div>
          {err && <div style={{ color:'#e11d48', marginTop:14, textAlign:'center' }}>{err}</div>}
        </div>

        {/* ── customer card + wallets ─────────────────── */}
        {cust && (
          <div className="profile" style={{ marginTop: 36 }}>
            {/* header */}
            <div style={{ display:'flex', alignItems:'center' }}>
              <div className="avatar">{initials}</div>
              <div>
                <h3 style={{ textTransform:'capitalize' }}>{cust.custName}</h3>
                <small style={{ color:'#6b7280' }}>ID:&nbsp;{cust.custId}</small>
              </div>
            </div>

            {/* personal info */}
            <h4 style={{ marginTop:26, color:'#374151' }}>Personal Information</h4>
            <div className="info-block">
              {[
                { label:'Username', value:cust.custUserName },
                { label:'Email',    value:cust.email    || '—' },
                { label:'Mobile',   value:cust.mobileNo || '—' },
                { label:'Location', value:`${cust.city||'-'}, ${cust.state||'-'}` },
              ].map(t=>(
                <div className="info-tile" key={t.label}>
                  <div className="info-label">{t.label}</div>
                  <div className="info-value">{t.value}</div>
                </div>
              ))}
            </div>

            {/* wallet cards */}
            <div className="wallet-section">
              <h4>Wallet Information</h4>
              {wallets.length === 0 ? (
                <div style={{ color:'#9ca3af', marginTop:8, fontStyle:'italic' }}>No wallets found</div>
              ) : (
                <div className="wallet-grid">
                  {wallets.map(w=>(
                    <div className="wallet-card" key={w.walletId}>
                      <small>Wallet&nbsp;<br />{w.walletType}</small>
                      ${Number(w.walletAmount).toLocaleString(undefined,{minimumFractionDigits:2})}
                    </div>
                  ))}
                </div>
              )}
            </div>
          </div>
        )}
      </div>
    </>
  );
}
