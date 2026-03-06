/*
1.1. Write a script that accepts a string from user through prompt and 
count the number of a specific character that the user will define in 
another prompt. Ask the user whether to consider difference between 
letter cases or not then display the number of letter appearance. 
*/

let message = prompt("Enter a message:");

let charToCount = prompt("Enter the character you want to count:");

if (charToCount.length !== 1) {
    alert("Please enter exactly one character!");
} else {
    let caseSensitive = confirm("Should the count be case-sensitive? (OK = Yes, Cancel = No)");
    let count = 0;

    for (let i = 0; i < message.length; i++) {
        if (caseSensitive) {
            if (message[i] === charToCount) {
                count++;
            }
        } else {
            if (message[i].toLowerCase() === charToCount.toLowerCase()) {
                count++;
            }
        }
    }

    alert(`The character "${charToCount}" appears ${count} times in your string.`);
    document.write(`<h1>${message}</h1>`);
    document.writeln(`<h3>The character ${charToCount} appears ${count} times in your string.</h3>`);
}
