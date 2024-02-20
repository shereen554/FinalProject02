using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class PharmacyLocation
{
    public int PharmacyId { get; set; }

    public string PharmacyLocation1 { get; set; } = null!;

    public virtual Pharmacy Pharmacy { get; set; } = null!;
}
