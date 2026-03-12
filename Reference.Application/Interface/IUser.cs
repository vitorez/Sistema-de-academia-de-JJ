using Reference.Application.DTOs;

namespace Reference.Application.Interface;

public interface IUser
{
    Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO registerUserDTO);
    Task<LoginResponse> LoginUserAsync(LoginDTO loginDTO);
}
