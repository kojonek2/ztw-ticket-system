<template>
    <div class="d-flex flex-column align-items-center w-100">
        <top-bar></top-bar>
        <hr />
        <p class="col-6 text-justify">
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum
            viverra lobortis justo vehicula blandit. Sed sit amet aliquam erat,
            et gravida augue. In faucibus sem vitae felis vehicula molestie eget
            ut neque. Nullam a purus lorem. Quisque pharetra, odio gravida
            volutpat lobortis, massa metus pulvinar mauris, at posuere arcu
            ipsum at arcu. Curabitur sodales mollis aliquam. Maecenas finibus
            purus leo, eget sollicitudin lacus luctus in. Vivamus in bibendum
            arcu, id dapibus ex. Suspendisse potenti. Vestibulum laoreet odio
            sapien, sit amet tempus mauris bibendum nec. Donec tempor commodo
            porttitor. Donec at augue et erat auctor aliquam. Nam quis ultricies
            ex. Morbi consectetur lectus vitae ultricies molestie. Vivamus
            egestas pellentesque sapien nec sollicitudin. Nam non consequat
            ante. Vestibulum luctus lacus velit, semper accumsan lorem viverra
            eget. Aenean sed malesuada libero. Nunc porta, lorem nec aliquet
            fermentum, erat risus tempus libero, at accumsan nibh arcu eget
            purus. Sed interdum, neque et aliquam viverra, metus ex bibendum
            leo, auctor placerat justo lacus nec nisl. Pellentesque mattis augue
            et placerat malesuada.
        </p>

        <div class="row row-cols-3 g-4 col-6">
            <div class="col">
                <div class="card h-100">
                    <img src="../assets/train_cart1.png" class="card-img-top" alt="..." />
                    <div class="card-body">
                        <h5 class="card-title">Nowe wagony</h5>
                        <p class="card-text">
                            Większość składów pociągów składa się z nowych lub zmodernizowanych wagonów przystosowanych do nowych standarów.

                        </p>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="card h-100">
                    <img src="../assets/train_cart2.svg" class="card-img-top" alt="..." />
                    <div class="card-body">
                        <h5 class="card-title">Wygodna podróż</h5>
                        <p class="card-text">
                            Większość wagonów wyposażona jest w klimatyzację oraz gniazdka elekryczne oraz USB pod każdym siedzieniem.
                        </p>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="card h-100">
                    <img src="../assets/car_bus.png" class="card-img-top" alt="..." />
                    <div class="card-body">
                        <h5 class="card-title">Konkurencyjny transport</h5>
                        <p class="card-text">
                            Kolej alternatywą dla samochodu i autobusu. Większy komfort, prędkość oraz 
                        </p>
                    </div>
                </div>
            </div>
        </div>

		<p class="col-6 text-justify mt-3">
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum
            viverra lobortis justo vehicula blandit. Sed sit amet aliquam erat,
            et gravida augue. In faucibus sem vitae felis vehicula molestie eget
            ut neque. Nullam a purus lorem. Quisque pharetra, odio gravida
            volutpat lobortis, massa metus pulvinar mauris, at posuere arcu
            ipsum at arcu. Curabitur sodales mollis aliquam. Maecenas finibus
            purus leo, eget sollicitudin lacus luctus in. Vivamus in bibendum
            arcu, id dapibus ex. Suspendisse potenti. Vestibulum laoreet odio
            sapien, sit amet tempus mauris bibendum nec. Donec tempor commodo
            porttitor. Donec at augue et erat auctor aliquam. Nam quis ultricies
            ex. Morbi consectetur lectus vitae ultricies molestie. Vivamus
            egestas pellentesque sapien nec sollicitudin. Nam non consequat
            ante. Vestibulum luctus lacus velit, semper accumsan lorem viverra
            eget. Aenean sed malesuada libero. Nunc porta, lorem nec aliquet
            fermentum, erat risus tempus libero, at accumsan nibh arcu eget
            purus. Sed interdum, neque et aliquam viverra, metus ex bibendum
            leo, auctor placerat justo lacus nec nisl. Pellentesque mattis augue
            et placerat malesuada.
        </p>

    </div>
</template>

<script>
import TopBar from "../components/TopBar.vue";
export default {
    name: "MainPage",
    components: {
        TopBar,
    },
};
</script>

<style>
.text-justify {
    text-align: justify;
}
</style>
