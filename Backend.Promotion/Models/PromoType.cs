﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Backend.Promotion.Models
{
    public partial class PromoType
    {
        public PromoType()
        {
            PromotionHeaders = new HashSet<PromotionHeader>();
        }

        public Guid PromoTypeId { get; set; }
        public string PromoTypeName { get; set; }
        public int SortOrder { get; set; }

        public virtual ICollection<PromotionHeader> PromotionHeaders { get; set; }
    }
}