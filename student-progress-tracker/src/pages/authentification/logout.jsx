import { useNavigate } from "react-router-dom";
import  { useEffect,useContext } from "react";
import { AuthContext } from "../../components/AuthProvider"; 

const Logout = () => { 

    const navigate = useNavigate();
    const { logout } = useContext(AuthContext); 
    
    useEffect(() => {
        localStorage.clear(); 
        logout(); 
        navigate("/login"); 
    }, [navigate, logout]);
    
    return <></>; 
    }

export default Logout;