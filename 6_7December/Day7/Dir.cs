namespace Day7;

public class Dir
{

    public string Name { get; set; }
    public Dir Parent { get; set; }
    public List<Tuple<string, int>> Files { get; set; }
    public List<Dir> Directories { get; set; }

    public Dir(string name, Dir parent = null)
    {
        this.Name = name;
        this.Parent = parent;
        this.Files = new List<Tuple<string, int>>();
        Directories = new List<Dir>();
    }

    public Dir()
    {
        this.Name = "temp";
    }


    public void AddDir(string name, Dir parent)
    {
        Dir temp = new Dir(name, parent);
        Directories.Add(temp);
    }

    public void AddFile(string name, int size)
    {
        this.Files.Add(new Tuple<string, int>(name, size));
    }

    public Dir FindDir(string name)
    {
        return Directories.Find(dir => dir.Name == name);
    }
}