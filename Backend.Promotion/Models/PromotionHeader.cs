﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Backend.Promotion.Models
{
    public partial class PromotionHeader
    {
        public PromotionHeader()
        {
            PromotionDetails = new HashSet<PromotionDetail>();
        }

        public string PromotionId { get; set; }
        public string PromotionDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid PromoTypeId { get; set; }
        public Guid ValueTypeId { get; set; }
        public int ValueType { get; set; }

        public virtual PromoType PromoType { get; set; }
        public virtual ValueType ValueTypeNavigation { get; set; }
        public virtual ICollection<PromotionDetail> PromotionDetails { get; set; }
    }
}