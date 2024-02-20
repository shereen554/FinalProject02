using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Delivery
{
    public int DeliveryId { get; set; }

    public string DeliveryName { get; set; } = null!;

    public string DeliveryAddress { get; set; } = null!;

    public string DeliveryEmail { get; set; } = null!;

    public string DeliveryPhone { get; set; } = null!;

    public int UDeliveryId { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User UDelivery { get; set; } = null!;

    public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();
}
