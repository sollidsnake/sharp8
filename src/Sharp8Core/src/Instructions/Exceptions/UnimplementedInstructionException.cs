namespace Sharp8Core.Instructions.Exceptions;

public class UnimplementedInstructionException : Exception
{
    public UnimplementedInstructionException(string message) : base(message) { }
}
