/*
Name --- charaters only 
Phone --- length 8
Mobile Number - (010 | 011|012) 11 length
email 
amira_nasser20@gmail.com
amira.232@gmail.com
a@.a
*/
function validateName(name) {
    return /^[A-Za-z\s]+$/.test(name);
}

function validatePhone(phone) {
    return /^\d{8}$/.test(phone);
}

function validateMobile(mobile) {
    return /^(010|011|012)\d{8}$/.test(mobile);
}

function validateEmail(email) {
    return /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-z]{2,}$/.test(email);
}

let name = prompt("Enter your Name:");
while (!validateName(name)) {
    name = prompt("Invalid name! Enter letters only:");
}

let phone = prompt("Enter your Phone Number (8 digits):");
while (!validatePhone(phone)) {
    phone = prompt("Invalid phone! Enter 8 digits:");
}

let mobile = prompt("Enter your Mobile Number (11 digits, starts with 010, 011, 012):");
while (!validateMobile(mobile)) {
    mobile = prompt("Invalid mobile! Enter 11 digits starting with 010, 011, or 012:");
}

let email = prompt("Enter your Email:");
while (!validateEmail(email)) {
    email = prompt("Invalid email! Enter a correct email format (e.g. abc@123.com):");
}

let color = prompt("Choose a color for your message (red, green, blue):").toLowerCase();
while (!["red", "green", "blue"].includes(color)) {
    color = prompt("Invalid choice! Choose either red, green, or blue:").toLowerCase();
}


document.write(`
  <h2 style="color:${color};">
    Welcome ${name}!<br>
    Your info has been saved.<br>
    Phone: ${phone}<br>
    Mobile: ${mobile}<br>
    Email: ${email}<br>
  </h2>
`);