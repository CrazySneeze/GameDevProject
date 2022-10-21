using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Player
{
    Vector3 pos;
    Dictionary<Item, int> inventory;
    Dictionary<Weapon, int> weapons;

    public Player(Vector3 pos)
    {
        this.pos = pos;
        this.inventory = new Dictionary<Item, int>();
        this.weapons = new Dictionary<Weapon, int>();
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

    public void addWeapon(Weapon weapon, int count)
    {
        foreach (var a in weapons.Keys)
        {
            if (a.Name == weapon.Name)
            {
                weapons[a] += count;
                return;
            }
        }

        weapons.Add(weapon, count);
    }
    public string invToStr()
    {
        string output = "";
        foreach(var a in weapons)
        {
            output += a.Key.Name + " " + a.Key.Description + " " + a.Key.Ammo + " " + a.Key.Damage + " " + a.Value.ToString() + "\n";
        }
        foreach (var a in inventory)
        {
            output += a.Key.Name + " " + a.Key.Description + " " + a.Value.ToString() + "\n";
        }
        return output;
    }
}
