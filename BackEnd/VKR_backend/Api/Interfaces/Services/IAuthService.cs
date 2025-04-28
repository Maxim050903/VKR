namespace Api.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string> LogIn(string IndividualNumber, string password);
    }
}