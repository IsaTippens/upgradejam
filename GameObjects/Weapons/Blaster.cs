namespace upgradejam;

public class Blaster : Weapon
{
    Texture2D bulletTexture;
    public Blaster(GameObject parent) : base(parent)
    {
        bulletTexture = Game1.GameContent.LoadTexture("textures/bullet");
        shootSpeed = 0.1f;
        Name = "Blaster";
    }

    public override void ShootNormal()
    {
        Bullet b = new Bullet(this.Parent, bulletTexture);
        Game1.pm.AddProjectile(b);
    }

    public override void ShootUpgrade()
    {
        for (int i = -1; i < 2; i++)
        {
            Bullet b = new Bullet(this.Parent, bulletTexture);
            b.Direction = new Vector2(i, -1);
            Game1.pm.AddProjectile(b);
        }
    }
}