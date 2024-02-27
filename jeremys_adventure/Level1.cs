public class Level1 : ILevel
{
    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int[] Pos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public bool StartLevel()
    {
        Monster smoll_rat = new Monster("Smoll rat", 6, new int[] { 1, 3 }, 4);
        Monster rat_king = new Monster("Rat king", 25, new int[] { 2, 8 }, 5);
        Monster rat_minion = new Monster("Rat minion", 12, new int[] { 0, 4 }, 6);
        Player player = new Player("Jeremy", 75, new int[] { 1, 5 });
        int reputation = 0; // Weet niet of we dit gaan implementeren.
        string choise_help_merchant = "";

        Console.Writeline("You wake up early in the morning as excited as you'll ever be.");
        Console.writeline("You grab your clothes, pack your weapons, stash your items and prepare for this exciting day.");
        Console.writeline("'You are Jeremy. A new adventurer.'");
        Console.writeline("Jeremy is a brave little duckie who seeks for adventure and has always wanted to be the worlds most famous adventurer");
        Console.writeline("Filled with hope and ambition you run outside.");
        Console.writeline("You find yourself at the entrance of a forest. This is where your journey finally begins.");
        Console.writeline("Now hurry! Destiny awaits!");

        Console.writeline("");
        Console.writeline("");
        Console.writeline("");

        Console.writeline("You walk into the forest but almost trip over something. You look down and...");
        Console.writeline("Suddenly you encounter a little rat blocking the way. Not a problem. Right? Good Luck!");
        BattlePlayerVsMonster(player, smoll_rat);
        Console.WriteLine("Your first victory! Congrats");
        Console.WriteLine("After defeating the rat you hear someone screaming for help a bit further in the forest");

        Console.WriteLine("After a minute you arrive at the location");
        Console.WriteLine("You see a man under a tree with his hands around his ancle. It looks like he's hurt.");
        Console.WriteLine("Next to him you see a car with a bit of wares, you concludee that this man is a merchant.");
        Console.writeline("Do you want to help the merchant?");
        while (choise_help_merchant != "Y" || choise_help_merchant != "N")
        {
            Console.writeline("Y/N");
            string choise_help_merchant = Console.ReadLine();
            choise_help_merchant = choise_help_merchant.ToUpper();
        }
        if (choise_help_merchant == "Y")
        {
            reputation++; //idk
            Console.WriteLine("You decided to tend to this mans wounds.");
            Console.WriteLine("After a while ");
            Console.writeline("As thanks the merchant hands you something. It's a weapon... Kind.. of.");
            Console.writeline("Sorry my boy, but this rubber knife is the best I've got. I wish you the best of luck on this perilous journey");
            Item bad_knife = new Item("Rubber knife", 2, 4, 0, 1, false);
            if (inventory.AddItem(bad_knife))
            {
                Console.WriteLine($"You received a {bad_knife.Name} from the farmer!");
            }
            Console.WriteLine("But be waarned for the dangers beyond this point will something you would never be able to comprehend.");
            
        }
        else if (choise_help_merchant == "N")
        {
            Console.WriteLine("You hear the merchant curse you as you coldly ignore him.");
        }

        Console.WriteLine("You walk further into the forest and ");

        
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