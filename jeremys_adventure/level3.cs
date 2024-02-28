public class Level3 : ILevel
{
    public string Name { get; set; }
    public int[] Pos { get; set; }

    public Level3()
    {
        Name = "Desert";
        Pos = new int[] { 0, 0 };
    }

    public bool StartLevel(Player player)
    {
        Console.WriteLine($"Welcome to the {Name} level!");

        Console.WriteLine("You find yourself in the scorching desert.");
        Console.WriteLine("You see an oasis in the distance.");
        Console.WriteLine("Do you want to enter the Oasis? Y/N");
        string questChoice = (Console.ReadLine() ?? "").ToUpper();
        if (questChoice == "Y")
        {

            Console.WriteLine("As you approach the oasis, you encounter a group of bandits!");

            Monster bandit1 = new Monster("Bandit 1", 10, new int[] { 3, 6 }, 1);
            Monster bandit2 = new Monster("Bandit 2", 12, new int[] { 4, 7 }, 2);

            BattlePlayerVsMonster(player, bandit1);
            BattlePlayerVsMonster(player, bandit2);

            if (player.HP > 0)
            {
                Console.WriteLine("Congratulations! You defeated the bandits and found a treasure chest!");
                Console.WriteLine("You open the treasure chest and find valuable loot!");
            }
            else
            {
                Console.WriteLine("You were defeated by the bandits...");
                Console.WriteLine("The bandits take your belongings and leave you stranded in the desert...");
                return false;
            }

            Console.WriteLine("You arrive at the oasis, exhausted but victorious.");
            Console.WriteLine("You replenish your water supply and rest for a while.");
            Console.WriteLine("You've earned an item to fight monsters!");
            Console.WriteLine("* Poison added to inventory *");

            player.Items.AddItem(new Item("poison", 4, 1, 0, 1, false));

            return true;
        }
        else
        {
            Console.WriteLine("You decided not to enter the Oasis.");
            return false;
        }
    }

    private bool BattlePlayerVsMonster(Player player, Monster monster)
    {
        Console.WriteLine($"You encounter {monster.Name}");
        while (player.HP > 0 && monster.HP > 0)
        {
            int playerDamage = player.DoDamage();
            bool monsterDefeated = monster.TakeDamage(playerDamage);

            if (monsterDefeated)
            {
                Console.WriteLine($"You have defeated {monster.Name}");
                return true;
            }

            int monsterDamage = monster.DoDamage();
            bool playerDefeated = player.TakeDamage(monsterDamage);

            if (playerDefeated)
            {
                Console.WriteLine("The Monster defeated you");
                return false;
            }
        }
        return false;
    }
}
