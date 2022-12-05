import {data} from "./input"

const {procedures} = data;
const splitedProcedures: string[] = procedures.split(/\r\n|\r|\n/); //
const numberProcedures: string[][] = splitedProcedures.map(procedure => procedure.split(/move | from | to /).slice(1));
let stackArray: string[][] = [];
stackArray.push(["S","L", "W"], ["J", "T", "N", "Q"], ["S", "C", "H", "F", "J"], ["T", "R", "M", "W", "N", "G", "B"],
    ['T', 'R', 'L', 'S', 'D', 'H','Q', 'B'], ['M', 'J', 'B','V', 'F', 'H','R', 'L'],
    [ 'D', 'W', 'R', 'N', 'J', 'M' ], ['B', 'Z', 'T', 'F', 'H', 'N','D', 'J'], ['H', 'L', 'Q','N', 'B', 'F','T']);
    
const stackArray2: string[][] = JSON.parse(JSON.stringify(stackArray));

numberProcedures.forEach(procedure => {
    const cratesCount: number = parseInt(procedure[0], 10);
    const startStack: number = parseInt(procedure[1], 10) - 1;
    const endStack: number = parseInt(procedure[2], 10) - 1;
    const reverseStack: string[] = [...stackArray[startStack]].reverse();

    let tempStack: string[] = [];
    for(let i = 0; i < cratesCount; i++){
        tempStack.push(reverseStack[i]);
        stackArray[startStack].pop();
    }
    tempStack.forEach(crate => stackArray[endStack].push(crate));
    
});

let topCrates:string = "";
stackArray.forEach(crate => topCrates += crate[crate.length - 1]);
console.log(topCrates);

// PART TWO

numberProcedures.forEach(procedure => {
    const cratesCount: number = parseInt(procedure[0], 10);
    const startStack: number = parseInt(procedure[1], 10) - 1;
    const endStack: number = parseInt(procedure[2], 10) - 1;

    const reverseStack: string[] = [...stackArray2[startStack]].reverse();

    let tempStack: string[] = [];

    for(let i: number = 0; i < cratesCount; i++){
        tempStack.push(reverseStack[i]);
        stackArray2[startStack].pop();
    }

    const inOrderTemp: string[] = tempStack.reverse();
    inOrderTemp.forEach(crate => stackArray2[endStack].push(crate));
    
});

topCrates = "";
stackArray2.forEach(crate => topCrates += crate[crate.length - 1]);
console.log(topCrates);