using System;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Models;

public partial class User
{
    public int UId { get; set; }

    public string UPassword { get; set; } = null!;

    public int? UAdminId { get; set; }

    public int? UDeliveryId { get; set; }

    public int? UPharmacyId { get; set; }

    public int? UCustomerId { get; set; }

    public string? UEmail { get; set; }

    public string? UName { get; set; }
    public string? Type { get; set; }

   
}


