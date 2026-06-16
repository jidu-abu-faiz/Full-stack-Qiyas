public interface IAuditService
{
    void Record(string message);
}

public class AuditService : IAuditService
{
    public void Record(string message)
    {
        Console.WriteLine($"AUDIT: {message}");
    }
}