public interface ILevel
{
    string Name { get; set; }
    public int[] Pos { get; set; }
    // public list<Choice> Choices
    public bool StartLevel();

}