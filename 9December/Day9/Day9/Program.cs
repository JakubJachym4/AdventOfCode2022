using System.ComponentModel;
using System.Runtime.CompilerServices;
using Day9;
string[] inputFile = File.ReadAllLines(@"input.txt");
List<(char Direction, int Distance)> instructions = new();

foreach (var line in inputFile)
{
    string[] temp = line.Split(" ");
    instructions.Add((temp[0][0], Int32.Parse(temp[1]) ));
}
//PART ONE
 Head headOfRope = new Head(0, 0);
 Tail tailOfRope = new Tail(0, 0);
 tailOfRope.SetHead(headOfRope); // connect both ends
 headOfRope.SetTail(tailOfRope);



 foreach (var instruction in instructions)
 {
     headOfRope.Move(instruction.Direction, instruction.Distance);
 }


void Display()
{
    int fieldLength = instructions.Count;
    for (int i = 0; i < fieldLength; i++)
    {
        for (int j = 0; j < fieldLength; j++)
        {
            if(i == 0 && j == 0)
                Console.Write("S");
            else if(tailOfRope.VisitedPositions.Any(position => position.X == j && position.Y == i))
                Console.Write("#");
            else
                Console.Write(".");
        }
        Console.WriteLine();
    }
}


Console.WriteLine(tailOfRope.VisitedPositionsCount);

List<MarkedKnot> knotsList = new();
// PART TWO
for (int i = 0; i <= 9; i++)
{
    knotsList.Add(new MarkedKnot(0, 0, i));
 
}

for (int i = 0; i <= 9; i++)
{
    if (i > 0)
    {
        knotsList[i].HeadKnot = knotsList[i - 1];
    }
    if (i < 9)
    {
        knotsList[i].TailKnot = knotsList[i + 1];
    }
}

foreach (var instruction in instructions)
{
    knotsList[0].Move(instruction.Direction, instruction.Distance);
}
Console.WriteLine(knotsList[9].VisitedPositionsCount);




