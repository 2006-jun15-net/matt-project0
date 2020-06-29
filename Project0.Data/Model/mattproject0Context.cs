using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project0.ConosoleApp
{
    public partial class mattproject0Context : DbContext
    {
        public mattproject0Context()
        {
        }

        public mattproject0Context(DbContextOptions<mattproject0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<OrderHist> OrderHist { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Store> Store { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => new { e.StoreId, e.Sku })
                    .HasName("PK__Inventor__E7231C1174E7C84A");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.Sku).HasColumnName("SKU");

                entity.HasOne(d => d.SkuNavigation)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.Sku)
                    .HasConstraintName("FK__Inventory__SKU__5535A963");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Inventory__Store__5441852A");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.Sku)
                    .HasName("PK__Items__CA1ECF0C1A373F69");

                entity.Property(e => e.Sku).HasColumnName("SKU");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ItemPrice).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<OrderHist>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__OrderHis__C3905BAFC1C48D65");

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.OrderTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderHist)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__OrderHist__Custo__5CD6CB2B");

                entity.HasOne(d => d.FromStoreNavigation)
                    .WithMany(p => p.OrderHist)
                    .HasForeignKey(d => d.FromStore)
                    .HasConstraintName("FK__OrderHist__FromS__5DCAEF64");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ItemId })
                    .HasName("PK__Orders__64B7B3973038C6D5");

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__OrderID__6477ECF3");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.Location).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
