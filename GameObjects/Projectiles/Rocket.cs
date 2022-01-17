using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
namespace upgradejam;

public class Rocket : Projectile
{
    Entity Target;
    public bool Upgraded;
    SoundEffectInstance RocketSound;
    SoundEffectInstance RocketLockOnSound;

    float aliveFor;
    public Rocket(GameObject parent, Texture2D texture)
    {
        var s = new Sprite(texture);
        Scale = Vector2.One * 2f;
        Sprite = s;
        Speed = 300f;
        lifetime = 10f;
        Damage = 40;
        Upgraded = false;
        Target = null;
        aliveFor = 0f;

        Position = parent.Position;
        var rl = WeaponSounds.Sounds["RocketLaunch"];
        var rlo = WeaponSounds.Sounds["RocketLockOn"];
        RocketSound = rl.CreateInstance();
        RocketLockOnSound = rlo.CreateInstance();
    }

    public override void Initialise()
    {
        if (Upgraded)
        {
            Speed = 200f;
        }
        RocketSound.Play();
        base.Initialise();
    }

    public override void Update()
    {
        if (!Active)
        {
            return;
        }
        aliveFor += Time.DeltaTime;
        if (aliveFor > 0.6f && ((Upgraded && Target == null) || (Target != null && !Target.Active)))
        {
            bool entityFound = false;
            float dist = float.MaxValue;
            foreach (var e in Game1.em.Entities)
            {
                if (!e.Active)
                {
                    continue;
                }
                var temp = Vector2.Distance(Position, e.Position);
                if (temp < dist)
                {
                    entityFound = true;
                    dist = temp;
                    Target = e;
                }
            }
            if (entityFound)
            {
                Speed = 500f;
                RocketLockOnSound.Play();
            }

        }

        if (Target != null && Target.Active)
        {
            Direction = Vector2.Normalize(Target.Position - Position);
            Rotation = (float)Math.Atan2(Direction.Y, Direction.X) + (float)Math.PI / 2;
        }
        Position += Direction * Speed * Time.DeltaTime;

        base.Update();
    }

    public override void Render(SpriteBatch batch)
    {
        Sprite.Render(batch);
    }
}