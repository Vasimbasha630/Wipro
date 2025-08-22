import React, { Component } from 'react';

class Login extends Component {
  state = { username: '', password: '', loggedIn: false, role: '' };

  componentDidMount() {
    console.log('Login component mounted');
  }

  componentDidUpdate(prevProps, prevState) {
    if (prevState.loggedIn !== this.state.loggedIn && this.state.loggedIn) {
      console.log('User logged in');
    }
  }

  componentWillUnmount() {
    console.log('Login component unmounting, clearing session');
    sessionStorage.clear();
  }

  sanitizeInput = input => input.replace(/</g, "&lt;").replace(/>/g, "&gt;");

  handleChange = e => this.setState({ [e.target.name]: e.target.value });

  handleLogin = e => {
    e.preventDefault();
    const username = this.sanitizeInput(this.state.username);
    const password = this.state.password;

    if (!username || !password) {
      alert('Username and password cannot be empty!');
      return;
    }

    const role = username.toLowerCase() === 'admin' ? 'admin' : 'user';

    this.setState({ loggedIn: true, role });
    sessionStorage.setItem('user', JSON.stringify({ name: username, role }));
    sessionStorage.setItem('csrfToken', Math.random().toString(36).substr(2));
    window.location.href = role === 'admin' ? '/admin' : '/profile';
  };

  render() {
    return (
      <form onSubmit={this.handleLogin}>
        <h2>Login</h2>
        <input
          type="text"
          name="username"
          placeholder="Username"
          onChange={this.handleChange}
        />
        <input
          type="password"
          name="password"
          placeholder="Password"
          onChange={this.handleChange}
        />
        <button type="submit">Login</button>
      </form>
    );
  }
}

export default Login;
