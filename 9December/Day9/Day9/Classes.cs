namespace Day9;

public class Coordinates
{
    public int X { get; set; }
    public int Y { get; set; }

    public Coordinates(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public void SetCords(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    protected Coordinates()
    {
        this.X = 0;
        this.Y = 0;
    }

    public (int X, int Y) Position()
    {
        return (this.X, this.Y);
    }
}

public class Head : Coordinates
{
    public Coordinates LastPosition { get; set; }
    private Tail? AttachedTail { get; set; }
    public Head(int x, int y)
    {
        this.X = x;
        this.Y = y;
        LastPosition = new Coordinates(x, y);
    }

    public void SetTail(Tail newTail)
    {
        this.AttachedTail = newTail;
    }
    public void Move(char direction, int distance)
    {
        
        for(int i = 0; i < distance; i++)
        {
            LastPosition.SetCords(this.X, this.Y);
            switch (direction)
            {
                case 'U':
                    MoveUp();
                    break;
            
                case 'D':
                    MoveDown();
                    break;
                case 'R':
                    MoveRight();
                    break;
                case 'L':
                    MoveLeft();
                    break;
            }
            AttachedTail.FollowHead();
        }
        
    }

    private void MoveUp()
    {
        this.Y++;
    }
    private void MoveDown()
    {
        this.Y--;
    }
    private void MoveRight()
    {
        this.X++;
    }
    private void MoveLeft()
    {
        this.X--;
    }
}

public class Tail : Coordinates
{
    private Head? AttachedHead { get; set; }
    public List<(int X, int Y)> VisitedPositions { get; set; }
    public int VisitedPositionsCount { get; set; } = 0;
    
    public Tail(int x, int y)
    {
        this.X = x;
        this.Y = y;
        VisitedPositions = new();
        VisitedPositions.Add((0, 0));
        VisitedPositionsCount++;
    }

    public void SetHead(Head newHead)
    {
        this.AttachedHead = newHead;
    }
    public bool IsNextTo()
    {
        (int X, int Y) calcAbsPath;
        calcAbsPath.X = Math.Abs(AttachedHead.X - this.X);
        calcAbsPath.Y = Math.Abs(AttachedHead.Y - this.Y);
        return calcAbsPath is { X: <= 1, Y: <= 1 };
    }

    public void FollowHead()
    {
        if(IsNextTo() == true)
            return;
        var lastHeadPosition = AttachedHead.LastPosition;
        this.X = lastHeadPosition.X;
        this.Y = lastHeadPosition.Y;
        if (HasVisited() == false)
        {
            VisitedPositions.Add((this.X, this.Y));
            VisitedPositionsCount++;
        }
    }
    
    public bool HasVisited()
    {
        return VisitedPositions.Any(pos =>
            pos.X == this.X && pos.Y == this.Y);
    }
}