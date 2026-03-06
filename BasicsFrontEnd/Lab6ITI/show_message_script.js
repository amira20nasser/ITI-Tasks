document.getElementById('btn').onclick = showWin;
let win;
let id;
function showWin() {
    win = open("./message.html", "_blank", "top=0,left=0");
    win.resizeTo(600, 200);
    id = setInterval(typing, 100);
}

let statements = [
    "Hello, my name is Amira.",
    "I am a Mobile Developer.",
    "Currently studying Full Stack .NET at ITI."
];
let lettersStatements = [];
for (let stat of statements) {
    lettersStatements.push(stat.split(""));
}
let pIndex = 0;
let lIndex = 0;
function typing() {
    let currentP = lettersStatements[pIndex];
    if (lIndex < currentP.length) {
        win.document.getElementsByTagName('p')[pIndex].innerHTML += currentP[lIndex];
        lIndex++;
    } else {
        pIndex++;
        lIndex = 0;
    }
    if (pIndex >= statements.length) {
        clearInterval(id);
        pIndex = 0;
        lIndex = 0;
    }
}

