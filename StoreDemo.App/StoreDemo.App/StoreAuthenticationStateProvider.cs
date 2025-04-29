using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using StoreDemo.App.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StoreDemo.App;

public class StoreAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly UserService _userService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public StoreAuthenticationStateProvider(UserService userService, IHttpContextAccessor httpContextAccessor)
    {
        _userService = userService;
        _httpContextAccessor = httpContextAccessor;
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
    }

    public string Login(string username, string password)
    {
        var user = _userService.GetUser(username);

        if (user != null && user.Password == "Password1!")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, "Admin")
            };

            // Generaet a JWT token based on the claims
            var token = new JwtSecurityToken(
                issuer: "StoreDemo",
                audience: Guid.NewGuid().ToString(),
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key")), SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        return string.Empty;
    }
}
