﻿using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class ApplicationUser:IdentityUser
    {
        public byte[]? Image { get; set; }
       
    }
}
