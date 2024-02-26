using System.Data;
using System.Text;

public class GameMap
{
    public List<List<ILevel?>> Levels_2d { get; private set; }
    private static Random Rand = new();
    public int CurrentX { get; private set; }
    public int CurrentY { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }
    public enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }
    public interface ILevel
    {
        public string Name { get; set; }
    }

    public GameMap(List<ILevel?> levels, int width, int height)
    {
        this.CurrentX = 0;
        this.CurrentY = 0;
        this.Width = width;
        this.Height = height;
        Levels_2d = GenerateMap(levels, width, height);

    }
    private List<List<ILevel?>> GenerateMap(List<ILevel?> levels, int width, int height)
    {
        List<List<ILevel?>> toReturn = new();
        int y = 0;
        int index = 0;
        while (y < height)
        {
            int x = 0;
            List<ILevel?> row = new();
            while (x < width)
            {
                try
                {
                    row.Add(levels[index]);
                    index++;
                }
                catch { row.Add(null); }
                x++;
            }
            toReturn.Add(row);
            y++;
        }
        return toReturn;
    }
    // MoveTo tries to move to next pos (true if succes, else false and pos is the same)
    public bool MoveTo(Direction toGoTo)
    {
        switch (toGoTo)
        {
            case Direction.LEFT:
                if (CurrentX > 0)
                {
                    CurrentX--;
                    return true;
                }
                return false;
            case Direction.RIGHT:
                if (CurrentX >= Width)
                {
                    CurrentX++;
                    return true;
                }
                return false;
            case Direction.UP:
                if (CurrentY > 0)
                {
                    CurrentX--;
                    return true;
                }
                return false;
            case Direction.DOWN:
                if (CurrentY <= Height)
                {
                    CurrentX++;
                    return true;
                }
                return false;
            default:
                return false;
        }
    }

    // returnes current level
    public ILevel? GetCurrentLevel()
    {
        return Levels_2d[CurrentY][CurrentX];
    }

    public void PrintMap()
    {
        for (int y = 0; y < this.Height; y++)
        {
            StringBuilder toPrint = new();
            for (int x = 0; x < this.Width; x++)
            {
                ILevel? lv = Levels_2d[y][x];
                if (x == this.CurrentX && y == this.CurrentY)
                {
                    toPrint.Append("[you're here!]");
                }
                else if (lv != null)
                {
                    toPrint.Append($"[{lv.Name}]");
                }
                else
                {
                    toPrint.Append("[ nothing? ]");
                }
            }
            Console.WriteLine(toPrint);
        }
    }
}