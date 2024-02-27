public interface ILevel
{
    string Name {get; set;}
    public int[2] Pos {get; set;}
    // public list<Choice> Choices
    public bool StartLevel();

}