using System.ComponentModel.DataAnnotations;

namespace Server.Application.DTOs.User;
public class UserRegistrationDTO
{
    [Required]
    public string UserName { get; set; }
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }
    public string? PhoneNo { get; set; }
    [Required]
    [PasswordValidation]
    public string PasswordHash { get; set; }
}


