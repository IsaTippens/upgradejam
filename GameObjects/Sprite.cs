namespace upgradejam;

public class Sprite : GameObject, IDisposable
{

    private Texture2D _sprite;

    private Vector2 _origin;

    public Vector2 Origin
    {
        get => _origin;
    }

    public Texture2D Texture
    {
        get
        {
            return _sprite;
        }
        set
        {
            _sprite = value;
        }
    }

    public Color Color;
    public Sprite(Texture2D texture) : base()
    {
        _sprite = texture;
        _origin = new Vector2(texture.Width / 2, texture.Height / 2);
        Color = Color.White;
    }

    public override void Update()
    {
    }

    public override void Render(SpriteBatch batch)
    {
        if (_sprite == null)
        {
            return;
        }
        var pos = Position;
        var sca = Scale;
        var rot = Rotation;
        if (Parent != null)
        {
            pos += Parent.Position;
            sca *= Parent.Scale;
            rot += Parent.Rotation;
        }
        batch.Draw(_sprite, pos, null, Color, rot, _origin, sca, SpriteEffects.None, 0);
    }

    public void Dispose()
    {
        _sprite.Dispose();
    }
}