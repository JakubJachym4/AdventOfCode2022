string text = File.ReadAllText(@"input.txt");
//Console.WriteLine(text);

// pre-run config
List<char> markerCache = new List<char> {text[0], text[1], text[2], text[3]};

for (int i = 3; i < text.Length - 1; i++)
{
    if (markerCache.Distinct().Count() == markerCache.Count())
    {
        Console.WriteLine(i); // i = 
        break;
    }
    if(i == 3)
        continue;
    
    markerCache.RemoveAt(0);
    markerCache.Add(text[i]);
}

// PART TWO

markerCache = new();
for (int i = 0; i < 14; i++)
{
    markerCache.Add(text[i]);
}
for (int i = 13; i < text.Length - 1; i++)
{
    if (markerCache.Distinct().Count() == markerCache.Count())
    {
        Console.WriteLine(i); // i = 
        break;
    }
    if(i == 13)
        continue;
    
    markerCache.RemoveAt(0);
    markerCache.Add(text[i]);
}