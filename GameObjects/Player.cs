namespace upgradejam;

public class Player : Entity
{
    Weapon weapon;

    public Weapon Weapon
    {
        get => weapon;
    }

    public bool Upgraded
    {
        get => weapon.Upgraded;
        private set => weapon.Upgraded = value;
    }

    public bool UpgradeReady
    {
        get => upgradeMeter >= upgradeThreshold;
    }

    private float upgradeThreshold;

    public float UpgradeThreshold
    {
        get => upgradeThreshold;
    }
    private float upgradeMeter;

    public float UpgradeMeter
    {
        get => upgradeMeter;
        set
        {
            upgradeMeter = value;
            if (upgradeMeter > upgradeThreshold)
            {
                upgradeMeter = upgradeThreshold;
            }
        }
    }

    private float upgradeUsage;
    public int Score;
    float time = 0f;

    public float Speed
    {
        get;
        set;
    }
    public Player()
    {
        var s = new Sprite(Game1.GameContent.LoadTexture("textures/spaceship"));
        Scale = Vector2.One * 2f;
        Sprite = s;
        Speed = 700f;
        Health = 100f;
        weapon = new Blaster(this);
        upgradeUsage = 10f;
        upgradeMeter = 0f;
        upgradeThreshold = 150f;
    }

    public void SwitchWeapon(Weapon w)
    {
        if (w.GetType() == weapon.GetType())
        {
            AddScore(1000, false);
            return;
        }
        if (Upgraded)
        {
            upgradeMeter = 0f;
            upgradeThreshold = 500f;
        }
        weapon = w;
    }

    public void AddScore(int points, bool enemyDestroyed = true)
    {
        
        if (!Upgraded && enemyDestroyed)
        {
            UpgradeMeter += points;
        }
        else 
        {
            points *= 2;
        }
        Score += points;
    }
    public override void Update()
    {
        if (InputManager.Instance.IsKeyDown(Keys.A))
        {
            Position.X -= Speed * Time.DeltaTime;
        }
        if (InputManager.Instance.IsKeyDown(Keys.D))
        {
            Position.X += Speed * Time.DeltaTime;
        }

        if (Position.X < 0)
        {
            Position.X = 0;
        }
        if (Position.X > ScreenUtil.Width)
        {
            Position.X = ScreenUtil.Width;
        }

        if (Upgraded)
        {
            upgradeMeter -= Time.DeltaTime * (upgradeThreshold / 10);
            if (upgradeMeter <= 0f)
            {
                upgradeMeter = 0f;
                Upgraded = false;
                upgradeThreshold = 500f;
            }
        }

        if (InputManager.Instance.IsKeyPressed(Keys.Space))
        {
            if (upgradeMeter >= upgradeThreshold)
            {
                Upgraded = true;
            }

        }


        if (InputManager.Instance.IsMouseLeftDown() && time <= 0f)
        {
            time = weapon.ShootSpeed;
            weapon.Shoot();
        }

        if (time > 0f)
        {
            time -= Time.DeltaTime;
        }
        base.Update();

    }

    public override void Render(SpriteBatch batch)
    {
        Sprite.Render(batch);
        base.Render(batch);
    }


}