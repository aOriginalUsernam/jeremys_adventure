public class Level2 : ILevel
{
    private Inventory inventory = new Inventory();

    public string Name { get; set; }
    public int[] Pos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public Level2()
    {
        Name = "12 charsLong";
    }
    public bool StartLevel(Player player)
    {
        Console.WriteLine("You walk past a farmhouse with a farmer.");
        Console.WriteLine("Would you want to accept his quest? (Y/N)");
        bool snakeQuest = false;
        int snakeCount = 0;
        string questChoice = (Console.ReadLine() ?? "").ToUpper();

        Monster snake1 = new Monster("Baby Snek", 5, new int[] { 0, 5 }, 1);
        Monster snake2 = new Monster("Cobra", 7, new int[] { 0, 3 }, 2);
        Monster snake3 = new Monster("King Cobra", 10, new int[] { 0, 5 }, 3);

        if (questChoice == "Y")
        {
            Console.WriteLine("You accepted the quest to kill 3 snakes.");
            snakeQuest = true;
        }
        else
        {
            Console.WriteLine("You declined the quest because you're lazy at the moment.");
        }

        while (snakeQuest)
        {
            int snakesLeft = 3 - snakeCount;
            while (snakesLeft > 0)
            {
                Console.WriteLine($"You have to kill {snakesLeft} more snakes.");

                Console.WriteLine("You head into the snake field. Where do you want to go? (UP/DOWN/LEFT/RIGHT)");
                string direction = (Console.ReadLine() ?? "").ToUpper();

                if (direction == "UP" || direction == "DOWN" || direction == "LEFT" || direction == "RIGHT")
                {
                    Random rand = new Random();
                    if (rand.Next(2) == 0)
                    {
                        Console.WriteLine("You head deeper into the grass field.");
                    }
                    else
                    {
                        Console.WriteLine("You found a snake.");
                        Console.WriteLine("You will battle it now.");
                        if (snakesLeft == 3)
                        {
                            BattlePlayerVsMonster(player, snake1);
                        }
                        else if (snakesLeft == 2)
                        {
                            BattlePlayerVsMonster(player, snake2);
                        }
                        else if (snakesLeft == 1)
                        {
                            BattlePlayerVsMonster(player, snake3);
                        }
                        snakeCount++;
                    }
                }
            }
            snakeQuest = false; //Klaar met quest
            Console.WriteLine("You finished the quest and went back to the old farmer.");
            Item reward = new Item("Wooden stick", 1, 1, 0, 1, false);
            if (inventory.AddItem(reward)) // Ik hoop dat het adden zo werkt.
            {
                Console.WriteLine($"You received a {reward.Name} from the farmer!");
            }
        }
        return true;
    }

    static void BattlePlayerVsMonster(Player player, Monster monster)
    {
        Console.WriteLine($"You encounter a {monster.Name} with {monster.HP} HP.");
        while (player.HP > 0 && monster.HP > 0)
        {
            Console.WriteLine($"You hit the {monster.Name}");
            monster.TakeDamage(player.DoDamage());
            Console.WriteLine($"The {monster.Name} has {monster.HP} HP left.");

            if (monster.HP <= 0)
            {
                Console.WriteLine($"You defeated the {monster.Name}!");
                break;
            }

            Console.WriteLine($"The {monster.Name} attacks you!");
            player.TakeDamage(monster.DoDamage());
            Console.WriteLine($"You have {player.HP} HP left.");

            if (player.HP <= 0)
            {
                Console.WriteLine($"You died fighting the {monster.Name}.");
                break;
            }
        }
    }
}
