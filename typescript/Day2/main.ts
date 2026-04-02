import { Stack } from './classes';
enum Gender {
    female = "female",
    male = "male"
}

let gender: Gender = Gender.female;
console.log(gender);

let s = new Stack<number>();
s.push(1);