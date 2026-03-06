document.writeln("<p>Task 1.6</p>");
document.writeln("<hr>");

let rows = parseInt(prompt("Enter number of rows:"));

for (let i = 1; i <= rows; i++) {
    for (let j = 1; j <= i; j++) {
        document.writeln("*");
    }
    document.writeln("<br>");
}