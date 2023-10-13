<template>
  <div class="container-fluid">
    <!-- STUB splash card and searchbar/login -->
    <Cover/>
    <!-- STUB select thing -->
    <SelectCategory/>
    <section class="row justify-content-around">
      <!-- STUB recipe cards -->
      <div v-for="recipe in recipes" :key="recipe.id" class="col-3">
        {{ recipe.title }}
      </div>
    </section>

    <!-- STUB add button -->
    <section class="row justify-content-end">
      <div class="col-1 text-center">
        <button class="btn btn-success"><i class="mdi mdi-plus"></i></button>
      </div>
    </section>
    <!-- STUB MODAL WRAPPERS -->
  </div>

</template>

<script>
import { computed, onMounted } from 'vue';
import {AppState} from '../AppState'
import Cover from '../components/Cover.vue';
import SelectCategory from "../components/SelectCategory.vue"
import {recipesService} from "../services/RecipesService"


export default {
    setup() {
      onMounted(()=>{
        AppState.recipes = [];
        recipesService.GetAllRecipes()
      })
        return {
          recipes : computed(()=> AppState.recipes)
        };
    },
    components: { Cover, SelectCategory }
}
</script>

<style scoped lang="scss">

</style>
