using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Shift
{
    public int ShiftId { get; set; }

    public string ShiftDay { get; set; } = null!;

    public TimeSpan ShiftStartTime { get; set; }

    public TimeSpan ShiftEndTime { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
}
