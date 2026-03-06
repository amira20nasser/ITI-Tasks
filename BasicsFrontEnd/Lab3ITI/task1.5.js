document.writeln("<p>Task 1.5</p>");
document.writeln("<hr>");

let start = parseInt(prompt("Enter the start of the range:"));
let end = parseInt(prompt("Enter the end of the range:"));

let totalSum = 0;

document.writeln("<h4 style='color:green;'>Number multiple of 3: </h4>");
console.log("%cNumber multiple of 3: ", "color:green;")
for (let i = start; i <= end; i++) {
    if (i % 3 === 0) {
        document.writeln(i + " ");
        console.log(i);
        totalSum += i;
    }
}

document.writeln("<br>");

document.writeln("<h4 style='color:green;'>Number multiple of 5: </h4>");
console.log("%cNumber multiple of 5: ", "color:green;")

for (let i = start; i <= end; i++) {
    if (i % 5 === 0) {
        document.writeln(i + " ");
        console.log(i);
        totalSum += i;
    }
}

document.writeln("<br><h4 style='color:green;'>Total sum is</h4> " + totalSum);
console.log(`%cTotal sum is: ${totalSum}`, "color:pink; font-weight:bold;")
