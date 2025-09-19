namespace LoropioKitchen.Domain.Entities;

public class User
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string PhoneNumber { get; private set; } = string.Empty;
    public UserRole Role { get; private set; } = UserRole.Customer;
    public UserStatus Status { get; private set; } = UserStatus.Active;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    // Factory or update methods
    public User(string name, string email, string phoneNumber, UserRole role)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        Role = role;
        Status = UserStatus.Active;
    }

    public void Deactivate() => Status = UserStatus.Inactive;
    public void UpdateName(string name) => Name = name;
}
