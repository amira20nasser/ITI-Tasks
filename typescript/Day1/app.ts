let myName: string = "Amira Nasser";
let num: number = 10;
let isEvent: boolean = num % 2 == 0;
let arr: (number | string | null)[] = [null, "amira", 1, 2, 3];
let arr2: number[] | undefined;
console.log(arr2);

function sayHello(name: string = "Amira"): string {
    return `Hello, ${name}`;
}


class Point2D {
    x: [number, number];
    y: [number, number];
    constructor(x: [number, number], y: [number, number]) {
        this.x = x;
        this.y = y;
    }
    calculateDistance(): number {
        const dx = this.x[1] - this.x[0];
        const dy = this.y[1] - this.y[0];
        return Math.sqrt(dx * dx + dy * dy);
    }
}

class Point3D extends Point2D {
    z: [number, number];
    constructor(x: [number, number], y: [number, number], z: [number, number]) {
        super(x, y);
        this.z = z;
    }
    calculateDistance(): number {
        const dx = this.x[1] - this.x[0];
        const dy = this.y[1] - this.y[0];
        const dz = this.z[1] - this.z[0];
        return Math.sqrt(dx * dx + dy * dy + dz * dz);
    }
}

const point2D = new Point2D([0, 3], [0, 4]);
console.log(`Distance = ${point2D.calculateDistance()}`);