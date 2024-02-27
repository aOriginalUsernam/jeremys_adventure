class Monster : ICreature
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int HP { get; set; }
    public int[] DMG_range { get; set; }
    private Random Rand { get; set; } = new();
    public Monster(string name, int hp, int[] dmg_range, int id)
    {
        Name = name;
        HP = hp;
        DMG_range = dmg_range;
        ID = id;
    }

    public string GetStats()
    {
        return $"{Name}: {HP} HP, {DMG_range[0]} min DMG, {DMG_range[1]} max DMG";
    }

    public bool TakeDamage(int damage, int modif = 0)
    {
        if (modif >= damage) return true;
        this.HP -= damage - modif;
        return this.HP <= 0;
    }

    public int DoDamage(int modif = 0)
    {
        // does random damage in the DMG_range
        return Rand.Next(DMG_range[0], DMG_range[1]) + modif;
    }
}