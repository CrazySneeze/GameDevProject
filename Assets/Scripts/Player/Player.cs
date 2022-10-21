using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    Vector3 pos;
    Dictionary<Item, int> inventory;

    public Player(Vector3 pos)
    {
        this.pos = pos;
        this.inventory = new Dictionary<Item, int>();
    }

    public void addItem(Item item, int count)
    {
        if (!inventory.ContainsKey(item))
        {
            inventory.Add(item, count);
        }
        else
        {
            inventory[item] += count;
        }
    }

    public string invToStr()
    {
        string output = "";
        foreach (var a in inventory)
        {
            output += a.Key.Name + " " + a.Key.Description + " " + a.Value.ToString();
        }
        return output;
    }
}
