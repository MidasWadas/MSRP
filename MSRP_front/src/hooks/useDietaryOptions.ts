import { useState, useEffect } from 'react';
import recipeService, { DietaryOption } from '../services/api/recipeService';

export const useDietaryOptions = () => {
  const [dietaryOptions, setDietaryOptions] = useState<DietaryOption[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchDietaryOptions = async () => {
      setLoading(true);
      try {
        const options = await recipeService.getDietaryOptions();
        setDietaryOptions(options);
        setError(null);
      } catch (err: any) {
        console.error('Failed to fetch dietary options:', err);
        
        // Set specific error messages based on error type
        if (err.code === 'ECONNREFUSED' || err.code === 'ECONNABORTED') {
          setError('Connection to API server failed or timed out. Check if the server is running.');
        } else if (err.message.includes('certificate')) {
          setError('SSL certificate issue. The application is using mock data for now.');
        } else if (err.response?.status === 404) {
          setError('API endpoint not found (404). Check the endpoint URL.');
        } else if (err.response?.status === 500) {
          setError('Server error (500). Check the backend logs.');
        } else {
          setError(`Failed to load dietary options: ${err.message}`);
        }
      } finally {
        setLoading(false);
      }
    };

    fetchDietaryOptions();
  }, []);

  return { dietaryOptions, loading, error };
};

export default useDietaryOptions;
