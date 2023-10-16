<template>
    <section class="row">
        <div class="col-12">
            <form @submit.prevent="">
                <input type="text">
            </form>
        </div>
    </section>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
export default {
    setup(){
    return {  }
    }
};
</script>


<style lang="scss" scoped>

</style>