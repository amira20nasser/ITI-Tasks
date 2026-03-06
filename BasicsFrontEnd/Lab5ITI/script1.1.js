/*
Fill an array (n numerical values) from the user, the n is determined by the user.
Use sort method to sort the array’s values in descending and ascending orders
Display the output in the console.
*/

// let n = parseInt(prompt("Enter count of array", 4));

// while (isNaN(n)) {
//     n = parseInt(prompt("Invalide,Enter count of array", 4));
// }

// let arr = [];
// for (let index = 0; index < n; index++) {
//     let number = parseInt(prompt(`Enter ${index + 1} number`, 0));
//     while (isNaN(number)) {
//         number = parseInt(prompt("Invalide,Enter count of array", 4));
//     }
//     arr.push(number);
// }

// let asc = [];
// let dsc = [];
// for (let index = 0; index < n; index++) {
//     asc.push(arr[index]);
//     dsc.push(arr[index]);
// }
// asc.sort(function (n1, n2) {
//     return n1 - n2;
// })

// dsc.sort(function (n1, n2) {
//     return n2 - n1;
// })
// alert(`original ${arr.join()} \n the Ascending ${asc.join()}`);
// alert(`original ${arr.join()} \n the Descending ${dsc.join()}`);

/*
1.2.1. Write a function called showAddr that accepts an address object with the
following properties: street, buildingNum, and city. It should return the
complete address of the user with the registered date.
Example: if the addrObj={street:”abc st.”,buildingNum:15,city:”xyz”}, calling
showAddr(addrObj) will return “15 abc st., xyz city registered in 15/10/2024”.
*/

// function showAddr(addr) {
//     return `${addr['buildingNum']} ${addr['street']} ${addr['city']} city registered in ${new Date().toLocaleDateString()}`
// }
// let obj = { street: "abc st.", buildingNum: 15, city: "xyz" };
// document.writeln(showAddr(obj));

/*
1.2.2. Write a function called dispVal that takes an object with two properties
and a string as arguments. It should return the value of the property with key
equal to the value of the string
Example: if obj={nm:”ali”,age:10} then calling dispVal(obj,”age”) will return “10
years old”
*/

// let obj = { nm: "ali", age: 10 }
// function dispVal(obj, property) {
//     return obj[property];
// }
// document.writeln(dispVal(obj, "nm"));


/*2.1.1. Create a parent window that opens a flying child window. Hint: Start by
creating a parent window that opens a child window.
Child window should always be on top view and moves up and down within
boundaries of user screen.
Parent window should contain a button that stops child window movement.
*/
// let win = open("w.html", "_blank", "top=0,left=0");
// let y = 10;
// let x = 10;
// function moveWin() {
//     win.focus();
//     win.moveBy(x, y);
//     win.resizeTo(300, 300);
//     // console.log("============")
//     // console.log(win.screenX);
//     // console.log(win.screenY);
//     // console.log("============")
//     if (win.screenY >= 540 || win.screenY <= 0 || win.screenX >= 600 || win.screenX <= 0) {
//         y = -y;
//         x = -x;
//     }
// }
// let id = setInterval(moveWin, 200)

// function stopWin() {
//     win.focus();
//     clearInterval(id);
//     console.log(id)
// }


// function time2() {
//     moveWin();
//     setTimeout(time2, 200);
// }
// let id = setTimeout(time2, 200);

/*2.1.2. Create a parent a window that opens a scrollable advertising child
window.*/

// let win = open("w.html", "_blank", "top=0,left=0");
// let scrolly = 30;
// function scrollWin() {
//     win.focus();
//     win.resizeTo(300, 300);
//     win.scrollBy(0, scrolly)
//     if (win.innerHeight + win.scrollY >= win.document.body.scrollHeight) {
//         scrolly = -scrolly;
//     }

//     if (win.scrollY <= 0) {
//         scrolly = -scrolly;
//     }
// }
// setInterval(scrollWin, 300)

// function time1() {
//     scrollWin();
//     setTimeout(time1, 300);
// }
// setTimeout(time1, 300)