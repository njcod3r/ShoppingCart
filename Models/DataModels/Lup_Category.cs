namespace MagicCard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lup_Category
    {
        public Lup_Category()
        {
            Lup_CategoryTranslation = new HashSet<Lup_CategoryTranslation>();
            Shp_Shop = new HashSet<Shp_Shop>();
        }

        [Key]
        public int CategoryId { get; set; }

        public string CategoryImage { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsDeletable { get; set; }

        public DateTime? RCDate { get; set; }

        public int? RCBy { get; set; }

        public DateTime? LADate { get; set; }

        public int? LABy { get; set; }

        public virtual ICollection<Lup_CategoryTranslation> Lup_CategoryTranslation { get; set; }

        public virtual ICollection<Shp_Shop> Shp_Shop { get; set; }
    }
}
