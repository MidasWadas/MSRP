import axios from 'axios';

// Get API URL from environment or use default
const API_URL = process.env.REACT_APP_API_URL || 'https://localhost:44373/api';

console.log('Using API URL:', API_URL);

// Create an API client instance with default configuration
const apiClient = axios.create({
  baseURL: API_URL,
  headers: {
    'Content-Type': 'application/json',
    // Add headers that might help with CORS issues
    'Accept': 'application/json',
  },
  // Add a timeout to prevent hanging requests
  timeout: 10000
});

// In a browser environment, we can't use Node.js https module directly
// Instead, we can configure axios to ignore SSL certificate issues in development
// by using axios-specific settings or custom options for production

// Response interceptor for global error handling
apiClient.interceptors.response.use(
  (response) => response,
  (error) => {
    // Detailed error handling
    if (error.response) {
      // The request was made and the server responded with a status code
      // that falls out of the range of 2xx
      console.error('API Error Response:', {
        status: error.response.status,
        data: error.response.data,
        headers: error.response.headers,
      });
    } else if (error.request) {
      // The request was made but no response was received
      console.error('API Error Request:', error.request);
    } else {
      // Something happened in setting up the request that triggered an Error
      console.error('API Error Setup:', error.message);
    }    
    return Promise.reject(error);  
  }
);

export default apiClient;