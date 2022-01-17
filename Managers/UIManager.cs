using System.Collections.Generic;
using Apos.Gui;
using FontStashSharp;
using Microsoft.Xna.Framework.Content;

namespace upgradejam;

public class UIManager : Manager
{
    private List<UI> _uis;

    private GraphicsDevice _device;
    private ContentManager _content;
    private Game1 _game;

    private IMGUI _ui;

    public IMGUI Ui
    {
        get => _ui;
    }

    private int current;

    public int CurrentUi
    {
        get => current;
        set
        {
            if (value >= _uis.Count || value < 0)
            {
                current = -1;
            }
            else
            {
                current = value;
            }
        }
    }

    public UIManager()
    {
        _uis = new List<UI>();
        current = 0;
        
        _ui = new IMGUI();
        GuiHelper.CurrentIMGUI = _ui;
    }

    public override void Initialize()
    {
         _game = Game1.Instance;
        _device = _game.GraphicsDevice;
        _content = _game.Content;
       
        base.Initialize();
    }

    public void Add<T>() where T : UI, new()
    {
        _uis.Add(new T());
    }

    public override void Update()
    {

        GuiHelper.UpdateSetup();
        _ui.UpdateAll(Time.GameTime);
        if (current != -1 && _uis.Count > 0)
        {
            _uis[current].Update(Time.GameTime);
        }
        GuiHelper.UpdateCleanup();
        base.Update();
    }

    public override void Render(SpriteBatch batch)
    {
        _ui.Draw(Time.GameTime);
        base.Render(batch);
    }
}