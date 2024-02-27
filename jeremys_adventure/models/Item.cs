public class Item(string Name, int MindmgMod, int MaxdmgMod, int HpMod, int Amount, bool Consumable)
{
    public string Name { get; set; } = Name;
    public int MindmgMod { get; set; } = MindmgMod;
    public int MaxdmgMod { get; set; } = MaxdmgMod;
    public int HpMod { get; set; } = HpMod;
    public int Amount { get; set; } = Amount;
    public bool Consumable { get; set; } = Consumable;



    private Inventory AllItems()
    {
        Inventory inv = new();
        Item knife = new Item("knife", 5, 10, 0, 1, false);
        Item HealthPotion = new Item("Health Potion", 0, 0, 20, 1, true);
        Item Poison = new Item("Poison", 100, 100, 0, 1, false);
        Item EneryBar = new Item("Energy Bar", 0, 0, 10, 2, true);
        Item sword = new Item("Sword", 20, 30, 0, 1, false);
        Item SpaceGun = new Item("Space Gun", 1, 80, 0, 1, false);
        Item apple = new Item("Apple", 0, 0, 15, 1, true);

        inv.AddItem(knife);
        inv.AddItem(HealthPotion);
        inv.AddItem(Poison);
        inv.AddItem(EneryBar);
        inv.AddItem(sword);
        inv.AddItem(SpaceGun);
        inv.AddItem(apple);
        return inv;
    }


}