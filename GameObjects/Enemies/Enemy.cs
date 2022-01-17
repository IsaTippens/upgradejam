using Microsoft.Xna.Framework.Audio;
namespace upgradejam;

public class Enemy : Entity, IEnemy
{
    public bool HasPickup;
    public Vector2 StartingPosition;
    public Vector2 ApproachSpeed;

    private SoundEffect Explode;

    //Public enemy #1
    public Enemy() : base()
    {
        Explode = WeaponSounds.Sounds["PlaneExplode"];
    }
    public bool isApproaching;

    private bool givenPoints = false;
    protected float points;
    public float Points
    {
        get => points;
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Destroy()
    {
        if (Explode != null)
        {
            Explode.Play();
        }
        if (HasPickup)
        {
            Console.WriteLine("Deploying pickup");
            var pickup = new PickUp(this);
            if (Game1.em.CurrentWave == 3)
            {
                pickup.Scripted = true;
                pickup.ScriptedWeapon = new RocketLauncher(Game1.plm.Player);
            }
            pickup.Position = Position;
            Game1.pm.AddProjectile(pickup);
        }
        Game1.plm.Player.AddScore((int)Points);
        givenPoints = true;
        base.Destroy();
    }
}