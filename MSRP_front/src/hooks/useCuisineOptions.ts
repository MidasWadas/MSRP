import { useState, useEffect } from 'react';
import recipeService, { type CuisineOption } from '../services/api/recipeService';

export const useCuisineOptions = () => {
  const [cuisineOptions, setCuisineOptions] = useState<CuisineOption[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchCuisineOptions = async () => {
      setLoading(true);
      try {
        const options = await recipeService.getCuisineOptions();
        setCuisineOptions(options);
        setError(null);
      } catch (err: unknown) {
        console.error('Failed to fetch cuisine options:', err);
        
        // Type assertion for the error object
        const error = err as {
          code?: string;
          message?: string;
          response?: { status?: number };
        };
        
        // Set specific error messages based on error type
        if (error.code === 'ECONNREFUSED' || error.code === 'ECONNABORTED') {
          setError('Connection to API server failed or timed out. Check if the server is running.');
        } else if (error.message?.includes('certificate')) {
          setError('SSL certificate issue. The application is using mock data for now.');
        } else if (error.response?.status === 404) {
          setError('API endpoint not found (404). Check the endpoint URL.');
        } else if (error.response?.status === 500) {
          setError('Server error (500). Check the backend logs.');
        } else {
          setError(`Failed to load cuisine options: ${error.message || 'Unknown error'}`);
        }
      } finally {
        setLoading(false);
      }
    };

    fetchCuisineOptions();
  }, []);

  return { cuisineOptions, loading, error };
};

export default useCuisineOptions;
