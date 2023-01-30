namespace Sharp8.Core.Instructions.Helpers;

public static class InstructionHelper
{
    public static (int, bool) SumAndCheckCarry(int a, int b)
    {
        var result = a + b;
        if (result > 0xFF)
        {
            result -= 0x100;
            return (result, true);
        }
        return (result, false);
    }

    public static (int, bool) SubAndCheckBorrow(int a, int b)
    {
        var result = a - b;
        if (result < 0)
        {
            result += 0x100;
            return (result, true);
        }
        return (result, false);
    }
}
