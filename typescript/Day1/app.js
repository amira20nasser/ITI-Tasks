"use strict";
let myName = "Amira Nasser";
let num = 10;
let isEvent = num % 2 == 0;
let arr = [null, "amira", 1, 2, 3];
function sayHello(name = "Amira") {
    return `Hello, ${name}`;
}
class Point2D {
    x;
    y;
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }
    calculateDistance() {
        const dx = this.x[1] - this.x[0];
        const dy = this.y[1] - this.y[0];
        return Math.sqrt(dx * dx + dy * dy);
    }
}
class Point3D extends Point2D {
    z;
    constructor(x, y, z) {
        super(x, y);
        this.z = z;
    }
    calculateDistance() {
        const dx = this.x[1] - this.x[0];
        const dy = this.y[1] - this.y[0];
        const dz = this.z[1] - this.z[0];
        return Math.sqrt(dx * dx + dy * dy + dz * dz);
    }
}
const point2D = new Point2D([0, 3], [0, 4]);
console.log(`Distance = ${point2D.calculateDistance()}`);
