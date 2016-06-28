namespace MagicCard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Info_ContactUs
    {
        [Key]
        public int RecordSerial { get; set; }

        [StringLength(100)]
        public string ContactPhone { get; set; }

        [StringLength(200)]
        public string ContactAddress { get; set; }

        [StringLength(200)]
        public string ContactEmail { get; set; }


        public string AdUrl { get; set; }
    }
}
