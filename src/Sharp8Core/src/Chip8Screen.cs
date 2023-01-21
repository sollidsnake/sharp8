namespace Sharp8Core;

public class Chip8Screen : IScreen
{
    public int Width => 64;
    public int Height => 32;
    public bool[,] Grid { get; } = new bool[64, 32];

    public void Clear() { }

    public void DrawSpriteLine(int x, int y, int bytes)
    {
        for (int i = 0; i < 8; i++)
        {
            try
            {
                var pixel = (((bytes << i) & 128) >> 7) != 0;
                Grid[x, y] = pixel;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("trying to drawn out of the canvas");
            }
            x++;
        }
    }

    public bool GetPixel(int x, int y)
    {
        return Grid[x, y];
    }

    public bool IsPixelSet(byte x, byte y)
    {
        throw new NotImplementedException();
    }

    public void SetPixel(byte x, byte y)
    {
        throw new NotImplementedException();
    }

    public void UnsetPixel(byte x, byte y)
    {
        throw new NotImplementedException();
    }
}
