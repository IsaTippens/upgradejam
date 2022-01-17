namespace upgradejam;

public class PlayerManager : Manager
{
    Player player;
    

    public Player Player { get => player; }

    
    bool _started;

    public bool Started
    {
        get => _started;
    }



    int lives;
    public PlayerManager()
    {
        _started = false;
        Drawable = true;
    }

    public void Start()
    {
        _started = true;
    }

    public override void Initialize()
    {
        player = new Player();
        player.Position = new Vector2(ScreenUtil.Width / 2, ScreenUtil.Height - player.Sprite.Origin.Y / 2f - 64f);
        Console.WriteLine("Player Manager Initialised");
        lives = 3;
        base.Initialize();
    }

    public override void Update()
    {
        if (_started)
        {
            player.Update();
        }
        base.Update();
    }

    public override void Render(SpriteBatch batch)
    {
        player.Render(batch);
        base.Render(batch);
    }
}