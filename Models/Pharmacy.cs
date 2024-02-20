using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Pharmacy
{
    public int PharmacyId { get; set; }

    public string PharmacyName { get; set; } = null!;

    public string PharmacyPhone { get; set; } = null!;

    public string PharmacyEmail { get; set; } = null!;

    public int UPharmacyId { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<PharmacyLocation> PharmacyLocations { get; set; } = new List<PharmacyLocation>();

    public virtual User UPharmacy { get; set; } = null!;

    public virtual ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
