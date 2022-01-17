namespace upgradejam;
public class ScreenUtil
{
    struct Screen
    {
        public int Width;
        public int Height;
    }
    static Screen _screen;
    public static int Width
    {
        get => _screen.Width;
        set => _screen.Width = value;
    }
    public static int Height
    {
        get => _screen.Height;
        set => _screen.Height = value;
    }
}