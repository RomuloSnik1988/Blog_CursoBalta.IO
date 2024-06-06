namespace Blog;

public static class Configuration
{
    //Token Json Web Token
    public static string JwtKey = "KEmfqfZSfmvPRYarZYKIKDqontUVLvuK";

    public static string ApiKeyName = "api_key";
    public static string ApiKey = "curso-ApiKEmfqfZSfmvPRYar";

    public static SmtpConfiguration Smtp = new();
    
    public class SmtpConfiguration
    {
        public string Host { get; set; }
        public int Port { get; set; } = 25;
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
