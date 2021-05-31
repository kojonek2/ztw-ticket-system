<template>
    <div class="d-flex flex-column align-items-center w-100">
        <top-bar></top-bar>
        <div>bar</div>
    </div>
</template>

<script>
import TopBar from "./components/TopBar.vue";
export default {
    components: {
        TopBar,
    },
    name: "Bar",
    mounted() {},
};
</script>

<style>
</style>
