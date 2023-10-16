<template>
    <section class="row">
        <div class="col-12">
            <form @submit.prevent="searchRecipes">
                <input v-model="searchData.search" type="text">
                <button>submit</button>
            </form>
        </div>
    </section>
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

</style>