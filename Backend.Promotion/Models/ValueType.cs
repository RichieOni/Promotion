﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Backend.Promotion.Models
{
    public partial class ValueType
    {
        public ValueType()
        {
            PromotionHeaders = new HashSet<PromotionHeader>();
        }

        public Guid ValueTypeId { get; set; }
        public byte[] ValueTypeName { get; set; }
        public int SortOrder { get; set; }

        public virtual ICollection<PromotionHeader> PromotionHeaders { get; set; }
    }
}