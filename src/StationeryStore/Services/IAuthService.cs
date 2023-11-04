using StationeryStore.Models;

namespace MinimalApiAuthentication.Services;
public interface IAuthService
{
    Task LoginAsync(string email, string password);
    Task RegisterAsync(string email, string password);
}