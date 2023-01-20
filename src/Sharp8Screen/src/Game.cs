using System.Diagnostics;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Sharp8Core.Screen;
using Sharp8Core;
using Sharp8Core.RomReader;
using Sharp8Core.Instructions;

namespace Sharp8Screen;

public class Screen : Chip8Screen
{
    public const float FPS = 1000f / 60;
    private readonly Vector2i _scale = new Vector2i(16, 16);
    private readonly Chip8RomReader _romReader;
    private Chip8Memory _memory;
    private Chip8 _chip8;
    private RenderWindow _window;

    public Screen(Chip8 chip8, Chip8Memory memory, Chip8RomReader romReader)
    {
        _romReader = romReader;
        _chip8 = chip8;
        _memory = memory;
        _window = CreateWindow();
    }

    private static void OnClose(object sender, EventArgs e)
    {
        ((RenderWindow)sender).Close();
    }

    public void RunRomFile(string filename)
    {
        _memory.LoadInstructions(_romReader.Read(filename));

        MainLoop();
    }

    private void MainLoop()
    {
        Clock clock = new Clock();
        var shape = new CircleShape(100);
        Stopwatch stopwatch = new Stopwatch();

        while (_window.IsOpen)
        {
            stopwatch.Restart();

            WindowLoop(_window);

            // ExecuteInstruction();

            _window.Display();

            float fps = Clock(stopwatch);

            // Console.WriteLine(fps);
        }
    }

    private void ClearScreen()
    {
        _window.Clear();
    }

    private void ExecuteInstruction()
    {
        var instruction = _chip8.ReadInstruction().Item2;

        switch (instruction)
        {
            case InstructionManager.ClearScreen:
                ClearScreen();
                break;
        }
    }

    private RenderWindow CreateWindow()
    {
        return new RenderWindow(
            new VideoMode(
                (uint)Size.X * (uint)_scale.X,
                (uint)Size.Y * (uint)_scale.X
            ),
            "Sharp8!"
        );
    }

    private void DrawSquare(int unscaledX, int unscaledY)
    {
        var x = unscaledX * _scale.X;
        var y = unscaledY * _scale.Y;

        var vertex = new VertexArray(PrimitiveType.LineStrip, 5);
        vertex[0] = new Vertex(new Vector2f(x, y));
        vertex[1] = new Vertex(new Vector2f(x + _scale.X, y));
        vertex[2] = new Vertex(new Vector2f(x + _scale.X, y + _scale.Y));
        vertex[3] = new Vertex(new Vector2f(x, y + _scale.Y));
        vertex[4] = new Vertex(new Vector2f(x, y));

        _window.Draw(vertex);

        Console.WriteLine(unscaledX);
    }

    private void DrawGrid()
    {
        for (var i = 0; i < Size.X; i++)
        {
            for (var j = 0; j < Size.Y; j++)
            {
                DrawSquare(i, j);
            }
        }
    }

    private float Clock(Stopwatch stopwatch)
    {
        float sleepTime = FPS - stopwatch.ElapsedMilliseconds;
        if (sleepTime > 0)
        {
            Thread.Sleep((int)sleepTime);
        }

        float fps = 1f / ((float)(stopwatch.Elapsed.TotalSeconds));
        return fps;
    }

    private void WindowLoop(RenderWindow window)
    {
        // window.Clear();
        window.DispatchEvents();

        // TODO: draw grid only when some key is pressed?
        DrawGrid();

        window.Closed += new EventHandler(OnClose!);
    }
}
