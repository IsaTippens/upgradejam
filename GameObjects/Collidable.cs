namespace upgradejam;

public class Collidable : GameObject
{
    public bool CollisionEnabled = true;
    private Vector2 _size;

    private Vector2 _origin;
    public Vector2 Size
    {
        get => _size;
        set => _size = value;
    }

    public float Width 
    {
        get => _size.X;
        set => _size.X = value;
    }

    public float Height
    {
        get => _size.Y;
        set => _size.Y = value;
    }

    public Vector2 SetOrigin(float x, float y)
    {
        _origin = new Vector2(x, y);
        return _origin;
    }
    public Vector2 SetBounds(Vector2 size)
    {
        _size = size;
        SetOrigin(size.X / 2, size.Y / 2);
        return _size;
    }

    public Vector2 SetBounds(float width, float height)
    {
        return SetBounds(new Vector2(width, height));
    }

    public Vector2 SetBounds(float length)
    {
        return SetBounds(length, length);
    }
    public Vector2 SetBounds(Sprite sprite)
    {
        _origin = sprite.Origin;
        var s = new Vector2(sprite.Texture.Width, sprite.Texture.Height);
        _size = s;
        return _size;
    }

    public bool CollidesWith(Collidable other)
    {
        if (!CollisionEnabled || !other.CollisionEnabled)
        {
            return false;
        }
        //Thanks copilot for this code
        //AABB collision
        var a = Position - other.Position;
        var b = _size + other._size;
        return Math.Abs(a.X) < b.X && Math.Abs(a.Y) < b.Y;

        

    }


}