import axios from 'axios';

 const API_ENDPOINT = process.env.REACT_APP_BASEURL;

 const user_endpoint= API_ENDPOINT + 'Student/GetStudentByStudentname/Studentname/';
 

export const getStudentDataByUsername = async (username) => {
    try {
        const response = await axios.get(user_endpoint+ username);
        return response.data;
    } catch (error) {
        console.error("Error fetching student data by username:", error);
        throw error;
    }
}

export async function createAccount(userData) {
    try {
      const response = await fetch(`${API_ENDPOINT}Student/CreateAccount`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(userData)
      });
  
      if (!response.ok) {
        const errorData = await response.json();
        throw new Error(errorData.message || 'Failed to create account');
      }
  
      return await response.json(); 
    } catch (error) {
      console.error('Error creating account:', error);
      throw error;
    }
  }

