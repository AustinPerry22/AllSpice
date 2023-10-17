<template>
    <form @submit.prevent="searchRecipes" class="text-end row justify-content-end">
        <input v-model="searchData.search" class="col-5" type="text" placeholder="Search..." required>
        <button class="btn btn-primary col-1"><i class="mdi mdi-magnify"></i></button>
        
    </form>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import { recipesService } from '../services/RecipesService';
export default {
    setup(){
        const searchData = ref({})
    return { 
        searchData,

        searchRecipes(){
            recipesService.searchRecipes(searchData.value)
        }
     }
    }
};
</script>


<style lang="scss" scoped>
input{
    border-radius: 0.375rem 0rem 0rem 0.375rem ;
    border-style: none;
}
button{
    border-radius: 0rem 0.375rem 0.375rem 0rem;
}
</style>