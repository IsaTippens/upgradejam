using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
namespace upgradejam;

public static class WeaponSounds
{
    public static Dictionary<string, SoundEffect> Sounds;
    static WeaponSounds()
    {
        Sounds = new Dictionary<string, SoundEffect>();
    }

    public static void LoadContent()
    {
        Sounds["RocketLaunch"] = Game1.GameContent.Load<SoundEffect>("soundfx/rocket_launch");
        Sounds["RocketLockOn"] = Game1.GameContent.Load<SoundEffect>("soundfx/lockon");
        Sounds["BulletLaunch"] = Game1.GameContent.Load<SoundEffect>("soundfx/bullet_launch");
        Sounds["BulletHit"] = Game1.GameContent.Load<SoundEffect>("soundfx/hitmarker");
        Sounds["PlaneExplode"] = Game1.GameContent.Load<SoundEffect>("soundfx/explosion");
    }
}