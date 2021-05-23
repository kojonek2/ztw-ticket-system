<template>
    <div class="d-flex flex-column align-items-center w-100">
        <top-bar></top-bar>

        <canvas id="c" width="1000" height="400"></canvas>
        <div>
            Wybrane miejsca:
            <div v-for="place in pickedPlaces" :key="place.placeId">Miejsce numer: {{place.number}}</div>
        </div>
    </div>
</template>

<script>
import TopBar from "../components/TopBar.vue";
import { fabric } from "fabric";
import axios from "axios";

export default {
    components: {
        TopBar,
    },
    name: "TestLoadPage",
    data: function () {
        return {
            canvas: null,
            pickedPlaces: [],
        };
    },
    methods: {
        createPlace: function () {
            var rect = new fabric.Rect({
                fill: "rgba(0,0,0,0)",
                width: 50,
                height: 50,
                strokeWidth: 4,
                stroke: "black",
                originX: "center",
                originY: "center",
                strokeUniform: true,
            });
            var t = new fabric.Text("1", {
                fontSize: 40,
                fontFamily: "Arial",
                fontWeight: "bold",
                originX: "center",
                originY: "center",
            });
            this.number++;

            var group = new fabric.Group([rect, t], {
                left: 150,
                top: 100,
                fill: "red",
                myType: "place",
                hoverCursor: "pointer",
                selectable: false,
            });
            group.controls = {
                ...fabric.Group.prototype.controls,
                mtr: new fabric.Control({ visible: false }),
            };

            this.canvas.add(group);
            return group;
        },
        createRect: function () {
            var rect = new fabric.Rect({
                fill: "rgba(0,0,0,0)",
                top: 150,
                left: 150,
                width: 200,
                height: 200,
                originX: "center",
                originY: "center",
                strokeWidth: 2,
                stroke: "black",
                hasRotatingPoint: false,
                strokeUniform: true,
                myType: "rect",
                selectable: false,
                hoverCursor: "default",
            });
            rect.controls = {
                ...fabric.Rect.prototype.controls,
                mtr: new fabric.Control({ visible: false }),
            };

            this.canvas.add(rect);
            return rect;
        },
        bringPlacesToFront: function () {
            this.frotnRect = !this.frotnRect;

            this.canvas.getObjects().forEach((object) => {
                if (object.myType == "place") {
                    this.canvas.bringToFront(object);
                }
            });
        },
        load: async function () {
            try {
                var response = await axios.get(
                    "/car/" + this.$route.params.name
                );
            } catch {
                return;
            }

            var car = response.data;
            car.places.forEach((place) => {
                const p = this.createPlace();
                p.left = place.x * this.canvas.width;
                p.top = place.y * this.canvas.height;
                p.scaleX = (place.width * this.canvas.width) / p.width;
                p.scaleY = (place.height * this.canvas.height) / p.height;
                p.placeId = place.placeId;

                p.item(1).text = place.number.toString();
                p.setCoords();

                p.on("mouseup", () => {
                    if (this.pickedPlaces.includes(place)) {
                        const index = this.pickedPlaces.indexOf(place)
                        this.pickedPlaces.splice(index, 1)

                        p.item(0).set({ fill: 'rgba(0,0,0,0)' })
                        this.canvas.renderAll()

                    } else {
                        this.pickedPlaces.push(place)

                        p.item(0).set({ fill: 'green' })
                        this.canvas.renderAll()
                    }
                });
            });

            car.graphics.forEach((graphic) => {
                var g;
                if (graphic.type == "rect") g = this.createRect();

                if (g != undefined) {
                    g.left = graphic.x * this.canvas.width;
                    g.top = graphic.y * this.canvas.height;
                    g.scaleX = (graphic.width * this.canvas.width) / g.width;
                    g.scaleY = (graphic.height * this.canvas.height) / g.height;
                    g.setCoords();
                }
            });
        },
    },
    async mounted() {
        this.canvas = new fabric.Canvas("c", {
            preserveObjectStacking: true,
        });
        this.canvas.selection = false;

        await this.load();

        this.bringPlacesToFront();
        this.canvas.renderAll();
    },
};
</script>

<style>
</style>
