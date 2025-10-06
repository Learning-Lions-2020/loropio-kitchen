namespace LoropioKitchen.Domain.Entities;

public class OtpCode
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid UserId { get; private set; }
    public string CodeHash { get; private set; } = string.Empty;
    public DateTime Expiry { get; private set; }
    public bool Used { get; private set; } = false;

    public User User { get; private set; } = null!;

    private OtpCode() { }

    public OtpCode(Guid userId, string codeHash, DateTime expiry)
    {
        UserId = userId;
        CodeHash = codeHash;
        Expiry = expiry;
        Used = false;
    }

    public void MarkAsUsed()
    {
        Used = true;
    }

    public bool IsValid(string codeHashToCheck)
    {
        return !Used && DateTime.UtcNow <= Expiry && CodeHash == codeHashToCheck;
    }
}
