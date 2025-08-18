import axios from 'axios';
import { useEffect, useState } from 'react';
import NavBar from './NavBar';

const API = 'https://localhost:7060/api/Orders/bycustomer'; // create this route

export default function MyOrders() {
  const uname = localStorage.getItem('uname');   // same trick as Home
  const [orders, setOrders] = useState([]);
  const [err, setErr]       = useState('');

  useEffect(() => {
    if (!uname) return;
    axios.get(`https://localhost:7060/api/Customers/byusername/${uname}`)
         .then(r => axios.get(`${API}/${r.data.custId}`))
         .then(r => setOrders(r.data))
         .catch(() => setErr('No orders found'));
  }, [uname]);

  return (
    <>
      <NavBar />
      <div className="table-wrap">
        <h3 style={{ margin:'0 0 12px 4px' }}>My Orders</h3>
        {err && <div style={{ color:'#9ca3af', marginBottom:12 }}>{err}</div>}
        {orders.length > 0 && (
          <table>
            <thead>
              <tr>
                <th>Order</th><th>Menu</th><th>Vendor</th>
                <th>Qty</th><th>Amount (₹)</th><th>Status</th><th>Comments</th>
              </tr>
            </thead>
            <tbody>
              {orders.map(o => (
                <tr key={o.orderId}>
                  <td>{o.orderId}</td>
                  <td>{o.menuId}</td>
                  <td>{o.vendorId}</td>
                  <td>{o.qtyOrd}</td>
                  <td>{o.billAmount}</td>
                  <td>{o.orderStatus}</td>
                  <td>{o.orderComments || '—'}</td>
                </tr>
              ))}
            </tbody>
          </table>
        )}
      </div>
    </>
  );
}
