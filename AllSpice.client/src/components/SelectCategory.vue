<template>
  <!-- style this row -->
    <section class="row justify-content-center text-center">  
      <div class="col-12 col-md-4">
        <div class="bg-white d-flex justify-content-around rounded elevation-2 py-1">
          <button @click="changeRecipes('home')" class="btn btn-outline-success">Home</button>
          <button @click="setFavorites()" class="btn btn-outline-success">My Favorites</button>
          <button @click="changeRecipes('mine')" class="btn btn-outline-success">My Recipes</button>
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


<style lang="scss" scoped>
</style>