namespace Obqvi_API.Extensions
{
    public static class PasswordExtensions
    {
        public static string Encrypt(this string password)
        {
            var pass = "";
            for (var i = 0; i < password.Length; i++) 
            {                        
                pass += i%2 == 0 ? password[i] : password[i] * (i+11);          
            }
            var a = pass.Length;
            return pass;
        }
    }
}
