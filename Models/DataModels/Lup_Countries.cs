namespace MagicCard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lup_Countries
    {
        public Lup_Countries()
        {
            Lup_Cities = new HashSet<Lup_Cities>();
        }

        [Key]
        public short CountryID { get; set; }

        [StringLength(5)]
        public string Initial { get; set; }

        [Required]
        [StringLength(70)]
        public string NameAr { get; set; }

        [StringLength(70)]
        public string NameEn { get; set; }

        [StringLength(20)]
        public string NationalityTitle { get; set; }

        [StringLength(5)]
        public string CallKey { get; set; }

        public bool IsDefault { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsDeletable { get; set; }

        public DateTime RCDate { get; set; }

        public short? RCBy { get; set; }

        public DateTime? LADate { get; set; }

        public short? LABy { get; set; }

        public virtual ICollection<Lup_Cities> Lup_Cities { get; set; }
    }
}
