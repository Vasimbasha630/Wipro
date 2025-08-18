import axios from 'axios';
import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import NavBar from './NavBar';

const CAPI = 'https://localhost:7060/api/Customers';
const WAPI = 'https://localhost:7060/api/Wallets/bycustomer';

export default function Home() {
  const uname = localStorage.getItem('uname');
  const nav = useNavigate();
  const [cust, setCust] = useState(null);
  const [wallets, setWal] = useState([]);

  useEffect(() => {
    if (!uname) return nav('/');
    axios.get(`${CAPI}/byusername/${uname}`)
         .then(r => { setCust(r.data); return axios.get(`${WAPI}/${r.data.custId}`); })
         .then(r => setWal(r.data))
         .catch(() => nav('/'));
  }, [uname, nav]);

  if (!cust) return null;

  const initials = cust.custName?.match(/\b\w/g)?.join('').slice(0, 2).toLowerCase() || '?';

  return (
    <>
      <NavBar />
      <div className="center-col">
        <div className="profile">
          <div style={{ display: 'flex', alignItems: 'center' }}>
            <div className="avatar">{initials}</div>
            <div>
              <h3 style={{ textTransform: 'capitalize' }}>{cust.custName}</h3>
              <small style={{ color: '#6b7280' }}>ID:&nbsp;{cust.custId}</small>
            </div>
          </div>

          <h4 style={{ marginTop: 26, color: '#374151' }}>Personal Information</h4>
          <div className="info-block">
            {[
              { label: 'Username',  value: cust.custUserName },
              { label: 'Email',     value: cust.email || '—' },
              { label: 'Mobile',    value: cust.mobileNo || '—' },
              { label: 'Location',  value: `${cust.city || '-'}, ${cust.state || '-'}` },
            ].map(t => (
              <div className="info-tile" key={t.label}>
                <div className="info-label">{t.label}</div>
                <div className="info-value">{t.value}</div>
              </div>
            ))}
          </div>

          <div className="wallet-section">
            <h4>Wallet Information</h4>
            {wallets.length === 0 ? (
              <div style={{ color: '#9ca3af', marginTop: 8, fontStyle: 'italic' }}>No wallets found</div>
            ) : (
              <div className="wallet-grid">
                {wallets.map(w => (
                  <div className="wallet-card" key={w.walletId}>
                    <small>Wallet&nbsp;<br />{w.walletType}</small>
                    ${Number(w.walletAmount).toLocaleString(undefined, { minimumFractionDigits: 2 })}
                  </div>
                ))}
              </div>
            )}
          </div>
        </div>
      </div>
    </>
  );
}
