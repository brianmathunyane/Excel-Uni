// src/pages/authentication/SignUp.js
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { createAccount } from '../../services/studenttrackerapi';


const SignUp = () => {
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    StudentId: 0,
    EnrolmentId: 2,
    FirstName: '',
    LastName: '',
    Email: '',
    Password: '',
    IDNumber: 3456789,
    
   
  });

  const [error, setError] = useState('');
  const [successMessage, setSuccessMessage] = useState('');

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');
    setSuccessMessage('');
    
    try {
      await createAccount({ ...formData });
      setSuccessMessage('Account created successfully!');
      setTimeout(() => navigate('/login'), 2000);
    } catch (err) {
      setError(err.message || 'Failed to create account.');
    }
  };

  return (
    <div className="container mt-5" style={{ maxWidth: '500px' }}>
      <h2 className="mb-4 text-center">Sign Up</h2>
      {error && <div className="alert alert-danger">{error}</div>}
      {successMessage && <div className="alert alert-success">{successMessage}</div>}
      <form onSubmit={handleSubmit}>
        {[
          
          { label: 'Name', name: 'FirstName', type: 'text' },
          { label: 'Surname', name: 'LastName', type: 'text' },
          { label: 'Email', name: 'Email', type: 'email' },
          { label: 'Password', name: 'Password', type: 'password' },
          { label: 'ID Number', name: 'IDNumber', type: 'number' },
          { label: 'Phone Number', name: 'PhoneNumber', type: 'number' },
          { label: 'Address', name: 'Address', type: 'text' }
        ].map(({ label, name, type }) => (
          <div className="form-group mb-3" key={name}>
            <label>{label}</label>
            <input
              type={type}
              className="form-control"
              name={name}
              value={formData[name]}
              onChange={handleChange}
              required
            />
          </div>
        ))}
    
        <button type="submit" className="btn btn-primary w-100">Sign Up</button>
      </form>
    </div>
  );
};

export default SignUp;
