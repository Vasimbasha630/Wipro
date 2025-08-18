import axios from 'axios';
import { useState } from 'react';
import { Link } from 'react-router-dom';

const API = 'https://localhost:7060/api/Customers';

export default function CreateCustomer() {
  const blank = { custName:'', custUserName:'', custPassword:'', city:'', state:'', email:'', mobileNo:'' };
  const [c, setC] = useState(blank);
  const [ok, setOk] = useState('');

  const h = e => setC({ ...c, [e.target.name]: e.target.value });

  const save = () => {
    axios.post(API, c).then(() => { setOk('Customer added successfully!'); setC(blank); });
  };

  return (
    <div className="center-col" style={{ height: '100vh' }}>
      <div className="card">
        <h2 style={{ textAlign: 'center', marginBottom: 12 }}>Add New Customer</h2>

        {ok && (
          <div style={{ background: '#d1fae5', color: '#065f46', padding: 6,
                        textAlign: 'center', borderRadius: 6, marginBottom: 14, fontSize: 14 }}>
            {ok}
          </div>
        )}

        {[
          { lbl: 'Full Name',      name: 'custName'      },
          { lbl: 'Username',       name: 'custUserName'  },
          { lbl: 'Password',       name: 'custPassword', type: 'password' },
          { lbl: 'City',           name: 'city'          },
          { lbl: 'State',          name: 'state'         },
          { lbl: 'Email Address',  name: 'email'         },
          { lbl: 'Mobile Number',  name: 'mobileNo'      },
        ].map(f => (
          <div key={f.name} style={{ display: 'flex', gap: 12 }}>
            <label style={{ width: 110 }}>{f.lbl}</label>
            <input
              className="field"
              style={{ flex: 1 }}
              type={f.type || 'text'}
              name={f.name}
              value={c[f.name]}
              onChange={h}
              placeholder={`Enter ${f.lbl.toLowerCase()}`}
            />
          </div>
        ))}

        <button className="btn" onClick={save}>Add Customer</button>
        <Link className="link" to="/">Back to login</Link>
      </div>
    </div>
  );
}
