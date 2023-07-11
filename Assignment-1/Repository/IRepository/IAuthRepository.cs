using Assignment_1.Models;
using Assignment_1.Models.DTO;

namespace Assignment_1.Repository.IRepository
{
    public interface IAuthRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto);
        Task<User> Register(RegistrationRequestDTO registrationRequestDto);
    }
}
