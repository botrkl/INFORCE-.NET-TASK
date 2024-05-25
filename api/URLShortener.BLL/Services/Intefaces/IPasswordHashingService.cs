namespace URLShortener.BLL.Services.Intefaces
{
    public interface IPasswordHashingService
    {
        Task<string> HashPasswordAsync(string password);
        Task<bool> VerifyPasswordAsync(string password, string hashedPassword);
    }
}
