import { all } from 'redux-saga/effects';
import { watchFetchRecipes } from 'features/recipes/recipes-list/recipes-list-saga';

export default function* rootSaga() {
  yield all([
    watchFetchRecipes(),
    // You will add more watchers here in the future
  ]);
}
