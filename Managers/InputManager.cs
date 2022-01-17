
namespace upgradejam;

public class InputManager : Manager
{
    KeyboardState oldState;
    KeyboardState newState;

    MouseState oldMouseState;
    MouseState newMouseState;



    private static InputManager instance;
    public static InputManager Instance {
        get {
            if (instance == null)
                instance = new InputManager();
            return instance;
        }
    }
    public InputManager()
    {
        oldState = Keyboard.GetState();
        newState = Keyboard.GetState();
        oldMouseState = Mouse.GetState();
        newMouseState = Mouse.GetState();

    }

    public override void Update() {
        oldState = newState;
        newState = Keyboard.GetState();

        oldMouseState = newMouseState;
        newMouseState = Mouse.GetState();
    }

    public bool IsKeyDown(Keys key) {
        return newState.IsKeyDown(key);
    }

    public bool IsKeyPressed(Keys key) {
        return newState.IsKeyDown(key) && oldState.IsKeyUp(key);
    }

    public bool IsKeyReleased(Keys key) {
        return newState.IsKeyUp(key) && oldState.IsKeyDown(key);
    }

    public bool IsKeyUp(Keys key) {
        return newState.IsKeyUp(key);
    }

    public bool IsMouseLeftDown() {
        return newMouseState.LeftButton == ButtonState.Pressed;
    }
}
