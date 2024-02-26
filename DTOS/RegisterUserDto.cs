using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOS
{
    public class RegisterUserDto
    {
        [Required]
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Address { get; set; }
        public bool Gender { get; set; }
        public byte[]? Image { get; set; }
       
    }
}
