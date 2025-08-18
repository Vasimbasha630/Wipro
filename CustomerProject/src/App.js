import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Login          from './components/Login';
import Register       from './components/Register';
import Menu           from './components/Menu';
import CreateCustomer from './components/CreateCustomer';
import ShowCustomer   from './components/ShowCustomer';
import SearchById     from './components/SearchById';
import SearchByUser   from './components/SearchByUser';
import Home           from './components/Home';
import ShowVendors    from './components/ShowVendors';
import MyOrders       from './components/MyOrders';
import Intro          from './components/Intro';


export default function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/"          element={<Intro          />} />   {/* splash */}
        <Route path="/login"     element={<Login          />} />
        <Route path="/home"      element={<Home           />} />
        <Route path="/register"  element={<Register       />} />
        <Route path="/menu"      element={<Menu           />} />
        <Route path="/vendors"   element={<ShowVendors    />} />
        <Route path="/orders"    element={<MyOrders       />} />
        <Route path="/add"       element={<CreateCustomer />} />
        <Route path="/show"      element={<ShowCustomer   />} />
        <Route path="/searchid"  element={<SearchById     />} />
        <Route path="/searchuser"element={<SearchByUser   />} />
        <Route path="/showall"   element={<ShowCustomer />} /> 
        {/* catch-all must be last */}
        <Route path="*" element={<h2>Page Not Found</h2>} />
      </Routes>
    </BrowserRouter>
  );
}
