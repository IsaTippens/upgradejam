namespace upgradejam;

public abstract class Weapon : IWeapon
{
    internal GameObject Parent;

    protected float shootSpeed;

    public float ShootSpeed
    {
        get
        {
            return shootSpeed;
        }
    }

    private string name;

    public string Name
    {
        get {
            if (name == null) {
                return "";
            }
            return name;
        }
        set => name = value;
    }

    public Weapon(GameObject parent) {
        Parent = parent;
        upgraded = false;
    }
    internal bool upgraded;
    public bool Upgraded
    {
        get => upgraded;
        set => upgraded = value;
    }
    public virtual void Shoot()
    {
        if (upgraded)
        {
            ShootUpgrade();
            return;
        }
        ShootNormal();
    }
    public virtual void ShootNormal()
    {

    }

    public virtual void ShootUpgrade()
    {

    }
}