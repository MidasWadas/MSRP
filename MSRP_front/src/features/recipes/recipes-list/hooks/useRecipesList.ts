import { useCallback } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchRecipesStart } from 'features/recipes/recipes-list/recipes-list-slice';
import { type RootState } from '@/store/rootReducer';

export const useRecipesList = () => {
  const dispatch = useDispatch();

  const data = useSelector((state: RootState) => state.recipesList.recipes);
  const isLoading = useSelector((state: RootState) => state.recipesList.loading);

  const fetchData = useCallback(() => {
    dispatch(fetchRecipesStart());
  }, [dispatch]);

  const loadingText = isLoading ? 'Loading recipes...' : '';

  return { fetchData, data, isLoading, loadingText };
};
