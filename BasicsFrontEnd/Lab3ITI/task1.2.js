document.writeln("<p>Task 1.2</p>");
document.writeln("<hr>");
let sum = 0;
let count = parseInt(prompt("How many values do you want to enter?"));

if (isNaN(count) || count <= 0) {
    console.log("Invalid number of values.");
} else {
    for (let i = 0; i < count; i++) {

        let input = prompt("Enter a number (0 to stop):");
        let number = parseFloat(input);
        if (isNaN(number)) {
            console.log("Invalid input. Please enter a numeric value.");
            i--;
            continue;
        }

        if (number === 0) {
            break;
        }

        sum += number;
        if (sum > 100) {
            break;
        }
    }
    console.log(
        `%cTotal Sum: %c${sum}`,
        "color: blue; font-weight: bold;",
        "color: green; font-size: 16px;"
    );
}

document.writeln(`<h2> the sum of values ${sum}</h2>`)