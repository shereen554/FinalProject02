using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class ApplicationUser:IdentityUser
    {
        public byte[]? Image { get; set; }
        public string pharmDoctor { get; set; } = null!;
        public int UPharmacyId { get; set; }
    }
}
