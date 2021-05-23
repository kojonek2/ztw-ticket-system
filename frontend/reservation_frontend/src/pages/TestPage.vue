<template>
    <div class="d-flex flex-column align-items-center w-100">
        <top-bar></top-bar>

        <canvas id="c" width="1000" height="400"></canvas>
        <button v-on:click="createPlace" class="btn btn-dark">Add Place</button>
        <button v-on:click="createRect" class="btn btn-dark">Add Rect</button>
        
        <div class="d-flex">
            <button v-on:click="saveCar" class="btn btn-dark">Save</button>
            <input v-model="name">
        </div>
    </div>
</template>

<script>
import TopBar from "../components/TopBar.vue";
import { fabric } from "fabric";
import axios from 'axios'

export default {
    components: {
        TopBar,
    },
    name: "TestPage",
    data: function () {
        return {
            canvas: null,
            number: 1,
            name: "",
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
            var t = new fabric.Text(this.number.toString(), {
                fontSize: 40,
                fontFamily: 'Arial',
                fontWeight: 'bold',
                originX: "center",
                originY: "center",
            });
            this.number++

            var group = new fabric.Group([rect, t], {
                left: 150,
                top: 100,
                fill: "red",
                myType: "place",
                hoverCursor: "pointer",
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
            });
            rect.controls = {
                ...fabric.Rect.prototype.controls,
                mtr: new fabric.Control({ visible: false }),
            };

            this.canvas.add(rect);
            this.bringPlacesToFront()

            return rect
        },
        bringPlacesToFront: function () {
            this.frotnRect = !this.frotnRect

            this.canvas.getObjects().forEach(object => {
                if (object.myType == 'place') {
                    this.canvas.bringToFront(object)
                }
            })
        },
        saveCar: async function() {
            const car = {
                Name: this.name,
                Places: [],
                Graphics: [],
            }

            this.canvas.getObjects().forEach(object => {
                if (object.myType == 'place') {
                    const place = {
                        x: object.left / this.canvas.width,
                        y: object.top / this.canvas.height,
                        number: parseInt(object.item(1).text),
                        width: (object.width * object.scaleX) / this.canvas.width,
                        height: (object.height * object.scaleY) / this.canvas.height,
                    }
                    car.Places.push(place)
                } else {
                    const graphic = {
                        x: object.left / this.canvas.width,
                        y: object.top / this.canvas.height,
                        width: (object.width * object.scaleX) / this.canvas.width,
                        height: (object.height * object.scaleY) / this.canvas.height,
                        type: object.myType,
                    }
                    car.Graphics.push(graphic)
                }
            })
            console.log(car)
            await axios.post("/car", car)
        }
    },
    mounted() {
        this.canvas = new fabric.Canvas("c", {
            preserveObjectStacking: true
        });
        this.canvas.selection = false;

        this.createPlace();

        var a = this.createPlace();
        a.top = 205;
        a.setCoords();

        this.createRect();

        this.canvas.renderAll();
    },
};
</script>

<style>
</style>
