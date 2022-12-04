import {data} from "./input"

const {allPairs} = data;
const pairs:Array<string> = allPairs.split(/\r\n|\r|\n/);

let containCounter:number = 0;

pairs.forEach(pair =>{
    const onePair:Array<number> = pair.split(/,|-/).map(item => parseInt(item, 10));
    const lowerLeft:number = onePair[0], upperLeft:number = onePair[1];
    if(lowerLeft <= onePair[2] && upperLeft >= onePair[3] ||
         lowerLeft >= onePair[2] && upperLeft <= onePair[3]){
        containCounter++;
    }
});

console.log(containCounter);

// PART TWO