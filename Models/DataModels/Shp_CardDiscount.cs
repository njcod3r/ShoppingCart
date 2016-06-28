namespace MagicCard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shp_CardDiscount
    {      

        [Key]
        public int CardDiscountId { get; set; }

        public decimal CardDiscountPercentage { get; set; }

        public int ShopId { get; set; }

        public bool IsCurrent { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? RCDate { get; set; }

        public int? RCBy { get; set; }

        public DateTime? LADate { get; set; }

        public int? LABy { get; set; }

        public virtual Shp_Shop Shp_Shop { get; set; }
    }
}
