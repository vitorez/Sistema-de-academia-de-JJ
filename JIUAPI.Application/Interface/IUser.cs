using JIUAPI.Application.DTOs;

namespace JIUAPI.Application.Interface;

public interface IUser
{
    Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO registerUserDTO);
    Task<LoginResponse> LoginUserAsync(LoginDTO loginDTO);
}
