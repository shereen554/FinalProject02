using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public DateTime InvoiceDate { get; set; }

    public int PaymentId { get; set; }

    public int OrderId { get; set; }

    public int PharmacyId { get; set; }

    public int DeliveryId { get; set; }

    public virtual Delivery Delivery { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Pharmacy Pharmacy { get; set; } = null!;
}
