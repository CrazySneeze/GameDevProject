public class Item
{
    protected string _ID;
    protected string _Name;
    protected string _Description;
    protected string[] _Tags;

    public Item (string ID, string Name, string Description, string[] tags)
    {
        _ID = ID;
        _Name = Name;
        _Description = Description;
        _Tags = tags;
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

    public string[] Tags
    {
        get { return _Tags; }
        set { this._Tags = value; }
    }
}

public class Weapon : Item
{
    private int _Damage;
    private string _Ammo;
    public Weapon(string ID, string Name, string Description, string[] tags, int damage, string ammo) : base(ID, Name, Description, tags)
    {
        _ID = ID;
        _Name = Name;
        _Description = Description;
        _Tags = tags;
        _Damage = damage;
        _Ammo = ammo;
    }

    public int Damage
    {
        get { return _Damage; }
        set { this._Damage = value; }
    }

    public string Ammo
    {
        get { return _Ammo; }
        set { this._Ammo = value; }
    }
}
