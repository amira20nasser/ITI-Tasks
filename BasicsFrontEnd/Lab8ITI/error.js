function check(param1, param2) {
    if (arguments.length < 2 || arguments > 2) {
        throw new Error("check(param1, param2): Invalid number of parameters");
    }
}

function addNumbers() {
    if (arguments.length === 0) {
        throw new Error("No parameters provided. Please pass numbers to add.");
    }
    if (arguments.length < 2) {
        throw new Error(" Please pass at least 2 numbers to add.");
    }
    for (const argument of arguments) {
        if (typeof argument !== "number") {
            throw new TypeError(`Invalid type: ${argument} is not a number.`);
        }
    }
    let sum = 0;
    for (const number of arguments) {
        sum += number;
    }
    return sum;
}