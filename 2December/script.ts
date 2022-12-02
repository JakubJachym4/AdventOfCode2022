import {data} from "./input";

const {guide} = data;
const values = {
    rock: 1,
    paper: 2,
    scissors: 3
}
const outcome = {
    win: 6,
    draw: 3,
    loss: 0
}

let totalScore:number = 0;
let ultraTotalScore:number = 0;
let temp:string ="";

for(let i:number = 0; i <guide.length; i++){
    if(guide[i] !== " " && guide[i] !== "\n"){
        if(temp === ""){
            temp = guide[i];
        }
        else{
            compareShapes(temp, guide[i]);
            ultraCompareShapes(temp, guide[i]);
            temp = "";
        }
    }
}

function compareShapes(opponent:string, you:string){
    if(opponent === "A"){
        if(you === "X")
            totalScore += values.rock + outcome.draw;
        else if(you === "Y")
            totalScore += values.paper + outcome.win;
        else
            totalScore +=  values.scissors + outcome.loss;
    }
    else if(opponent === "B"){
        if(you === "Y")
            totalScore += values.paper + outcome.draw;
        else if(you === "Z")
            totalScore += values.scissors + outcome.win;
        else
            totalScore += values.rock + outcome.loss;
    }
    else if(opponent === "C"){
        if(you === "Z")
            totalScore += values.scissors + outcome.draw;
        else if(you === "X")
            totalScore += values.rock + outcome.win;
        else
            totalScore += values.paper + outcome.loss;
    }
    else{
        console.log(`wyjebalo | opponent: ${opponent} | you: ${you}`);
    }
}

console.log(`Total score: ${totalScore}`);

function ultraCompareShapes(opponent: string, you: string){
    if(you === "X"){
        if(opponent === "A")
            ultraTotalScore += values.scissors + outcome.loss;
        else if(opponent === "B")
            ultraTotalScore += values.rock + outcome.loss;
         else
            ultraTotalScore += values.paper + outcome.loss;
    }
    else if(you === "Y"){
        if(opponent === "A")
            ultraTotalScore += values.rock + outcome.draw;
        else if(opponent === "B")
            ultraTotalScore += values.paper + outcome.draw;
        else
            ultraTotalScore += values.scissors + outcome.draw;
    }
    else if(you === "Z"){
        if(opponent === "A")
            ultraTotalScore += values.paper + outcome.win;
        else if(opponent === "B")
            ultraTotalScore += values.scissors + outcome.win;
        else
            ultraTotalScore += values.rock + outcome.win;
    }
    else{
        console.log(`wyjebalo | opponent: ${opponent} | you: ${you}`);
    }
}

console.log(`Ultra total score: ${ultraTotalScore}`);