using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    Vector3 pos;
    Dictionary<Item, int> inventory;

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
}
