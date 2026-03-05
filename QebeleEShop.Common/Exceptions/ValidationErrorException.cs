namespace QebeleEShop.Common.Exceptions;

public class ValidationErrorException:Exception
{
    public ValidationErrorException(string message) : base(message)
    {
    }
}
