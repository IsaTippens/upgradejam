namespace upgradejam;

public class Entity : Collidable
{

    float health;
    public float Health
    {
        get => health;
        set => health = value;
    }

    private Sprite _sprite;
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
    public Entity()
    {
        health = 100f;
        invinsibilityTime = 0f;
    }

    float invinsibilityTime;

    public override void Update()
    {   
        if (health <= 0f)
        {
            Active = false;
        }
        if (invinsibilityTime > 0f)
        {
            invinsibilityTime -= Time.DeltaTime;
        }
        base.Update();
    }

    public void DealDamage(float damage)
    {
        if (invinsibilityTime <= 0f)
        {
            health -= damage;
            invinsibilityTime = 0.01f;
        }
    }
}