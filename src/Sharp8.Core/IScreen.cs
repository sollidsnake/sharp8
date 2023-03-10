using System.Text;

namespace Sharp8.Core;

public interface IScreen
{
    public int Width { get; }
    public int Height { get; }

#pragma warning disable CA1819
#pragma warning disable CA1814
    public bool[,] Grid { get; }

    public abstract void ScreenUpdated(int x, int y, int height);

    public int ScreenSize => Width * Height;

    void Clear();
    bool DrawSpriteLine(int x, int y, int bytes);
    bool GetPixel(int x, int y);

    public string GenGridTableWithBorders()
    {
        var sb = new StringBuilder();
        for (int y = 0; y < Height; y++)
        {
            sb.Append('|');
            for (int x = 0; x < Width; x++)
            {
                sb.Append(Grid[x, y] ? 'X' : ' ');
            }
            sb.AppendLine("|");
        }

        return sb.ToString();
    }
}
