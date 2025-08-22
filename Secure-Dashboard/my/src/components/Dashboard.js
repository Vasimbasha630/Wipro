import React, { useState } from 'react';
import UserProfile from './UserProfile';

const Dashboard = () => {
  const user = JSON.parse(sessionStorage.getItem('user'));
  const [isLoggedIn, setIsLoggedIn] = useState(!!user);

  const handleLogout = () => {
    setIsLoggedIn(false);
    sessionStorage.clear();
    window.location.href = '/login';
  };

  return (
    <div>
      {isLoggedIn ? (
        <UserProfile user={user} onLogout={handleLogout} />
      ) : (
        <h2>Please login to access the dashboard.</h2>
      )}
    </div>
  );
};

export default Dashboard;
