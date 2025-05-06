// src/App.js
import React from 'react';
import { Routes, Route, BrowserRouter } from 'react-router-dom';
import Navbar from './components/Navbar';
import Login from './pages/authentification/login';
import { AuthProvider } from './components/AuthProvider';
import PrivateRoutes from './components/PrivateRoutes';
import Logout from './pages/authentification/logout';
import SignUp from './pages/authentification/signup';
import LearnerProfile from './pages/report/learnerProfile';

const Home = () => <h2 className="text-center mt-4">Welcome to the Student Enrolment App</h2>;

function App() {
  return (
    <BrowserRouter>
    <AuthProvider>
      <Navbar />
      <div className="container mt-3">
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Login />} />
          <Route exact path="/signup" element={<SignUp />} />
         
          <Route element={<PrivateRoutes />}>

          <Route exact path="/logout" element={<Logout />} />
          <Route exact path="/learnerProfile" element={<LearnerProfile />} />
          
          </Route>
          
        </Routes>
      </div>
      </AuthProvider>
    </BrowserRouter>
  );
}

export default App;
