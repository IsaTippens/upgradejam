namespace upgradejam;

public class GameObject 
{
    bool _active;
    public bool Active
    {
        get => _active;
        set
        {
            _active = value;
        }
    }
    public Vector2 Position;
    public float Rotation;
    public Vector2 Scale;

    public GameObject Parent;

    public GameObject()
    {
        Position = Vector2.Zero;
        Rotation = 0f;
        Scale = Vector2.One;
        _active = true;
    }

    public virtual void Initialise()
    {

    }

    public virtual void Start()
    {

    }

    public virtual void Destroy()
    {
        
    }

    public virtual void Update()
    {
    }

    public virtual void Render(SpriteBatch batch)
    {
    }
}