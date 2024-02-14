class Player : ICreature
{
    public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int HP { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int[] DMG_range { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public int DoDamage(int modif = 0)
    {
        throw new NotImplementedException();
    }

    public string GetStats()
    {
        throw new NotImplementedException();
    }

    public bool TakeDamage(int damage, int modif = 0)
    {
        throw new NotImplementedException();
    }
}