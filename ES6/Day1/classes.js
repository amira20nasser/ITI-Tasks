// Write a script to create different shapes (rectangle, square, circle) make 
// all of them inherits from shape class. 
//a. each shape contains two functions to calculate its area and its 
//perimeter. 


class Shape {
    constructor() {
        if (this.constructor === Shape)
            throw ("Couldn't Create Instance");
    }
    area() {
        throw ("Method  must be implemented.");
    }
    perimeter() {
        throw ("Method  must be implemented.");
    }
    toString() {
        return `Area ${this.area()} Perimeter ${this.perimeter()}`
    }
}

class Rectangle extends Shape {
    constructor(width, height) {
        super();
        this.width = width;
        this.height = height;
    }

    area() {
        return this.width * this.height;
    }

    perimeter() {
        return 2 * (this.width + this.height);
    }
}

class Square extends Rectangle {
    constructor(width) {
        super(width, width);
    }
}

class Circle extends Shape {
    constructor(radius) {
        super();
        this.radius = radius;
    }

    area() {
        return Math.PI * this.radius ** 2;
    }

    perimeter() {
        return 2 * Math.PI * this.radius;
    }
}

export { Shape, Rectangle, Square, Circle };