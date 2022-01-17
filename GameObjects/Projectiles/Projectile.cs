namespace upgradejam;

public class Projectile : Collidable
{
    public CollisionType CollisionType
    {
        get;
        protected set;
    }

    internal Sprite _sprite;
    internal float lifetime;

    public float Damage;
    public float Lifetime
    {
        get => lifetime;
    }

    internal float livedFor;
    public float LivedFor
    {
        get => livedFor;
    }

    public Sprite Sprite
    {
        get => _sprite;
        set
        {
            if (value.Texture != null)
            {
                SetBounds(value);
            }

            _sprite = value;
            _sprite.Parent = this;
        }
    }
    public float Speed
    {
        get;
        set;
    }

    public Vector2 Direction;
    public Projectile(CollisionType collisionType)
    {
        CollisionType = collisionType;     
        livedFor = 0f;
    }

    public Projectile() : this(CollisionType.Enemy)
    {
        Direction = new Vector2(0, -1);
    }

    public virtual void Hit()
    {

    }

    public override void Update()
    {
        livedFor += Time.DeltaTime;
        if (CollisionType == CollisionType.Enemy)
        {
            foreach (var e in Game1.em.Entities)
            {
                if (CollidesWith(e) && !e.isApproaching)
                {
                    e.DealDamage(Damage);
                    Hit();
                    Active = false;

                }
            }
        }

        base.Update();
    }

    ~Projectile()
    {
        _sprite.Destroy();
    }

}