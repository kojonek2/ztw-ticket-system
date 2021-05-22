<template>
    <div id="app" class="d-flex align-items-center justify-content-center">
        <div>
            <router-link to='/'>
                <img src="../assets/train.png" class="img-fluid logo">
            </router-link>
        </div>
        <div>
            <div class="upperText">Koleje - rezerwacje</div>
            <div class="lowerText">System obsługi rezerwacji miejsc w pociągu</div>
        </div>
    </div>
</template>

<script>
export default {
    name: "LogoWithTexts",
};
</script>

<style>
.logo {
    height: 150px;
}

.upperText {
    font-size: 3rem;
}

.lowerText {
    font-size: 1.2rem;
}
</style>