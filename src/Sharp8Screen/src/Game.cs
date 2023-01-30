using SFML.System;
using SFML.Window;
using Sharp8Core;

namespace Sharp8Screen;

public class Game
{
    public const int FPS = 60;
    private readonly IChip8 _chip8;
    private readonly Screen _screen;
    private const int INSTRUCTIONS_PER_FRAME = 10;
    private bool _debug;
    private bool _waitingForDebugKey;
    public string[] DebugPoints { get; set; } = Array.Empty<string>();

    public Game()
    {
        _screen = new Screen();
        _chip8 = new Chip8(_screen, new Chip8Memory(), new Chip8Stack());
        _ = new Input(_screen.Window, _chip8.Input);
    }

    public void DebugWaitKeyPress()
    {
        _waitingForDebugKey = true;
        while (_waitingForDebugKey)
        {
            _screen.Window.WaitAndDispatchEvents();
        }
    }

    public void Run(string filename)
    {
        _chip8.LoadRom(File.ReadAllBytes(filename));
        _screen.Window.SetFramerateLimit(FPS);
        SetupDebugKeys();

        var clock = new Clock();

        while (_screen.Window.IsOpen)
        {
            Loop(clock);
        }
    }

    public void SetupDebugKeys()
    {
        _screen.Window.KeyReleased += new EventHandler<KeyEventArgs>(
            (sender, e) =>
            {
                if (e.Code == Keyboard.Key.F10)
                {
                    _waitingForDebugKey = false;
                }

                if (e.Code == Keyboard.Key.F5)
                {
                    _debug = !_debug;
                    _waitingForDebugKey = false;
                }
            }
        );
    }

    private void Loop(Clock clock)
    {
        _screen.Window.DispatchEvents();

        for (int i = 0; i < INSTRUCTIONS_PER_FRAME; i++)
        {
            ExecuteChip8Instruction();
        }

        _screen.Draw();
        _chip8.TickTimers();

        _ = clock.ElapsedTime;
        clock.Restart();
    }

    private void ExecuteChip8Instruction()
    {
        if (_debug)
        {
            DebugWaitKeyPress();
        }

        var chip8PCX4 = _chip8.ProgramCounter.ToString("X4");
        if (DebugPoints.Contains(chip8PCX4))
        {
            Console.WriteLine($"Debug point hit: {chip8PCX4}");
            _debug = true;
        }

        _chip8.ExecuteNextInstruction();
        // _chip8.PrintDebug();
    }
}
