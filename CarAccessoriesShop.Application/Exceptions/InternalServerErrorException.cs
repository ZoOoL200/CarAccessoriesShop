namespace CarAccessoriesShop.Application.Exceptions;

public class InternalServerErrorException : Exception
{
    public InternalServerErrorException(string message ) : base(message) { }
    public InternalServerErrorException(string message , Exception innerexception) : base(message, innerexception) { }
}
