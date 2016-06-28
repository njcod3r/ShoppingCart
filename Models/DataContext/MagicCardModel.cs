namespace MagicCard
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MagicCardModel : DbContext
    {
        public MagicCardModel()
            : base("name=DBMagicCard")
        {
        }

        public virtual DbSet<Info_ContactUs> Info_ContactUs { get; set; }
        public virtual DbSet<Lup_Category> Lup_Category { get; set; }
        public virtual DbSet<Lup_CategoryTranslation> Lup_CategoryTranslation { get; set; }
        public virtual DbSet<Lup_Cities> Lup_Cities { get; set; }
        public virtual DbSet<Lup_Countries> Lup_Countries { get; set; }
        public virtual DbSet<Lup_Language> Lup_Language { get; set; }
        public virtual DbSet<Shp_CardDiscount> Shp_CardDiscount { get; set; }
        public virtual DbSet<Shp_Shop> Shp_Shop { get; set; }
        public virtual DbSet<Shp_ShopTranslation> Shp_ShopTranslation { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Usr_Roles> Usr_Roles { get; set; }
        public virtual DbSet<Usr_Users> Usr_Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lup_Category>()
                .HasMany(e => e.Lup_CategoryTranslation)
                .WithRequired(e => e.Lup_Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lup_Category>()
                .HasMany(e => e.Shp_Shop)
                .WithRequired(e => e.Lup_Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lup_Cities>()
                .HasMany(e => e.Usr_Users)
                .WithRequired(e => e.Lup_Cities)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lup_Countries>()
                .Property(e => e.Initial)
                .IsUnicode(false);

            modelBuilder.Entity<Lup_Countries>()
                .Property(e => e.NameEn)
                .IsUnicode(false);

            modelBuilder.Entity<Lup_Countries>()
                .Property(e => e.CallKey)
                .IsUnicode(false);

            modelBuilder.Entity<Lup_Language>()
                .HasMany(e => e.Lup_CategoryTranslation)
                .WithRequired(e => e.Lup_Language)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lup_Language>()
                .HasMany(e => e.Shp_ShopTranslation)
                .WithRequired(e => e.Lup_Language)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shp_CardDiscount>()
                .Property(e => e.CardDiscountPercentage)
                .HasPrecision(4, 2);

            modelBuilder.Entity<Shp_Shop>()
                .HasMany(e => e.Shp_CardDiscount)
                .WithRequired(e => e.Shp_Shop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shp_Shop>()
                .HasMany(e => e.Shp_ShopTranslation)
                .WithRequired(e => e.Shp_Shop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usr_Roles>()
                .HasMany(e => e.Usr_Users)
                .WithRequired(e => e.Usr_Roles)
                .WillCascadeOnDelete(false);
        }
    }
}
