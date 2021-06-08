<template>
    <div class="d-flex flex-column align-items-center w-100">
        <canvas id="c" width="1000" height="400"></canvas>
    </div>
</template>

<script>
import { fabric } from "fabric";

export default {
    name: "PickPlaceCanvas",
    data: function () {
        return {
            canvas: null,
        };
    },
    watch: {
        train: function() {
            this.load();
        },
        trainCarId: function() {
            this.load()
        }
    },
    props: {
        train: Object,
        trainCarId: Number,
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
        load: function () {
            this.canvas.clear()
            if (this.train == null || this.trainCarId == null) return;
            
            var trainCar = this.train.trainCars.find(tc => tc.trainCarsId == this.trainCarId)
            if (trainCar == null)
                return;
            
            trainCar.car.places.forEach((place) => {
                const p = this.createPlace();
                p.left = place.x * this.canvas.width;
                p.top = place.y * this.canvas.height;
                p.scaleX = (place.width * this.canvas.width) / p.width;
                p.scaleY = (place.height * this.canvas.height) / p.height;
                p.placeId = place.placeId;

                var fill;
                if (place.picked != undefined && place.picked) {
                    fill = "green"
                } else if (place.occupied != undefined && place.occupied) {
                    fill = "red"
                    p.hoverCursor = "default"
                } else {
                    fill = "rgba(0,0,0,0)"
                }

                p.item(1).text = place.number.toString();
                p.item(0).set({ fill: fill });
                p.setCoords();

                p.on("mouseup", () => {
                    if (place.occupied != undefined && place.occupied) {
                        //do nothing
                    } else if (place.picked != undefined && place.picked) {
                        this.$set(place, "picked", false)

                        p.item(0).set({ fill: "rgba(0,0,0,0)" });
                        this.canvas.renderAll();
                    } else {
                        this.$set(place, "picked", true)

                        p.item(0).set({ fill: "green" });
                        this.canvas.renderAll();
                    }
                });
            });

            trainCar.car.graphics.forEach((graphic) => {
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

            this.bringPlacesToFront();
            this.canvas.renderAll();
        },
    },
    async mounted() {
        this.canvas = new fabric.Canvas("c", {
            preserveObjectStacking: true,
        });
        this.canvas.selection = false;

        this.load();
    },
};
</script>

<style>
</style>
