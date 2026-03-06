// 1.2. Write a script to determine whether the entered string is
// palindrome or not.  Request the string to be entered via prompt, ask the
// user whether to consider case sensitivity of the entered string or not via
// confirm, handle both cases in your script
// i.e. RADAR NOON MOOM are palindrome.
// Note: raDaR is not a palindrome if user requested considering case of
// entered string, it will be palindrome if user requested ignoring case
// sensitivity. 

let message = prompt("Enter a string:");

let caseSensitive = confirm("Should the palindrome check be case-sensitive? (OK = Yes, Cancel = No)");

let stringToCheck = caseSensitive ? message : message.toLowerCase();

stringToCheck = stringToCheck.trim();


let reversedString = stringToCheck.split("").reverse().join("");

if (stringToCheck === reversedString) {
    alert(`"${message}" is a palindrome.`);
} else {
    alert(`"${message}" is NOT a palindrome.`);
}