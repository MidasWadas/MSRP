import { combineReducers } from '@reduxjs/toolkit';
import recipesListReducer from 'features/recipes/recipes-list/recipes-list-slice';

const rootReducer = combineReducers({
  recipesList: recipesListReducer,
  // here you will add additional reducers, such as recipeDetails, filters, etc.
});

export type RootState = ReturnType<typeof rootReducer>;

export default rootReducer;
