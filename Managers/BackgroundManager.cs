using System.Collections.Generic;

namespace upgradejam;

public class BackgroundManager : Manager
{
    Texture2D background;

    List<Sprite> sprites;
    List<Sprite> rocks;
    List<Sprite> islands;

    int maxClouds = 15;
    List<Sprite> clouds;

    public BackgroundManager()
    {
        Drawable = true;
        sprites = new List<Sprite>();
    }

    public override void Initialize()
    {
        background = Game1.GameContent.LoadTexture("textures/water");
        int height = ScreenUtil.Height / background.Height + 2;
        int width = ScreenUtil.Width / background.Width + 1;
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                var s = new Sprite(background);
                s.Position = new Vector2(j * background.Width, i * background.Height - background.Height);
                s.Color = Color.DarkGray;
                sprites.Add(s);
            }
        }

        createClouds();

        base.Initialize();
    }

    Texture2D RandomCloud()
    {
        int num = RNG.Next(0, 3);
        switch (num)
        {
            case 0:
                return Game1.GameContent.LoadTexture("textures/cloud");
            case 1:
                return Game1.GameContent.LoadTexture("textures/cloud1");
            case 2:
                return Game1.GameContent.LoadTexture("textures/cloud2");
            default:
                return Game1.GameContent.LoadTexture("textures/cloud");
        }
    }
    Sprite createCloud()
    {
        var s = new Sprite(RandomCloud());
        var scale = RNG.Next(1f, 1.5f);
        s.Position = new Vector2(RNG.Next(0, ScreenUtil.Width), RNG.Next(0, ScreenUtil.Height));
        s.Scale = new Vector2(scale, scale);
        s.Color = Color.WhiteSmoke;
        return s;
    }

    void createClouds()
    {
        clouds = new List<Sprite>();
        for (int i = 0; i < maxClouds; i++)
        {
            clouds.Add(createCloud());
        }
    }

    float targetSpeed = 250f;
    float scrollSpeed = 250f;
    public override void Update()
    {
        if (Game1.plm.Player.Upgraded)
        {
            targetSpeed = 600f;
        }
        else
        {
            targetSpeed = 250f;
        }
        if (scrollSpeed != targetSpeed)
        {
            scrollSpeed = MathHelper.Lerp(scrollSpeed, targetSpeed, Time.DeltaTime);
        }
        foreach (var s in sprites)
        {
            s.Position.Y += scrollSpeed * Time.DeltaTime;
            if (s.Position.Y + background.Height / 2f >= ScreenUtil.Height + background.Height)
            {
                s.Position.Y = -background.Height;
            }
        }

        for (int i = 0; i < clouds.Count; i++)
        {
            var c = clouds[i];
            c.Color = Color.DarkGray;
            c.Position.Y += (scrollSpeed * (1f / c.Scale.Length())) * Time.DeltaTime;
            if (c.Position.Y + background.Height / 2f >= ScreenUtil.Height + background.Height)
            {
                clouds.RemoveAt(i);
                var cloud = createCloud();
                cloud.Position.Y = -cloud.Texture.Height * cloud.Scale.Y;
                clouds.Add(cloud);
            }
        }
        base.Update();
    }

    public override void Render(SpriteBatch batch)
    {
        foreach (var s in sprites)
        {
            s.Render(batch);
        }

        foreach (var s in clouds)
        {
            s.Render(batch);
        }
        base.Render(batch);
    }
}