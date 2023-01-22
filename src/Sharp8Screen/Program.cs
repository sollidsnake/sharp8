// See https://aka.ms/new-console-template for more information

using Sharp8Screen;

public class Program
{
    public static readonly float FPS = 1000f / 60;

    public static void Main(string[] args)
    {
        var game = new Game();

        if (args.Length == 2)
        {
            // game.Run(args[1]);
            // return;
        }

        game.Run("../../tests/assets/ibmlogo.ch8");
    }
}
