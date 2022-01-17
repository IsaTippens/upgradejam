
using System.Collections.Generic;

namespace upgradejam;

public class EnemyManager : Manager
{
    List<Enemy> _enemies;

    int wave;
    public int CurrentWave
    {
        get => wave;
    }
    bool waveStarted;
    public List<Enemy> Entities
    {
        get => _enemies;
    }
    public EnemyManager()
    {
        Drawable = true;
        _enemies = new List<Enemy>();
        wave = 0;
        waveStarted = false;

    }

    public void Reset()
    {
        _enemies.Clear();
        wave = 1;
        waveStarted = false;
    }

    public void Start()
    {
        Reset();
        waveStarted = true;
        CreateWave();
    }

    public void CreateWave()
    {
        bool createdPickup = false;
        for (int i = 0; i < wave; i++)
        {
            MeQuestionMark e = new MeQuestionMark();
            e.Position = new Vector2(RNG.Next(ScreenUtil.Width / 10f, ScreenUtil.Width * 9f / 10f), -RNG.Next(50f, 500f));
            e.StartingPosition = new Vector2(RNG.Next(ScreenUtil.Width / 10f, ScreenUtil.Width * 9f / 10f), RNG.Next(50f, 400f));
            if (!createdPickup && wave > 2)
            {
                if (wave == 3) {
                    e.HasPickup = true;
                    createdPickup = true;
                } else {
                    e.HasPickup = RNG.Next(0, 100) > 50;
                    createdPickup = true;
                }
            }
            AddEnemy(e);
        }
    }

    public override void Initialize()
    {
        Console.WriteLine("Enemy Manager Initialised");
        base.Initialize();
    }

    public void AddEnemy(Enemy e)
    {
        e.Initialise();
        _enemies.Add(e);
    }

    public void AddEnemy<T>() where T : Enemy, new()
    {
        T e = new T();
        _enemies.Add(e);
    }

    public override void Update()
    {
        if (waveStarted)
        {
            if (Entities.Count == 0)
            {
                wave++;
                CreateWave();
            }
        }
        for (int i = 0; i < Entities.Count; i++)
        {
            Entity e = Entities[i];
            e.Update();
            if (!e.Active || e.Health <= 0f)
            {
                e.Destroy();
                Entities.RemoveAt(i);
                i--;
            }
        }
        base.Update();
    }

    public override void Render(SpriteBatch batch)
    {
        foreach (Entity e in Entities)
        {
            e.Render(batch);
        }
        base.Render(batch);
    }
}