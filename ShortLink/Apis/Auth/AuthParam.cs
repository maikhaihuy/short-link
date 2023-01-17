using System.ComponentModel.DataAnnotations;

namespace ShortLink.Apis.Auth
{
    public class LoginParam
    {
        [Required]
        public string LoginName { get; set; }
        [Required]
        public string Password { get; set; }
    }
    
    public class RegisterParam
    {
        [Required]
        public string LoginName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}