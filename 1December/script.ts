import {data} from "./input"

const {elves} = data;
let elvesArray: Array<number> = [];

let newNumber:string = "";

for(let i:number = 0; i < elves.length; i++){
    

    if(elves[i] === "\n"){
        
        elvesArray.push(Number(newNumber));
        newNumber = "";
    }
    else{
        newNumber += elves[i];
    }
}

let addedElves: Array<number> = [];
let counter = 0;
elvesArray.forEach(elf =>{

    if(elf === 0){
        counter++;
        return;
    }

    if(addedElves[counter] === undefined)
        addedElves[counter] = 0;
    

    addedElves[counter] += elf;
})

console.log(Math.max(...addedElves));

// get top 3
let top3ElvesSum: number = 0;

for(let i:number = 0; i < 3; i++){
    const currentMax = Math.max(...addedElves);
    const index = addedElves.findIndex(element => element === currentMax);
    addedElves.splice(index, 1);
    top3ElvesSum += currentMax;
}
console.log(top3ElvesSum);