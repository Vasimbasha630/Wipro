import logo from './logo.svg';
import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';
import './App.css';
import UserShow from './components/usershow/usershow';
import EmployShow from './components/employshow/employshow';
import UserSearch from './components/usersearch/usersearch';
import EmploySearch from './components/employsearch/employsearch';
import PostShow from './components/postshow/Postshow';
import PostSearch from './components/postsearch/Postsearch';
import EmployAdd from './components/employAdd/employAdd';

function App() {
  return (
    <div className="App">
       <BrowserRouter>
        <nav>
          <Link to="/UserShow">User Show</Link> |{" "}
          <Link to="/EmployShow">Employ Show</Link> |{" "}
          <Link to="/UserSearch">User Search</Link> |{" "}
          <Link to="/EmploySearch">Employ Search</Link> |{" "}
          <Link to="/PostShow">Post Show</Link> |{" "}
          <Link to="/PostSearch">Post Search</Link>|{" "}
          <Link to="/EmployAdd">Employ Add</Link>|{" "}
        </nav>

        <Routes>
          <Route path='/UserShow' element={<UserShow />} />
          <Route path='/EmployShow' element={<EmployShow />} />
          <Route path='/UserSearch' element={<UserSearch />} />
          <Route path='/EmploySearch' element={<EmploySearch />} />
          <Route path='/PostShow' element={<PostShow />} />
          <Route path='/PostSearch' element={<PostSearch />} />
          <Route path='/EmployAdd' element={<EmployAdd />} />
        </Routes>
      </BrowserRouter>

    </div>
  );
}
export default App;