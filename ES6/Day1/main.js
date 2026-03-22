
//swap 
let a = 5;
let b = 10;

[b, a] = [a, b];
console.log(a);
console.log(b);
import { Rectangle, Square, Circle, Shape } from './classes.js';

// const shape = new Shape();
const rect = new Rectangle(10, 5);
const square = new Square(4);
const circle = new Circle(3);

console.log(rect.toString());
console.log(square);
console.log(circle);