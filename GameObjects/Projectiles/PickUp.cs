using System.Collections.Generic;
namespace upgradejam;

public class PickUp : Projectile
{
    public bool Scripted;
    public Weapon ScriptedWeapon;
    public PickUp(GameObject parent) : base(CollisionType.Player)
    {
        Active = true;
        Scripted = false;
        Direction = new Vector2(0, 1);
        Speed = 400f;
        var texture = Game1.GameContent.LoadTexture("textures/pickup");
        var s = new Sprite(texture);
        Scale = Vector2.One * 2f;
        Sprite = s;
        Position = parent.Position;
    }

    public override void Initialise()
    {
        lifetime = 20f;
        base.Initialise();
    }
    public Weapon RandomWeapon()
    {
        int numWeapons = 2;
        int randomWeapon = RNG.Next(0, numWeapons);
        var player = Game1.plm.Player;
        switch (randomWeapon)
        {
            case 0:
                return new Blaster(player);
            case 1:
                return new RocketLauncher(player);
            default:
                return new Blaster(player);
        }
    }

    public override void Update()
    {
        if (!Active)
        {
            return;
        }
        if (CollidesWith(Game1.plm.Player))
        {
            if (Scripted && ScriptedWeapon != null)
            {
                Game1.plm.Player.SwitchWeapon(ScriptedWeapon);
            }
            else
            {
                Game1.plm.Player.SwitchWeapon(RandomWeapon());
            }
            Active = false;
            Destroy();
        }

        Position += Direction * Speed * Time.DeltaTime;

        Sprite.Update();
        base.Update();
    }

    public override void Render(SpriteBatch batch)
    {
        Sprite.Render(batch);
    }

}