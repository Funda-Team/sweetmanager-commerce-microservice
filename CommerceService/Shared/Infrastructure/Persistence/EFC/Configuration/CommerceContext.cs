using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CommerceService.Shared.Infrastructure.Persistence.EFC.Configuration;

public partial class CommerceContext : DbContext
{
    public CommerceContext()
    {
    }

    public CommerceContext(DbContextOptions<CommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ContractOwner> ContractOwners { get; set; }

    public virtual DbSet<PaymentCustomer> PaymentCustomers { get; set; }

    public virtual DbSet<PaymentOwner> PaymentOwners { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=commerce;user=root;password=password;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContractOwner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contract_owners");

            entity.HasIndex(e => e.SubscriptionsId, "subscriptions_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FinalDate)
                .HasColumnType("datetime")
                .HasColumnName("final_date");
            entity.Property(e => e.OwnersId).HasColumnName("owners_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");
            entity.Property(e => e.State)
                .HasMaxLength(20)
                .HasColumnName("state");
            entity.Property(e => e.SubscriptionsId).HasColumnName("subscriptions_id");

            entity.HasOne(d => d.Subscriptions).WithMany(p => p.ContractOwners)
                .HasForeignKey(d => d.SubscriptionsId)
                .HasConstraintName("contract_owners_ibfk_1");
        });

        modelBuilder.Entity<PaymentCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("payment_customers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomersId).HasColumnName("customers_id");
            entity.Property(e => e.FinalAmount)
                .HasPrecision(10)
                .HasColumnName("final_amount");
        });

        modelBuilder.Entity<PaymentOwner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("payment_owners");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.FinalAmount)
                .HasPrecision(10)
                .HasColumnName("final_amount");
            entity.Property(e => e.OwnersId).HasColumnName("owners_id");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("subscriptions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.HotelId).HasColumnName("hotel_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(10)
                .HasColumnName("price");
            entity.Property(e => e.State)
                .HasMaxLength(20)
                .HasColumnName("state");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
