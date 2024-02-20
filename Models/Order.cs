using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public double OrderPrice { get; set; }

    public int CustomerId { get; set; }

    public int PharmacyId { get; set; }

    public int DeliveryId { get; set; }

    public virtual Delivery Delivery { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();

    public virtual ICollection<Pharmacy> Pharmacies { get; set; } = new List<Pharmacy>();
}
