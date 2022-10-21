using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public string ID;
    public string Name;
    public string Description;
    public string[] Tags;
    public int Count;
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        item = new Item(ID, Name, Description, Tags);
    }
}
