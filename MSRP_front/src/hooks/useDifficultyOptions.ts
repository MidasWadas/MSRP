import { useState, useEffect } from 'react';
import recipeService, { type DifficultyOptions } from '../services/api/recipeService';

export const useDifficultyOptions = () => {
  const [difficultyOptions, setDifficultyOptions] = useState<DifficultyOptions[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchDifficultyOptions = async () => {
      setLoading(true);
      try {
        const options = await recipeService.getDifficultyOptions();
        setDifficultyOptions(options);
        setError(null);
      } catch (err: unknown) {
        console.error('Failed to fetch difficulty options:', err);
        
        // Set specific error messages based on error type
        if (err instanceof Error) {
          const error = err as { 
            code?: string; 
            message: string; 
            response?: { status?: number } 
          };
          
          if (error.code === 'ECONNREFUSED' || error.code === 'ECONNABORTED') {
            setError('Connection to API server failed or timed out. Check if the server is running.');
          } else if (error.message.includes('certificate')) {
            setError('SSL certificate issue. The application is using mock data for now.');
          } else if (error.response?.status === 404) {
            setError('API endpoint not found (404). Check the endpoint URL.');
          } else if (error.response?.status === 500) {
            setError('Server error (500). Check the backend logs.');
          } else {
            setError(`Failed to load difficulty options: ${error.message}`);
          }
        } else {
          setError('Failed to load difficulty options: Unknown error');
        }
      } finally {
        setLoading(false);
      }
    };

    fetchDifficultyOptions();
  }, []);

  return { difficultyOptions, loading, error };
};

export default useDifficultyOptions;
