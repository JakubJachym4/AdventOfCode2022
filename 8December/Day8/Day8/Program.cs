string text = File.ReadAllText(@"inputTest.txt");
string[] rowsArray = text.Split("\r\n");
string[] columnsArray = new string[rowsArray.Length];
int visibleTrees = 0;
visibleTrees += (rowsArray.Length * 2) +  (rowsArray[0].Length * 2) - 4;

foreach (var row in rowsArray)
{
    int allTrees = CheckRowVisibility(row, 0, 0, 0, 0);
    int index = 0;
    foreach (var c in row)
    {
        columnsArray[index] += c;
        index++;
    }
}

foreach (var column in columnsArray)
{
    int allTrees = CheckRowVisibility(column, 0, 0, 0, 0);
    Console.WriteLine(allTrees);
}

int CheckRowVisibility(string row, int index, int height, int totalTrees, int theHighestIndex)
{
    int thisHeight = row[index] - '0';
    if (thisHeight > height)
    {
        height = thisHeight;

        theHighestIndex = index;
        if (index != 0 && index != row.Length - 1)
            totalTrees++;
    }
    else
    {
        if (thisHeight == height)
            theHighestIndex = index;
        index++;
        if (index > row.Length - 1 || thisHeight == 9)
            return totalTrees + CheckRowVisibilityReverse(row, row.Length - 1, 0, 0, theHighestIndex);
    }
    totalTrees = CheckRowVisibility(row, index, height, totalTrees, theHighestIndex);
    
    return totalTrees;
}

int CheckRowVisibilityReverse(string row, int index, int height, int totalTrees, int theHighestIndex)
{
    int thisHeight = row[index] - '0';
    if (thisHeight > height)
    {
        height = thisHeight;
        if (index != 0 && index != row.Length - 1)
            totalTrees++;
    }
    else
    {
        index--;
        if (index < 0 || index == theHighestIndex)
            return totalTrees;
    }

    totalTrees = CheckRowVisibilityReverse(row, index, height, totalTrees, theHighestIndex);
    return totalTrees;
}
// am i overcomplicating it? sure. is it worth it? no.