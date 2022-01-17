namespace upgradejam;
    public interface IManager
    {
        bool Drawable {get;}
        void Initialize();
        void Update();
        void Render(SpriteBatch batch);
    }
;