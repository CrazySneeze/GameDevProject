using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    Vector3 pos;
    public Dictionary<Item, int> inventory { get; set; }
    public List<Weapon> weapons { get; set; }

    public Player(Vector3 pos)
    {
        this.pos = pos;
        this.inventory = new Dictionary<Item, int>();
        this.weapons = new List<Weapon>();
    }

    public void addItem(Item item, int count)
    {
        foreach(var a in inventory.Keys)
        {
            if (a.Name == item.Name)
            {
                inventory[a] += count;
                return;
            }
        }

        inventory.Add(item, count);
    }

    public void addWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
    }

    public void removeItem(Item item, int count)
    {
        foreach (var a in inventory.Keys)
        {
            if (a.Name == item.Name)
            {
                if (count - inventory[a] <= 0)
                {
                    inventory.Remove(a);
                }
                else
                {
                    inventory[a] -= count;
                }
                return;
            }
        }
    }

    public string invToStr()
    {
        string output = "";
        foreach(var a in weapons)
        {
            output += a.Name + " " + a.Description + " " + a.Ammo + " " + a.Damage + "\n";
        }
        foreach (var a in inventory)
        {
            output += a.Key.Name + " " + a.Key.Description + " " + a.Value.ToString() + "\n";
        }
        return output;
    }
}
