using System.Threading.Tasks.Dataflow;

namespace CarAccessoriesShop.Application.Exceptions;

public class ValidationAppException : Exception
{
    public IEnumerable<string> Errors { get; }

    public ValidationAppException(IEnumerable<string> errors)
        : base("Validation failed")
    {
        Errors = errors;
    }
}
