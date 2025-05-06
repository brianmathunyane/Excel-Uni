import React, { useState,useContext } from 'react';
import { useNavigate } from 'react-router-dom';
import {  getStudentDataByUsername } from '../../services/studenttrackerapi'; 
import { AuthContext } from '../../components/AuthProvider';

const Login = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [errorMsg, setErrorMsg] = useState('');
  const navigate = useNavigate();

  const { login } = useContext(AuthContext); 

  const handleLogin = async (e) => {
    e.preventDefault();
    try {
      const user = await getStudentDataByUsername(username); // Assuming username = user ID

      if (user && user.Password === password) {
        // Password matches
        // Store user data in local storage or context
        localStorage.setItem("isValid", "true");
        localStorage.setItem("userData", JSON.stringify(user));
        login(); 
        navigate('/');
      } else {
        // Password does not match
        setErrorMsg('Invalid username or password');
      }
    } catch (error) {
      setErrorMsg('User not found or API error');
    }
  };

  return (
    <div className="container mt-5" style={{ maxWidth: '400px' }}>
      <h2 className="mb-4 text-center">Login</h2>
      {errorMsg && <div className="alert alert-danger">{errorMsg}</div>}
      <form onSubmit={handleLogin}>
        <div className="form-group mb-3">
          <label>Username</label>
          <input 
            type="text" 
            className="form-control"
            value={username} 
            onChange={(e) => setUsername(e.target.value)} 
            required 
          />
        </div>
        <div className="form-group mb-3">
          <label>Password</label>
          <input 
            type="password" 
            className="form-control"
            value={password} 
            onChange={(e) => setPassword(e.target.value)} 
            required 
          />
        </div>
        <button type="submit" className="btn btn-primary w-100">Login</button>
      </form>
    </div>
  );
};

export default Login;

export const isAuthenticated = () => {
  const isValid = Boolean(localStorage.getItem("isValid"));

  if (isValid) {
    return true;
  }
  return false;
}
