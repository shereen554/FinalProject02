using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Medicine
{
    public int MediCineId { get; set; }

    public string MediCineName { get; set; } = null!;

    public string MediCineType { get; set; } = null!;

    public string MediCineEffectiveMaterial { get; set; } = null!;

    public double MediCineCoastPrice { get; set; }

    public double MediCineSellingPrice { get; set; }

    public string MediCineAvailability { get; set; } = null!;

    public DateTime MediCineProductionDate { get; set; }

    public DateTime MediCineExpirationDate { get; set; }

    public int MediCineQuantity { get; set; }

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Pharmacy> Pharmacies { get; set; } = new List<Pharmacy>();
}
