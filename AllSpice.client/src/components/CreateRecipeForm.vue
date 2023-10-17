<template>
    <form @submit.prevent="createRecipe">
        <label for="title">Recipe Name</label>
        <input v-model="recipeData.title" type="text" class="form-control" maxlength="255" required>
        <label for="instructions">Instructions</label>
        <input v-model="recipeData.instructions" type="text" class="form-control" maxlength="5000" required>
        <label for="background-img">Image Url</label>
        <input v-model="recipeData.img" type="url" class="form-control" maxlength="5000" required>
        <label for="category">Category</label>
        <select v-model="recipeData.category" class="form-control" required>
            <option value="Soup">Soup</option>
            <option value="Salad">Salad</option>
            <option value="Vegetables">Vegetables</option>
            <option value="Desserts">Desserts</option>
            <option value="Main Course">Main Course</option>
        </select>
        <button class="btn btn-success" data-bs-toggle="modal" data-bs-target="#create-recipe">Create Recipe</button>
    </form>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService';
import {Modal} from 'bootstrap';
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
                Modal.getOrCreateInstance("#active-recipe").show()
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