<template>
    <form @submit.prevent="createRecipe" class="container-fluid">
        <section class="row justify-content-around">
            <div class="col-6">
                <label for="title">Recipe Name</label>
                <input v-model="recipeData.title" type="text" class="form-control" maxlength="255" required>
            </div>
            <div class="col-6">
                <label for="category">Category</label>
                <select v-model="recipeData.category" class="form-control" required>
                    <option value="Soup">Soup</option>
                    <option value="Salad">Salad</option>
                    <option value="Vegetables">Vegetables</option>
                    <option value="Desserts">Desserts</option>
                    <option value="Main Course">Main Course</option>
                </select>
            </div>
            
        </section>
        <label for="instructions">Instructions</label>
        <textarea v-model="recipeData.instructions" type="text" rows="10" class="form-control" maxlength="5000" required></textarea>
        <label for="background-img">Image Url</label>
        <input v-model="recipeData.img" type="url" class="form-control" maxlength="5000" required>
        <section class="row justify-content-center mt-3">
            <button class="btn btn-success col-6" data-bs-toggle="modal" data-bs-target="#create-recipe">Create Recipe</button>
        </section>
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