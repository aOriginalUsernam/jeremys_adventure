public class Inventory
{
    List<Item> Items = new();

    public int[] GetTotalMods()
    {
        int min_dmg = 0;
        int max_dmg = 0;
        int hp_mod = 0;
        foreach (Item item in Items)
        {
            if (item.Consumable)
            {
                continue;
            }

            min_dmg += item.MindmgMod * item.Amount;
            max_dmg += item.MaxdmgMod * item.Amount;
            hp_mod += item.HpMod * item.Amount;
        }
        return new int[] { min_dmg, max_dmg, hp_mod };
    }

    public List<Item> get_consumables()
    {
        List<Item> Consumables = new();

        foreach (Item item in Items)
        {
            if (item.Consumable)
            {
                Consumables.Add(item);
            }

        }
        return Consumables;
    }

    public bool RemoveItem(Item toFind)
    {
        if (toFind.Consumable)
        {
            foreach (var item in Items)
            {
                if (toFind.Name.Equals(item.Name))
                {
                    if (item.Amount > 1)
                    {
                        item.Amount -= 1;
                    }
                    else
                    {
                        Items.Remove(item);
                    }
                    return true;
                }
            }
            return false;
        }
        return false;
    }

    public bool AddItem(Item toAdd)
    {
        if (Items.Any(item => item.Name == toAdd.Name))
        {
            Item result = Items.Find(
            delegate (Item i)
            {
                return i.Name == toAdd.Name;
            }
            ) ?? throw new Exception("item not found");
            result.Amount++;
            return true;
        }

        Items.Add(toAdd);
        return true;
    }

    public void DisplayInventory()
    {
        Console.WriteLine("Items in Inventory");
        foreach (var item in Items)
        {
            Console.WriteLine($"Name: {item.Name},Amount: {item.Amount}, Consumable: {item.Consumable}");
        }
    }

    public int UseItem(string itemName)
    {
        Item? item = this.Items.Find(i => i.Name.ToLower() == itemName.ToLower());
        if (item != null)
        {
            if (item.Consumable)
            {
                int HP = item.HpMod;
                Items.Remove(item);
<<<<<<< HEAD
                Console.WriteLine($" You used an Item Health is now {HP}");
            }
            else
            {
                Monster.TakeDamage(item.MaxdmgMod);
                Items.Remove(item);
                Console.WriteLine($"You have used {item.Name} enemy took {item.MaxdmgMod} damage");

<<<<<<< HEAD
=======

>>>>>>> b1e4a69bdc5921255fe3634ab40a3b4077098a2b
            }
        }
        else
        {
            Console.WriteLine($"No item found {item.Name}");
        }
    }   
=======
                return HP;
            }
        }
        return 0;
    }
>>>>>>> ebcf0f65293954484fde08a4fa412dbec6a3d705



}

