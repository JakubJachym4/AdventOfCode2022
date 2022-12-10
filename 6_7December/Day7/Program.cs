using Day7;

string PATH = @"input.txt";

int counter = 0;
Dir root = new Dir("/");
Dir temp = root;
foreach (string line in File.ReadLines(@"input.txt"))
{
    if (line[0] == '$')
    {
        string command = line.Substring(2, 2);
        if (command == "ls")
        {
            HandleLs();
        }
        else if (command == "cd")
        {
            string commandSubject = line.Substring(5);
            if (commandSubject == "..")
            {
                temp = temp.Parent;
            }
            else if (commandSubject == "/")
            {
                temp = root;
            }
            else
            {
                temp = temp.FindDir(commandSubject);
            }
        }
    }

    counter++;
}

void HandleLs()
{
    using (StreamReader text = new StreamReader(PATH))
    {
        for (int i = 0; i <= counter; i++)   //get to the current line
        {
            text.ReadLine();
        }
        
        while (true)
        {
            string? line = text.ReadLine();
            if(line == null)
                return;
            if (line[0] == '$')
            {
                return;
            }

            string firstCharacters = line.Substring(0, 3);
            if (firstCharacters == "dir")
            {
                temp.AddDir(line.Substring(4), temp);
            }
            else
            {
                string[] fileData = line.Split(" ");
                temp.AddFile(fileData[1], Int32.Parse(fileData[0]));
            }
            
        }
    }
}

int realSum = 0;
List<int> dirSizes = new();

int FindTotalSize(Dir directory, int sum)
{
    foreach (var file in directory.Files)
    {
        sum += file.Item2;
    }

    foreach (var dir in directory.Directories)
    {
        int foundSize = FindTotalSize(dir, 0);
        sum += foundSize;
        
        if (foundSize <= 100000)
        {
            realSum += foundSize;
        }
    }


    dirSizes.Add(sum);
    return sum;
}

int totalSum = FindTotalSize(root, 0);


// PART TWO
int unusedSize = 70000000 - totalSum;
//Console.WriteLine(unusedSize);
const int neededSize = 30000000;

var results = dirSizes.FindAll(dirSize => dirSize + unusedSize >= neededSize);
Console.WriteLine(results.Min());