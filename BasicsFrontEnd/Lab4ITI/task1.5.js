let radius = parseFloat(prompt("Enter the radius of the circle:"));
if (!isNaN(radius) && radius >= 0) {
    let area = Math.PI * radius * radius;
    console.log("The area of the circle is: " + area.toFixed(2));
} else {
    alert("Please enter a valid non-negative number for the radius.");
}

let number = parseFloat(prompt("Enter a number to calculate its square root:"));
if (!isNaN(number) && number >= 0) {
    let sqrtResult = Math.sqrt(number);
    console.log("The square root of " + number + " is: " + sqrtResult.toFixed(2));
} else {
    alert("Please enter a valid non-negative number.");
}

let angle = parseFloat(prompt("Enter an angle in degrees to calculate its cosine:"));
if (!isNaN(angle)) {
    let radians = angle * (Math.PI / 180);
    let cosValue = Math.cos(radians);
    console.log("The cosine of " + angle + "° is: " + cosValue.toFixed(2));
} else {
    console.log("Invalid input for angle.");
}