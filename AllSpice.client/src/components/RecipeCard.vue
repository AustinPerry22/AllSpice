<template>
    <section class="row justify-content-center">
        <div @click="openRecipeModal(recipe.id)" class="col-10 col-md-9">
          <section class="row elevation-3 recipe-cover align-content-between selectable">
            <div class="col-12">
              <section class="row justify-content-between">
                <h5 class="category col-md-4 col-7 mt-2 ms-1 ms-md-3 p-0">{{ recipe.category }}</h5>
                  <!-- TODO change heart based on favorite -->
                <div v-if="account.id" class="col-4 text-end pe-0">
                  <button v-if="isFavorite" @click.stop="deleteFavorite" class="heart"><i class="mdi mdi-heart"></i></button>
                  <button v-else @click.stop="addFavorite" class="heart"><i class="mdi mdi-heart-outline"></i></button>

                </div>
              </section>
            </div>
            <div class="col-12">
              <section class="row justify-content-center">
                <h4 class="title col-11">{{ recipe.title }}</h4>
              </section>
            </div>
          </section>
        </div>
    </section>
</template>

<script>
import { computed } from 'vue';
import { Recipe } from '../models/Recipe';
import { AppState } from '../AppState';
import Pop from '../utils/Pop';
import { favoritesService } from '../services/FavoritesService';
import {recipesService} from '../services/RecipesService';
import{ingredientsService} from '../services/IngredientsService'
import { Favorite } from '../models/Favorite';
import { Modal } from 'bootstrap';

export default {
props: {recipe: {type: [Recipe, Favorite], required: true}},
setup(props) {
  return {
    recipeImg: computed(()=> `url('${props.recipe.img}')`),
    account: computed(()=> AppState.account),
    isFavorite: computed(()=> {
      let favorite = null
      favorite = AppState.favorites.filter(fav => fav.id == props.recipe.id)
      if(favorite[0])
      {
        return true
      }
      return false
    }),

    async addFavorite()
    {
      try {
        await favoritesService.addFavorite(props.recipe.id)
      } catch (error) {
        Pop.error(error)
      }
    },

    async deleteFavorite()
    {
      try {
        await favoritesService.deleteFavorite(props.recipe.id)
      } catch (error) {
        Pop.error(error)
      }
    },

    async getIngredients(){
      try{
        await ingredientsService.getIngredients()
      }
      catch(error){
        Pop.error(error)
      }
    },
    openRecipeModal(recipeId)
    {
      recipesService.setActiveRecipe(recipeId);
      this.getIngredients()
      Modal.getOrCreateInstance('#active-recipe').show()
    }
  };
},
};
</script>


<style lang="scss" scoped>
.recipe-cover{
    background-image: v-bind(recipeImg);
    background-position: center;
    background-size: cover;
    height: 47.5vh;
    border-radius: .5rem;
}

.recipe-cover:hover{
  transform: scale(1.01);
}

.category{
  background-color: rgba(128, 128, 128, 0.692);
  backdrop-filter: blur(10px);
  color: white;
  text-align: center;
  border-radius: 1rem;
}

.heart{
  background-color: rgba(128, 128, 128, 0.692);
  backdrop-filter: blur(10px);
  color: rgba(245, 44, 78, 0.89);
  text-align: center;
  font-size: larger;
  border-radius: .5rem;
  height: fit-content;
  border: none;
  width: 5vh;
  height: 5vh;
}

.title{
  background-color: rgba(128, 128, 128, 0.692);
  backdrop-filter: blur(10px);
  color: white;
  text-align: center;
  padding-bottom: .5rem;
  border-radius: .5rem;
}

@media screen and (max-width: 768px){
 .recipe-cover{
  height: 35vh;
  }
}
</style>