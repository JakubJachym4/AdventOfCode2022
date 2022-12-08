string text = File.ReadAllText(@"input.txt");
string[] treeArray = text.Split("\r\n");
List<char[]> treeMap = new();
List<string> indexes = new();
List<char[]> treeMapCol = new();
int treesCount = 0;


for (int i = 0; i < treeArray.Length; i++)
{
    treeMap.Add(treeArray[i].ToCharArray());
}

int index = 0;
foreach (var row in treeArray)
{
    char[] tempArr = new char[treeArray.Length];
    for (int i = 0; i < row.Length; i++)
    {
        tempArr[i] = treeArray[i][index];
       
    }
    index++;
    treeMapCol.Add(tempArr);
}




for (int i = 0; i < treeMapCol.Count; i++)
{
    int height = -1;
    for (int j = 0; j < treeMap[i].Length; j++)
    {
        int thisHeight = treeMap[i][j] - '0';
        if (thisHeight > height)
        {
            height = thisHeight;
            if(indexes.Exists(item =>
               {
                   string[] values = item.Split(":");
                   return Int32.Parse(values[0]) == i && Int32.Parse(values[1]) == j;
               })) continue;
            treesCount++;
            indexes.Add($"{i}:{j}");
        }
    }
    //reverse
    height = -1;
    for (int j = treeMap[i].Length - 1; j >= 0; j--)
    {
        int thisHeight = treeMap[i][j] - '0';
        if (thisHeight > height)
        {
            height = thisHeight;
            if (indexes.Exists(item =>
                {
                    string[] values = item.Split(":");
                    return Int32.Parse(values[0]) == i && Int32.Parse(values[1]) == j;
                }))
            {
                j = 0;
                continue;
            }
            treesCount++;
            indexes.Add($"{i}:{j}");
        }
    }
}

for (int i = 0; i < treeMapCol.Count; i++)
{
    int height = -1;
    for (int j = 0; j < treeMapCol[i].Length; j++)
    {
        int thisHeight = treeMapCol[i][j] - '0';
        if (thisHeight > height || (thisHeight == 0 && height == 0))
        {
            height = thisHeight;
            if(indexes.Exists(item =>
               {
                   string[] values = item.Split(":");
                   return Int32.Parse(values[0]) == j && Int32.Parse(values[1]) == i;
               })) continue;
            treesCount++;
            indexes.Add($"{j}:{i}");
        }
    }
    //reverse
    height = -1;
    for (int j = treeMapCol[i].Length - 1; j >= 0; j--)
    {
        int thisHeight = treeMapCol[i][j] - '0';
        if (thisHeight > height)
        {
            height = thisHeight;
            if (indexes.Exists(item =>
                {
                    string[] values = item.Split(":");
                    return Int32.Parse(values[0]) == j && Int32.Parse(values[1]) == i;
                }))
            {
                continue;
            }
            treesCount++;
            indexes.Add($"{j}:{i}");
        }
    }
}

// foreach (var tree in indexes)
// {
//     Console.WriteLine(tree);
// }
Console.WriteLine($"Trees count: {treesCount}");