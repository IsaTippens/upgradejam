using Apos.Gui;
namespace upgradejam;

public class TestUI : UI
{
    public TestUI() : base()
    {
    }

    public override void Update(GameTime gameTime)
    {
        Panel.Push().XY = new Vector2(ScreenUtil.Width / 2 - 100, ScreenUtil.Height / 2 - 200);
        Label.Put("You are Pilot");
        Label.Put("Use A and D to move left and right");
        Label.Put("Press Left mouse button to shoot");
        Label.Put("Press Spacebar to upgrade weapon");
        Label.Put("Press Alt + f4 to exit");
        if (Button.Put("Go Back!").Clicked)
        {
            Game1.uim.CurrentUi = 0;
        }
        Panel.Pop();
        base.Update(gameTime);
    }

}