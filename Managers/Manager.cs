namespace upgradejam;

public abstract class Manager : IManager
{
    public bool Drawable {
        get;
        internal set;
    }

    public virtual void Initialize()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void Render(SpriteBatch batch)
    {

    }
}
