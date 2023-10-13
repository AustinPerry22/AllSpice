<template>
  <div class="container-fluid">
    <!-- STUB splash card and searchbar/login -->
    <Cover/>
    <!-- STUB select thing -->
    <SelectCategory/>
    <!-- STUB recipe cards -->
    <!-- 1 v-for appstate.recipecards -->

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
import Cover from '../components/Cover.vue';
import SelectCategory from "../components/SelectCategory.vue"


export default {
    setup() {
        return {};
    },
    components: { Cover, SelectCategory }
}
</script>

<style scoped lang="scss">

</style>
