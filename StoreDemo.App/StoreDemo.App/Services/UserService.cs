using Microsoft.AspNetCore.Identity;

namespace StoreDemo.App.Services;

public class UserService
{
    public User? GetUser(string username)
    {
        if (username != "admin") return null;

        return new User()
        {
            Name = "admin",
            Password = "Password1!"
        };
    }
}

public class User
{
    public required string Name { get; set; }
    public required string Password { get; set; }
}
