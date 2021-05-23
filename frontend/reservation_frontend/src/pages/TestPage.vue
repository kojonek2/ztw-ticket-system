<template>
    <div class="d-flex flex-column align-items-center">
        <top-bar></top-bar>
        <canvas></canvas>
    </div>
</template>

<script>
import TopBar from '../components/TopBar.vue'

export default {
    components: {
        TopBar
    },
    name: "TestPage",
};
</script>

<style>
</style>
