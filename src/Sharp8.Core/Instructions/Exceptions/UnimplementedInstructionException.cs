using System.Runtime.Serialization;

namespace Sharp8.Core.Instructions.Exceptions;

public class UnimplementedInstructionException : Exception
{
    public UnimplementedInstructionException() { }

    public UnimplementedInstructionException(string message) : base(message) { }

    public UnimplementedInstructionException(
        string? message,
        Exception? innerException
    ) : base(message, innerException) { }

    protected UnimplementedInstructionException(
        SerializationInfo info,
        StreamingContext context
    ) : base(info, context) { }
}
