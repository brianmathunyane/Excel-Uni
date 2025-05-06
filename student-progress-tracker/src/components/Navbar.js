
import React, { useContext } from 'react';
import { Link } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min';

import { AuthContext } from './AuthProvider';

const Navbar = () => {

  const { isLoggedIn } = useContext(AuthContext);

  return (
    <nav className="navbar navbar-expand-lg navbar-dark bg-primary">
      <div className="container">
        <Link className="navbar-brand" to="/">Student Enrolment</Link>
        <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav">
          <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse" id="navbarNav">
          <ul className="navbar-nav ms-auto">
            <li className="nav-item">
              <Link className="nav-link" to="/">Home</Link>
            </li>
            {!isLoggedIn && (
              <li className="nav-item">
                <Link className="nav-link" to="/login">Login</Link>
              </li>)}
            {!isLoggedIn && (
              <li className="nav-item">
                <Link className="nav-link" to="/signup">Sign Up</Link>
              </li>)}



            {isLoggedIn && (

              <><li className="nav-item">
                <Link className="nav-link" to="/learnerProfile">Report</Link>
              </li><li className="nav-item">
                  <Link className="nav-link" to="/logout">Logout</Link>
                </li></>
            )}


          </ul>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
