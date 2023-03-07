using System.ComponentModel.DataAnnotations;

namespace MeetMe.UI.Models;

public class UserLoginModel
{
 [Required(ErrorMessage = "Mail Alanı Boş Geçilemez")]
 public string Mail { get; set; } = null!;
 
 [Required(ErrorMessage = "Şifre Alanı Boş Geçilemez")]
 public string Password { get; set; } = null!;
}