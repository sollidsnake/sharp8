using System.Diagnostics;
using System.Numerics;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Sharp8Core.Screen;
using Sharp8Core;
using Sharp8Core.RomReader;

namespace Sharp8Screen;

public class Screen : Chip8Screen
{
    public readonly float FPS = 1000f / 60;
    private readonly Vector2 _scale = new Vector2(8, 8);
    private readonly Chip8RomReader _romReader;
    private HexInstructions? _hexInstructions;

    public Screen(Chip8RomReader romReader)
    {
        _romReader = romReader;
    }

    private static void OnClose(object sender, EventArgs e)
    {
        ((RenderWindow)sender).Close();
    }

    public void RunRomFile(string filename)
    {
        _hexInstructions = _romReader.Read(filename);

        MainLoop();
    }

    private void MainLoop()
    {
        Clock clock = new Clock();
        RenderWindow window = CreateWindow();
        var shape = new CircleShape(100);
        Stopwatch stopwatch = new Stopwatch();

        while (window.IsOpen)
        {
            stopwatch.Restart();

            WindowLoop(window);

            var random = new Random().Next(0, 3);
            shape.FillColor = new Color[]
            {
                Color.Green,
                Color.Blue,
                Color.Magenta
            }[random];

            window.Draw(shape);
            window.Display();

            float fps = Clock(stopwatch);

            Console.WriteLine(fps);
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

    private static void WindowLoop(RenderWindow window)
    {
        window.Clear();
        window.DispatchEvents();
        window.Closed += new EventHandler(OnClose!);
    }
}
