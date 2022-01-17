using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Apos.Gui;
using FontStashSharp;

namespace upgradejam
{
    public class Game1 : Game
    {
        private static GraphicsDeviceManager _graphics;

        private SpriteBatch _spriteBatch;

        private ManagerList _managers;

        private InputManager im;

        public static ProjectileManager pm;
        public static PlayerManager plm;

        public static GameManager gm;
        public static EnemyManager em;
        public static SceneManager sm;
        public static ContentManager GameContent;

        public static SoundEffect SE;

        public static UIManager uim;

        private int RefWidth;
        private int RefHeight;

        private IMGUI _ui;

        private static Game1 _instance
        {
            get;
            set;
        }
        public static Game1 Instance
        {
            get => _instance;
        }



        public Game1()
        {
            _instance = this;
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _managers = new ManagerList();
            _managers.Add(new BackgroundManager());
            gm = _managers.Add(new GameManager());
            im = _managers.Add(InputManager.Instance);
            pm = _managers.Add(ProjectileManager.Instance);
            sm = _managers.Add(new SceneManager());
            plm = _managers.Add(new PlayerManager());
            em =_managers.Add(new EnemyManager());
            uim = _managers.Add(new UIManager());

            GameContent = Content;

            RefWidth = 1280;
            RefHeight = 720;


        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = RefWidth;
            _graphics.PreferredBackBufferHeight = RefHeight;
            _graphics.ApplyChanges();

            base.Initialize();
            ScreenUtil.Width = RefWidth;
            ScreenUtil.Height = RefHeight;
            Window.Title = "Intergalatic SpaceShooter";

            _managers.Initialize();
            uim.Add<MenuUI>();
            uim.Add<TestUI>();
            uim.Add<GameUI>();

        }

        public void SetTitle(string title)
        {
            Window.Title = title;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            WeaponSounds.LoadContent();
            var song = Content.Load<Song>("music/loopy");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
            // TODO: use this.Content to load your game content here
            FontSystem fontSystem = FontSystemFactory.Create(GraphicsDevice, 2048, 2048);
            fontSystem.AddFont(TitleContainer.OpenStream($"{Content.RootDirectory}/fonts/Roboto-Regular.ttf"));
            GuiHelper.Setup(this, fontSystem);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Time.Update(gameTime);
            _managers.Update();

            


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _managers.Render(_spriteBatch);
            _spriteBatch.End();

            uim.Render(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
