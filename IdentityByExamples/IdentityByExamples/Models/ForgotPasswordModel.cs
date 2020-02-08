using System.ComponentModel.DataAnnotations;

namespace IdentityByExamples.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
