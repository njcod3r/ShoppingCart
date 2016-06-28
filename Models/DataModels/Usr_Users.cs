namespace MagicCard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usr_Users
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(200)]
        public string UserName { get; set; }

        [Required]
        public byte[] UserPassword { get; set; }

        [Required]
        [StringLength(200)]
        public string UserEmail { get; set; }

        [Required]
        [StringLength(200)]
        public string UserFirstName { get; set; }

        [Required]
        [StringLength(200)]
        public string UserLastName { get; set; }

        [StringLength(200)]
        public string UserAddress { get; set; }

        [StringLength(100)]
        public string UserMobile { get; set; }

        public string UserImage { get; set; }

        public short CityRecordID { get; set; }

        [StringLength(100)]
        public string UserZipCode { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsDeletable { get; set; }

        public DateTime? RCDate { get; set; }

        public int? RCBy { get; set; }

        public DateTime? LADate { get; set; }

        public int? LABy { get; set; }

        public int UserRoleId { get; set; }

        public virtual Lup_Cities Lup_Cities { get; set; }

        public virtual Usr_Roles Usr_Roles { get; set; }
    }
}
