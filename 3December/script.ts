import {data} from "./input"

const {rucksacks} = data;
const linesArray:Array<string> = rucksacks.split(/\r\n|\r|\n/);
let sharedCharacters:Array<string> = [];


linesArray.forEach(line =>{
    const halfOfLine = Math.floor(line.length/2);
    
    (function () {
        for (let i: number = 0; i < halfOfLine; i++) {
            for (let j: number = 0; j < line.length - halfOfLine; j++) {
                if (line[i] === line[j + halfOfLine]) {
                    //console.log(`i: ${i}, j: ${j + halfOfLine}`)
                    sharedCharacters.push(line[j + halfOfLine]);
                    return;
                }
            }
        }
    })();
});

const convertToPriority = (character: string) =>{
    if(character == character.toUpperCase()){
        return character.charCodeAt(0) - 64 + 26; // 64 === ("A" ASCII value) - 1
    }
    else{
        return character.charCodeAt(0) - 96; // 96 === ("a" ASCII value) - 1
    }
}

let priorityArray: Array<number> = [];
let sum:number = 0;
sharedCharacters.forEach(character => sum += convertToPriority(character)); 
console.log(sum);

// PART TWO
const secondSharedCharacters: Array<string> = [];

let linesCounter:number = 0;
let threeLines:Array<string> = [];
linesArray.forEach(oneLine => {
    linesCounter++;
    threeLines.push(oneLine);
    if(linesCounter % 3 === 0){
        monster();
        threeLines = [];
        linesCounter = 0; 
    }
})

function monster(): void{
    (() => {
        for (let i: number = 0; i < threeLines[0].length; i++) {
            for (let j: number = 0; j < threeLines[1].length; j++) {
                for(let k: number = 0; k < threeLines[2].length; k++){
                    if(threeLines[0][i] === threeLines[1][j] && threeLines[1][j] === threeLines[2][k]){
                        secondSharedCharacters.push(threeLines[0][i]);
                        return;
                    }
                }
            }
        }
    })();
}

let secondPriorityArray: Array<number> = [];
sum = 0;
secondSharedCharacters.forEach(character => sum += convertToPriority(character));

console.log(sum);