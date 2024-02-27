using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

class GameLoop
{
    public static void StartGame()
    {
        // create variables
        // make player
        System.Console.WriteLine("what is ur name?: ");
        string name = Console.ReadLine() ?? "jeremy";
        Player player = new(name, 15, new int[] { 4, 7 }, 0);

        // make levels
        List<ILevel?> levels = new()
        {
            new Level1(),
            null,
            new Level2(),
            null
        };

        //make map
        GameMap map = new GameMap(levels, 2, 2);

        // main game loop
        while (true)
        {
            System.Console.WriteLine("map:/n");
            map.PrintMap();

            //move in map
            bool moved = false;
            while (!moved)
            {
                System.Console.WriteLine("move (N/E/S/W)");
                switch (Console.ReadLine())
                {
                    case "N":
                        moved = map.MoveTo(GameMap.Direction.UP);
                        break;
                    case "E":
                        moved = map.MoveTo(GameMap.Direction.RIGHT);
                        break;
                    case "S":
                        moved = map.MoveTo(GameMap.Direction.DOWN);
                        break;
                    case "W":
                        moved = map.MoveTo(GameMap.Direction.LEFT);
                        break;
                    default:
                        System.Console.WriteLine("invalid input");
                        break;
                }
            }

            //start level
            bool isAlive = true;
            ILevel? level = map.GetCurrentLevel();
            if (level != null)
            {
                isAlive = level.StartLevel();
            }
            else
            {
                System.Console.WriteLine("nothing here...");
            }
            if (!isAlive)
            {
                System.Console.WriteLine("you are dead. skill issue");
                break;
            }
        }
    }
}