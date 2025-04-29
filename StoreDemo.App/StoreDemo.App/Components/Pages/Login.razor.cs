using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.ComponentModel.DataAnnotations;

namespace StoreDemo.App.Components.Pages;

public partial class Login
{
    [Inject]
    public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

    [SupplyParameterFromForm]
    private AdminLoginRequest LoginRequest { get; set; } = new();

    private string? ErrorMessage;
    private bool IsLoading = false;

    private async Task HandleLogin()
    {
        IsLoading = true;
        try
        {
            var customAuthenticaitonStateProvider = (StoreAuthenticationStateProvider)AuthenticationStateProvider;

            var token = customAuthenticaitonStateProvider.Login(LoginRequest.Username!, LoginRequest.Password!);
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
        finally
        {
            IsLoading = false;
        }
    }

}

public record AdminLoginRequest
{
    [Required]
    public string? Username { get; set; }

    [Required]
    public string? Password { get; set; }
}
