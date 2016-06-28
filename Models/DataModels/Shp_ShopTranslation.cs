namespace MagicCard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shp_ShopTranslation
    {
        [Key]
        public int RecordSerial { get; set; }

        public int ShopId { get; set; }

        public int LanguageId { get; set; }

        [Required]
        [StringLength(200)]
        public string ShopTitle { get; set; }

        [StringLength(200)]
        public string ShopAddress { get; set; }

        public string ShopDescription { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsDeletable { get; set; }

        public DateTime? RCDate { get; set; }

        public int? RCBy { get; set; }

        public DateTime? LADate { get; set; }

        public int? LABy { get; set; }

        public virtual Lup_Language Lup_Language { get; set; }

        public virtual Shp_Shop Shp_Shop { get; set; }
    }
}
