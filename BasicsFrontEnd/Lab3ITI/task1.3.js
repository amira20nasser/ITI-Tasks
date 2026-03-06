
document.writeln("<p>Task 1.3</p>");
document.writeln("<hr>");
let number1 = parseInt(prompt("Enter a number"));
let number2 = parseInt(prompt("Enter another number"));

if (isNaN(number1) || isNaN(number2)) {
    console.log("%cInvalid number of values.", "color: pink; font-size: 16px;");
} else {
    (number1 > number2) ?
        console.log(`%cThe number ${number1} is bigger`, "color:green; font-size:18px;")
        : (number1 == number2) ?
            console.log(`%c${number1} = ${number2}`, "color:green; font-size:18px;")
            : console.log(`%cThe number ${number2} is bigger`, "color:green; font-size:18px;")
}
