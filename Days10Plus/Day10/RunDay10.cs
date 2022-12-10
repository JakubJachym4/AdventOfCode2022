using System.Collections;
namespace Day10;
public static class PartOne
{
    
    public static void Run(string[] lines)
    {
        string[,] output = new string[6,40];
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 40; j++)
            {
                output[i, j] = "0";
            }
        }
        int answer = 0;
        int x = 1;
        int cycle = -1; // = 0 for part one

        foreach (var line in lines)
        {
            
            var instruction = line.Split(" ");
            if (instruction.Length < 2)
            {
                cycle++;
                output[cycle / 40, cycle % 40] = Math.Abs(x - (cycle % 40)) <= 1 ? "#" : ".";
                if (cycle % 40 == 20)
                {
                    Console.WriteLine(x + " " + cycle + " " + line);
                    answer += x * cycle;
                }
            }
            else
            {
                cycle++;
                output[cycle / 40, cycle % 40] = Math.Abs(x - (cycle % 40)) <= 1 ? "#" : ".";
                if (cycle % 40 == 20)
                {
                    Console.WriteLine(x + " " + cycle + " " + line);
                    answer += x * cycle;
                }

                cycle++;
                output[cycle / 40, cycle % 40] = Math.Abs(x - (cycle % 40)) <= 1 ? "#" : ".";
                if (cycle % 40 == 20)
                {
                    Console.WriteLine(x + " " + cycle + " " + line);
                    answer += x * cycle;
                }

                x += int.Parse(instruction[1]);
            }
        }
        Console.WriteLine(answer);
        PrintOutput(output);
    }

    private static void PrintOutput(string[,] output)
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 40; j++)
            {
                Console.Write(output[i,j]);
            }
            Console.Write("\r\n");
        }
    }

    
}