using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Reference.Application.DTOs;
using Reference.Application.Interface;
using Reference.Domain.Entities;
using Reference.Infra.Data;

namespace Reference.Infra.Implementations;

internal class UserService : IUser
{
    private readonly AppDbContext appDbContext;
    private readonly IConfiguration configuration;

    public UserService(AppDbContext appDbContext, IConfiguration configuration)
    {
        this.appDbContext = appDbContext;
        this.configuration = configuration;
    }

    public async Task<LoginResponse> LoginUserAsync(LoginDTO loginDTO)
    {
        var getUser = await ProcurarUserPorEmail(loginDTO.Email!);
        if (getUser == null) return new LoginResponse(false, "Usuario não encontrado");


        bool checarSenha = BCrypt.Net.BCrypt.Verify(loginDTO.Senha, getUser.Senha);
        if (checarSenha)
            return new LoginResponse(true, "Login feito com sucesso", GenerateJWTToken(getUser));
        else
            return new LoginResponse(false, "Credenciais Invalidas");
    }

    private string GenerateJWTToken(ApplicationUser user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])!);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var UserClaims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Nome),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: UserClaims,
            expires: DateTime.Now.AddDays(5),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private async Task<ApplicationUser> ProcurarUserPorEmail(string email) =>
        await appDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO registerUserDTO)
    {
        var getUser = await ProcurarUserPorEmail(registerUserDTO.Email!);
        if (getUser != null)
            return new RegistrationResponse(false, "User ja existe");

        appDbContext.Users.Add(new ApplicationUser()
        {
            Nome = registerUserDTO.Nome,
            Email = registerUserDTO.Email,
            Senha = BCrypt.Net.BCrypt.HashPassword(registerUserDTO.Senha)
        });
        await appDbContext.SaveChangesAsync();
        return new RegistrationResponse(true, "Registrado com Sucesso");
    }
}