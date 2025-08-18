import axios from 'axios';
import { useEffect, useState } from 'react';
import NavBar from './NavBar';

const API = 'https://localhost:7060/api/Vendors';   // expose this in Web-API

export default function ShowVendors() {
  const [rows, setRows] = useState([]);
  useEffect(() => { axios.get(API).then(r => setRows(r.data)); }, []);

  return (
    <>
      <NavBar />
      <div className="table-wrap">
        <h3 style={{ margin:'0 0 12px 4px' }}>Vendors</h3>
        <table>
          <thead>
            <tr>
              <th>ID</th><th>Name</th><th>User Name</th>
              <th>Email</th><th>Mobile</th>
            </tr>
          </thead>
          <tbody>
            {rows.map(v => (
              <tr key={v.vendorId}>
                <td>{v.vendorId}</td>
                <td>{v.vendorName}</td>
                <td>{v.vendorUserName}</td>
                <td>{v.vendorEmail}</td>
                <td>{v.vendorMobile}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </>
  );
}

