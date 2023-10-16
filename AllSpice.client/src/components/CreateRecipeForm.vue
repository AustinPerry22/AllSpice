<template>
    <form @submit.prevent="createRecipe">
        <label for="title">Recipe Name</label>
        <input v-model="recipeData.title" type="text" class="form-control" maxlength="255" required>
        <label for="instructions">Instructions</label>
        <input v-model="recipeData.instructions" type="text" class="form-control" maxlength="5000" required>
        <label for="background-img">Image Url</label>
        <input v-model="recipeData.img" type="url" class="form-control" maxlength="5000" required>
        <label for="category">Category</label>
        <input v-model="recipeData.category" type="text" class="form-control" maxlength="255" required>
        <button class="btn btn-success">Create Recipe</button>
    </form>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService';
export default {
    setup(){
        const recipeData = ref({})
    return { 
        recipeData,
        async createRecipe()
        {
            try {
                await recipesService.createRecipe(recipeData.value)
                recipeData.value = {}
            } catch (error) {
                Pop.error(error)
            }
        }
     }
    }
};
</script>


<style lang="scss" scoped>

</style>