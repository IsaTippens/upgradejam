using System.Collections.Generic;
namespace upgradejam;

public class ProjectileManager : Manager
{

    private static ProjectileManager instance;
    public static ProjectileManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ProjectileManager();
            }
            return instance;
        }
    }

    private List<Projectile> _projectilesToBeAdded;
    private List<Projectile> _projectiles;
    public ProjectileManager()
    {
        Drawable = true;
        _projectiles = new List<Projectile>();
        _projectilesToBeAdded = new List<Projectile>();
    }

    public override void Initialize()
    {
        base.Initialize();
    }
    public void AddProjectile(Projectile p)
    {
        _projectilesToBeAdded.Add(p);
    }
    public override void Update()
    {
        foreach (Projectile p in _projectilesToBeAdded)
        {
            p.Initialise();
            _projectiles.Add(p);
        }
        _projectilesToBeAdded.Clear();
        for (int i = 0; i < _projectiles.Count; i++)
        {
            Projectile p = _projectiles[i];
            if (p.Active)
            {
                p.Update();
            }

            if (p.LivedFor > p.Lifetime || !p.Active)
            {
                _projectiles.RemoveAt(i);
                p.Destroy();
                i--;
            }
        }
        base.Update();
    }

    public override void Render(SpriteBatch batch)
    {
        foreach (Projectile p in _projectiles)
        {
            p.Render(batch);
        }
        base.Render(batch);
    }
}