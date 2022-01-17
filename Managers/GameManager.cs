namespace upgradejam;
public class GameManager : Manager
{
    public GameManager()
    {
    }

    public void Start()
    {
        Game1.plm.Start();
        Game1.em.Start();
        Console.WriteLine("Game Started");
    }
}