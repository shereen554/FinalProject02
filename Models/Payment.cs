using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Payment
{
    public int PayId { get; set; }

    public string PayMethod { get; set; } = null!;

    public DateTime PayDate { get; set; }

    public string PayStatus { get; set; } = null!;

    public int InoiceId { get; set; }

    public virtual Invoice Inoice { get; set; } = null!;
}
