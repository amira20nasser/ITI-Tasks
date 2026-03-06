
document.writeln("<p>Task 1.4</p>");
document.writeln("<hr>");

let x = parseInt(prompt("Enter value of x:"));
let y = parseInt(prompt("Enter value of y:"));
let z = parseInt(prompt("Enter value of z:"));

if (x % y === 0 && x % z === 0) {
    console.log(`%c${x} is divisible by both ${y} and ${z}`, "color:green; font-size:30;");
}
else if (x % y === 0) {
    console.log(`%c${x} is divisible by ${y} only`, "color:green; font-size:30;");
}
else if (x % z === 0) {
    console.log(`%c${x} is divisible by ${z} only`, "color:green; font-size:30;");
}
else {
    console.log(`%c${x} is not divisible by ${y} nor ${z}`, "color:green; font-size:30;");
}