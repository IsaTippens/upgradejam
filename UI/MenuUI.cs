using Apos.Gui;
namespace upgradejam;

public class MenuUI : UI
{
    public MenuUI() : base()
    {
    }
    public override void Update(GameTime gameTime)
    {
        Panel.Push().XY = new Vector2(ScreenUtil.Width / 2 - 100, ScreenUtil.Height / 2 - 100);
        var startButton = Button.Put("Start");
        startButton.IsFocusable = false;

        if (startButton.Clicked)
        {
            Game1.Instance.SetTitle("ecs good");
            Game1.gm.Start();
            Game1.uim.CurrentUi = 2;
        }
        if (Button.Put("Instructions").Clicked)
        {
            Game1.uim.CurrentUi = 1;
        }
        Panel.Pop();
        base.Update(gameTime);
    }
}