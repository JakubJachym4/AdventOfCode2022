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
sharedCharacters.forEach(character => priorityArray.push(convertToPriority(character))); 
let sum:number = 0;
priorityArray.forEach(priority => sum += priority);


console.log(sum);