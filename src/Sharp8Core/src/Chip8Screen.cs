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
                Grid[x, y] = (bytes & (1 << i)) != 0;
            }
            catch (IndexOutOfRangeException) { }
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
