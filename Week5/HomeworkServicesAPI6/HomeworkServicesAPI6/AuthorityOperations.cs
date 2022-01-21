using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DAL.Models;

namespace HomeworkServicesAPI6
{
    public class AuthorityOperations
    {
        private MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
     
        public string CreateToken(Login login, IConfiguration _configuration)
        {
            ///Kullanıcının Username ve Role değerlerini içeren bir Claim nesnesi üretilir.
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1), //Token süresini belirtir
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token); // Bir token üretilir.

            return jwt;

        }
        public string MD5Hashing(string _password)
        {
            byte[] array = Encoding.UTF8.GetBytes(_password);

            // Dizideki veriler hashlenir.
            array = md5.ComputeHash(array);

            //Hashlenen veriyi tutmak için StringBuilder nesnesi oluşturulur.
            StringBuilder stringBuilder = new StringBuilder();

            //Dizideki her byte hexdecimal'e dönüştürülerek stringBuilder'da depolanır.
            foreach (byte b in array)
            {
                stringBuilder.Append(b.ToString("x2").ToLower());
            }
            return stringBuilder.ToString();
        }
    }
}
