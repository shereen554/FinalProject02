using Microsoft.Build.Framework;

namespace WebApplication1.DTOS
{
    public class dtoLogin
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
