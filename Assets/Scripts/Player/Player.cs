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
