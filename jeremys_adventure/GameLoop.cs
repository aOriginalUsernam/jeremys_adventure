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
            new level2(),
            null
        };

        //make map
        GameMap map = new GameMap(levels, 2, 2);

        // main game loop
        while (true)
        {

        }
    }
}