using Microsoft.Xna.Framework.Audio;
namespace upgradejam;

public class Bullet : Projectile
{
    SoundEffect se;
    SoundEffect hit;
    public Bullet(GameObject parent, Texture2D texture)
    {
        var s = new Sprite(texture);
        Scale = Vector2.One * 2f;
        Sprite = s;
        Speed = 450f;
        lifetime = 5f;
        Damage = 10;

        Position = parent.Position;
        se = WeaponSounds.Sounds["BulletLaunch"];
        hit = WeaponSounds.Sounds["BulletHit"];
    }

    public override void Initialise()
    {
        se.Play();
        base.Initialise();
    }

    public override void Hit()
    {
        hit.Play();
        base.Hit();
    }
    public override void Update()
    {
        if (!Active)
        {
            return;
        }
        Position += Direction * Speed * Time.DeltaTime;

        base.Update();
    }

    public override void Render(SpriteBatch batch)
    {
        Sprite.Render(batch);
    }
}