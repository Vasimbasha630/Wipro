import React, { useState, useEffect } from 'react';

const UserProfile = ({ user, onLogout }) => {
  const [status, setStatus] = useState('Logged Out');
  const [userData, setUserData] = useState(null);

  useEffect(() => {
    setStatus('Logged In');
    setTimeout(() => setUserData(user), 500); // simulate API fetch
  }, [user]);

  return (
    <div>
      <h2>User Profile</h2>
      {userData ? (
        <>
          <p>Name: {userData.name}</p>
          <p>Role: {userData.role}</p>
          <p>Status: {status}</p>
          <button onClick={onLogout}>Logout</button>
        </>
      ) : (
        <p>Loading user data...</p>
      )}
    </div>
  );
};

export default UserProfile;
