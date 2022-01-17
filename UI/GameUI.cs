using Apos.Gui;
namespace upgradejam;

public class GameUI : UI
{
    public GameUI() : base()
    {
    }

    public override void Update(GameTime gameTime)
    {
        var player = Game1.plm.Player;
        Panel.Push();
        
        Label.Put("Score: " + player.Score);
        var playerUpgrade = player.UpgradeMeter;
        var playerThreshold = player.UpgradeThreshold;
        var playerReady = player.UpgradeReady;
        string formattedValue = playerUpgrade.ToString("0") + "/" + playerThreshold;
        string message = "Upgrade Meter: " + (player.UpgradeReady ? "Ready! (Press SPACE to UPGRADE)" : formattedValue);
        Label.Put(message);
        Label.Put("Weapon: " + player.Weapon.Name);
        Panel.Pop();
        base.Update(gameTime);
    }
}