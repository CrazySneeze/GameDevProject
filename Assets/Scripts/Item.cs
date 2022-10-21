public class Item
{
    private string _ID;
    private string _Name;
    private string _Description;

    public Item (string ID, string Name, string Description)
    {
        this._ID = ID;
        this._Name = Name;
        this._Description = Description;
    }

    public string ID
    {
        get { return _ID; }

        set { this._ID = value; }
    }
    public string Name
    {
        get { return _Name; }

        set { this._Name = value; }
    }
    public string Description
    {
        get { return _Description; }

        set { this._Description = value; }
    }
}
