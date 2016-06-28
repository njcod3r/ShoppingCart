namespace MagicCard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lup_CategoryTranslation
    {
        [Key]
        public int RecordSerial { get; set; }

        public int CategoryId { get; set; }

        public int LanguageId { get; set; }

        [Required]
        [StringLength(200)]
        public string CategoryTitle { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsDeletable { get; set; }

        public DateTime? RCDate { get; set; }

        public int? RCBy { get; set; }

        public DateTime? LADate { get; set; }

        public int? LABy { get; set; }

        public virtual Lup_Category Lup_Category { get; set; }

        public virtual Lup_Language Lup_Language { get; set; }
    }
}
