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

Head headOfRope = new Head(0, 0);
Tail tailOfRope = new Tail(0, 0);
tailOfRope.SetHead(headOfRope);
headOfRope.SetTail(tailOfRope);

foreach (var instruction in instructions)
{
    headOfRope.Move(instruction.Direction, instruction.Distance);
}


int fieldLength = instructions.Count;

void Display()
{
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




