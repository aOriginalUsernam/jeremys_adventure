public interface ICreature
{
    public int ID { get; set; }
    public int HP { get; set; }
    public int[] DMG_range { get; set; }

    public bool TakeDamage(int damage);

    public string GetStats();
    public int DoDamage(int modif = 0);
}