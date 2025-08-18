import axios from 'axios';
import { useState } from 'react';
import NavBar from './NavBar';

const CAPI = 'https://localhost:7060/api/Customers';
const WAPI = 'https://localhost:7060/api/Wallets/bycustomer';

export default function SearchById() {
  const [id,      setId]      = useState('');
  const [cust,    setCust]    = useState(null);
  const [wallets, setWallets] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error,   setError]   = useState('');

  /* ── click handler ─────────────────────────────────────────────── */
  const search = () => {
    setError(''); setCust(null); setWallets([]); setLoading(true);
    if (!id) { setError('Please enter a Customer Id.'); setLoading(false); return; }

    axios.get(`${CAPI}/${id}`)
         .then(r => { setCust(r.data); return axios.get(`${WAPI}/${id}`); })
         .then(r => setWallets(r.data))
         .catch(() => setError('No customer found'))
         .finally(() => setLoading(false));
  };

  /* ── derived helpers ───────────────────────────────────────────── */
  const initials = cust?.custName?.match(/\b\w/g)?.join('').slice(0,2).toLowerCase() || '?';

  /* ── render ────────────────────────────────────────────────────── */
  return (
    <>
      <NavBar />

      <div className="center-col" style={{ marginTop: 20 }}>
        <div className="card" style={{ maxWidth: 650, width: '95%' }}>
          <h3 style={{ marginBottom: 18, textAlign:'center' }}>Search Customer by ID</h3>

          <div style={{ display:'flex', gap:12 }}>
            <input
              className="field"
              style={{ flex:1 }}
              value={id}
              onChange={e=>setId(e.target.value)}
              placeholder="Enter ID"
            />
            <button className="btn" style={{ width:120 }} onClick={search} disabled={loading}>
              {loading ? 'Searching…' : 'Search'}
            </button>
          </div>

          {error && <div style={{ color:'#e11d48', marginTop:16, textAlign:'center' }}>{error}</div>}
        </div>

        {/* ───────────────────── customer card ───────────────────── */}
        {cust && (
          <div className="profile" style={{ marginTop: 36 }}>
            <div style={{ display:'flex', alignItems:'center' }}>
              <div className="avatar">{initials}</div>
              <div>
                <h3 style={{ textTransform:'capitalize' }}>{cust.custName}</h3>
                <small style={{ color:'#6b7280' }}>ID:&nbsp;{cust.custId}</small>
              </div>
            </div>

            <h4 style={{ marginTop: 26, color:'#374151' }}>Personal Information</h4>
            <div className="info-block">
              {[
                { label:'Username', value:cust.custUserName },
                { label:'Email',    value:cust.email || '—' },
                { label:'Mobile',   value:cust.mobileNo || '—' },
                { label:'Location', value:`${cust.city || '-'}, ${cust.state || '-'}` }
              ].map(t => (
                <div className="info-tile" key={t.label}>
                  <div className="info-label">{t.label}</div>
                  <div className="info-value">{t.value}</div>
                </div>
              ))}
            </div>

            {/* ───────────────── wallet cards ────────────────────── */}
            <div className="wallet-section">
              <h4>Wallet Information</h4>
              {wallets.length === 0 ? (
                <div style={{ color:'#9ca3af', marginTop:8, fontStyle:'italic' }}>No wallets found</div>
              ) : (
                <div className="wallet-grid">
                  {wallets.map(w => (
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
