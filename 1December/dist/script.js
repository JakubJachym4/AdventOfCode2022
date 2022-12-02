"use strict";
exports.__esModule = true;
var input_1 = require("./input");
var elves = input_1.data.elves;
var elvesArray = [0];
for (var i = 1; i < 50; i++) {
    var newNumber = "";
    if (elves[i] === "\n") {
        elvesArray.push(parseInt(newNumber));
        newNumber = "";
    }
    else {
        newNumber += elves[i];
    }
}
elvesArray.map(function (elve) { return console.log(elve); });
