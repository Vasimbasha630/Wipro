import axios from 'axios';
import { useEffect, useState } from 'react';
import NavBar from './NavBar';

const API = 'https://localhost:7060/api/Menu';   // add this endpoint to Web-API

export default function ShowMenu() {
  const [rows, setRows] = useState([]);
  useEffect(() => { axios.get(API).then(r => setRows(r.data)); }, []);

  return (
    <>
      <NavBar />
      <div className="table-wrap">
        <h3 style={{ margin:'0 0 12px 4px' }}>Menu</h3>
        <table>
          <thead>
            <tr>
              <th>ID</th><th>Item</th><th>Type</th>
              <th>Price (₹)</th><th>Description</th><th>Rating</th>
            </tr>
          </thead>
          <tbody>
            {rows.map(m => (
              <tr key={m.menuId}>
                <td>{m.menuId}</td>
                <td>{m.itemName}</td>
                <td>{m.itemType}</td>
                <td>{m.price}</td>
                <td>{m.description}</td>
                <td>{m.rating}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </>
  );
}
