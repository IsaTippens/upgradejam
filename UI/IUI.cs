namespace upgradejam;

public interface IUI
{
    void Initialize();
    void Update(GameTime gameTime);
    void Render(GameTime gameTime);
}