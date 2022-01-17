namespace upgradejam;

public class SceneManager : Manager
{
    public SceneManager()
    {
        Drawable = true;
    }

    public override void Initialize()
    {
        Console.WriteLine("Scene Manager Initialised");
        base.Initialize();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Render(SpriteBatch batch)
    {
        base.Render(batch);
    }
}