<template>
    <section class="row justify-content-center text-center">
      <div class="col-3">
        <div class="bg-dark d-flex justify-content-around">
          <button @click="changeRecipes('home')" class="btn btn-success">Home</button>
          <button @click="setFavorites()" class="btn btn-success">My Favorites</button>
          <button @click="changeRecipes('mine')" class="btn btn-success">My Recipes</button>
        </div>
      </div>
    </section>
</template>

<script>
import { favoritesService } from '../services/FavoritesService';
import { recipesService } from '../services/RecipesService';

export default {
setup() {
  return {
    changeRecipes(recipeType){
      recipesService.changeRecipes(recipeType)
    },

    setFavorites(){
      favoritesService.setFavorites()
    }
  };
},
};
</script>


<style>
</style>