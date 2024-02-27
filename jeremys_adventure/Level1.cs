public class Level1 : ILevel
{
    public string Name { get; set; } = "home";
    public int[] Pos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public bool StartLevel(Player p)
    {
        System.Console.WriteLine("welcome back home");
        return true;
    }
}