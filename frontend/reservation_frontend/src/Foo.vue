<template>
	<div class="d-flex flex-column align-items-center w-100">
		<top-bar></top-bar>
		<div>Foo</div>
	</div>
</template>

<script>
import TopBar from './components/TopBar.vue';
export default {
	name: "Foo",
	components: {
		TopBar
	}
};
</script>

<style>
</style>
