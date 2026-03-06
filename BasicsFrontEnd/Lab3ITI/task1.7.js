document.writeln("<p>Task 1.7</p>");
document.writeln("<hr>");


let x, y;
while (true) {
    x = prompt("Enter the first number (x):");
    x = Number(x);
    if (isNaN(x)) {
        console.log("%cError: x must be numeric values.", "color:red");
    } else {
        break;
    }
}
while (true) {
    y = prompt("Enter the second number (y):");
    y = Number(y);
    if (isNaN(y)) {
        console.log("%cError: y must be numeric values.", "color:red");

    } else {
        break;
    }
}

let z = prompt("Enter type (odd / even / no):", "even");

if (typeof z !== "string" || (z !== "odd" && z !== "even" && z !== "no")) {
    console.log("%cError: z must be 'odd', 'even', or 'no'.", "color:red;");
} else {
    let sum = 0;

    let step = x < y ? 1 : -1;

    console.log("%cNumbers in range:", "color: blue; font-weight: bold;");
    for (let i = x; step === 1 ? i <= y : i >= y; i += step) {
        if (z === "odd" && i % 2 !== 0) {
            console.log("%c" + i, "color: green; font-size: 14px;");
            sum += i;
        } else if (z === "even" && i % 2 === 0) {
            console.log("%c" + i, "color: green; font-size: 14px;");

            sum += i;
        } else if (z === "no") {
            console.log("%c" + i, "color: green; font-size: 14px;");
            sum += i;
        }
    }

    console.log("%cSum = " + sum, "color: red; font-weight: bold;");
}