<template>
  <div class="container-fluid">
    <!-- STUB splash card and searchbar/login -->
    <Cover/>
    <section class="row justify-content-around mx-md-3 mt-4 mt-md-0">
      <!-- STUB recipe cards -->
      <div v-for="recipe in recipes" :key="recipe.id" class="col-6 col-md-4 my-3 my-md-4 g-md-5">
        <RecipeCard :recipe="recipe"/>
      </div>
    </section>

    <!-- STUB add button -->
    <section class="row justify-content-end sticky-bottom">
      <div v-if="user.isAuthenticated" class="col-3 col-md-1 text-center">
        <!-- TODO make custom button -->
        <button class="add-recipe-button elevation-5 mb-3 mb-md-4 me-md-3" data-bs-toggle="modal" data-bs-target='#create-recipe'><i class="mdi mdi-plus"></i></button>
      </div>
    </section>


    <!-- STUB MODAL WRAPPERS -->
    <ModalWrapper id="active-recipe">
        <template #header>
          <div class="text-center">
            <h5>{{ activeRecipe.title }}</h5>
          </div>
        </template>
        <template #body>
          <RecipeDetails/>
        </template>
    </ModalWrapper>

    <ModalWrapper id="create-recipe">
        <template #header>
          <h5>New Recipe</h5>
        </template>
        <template #body>
          <CreateRecipeForm/>
        </template>
    </ModalWrapper>
  </div>

</template>

<script>
import { computed, onMounted, watchEffect } from 'vue';
import {AppState} from '../AppState'
import Cover from '../components/Cover.vue';
import RecipeCard from '../components/RecipeCard.vue';
import RecipeDetails from '../components/RecipeDetails.vue';
import CreateRecipeForm from '../components/CreateRecipeForm.vue'
import {recipesService} from "../services/RecipesService"
import {favoritesService} from "../services/FavoritesService"
import Pop from '../utils/Pop';


export default {
    setup() {
      onMounted(()=>{
        AppState.recipes = [];
        getAllRecipes();
      });
      watchEffect(()=>{
        AppState.account.id;
        getFavorites();
    });

    async function getAllRecipes()
    {
      try{
          AppState.recipes = [];
          recipesService.getAllRecipes()
      }
      catch (error){
        Pop.error(error)
      }
    }

    async function getFavorites(){
      try {
        if(AppState.account.id)
        {
          AppState.favorites = [];
          favoritesService.getFavorites();
        }
      } catch (error) {
        Pop.error(error)
      }
    }
        return {
          recipes : computed(()=> AppState.activeRecipes),
          activeRecipe: computed (()=> AppState.activeRecipe),
          user : computed(()=> AppState.user)
        };
    },
    components: { Cover, RecipeCard, RecipeDetails, CreateRecipeForm }
}
</script>

<style scoped lang="scss">
.add-recipe-button
{
  background-color: #198754;
  color: white;
  border-radius: 15rem;
  border-style: none;
  font-size: 225%;
  height: 7.5vh;
  width: 7.5vh;
}
</style>
