namespace Day9;

public class MarkedKnot : Tail
{
    public int Number {get; set;}
    public virtual MarkedKnot? HeadKnot { get; set; }
    public MarkedKnot? TailKnot { get; set; }
    public Coordinates LastPosition { get; set; }
    
    public MarkedKnot(int x, int y, int number) : base(x, y)
    {
        this.Number = number;
        this.LastPosition = new(x, y);

    }

    public void SetKnots(MarkedKnot headKnot, MarkedKnot tailKnot)
    {
        this.HeadKnot = headKnot;
        this.TailKnot = tailKnot;
    }

    public int NextToDistance()
    {
        (int X, int Y) calcAbsPath;
        calcAbsPath.X = Math.Abs(HeadKnot.X - this.X);
        calcAbsPath.Y = Math.Abs(HeadKnot.Y - this.Y);
        if (calcAbsPath is { X: <= 1, Y: <= 1 })
            return 1;
        else if (calcAbsPath is { X: >= 2, Y: >= 2 })
            return 2;
        else if (calcAbsPath is { Y: >= 2 })
            return 3;
        else if (calcAbsPath is { X: >= 2 })
            return 4;
        
        return 0;
    }
    
    public override void FollowHead()
    {
        var lastHeadPosition = HeadKnot.LastPosition;
        int result = NextToDistance();
        if (result == 1)
        {
            return;
        }
        else if (result == 2)
        {
            if (this.Y < HeadKnot.Y)
                this.Y = HeadKnot.Y - 1;
            else
                this.Y = HeadKnot.X + 1;
            
            if (this.X < HeadKnot.X)
                this.X = HeadKnot.X - 1;
            else
                this.X = HeadKnot.X + 1;
        }
        else if (result == 3)
        {
            this.X = HeadKnot.X;
            if (this.Y < HeadKnot.Y)
                this.Y = HeadKnot.Y - 1;
            else
                this.Y = HeadKnot.Y + 1;

        }
        else if (result == 4)
        {
            this.Y = HeadKnot.Y;
            if (this.X < HeadKnot.X)
                this.X = HeadKnot.X - 1;
            else
                this.X = HeadKnot.X + 1;

        }
        
        this.LastPosition.X = this.X;
        this.LastPosition.Y = this.Y;
        
        
        if (HasVisited() == false)
        {
            VisitedPositions.Add((this.X, this.Y));
            VisitedPositionsCount++;
        }
        if(this.Number != 9)
            TailKnot.FollowHead();
    }
    
    protected override bool HasVisited()
    {
        return this.VisitedPositions.Any(pos =>
            pos.X == this.X && pos.Y == this.Y);
    }
    public void Move(char direction, int distance)
    {
        for (int i = 0; i < distance; i++)
        {
            LastPosition.SetCords(this.X, this.Y);
            switch (direction)
            {
                case 'U':
                    this.Y++;
                    break;
                case 'D':
                    this.Y--;
                    break;
                case 'R':
                    this.X++;
                    break;
                case 'L':
                    this.X--;
                    break;
            }

            TailKnot.FollowHead();
        }
    }
}