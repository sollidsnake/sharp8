using SFML.Window;
using Sharp8Core;

namespace Sharp8Screen;

public class Input
{
    public bool[] Keys = new bool[16];
    public bool[] KeysPressed = new bool[16];
    public bool[] KeysReleased = new bool[16];
    private Chip8Input _input;
    private Window _window;

    public Input(Window window, Chip8Input input)
    {
        _window = window;
        _input = input;

        CreateEvents();
    }

    private void CreateKeysEvent(KeyEventArgs args, bool pressed)
    {
        switch (args.Code)
        {
            case Keyboard.Key.Num1:
                _input[0x1] = pressed;
                break;
            case Keyboard.Key.Num2:
                _input[0x2] = pressed;
                break;
            case Keyboard.Key.Num3:
                _input[0x3] = pressed;
                break;
            case Keyboard.Key.Num4:
                _input[0xC] = pressed;
                break;
            case Keyboard.Key.Q:
                _input[0x4] = pressed;
                break;
            case Keyboard.Key.W:
                _input[0x5] = pressed;
                break;
            case Keyboard.Key.E:
                _input[0x6] = pressed;
                break;
            case Keyboard.Key.R:
                _input[0xD] = pressed;
                break;
            case Keyboard.Key.A:
                _input[0x7] = pressed;
                break;
            case Keyboard.Key.S:
                _input[0x8] = pressed;
                break;
            case Keyboard.Key.D:
                _input[0x9] = pressed;
                break;
            case Keyboard.Key.F:
                _input[0xE] = pressed;
                break;
            case Keyboard.Key.Z:
                _input[0xA] = pressed;
                break;
            case Keyboard.Key.X:
                _input[0x0] = pressed;
                break;
            case Keyboard.Key.C:
                _input[0xB] = pressed;
                break;
            case Keyboard.Key.V:
                _input[0xF] = pressed;
                break;
        }
    }

    private void CreateEvents()
    {
        _window.KeyPressed += (sender, args) =>
        {
            CreateKeysEvent(args, true);
        };

        _window.KeyReleased += (sender, args) =>
        {
            CreateKeysEvent(args, false);
        };
    }

}
