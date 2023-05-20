namespace ShortLink.Models
{
    public class AuthModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public AccountModel Account { get; set; }
    }
}
