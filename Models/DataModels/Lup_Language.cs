namespace MagicCard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lup_Language
    {
        public Lup_Language()
        {
            Lup_CategoryTranslation = new HashSet<Lup_CategoryTranslation>();
            Shp_ShopTranslation = new HashSet<Shp_ShopTranslation>();
        }

        [Key]
        public int LanguageId { get; set; }

        [Required]
        [StringLength(200)]
        public string LanguageTitle { get; set; }

        public bool IsDefault { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsDeletable { get; set; }

        public DateTime? RCDate { get; set; }

        public int? RCBy { get; set; }

        public DateTime? LADate { get; set; }

        public int? LABy { get; set; }

        public virtual ICollection<Lup_CategoryTranslation> Lup_CategoryTranslation { get; set; }

        public virtual ICollection<Shp_ShopTranslation> Shp_ShopTranslation { get; set; }
    }
}
