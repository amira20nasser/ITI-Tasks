// 1.3 Build your own function that takes a single string argument and
// returns the largest word in the string. If there are two or more words
// that are the same length, return the first word from the string with that
// length.
// e.g. if Input is: "this is a javascript string demo"
// Output will be: javascript 

function findLargestWord(str) {
    let words = str.split(" ");

    let largestWord = "";

    for (let i = 0; i < words.length; i++) {
        if (words[i].length > largestWord.length) {
            largestWord = words[i];
        }
    }

    return largestWord;
}

let userInput = prompt("Enter a string:");
let largest = findLargestWord(userInput);
alert(`The largest word is: "${largest}"`);