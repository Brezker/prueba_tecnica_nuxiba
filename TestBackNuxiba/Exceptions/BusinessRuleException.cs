namespace TestBackNuxiba.Exceptions;

// Thrown when a well-formed request breaks a business rule
// (e.g. a login without a previous logout). Mapped to 400.
public class BusinessRuleException : Exception
{
    public BusinessRuleException(string message)
        : base(message)
    {
    }
}
