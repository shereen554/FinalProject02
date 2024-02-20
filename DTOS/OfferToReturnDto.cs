﻿using WebApplication1.Models;

namespace WebApplication1.DTOS
{
    public class OfferToReturnDto
    {
        public int OfferId { get; set; }

        public string OfferName { get; set; } = null!;

        public double OfferDiscount { get; set; }

        public string OfferDescription { get; set; } = null!;

        public string OfferPeriod { get; set; } = null!;

        public DateTime OfferStartDate { get; set; }

        public DateTime OfferEndDate { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();

        public virtual ICollection<Pharmacy> Pharmacies { get; set; } = new List<Pharmacy>();
    }
}
