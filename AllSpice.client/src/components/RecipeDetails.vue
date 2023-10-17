<template>
<section class="row">
    <div class="col-4 bg-img text-end">
        <button class="btn btn-light"><i class="mdi mdi-heart"></i></button>
    </div>
    <div class="col-4">
        <h5>{{ recipe.category }}</h5>
        <div v-if="recipe.creatorId == accountId">
            <div v-if="!locked">
                <form @submit.prevent="editRecipe">
                    <textarea v-model="recipe.instructions" type="text" maxlength="5000" rows="15" class="form-control" required></textarea>
                    <button class="btn btn-success">Save Instructions</button>
                </form>
            </div>
            <div v-else>
                <p>{{ recipe.instructions }}</p>
            </div>
        </div>
        <div v-else>
            <p>{{ recipe.instructions }}</p>
        </div>
    </div>
    <div class="col-4">
        <div v-if="recipe.creatorId == accountId" class="text-end">
            <button v-if="!locked" @click="toggleLock()" class="btn btn-danger" >lock</button>
            <button v-else @click="toggleLock()" class="btn btn-success" >unlock</button>
        </div>
        <div v-for="ingredient in ingredients" :key="ingredient.id">
            <h5>{{ ingredient.quantity }}  {{ ingredient.name }}</h5>
            <button v-if="!locked" @click="deleteIngredient(ingredient.id)" class="btn btn-danger"><i class="mdi mdi-delete"></i></button>
        </div>
        <div v-if="!locked">
            <form @submit.prevent="createIngredient">
                <label for="name">Ingredient Name:</label>
                <input v-model="ingredientData.name" type="text" required maxlength="255" class="form-control">
                <label for="quantity">Quantity:</label>
                <input v-model="ingredientData.quantity" type="text" maxlength="255" placeholder="1 Cup" class="form-control" required>
                <button class="btn btn-success">Add Ingredient</button>
            </form>
        </div>
    </div>
    <div v-if="!locked" class="text-end">
        <button @click="deleteRecipe" class="btn btn-danger">Delete Recipe</button>
    </div>
</section>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, watchEffect, ref } from 'vue';
import Pop from '../utils/Pop';
import { ingredientsService } from '../services/IngredientsService';
import { recipesService } from '../services/RecipesService';
import { Modal } from 'bootstrap';
export default {
    setup(){
        const ingredientData = ref({})
        watchEffect(()=>{
            AppState.activeRecipe
            AppState.instructionsLock = true;
        })
        
    return { 
        ingredientData,
        locked: computed(()=> AppState.instructionsLock),
        recipe: computed(()=> AppState.activeRecipe),
        recipeImg: computed(()=> `url('${AppState.activeRecipe.img}')`),
        ingredients: computed(()=> AppState.ingredients),
        accountId: computed(()=> AppState.account.id),
        toggleLock(){
            AppState.instructionsLock = !AppState.instructionsLock;
        },

        async createIngredient(){
            try {
                await ingredientsService.createIngredient(ingredientData.value)
                ingredientData.value = {} 
            } catch (error) {
                Pop.error(error)
            }
        },

        async deleteIngredient(ingredientId){
            try{
                await ingredientsService.deleteIngredient(ingredientId)
            } catch (error){
                Pop.error(error)
            }
        },
        
        async editRecipe(){
            try{
                await recipesService.editRecipe(this.recipe)
            }catch (error){
                Pop.error(error)
            }
        },
        
        async deleteRecipe(){
            try {
                if(await Pop.confirm("Are you sure you want to delete this recipe?"))
                {
                    Modal.getOrCreateInstance("#active-recipe").hide()
                    await recipesService.deleteRecipe(this.recipe.id)
                    Pop.success("Recipe Deleted")
                }
            } catch (error) {
                Pop.error(error)
            }
        }


     }
    }
};
</script>


<style lang="scss" scoped>
.bg-img{
    background-image: v-bind(recipeImg);
    background-position: center;
    background-size: cover;
    height: 70vh;
    border-radius: .5rem;
    min-height: fit-content;
}
</style>