<template>
    <section class="row justify-content-center">
        <div class="col-11 recipe-cover">
            {{ recipe }}
        </div>
    </section>
</template>

<script>
import { computed } from 'vue';
import { Recipe } from '../models/Recipe';

export default {
props: {recipe: {type: Recipe, required: true}},
setup(props) {
  return {
    recipeImg: computed(()=> `url('${props.recipe.img}')`)
  };
},
};
</script>


<style>
.recipe-cover{
    background-image: v-bind(recipeImg);
}
</style>