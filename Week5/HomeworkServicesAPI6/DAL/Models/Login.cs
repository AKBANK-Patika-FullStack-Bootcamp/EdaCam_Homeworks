
using Microsoft.AspNetCore.Mvc;

namespace DAL.Models
{
    public class Login
    {
        public string Username { get; set; }= string.Empty;
        public string PasswordHash { get; set; }
        public string PassworSalt { get; set; }
    }
    public class LoginDto
    {   
        [FromHeader]
        public string Username { get; set; } = string.Empty;
        [FromHeader]
        public string Password { get; set; } = string.Empty;
    }
    public class APIAuthority
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
    }
}
