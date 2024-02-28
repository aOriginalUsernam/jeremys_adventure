public class Level1 : ILevel
{
    public string Name { get; set;} = "level1";
    public int[] Pos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public bool StartLevel(Player player)
    {
        Monster smoll_rat = new Monster("Smoll rat", 9, new int[] { 1, 3 }, 4);
        Monster weird_rat = new Monster("Weird rat", 30, new int[] { -2, 6 }, 7);
        Monster rat_king = new Monster("Rat king", 125, new int[] { 4, 7 }, 5);
        Monster rat_minion = new Monster("Rat minion", 28, new int[] { 0, 4 }, 6);
        int reputation = 0; // Weet niet of we dit gaan implementeren.
        string? choise_help_merchant = "";
        bool true_statement = true;


        Console.WriteLine("You have decided to go to the forest. There have been rumours going on about an amazing weapon hidden in this location");
        Console.WriteLine("At the entrance of the forest path you notice a pile of bottles on the ground with a sign next to them");
        Console.WriteLine("'Adventurer you might need these more than me if you find yourself going through these dangerous woods'");
        Item healing_potion = new Item("healing potion", 0, 0, 8, 5, true);
        player.Items.AddItem(healing_potion);
        Console.ReadLine();
        Console.WriteLine($"You received 5 {healing_potion.Name} from the pile!");
        Console.WriteLine("You walk into the forest but almost trip over something. You look down and...");
        Console.WriteLine("Suddenly you encounter a little rat blocking the way. Not a problem. Right? Good Luck!");
        Console.ReadLine();
        Console.WriteLine("");
        BattlePlayerVsMonster(player, smoll_rat);
        Console.WriteLine("Victory! Congrats");
        Console.WriteLine("After defeating the rat you hear someone screaming for help a bit further in the forest");

        Console.WriteLine("After a minute you arrive at the location");
        Console.WriteLine("You see a man under a tree with his hands around his ancle. It looks like he's hurt.");
        Console.WriteLine("Next to him you see a car with a bit of wares, you concludee that this man is a merchant.");
        Console.WriteLine("Do you want to help the merchant?");
        while (true_statement == true)
        {
            Console.WriteLine("Y/N");
            choise_help_merchant = Console.ReadLine();
            if (choise_help_merchant != null){
                string? choise_help_merchant1 = (choise_help_merchant);
            }
            if (choise_help_merchant == "Y")
            {
                reputation++; //idk
                Console.WriteLine("You decided to tend to this mans wounds.");
                Console.WriteLine("After a while ");
                Console.WriteLine("As thanks the merchant hands you something. It's a weapon... Kind.. of.");
                Console.WriteLine("Sorry my boy, but this rubber knife is the best I've got. I wish you the best of luck on this perilous journey");
                Item bad_knife = new Item("Rubber knife", 2, 4, 0, 1, false);
                player.Items.AddItem(bad_knife);
                Console.WriteLine($"You received a {bad_knife.Name} from the farmer!");
                Console.WriteLine("But be warned for the dangers beyond this point will something you would never be able to comprehend.");
                Console.ReadLine();
                true_statement = false;
                
            }
            else if (choise_help_merchant == "N")
            {
                Console.WriteLine("You hear the merchant curse you as you coldly ignore him.");
                true_statement = false;
            }
        }

        true_statement = true;
        Console.WriteLine("You walk further into the forest and encounter a split in the road.");
        Console.WriteLine("On the left there is a tree with 2 rats in front of it and on the right a chest with 3 rats");
        Console.WriteLine("Will you choose to go left, right or go straight ahead ignoring them both?");
        Console.WriteLine("(left), (right), (straight)");

        string? choise_split = Console.ReadLine();
        if (choise_split != null){
            string choise_split1 = choise_split;
        }
        
        while (true_statement == true)
        {

            if (choise_split == "right")
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine("You fight a rat");
                    Random rand = new Random();
                    if (rand.Next(2) == 0)
                    {
                        BattlePlayerVsMonster(player, smoll_rat);
                        Console.ReadLine();
                    }
                    else
                    {
                        BattlePlayerVsMonster(player, weird_rat);
                        Console.ReadLine();
                    }
                }
                Console.WriteLine("But when you go to fight the last minion you notice something off.");
                Console.WriteLine("This rat looks way stronger than the last two!! Prepare for a hefty battle.");
                Console.ReadLine();
                BattlePlayerVsMonster(player, rat_minion);
                Console.WriteLine("You look behind a tree and see a chest with a note and a knife in it.");
                Console.WriteLine("'Because you fought valiantly and with all your heart I bestow this gift on thee'");
                Item true_knife = new Item("True knife", 4, 7, 0, 1, false);
                player.Items.AddItem(true_knife);
                Console.WriteLine($"You received a {true_knife.Name} from the chest!");
                Console.ReadLine();
                true_statement = false;
            }

            else if (choise_split == "left")
            {
                BattlePlayerVsMonster(player, smoll_rat);
                Console.WriteLine("Beat the first rat");
                Console.ReadLine();
                BattlePlayerVsMonster(player, weird_rat);
                Console.WriteLine("Congratulations. You win!");
                Console.ReadLine();
                Item healing_potion2 = new Item("healing potion", 0, 0, 8, 2, true);
                player.Items.AddItem(healing_potion2);
                Console.WriteLine($"You received a {healing_potion.Name} from the tree!");
                Console.ReadLine();
                true_statement = false;
            }
            else if (choise_split == "straight")
            {
                Console.WriteLine("Suddenly out of nowhere a singular rat jumps onto you!");
                Random rand = new Random();
                if (rand.Next(2) == 0)
                {
                    BattlePlayerVsMonster(player, smoll_rat);
                }
                else
                {
                    BattlePlayerVsMonster(player, weird_rat);
                }
                true_statement = false;
            }
        }

        Console.ReadLine();
        Console.WriteLine("finally you come at the end of this long forest. At the end of the path lays a shrine");
        Console.WriteLine("In the middle of the shrine you notice a large chest almost beaming with light.");
        Console.WriteLine("You try to go and open the chest, but before you can...");
        Console.WriteLine("Two giant rats jump at you!! Prepare to battle.");
        Console.ReadLine();
        BattlePlayerVsMonster(player, rat_minion);

        Console.WriteLine("That's one");
        Console.ReadLine();
        BattlePlayerVsMonster(player, rat_minion);

        Console.WriteLine("The two rats are now defeated.");
        Console.WriteLine("You go to open the chest and find inside...");
        Console.WriteLine("A golden rubber duckie");
        Console.WriteLine("It gives you a huge power boost.");
        Item rubber_duckie = new Item("Rubber duckie", 5, 10, 0, 1, false);
        player.Items.AddItem(rubber_duckie);
        Console.ReadLine();

        Console.WriteLine("But before you know you get ambushed from behind");
        Console.WriteLine("The biggest rat you've ever seen stands behind you. This is it.");
        Console.ReadLine();
        BattlePlayerVsMonster(player, rat_king);
        Console.WriteLine("After a great battle you decide it's time to head back.");
        Console.ReadLine();

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