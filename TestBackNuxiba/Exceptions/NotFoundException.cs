namespace TestBackNuxiba.Exceptions;

// Thrown when a requested resource (user, login record) does not exist. Mapped to 404.
public class NotFoundException : Exception
{
    public NotFoundException(string message)
        : base(message)
    {
    }
}
