class GameLoop
{
    public static void StartGame()
    {
        // create variables
        // make player
        System.Console.WriteLine("what is ur name?: ");
        string name = Console.ReadLine() ?? "jeremy";
        System.Console.WriteLine("nice to meet you. your name sucks, so now it is Jeremy...");
        Player player = new Player("Jeremy", 50, new int[] { 0, 8 }, 0);

        Console.WriteLine("You wake up early in the morning as excited as you'll ever be.");
        Console.WriteLine("You grab your clothes, pack your weapons, stash your items and prepare for this exciting day.");
        Console.WriteLine("'You are Jeremy. A new adventurer.'");
        Console.WriteLine("Jeremy is a brave little duckie who seeks for adventure and has always wanted to be the worlds most famous adventurer");
        Console.WriteLine("Filled with hope and ambition you run outside.");
        Console.WriteLine("This is where your journey finally begins.");
        Console.WriteLine("Now hurry! Destiny awaits!");

        // make levels
        List<ILevel?> levels = new()
        {
            null,
            new Level1(),
            new Level2(),
            new Level3()
        };

        //make map
        GameMap map = new GameMap(levels, 2, 2);

        // main game loop
        while (true)
        {


            //move in map
            bool moved = false;
            while (!moved)
            {
                System.Console.WriteLine("map:\n");
                map.PrintMap();
                System.Console.WriteLine("move (N/E/S/W) (I voor inventory)");
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
                    case "I":
                        System.Console.WriteLine(player.GetStats());
                        player.Items.DisplayInventory();
                        break;
                    default:
                        System.Console.WriteLine("invalid input");
                        break;
                }
                if (!moved)
                {
                    System.Console.WriteLine("can not go there");
                }
            }

            //start level
            bool isAlive = true;
            ILevel? level = map.GetCurrentLevel();
            if (level != null)
            {
                isAlive = level.StartLevel(player);
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