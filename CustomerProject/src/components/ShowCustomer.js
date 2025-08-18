import axios from 'axios';
import { useEffect, useState } from 'react';
import NavBar from './NavBar';

const API = 'https://localhost:7060/api/Customers';

export default function ShowCustomer() {
  const [list, setList] = useState([]);
  useEffect(() => { axios.get(API).then(r => setList(r.data)); }, []);

  return (
    <>
      <NavBar />
      <div className="table-wrap">
        <h3 style={{ margin: '0 0 12px 4px' }}>Customer Directory</h3>
        <table>
          <thead>
            <tr>
              <th>ID</th><th>User Name</th><th>Email</th><th>City</th><th>State</th><th>Mobile Number</th>
            </tr>
          </thead>
          <tbody>
            {list.map(c => (
              <tr key={c.custId}>
                <td>{c.custId}</td>
                <td>{c.custUserName}</td>
                <td>{c.email || '—'}</td>
                <td>{c.city || '—'}</td>
                <td>{c.state || '—'}</td>
                <td>{c.mobileNo || '—'}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </>
  );
}
