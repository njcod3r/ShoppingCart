namespace MagicCard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shp_Shop
    {
        public Shp_Shop()
        {
            Shp_ShopTranslation = new HashSet<Shp_ShopTranslation>();
            Shp_CardDiscount = new HashSet<Shp_CardDiscount>();
        }

        [Key]
        public int ShopId { get; set; }

        public int CategoryId { get; set; }       

        public bool IsActive { get; set; }

        public string ShopImage { get; set; }

        public string ShopImage1 { get; set; }

        public string ShopImage2 { get; set; }

        public string ShopImage3 { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsDeletable { get; set; }

        public DateTime? RCDate { get; set; }

        public int? RCBy { get; set; }

        public DateTime? LADate { get; set; }

        public int? LABy { get; set; }

        public virtual Lup_Category Lup_Category { get; set; }

        public virtual ICollection<Shp_CardDiscount> Shp_CardDiscount { get; set; }

        public virtual ICollection<Shp_ShopTranslation> Shp_ShopTranslation { get; set; }
    }
}
