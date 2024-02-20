using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public DateTime CustomerBirthDate { get; set; }

    public string CustomerGender { get; set; } = null!;

    public string CustomerEmail { get; set; } = null!;

    public string CustomerPhone { get; set; } = null!;

    public string CustomerAddress { get; set; } = null!;

    public string CustomerType { get; set; } = null!;

    public int OrderId { get; set; }

    public int UCustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public virtual User UCustomer { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
