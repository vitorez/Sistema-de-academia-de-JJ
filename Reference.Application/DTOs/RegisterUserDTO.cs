using System.ComponentModel.DataAnnotations;
namespace Reference.Application.DTOs;

public class RegisterUserDTO
{
    [Required]
    public string Nome { get; set; } = string.Empty;
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Senha { get; set; } = string.Empty;
    [Required, Compare(nameof(Senha))]
    public string ConfirmarSenha { get; set; } = string.Empty;
}