namespace upgradejam;

public class RocketLauncher : Weapon
{
    Texture2D bulletTexture;
    public RocketLauncher(GameObject parent) : base(parent)
    {
        bulletTexture = Game1.GameContent.LoadTexture("textures/rocket");
        shootSpeed = 0.6f;
        Name = "Rocket Launcher";
    }

    public override void ShootNormal()
    {
        shootSpeed = 0.45f;
        Rocket b = new Rocket(this.Parent, bulletTexture);
        Game1.pm.AddProjectile(b);
    }

    public override void ShootUpgrade()
    {
        shootSpeed = 0.3f;
        Rocket b = new Rocket(this.Parent, bulletTexture);
        b.Upgraded = true;
        Game1.pm.AddProjectile(b);
    }
}