import React from 'react';

const AdminDashboard = () => {
  const user = JSON.parse(sessionStorage.getItem('user'));
  return (
    <div>
      <h2>Admin Dashboard</h2>
      <p>Welcome, {user.name} (Admin)</p>
      <p>You can manage users from here.</p>
    </div>
  );
};

export default AdminDashboard;
