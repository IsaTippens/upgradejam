namespace upgradejam;

public class Time
{
    public static float DeltaTime { get; private set; }
    public static float TotalTime { get; private set; }

    public static GameTime GameTime { get; private set; }

    public static void Update(GameTime gameTime)
    {
        DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        TotalTime += DeltaTime;
        GameTime = gameTime;
    }

}