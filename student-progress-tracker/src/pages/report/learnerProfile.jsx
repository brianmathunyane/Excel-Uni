import React, { useEffect, useState } from 'react';

const LearnerProfile = () => {
    const [user, setUser] = useState(null);
   

    useEffect(() => {
        // Load user data from localStorage
        const storedUser = localStorage.getItem("userData");
        if (storedUser) {
            const parsedUser = JSON.parse(storedUser);
            setUser(parsedUser);
          
        }
    }, []);

   
    if (!user) return <p>Loading user data...</p>;

    return (
        <div className="container mt-4">
            <h2>Learner Profile</h2>
            <div className="card mb-4">
                <div className="card-body">
                    <h5 className="card-title">{user.Name} {user.Surname}</h5>
                    <p className="card-text"><strong>Email:</strong> {user.Email}</p>
                    <p className="card-text"><strong>ID Number:</strong> {user.IDNumber}</p>
                    <p className="card-text"><strong>Phone:</strong> {user.PhoneNumber}</p>
                    <p className="card-text"><strong>Address:</strong> {user.Address}</p>
                </div>
            </div>

            <h4>Academic Enrolments</h4>
            
        </div>
    );
};

export default LearnerProfile;
