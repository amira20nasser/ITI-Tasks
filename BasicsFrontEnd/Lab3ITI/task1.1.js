// Task 1
var message = prompt("Enter Your Message", "Amira Nasser");
document.writeln("<p>Task 1.1</p>");
document.writeln("<hr>");

for (let index = 0; index < 6; index++) {
    document.writeln(`<h${index + 1}>${message}<h${index + 1}>`);
}
document.writeln("<hr>");