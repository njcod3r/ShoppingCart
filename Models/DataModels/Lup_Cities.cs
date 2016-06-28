namespace MagicCard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lup_Cities
    {
        public Lup_Cities()
        {
            Usr_Users = new HashSet<Usr_Users>();
        }

        [Key]
        public short CityRecordID { get; set; }

        [StringLength(50)]
        public string CityCode { get; set; }

        [Required]
        [StringLength(50)]
        public string NameAr { get; set; }

        [StringLength(50)]
        public string NameEn { get; set; }

        [StringLength(50)]
        public string CallKey { get; set; }

        public short? CountryID { get; set; }

        public bool IsDefault { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsDeletable { get; set; }

        public DateTime RCDate { get; set; }

        public short? RCBy { get; set; }

        public DateTime? LADate { get; set; }

        public short? LABy { get; set; }

        public virtual Lup_Countries Lup_Countries { get; set; }

        public virtual ICollection<Usr_Users> Usr_Users { get; set; }
    }
}
