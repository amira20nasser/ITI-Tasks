// 1)	Using rest parameter and spread operator return max value from any array
//  note: array length is not fixed return min and max value and display each of them separately after function call.
function findMax(...numbers) {
    let l = numbers.length;
    if (l > 1) {
        let min = numbers[0];
        let max = numbers[0];
        for (let i = 0; i < l; i++) {
            if (min > numbers[i]) {
                min = numbers[i];
            }
            if (max < numbers[i]) {
                max = numbers[i];
            }
        }
        return [min, max];
    }
}

let arr = [10, 20, 30, 40, 50];
let [minValue, maxValue] = findMax(...arr);
console.log("Min:", minValue);
console.log("Max:", maxValue);

// 2)	 Study new array api methods then create the following methods and apply it on this array 
var fruits = ["apple", "strawberry", "banana", "orange", "mango"]
//. test that every element in the given array is a string
console.log(fruits.every(e => typeof e === 'string'));

// test that some of array elements starts with "a"
const startsWithA = fruits.some(f => f.startsWith("a"));
console.log(startsWithA);

//generates new array filtered from the given array with only elements that
//starts with "b" or "s"
let newArr = fruits.filter(fruit => fruit.startsWith('b') || fruit.startsWith("s"));
console.log(newArr);

//. generates new array each element of the new array contains a string 
//declaring that you like the give fruit element
let newArr2 = fruits.map(fruit => `I like ${fruit}`);

// . use forEach to display all elements of the new array from previous point
newArr2.forEach(fruit => console.log(fruit));