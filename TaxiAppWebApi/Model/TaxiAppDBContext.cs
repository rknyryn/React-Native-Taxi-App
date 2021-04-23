using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TaxiAppWebApi.Model
{
    public partial class TaxiAppDBContext : DbContext
    {
        public TaxiAppDBContext()
        {
        }

        public TaxiAppDBContext(DbContextOptions<TaxiAppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TaxiTripDatum> TaxiTripData { get; set; }
        public virtual DbSet<TaxiZone> TaxiZones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #pragma warning disable CS1030 // #warning yönergesi
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:taxiappwebapi.database.windows.net,1433;Initial Catalog=TaxiAppDB;Persist Security Info=False;User ID=taxiappwebapi;Password=159a753s552d*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                #pragma warning restore CS1030 // #warning yönergesi
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TaxiZone>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK__TaxiZone__E7FEA4774C190242");

                entity.Property(e => e.Borough).IsUnicode(false);

                entity.Property(e => e.ServiceZone).IsUnicode(false);

                entity.Property(e => e.Zone).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
