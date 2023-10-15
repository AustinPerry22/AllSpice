<template>
    <section class="row justify-content-center">
        <div class="col-9">
          <section class="row elevation-3 recipe-cover align-content-between selectable">
            <div class="col-12">
              <section class="row justify-content-between">
                <h5 class="category col-4 mt-2 ms-3 p-0">{{ recipe.category }}</h5>
                  <!-- TODO change heart based on favorite -->
                  <h5 v-if="account.id && recipe.isFavorite" @click="toggleFavorite()" class="col-1 me-2 mt-2 p-0 heart"><i class="mdi mdi-heart"></i></h5>
                  <h5 v-else-if="account.id" @click="toggleFavorite()" class="col-1 me-2 mt-2 p-0 heart"><i class="mdi mdi-heart-outline"></i></h5>
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

export default {
props: {recipe: {type: Recipe, required: true}},
setup(props) {
  return {
    recipeImg: computed(()=> `url('${props.recipe.img}')`),
    account: computed(()=> AppState.account),

    async toggleFavorite()
    {
      try {
        favoritesService.toggleFavorite(props.recipe)
      } catch (error) {
        Pop.error(error)
      }
    }
  };
},
};
</script>


<style>
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
  border-radius: .5rem;
  height: fit-content;
}

.title{
  background-color: rgba(128, 128, 128, 0.692);
  backdrop-filter: blur(10px);
  color: white;
  text-align: center;
  padding-bottom: .5rem;
  border-radius: .5rem;
}
</style>