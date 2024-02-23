using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Controllers;

namespace WebApplication1.Models;

public partial class RequestMedicinesContext : IdentityDbContext<ApplicationUser>
{
    public RequestMedicinesContext()
    {
    }

    public RequestMedicinesContext(DbContextOptions<RequestMedicinesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Medicine> Medicines { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Pharmacy> Pharmacies { get; set; }

    public virtual DbSet<PharmacyLocation> PharmacyLocations { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=RequestMedicines2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(

            new IdentityRole()
            {
                Id=Guid.NewGuid().ToString(),
                Name ="Admin",
                NormalizedName="admin",
                ConcurrencyStamp= Guid.NewGuid().ToString()
            },
              new IdentityRole()
              {
                  Id = Guid.NewGuid().ToString(),
                  Name = "Customer",
                  NormalizedName = "customer",
                  ConcurrencyStamp = Guid.NewGuid().ToString()
              },
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Pharmacy",
                    NormalizedName = "pharmacy",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                  new IdentityRole()
                  {
                      Id = Guid.NewGuid().ToString(),
                      Name = "Delivery",
                      NormalizedName = "delivery",
                      ConcurrencyStamp = Guid.NewGuid().ToString()
                  }
            );

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__8CB286B97F8A9188");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("Customer_ID");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("Customer_Address");
            entity.Property(e => e.CustomerBirthDate)
                .HasColumnType("date")
                .HasColumnName("Customer_BirthDate");
            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Customer_Email");
            entity.Property(e => e.CustomerGender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Customer_Gender");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Customer_Name");
            entity.Property(e => e.CustomerPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Customer_Phone");
            entity.Property(e => e.CustomerType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Customer_Type");
            entity.Property(e => e.OrderId).HasColumnName("Order_ID");
            entity.Property(e => e.UCustomerId).HasColumnName("U_CustomerID");

            

            entity.HasMany(d => d.Orders).WithMany(p => p.Customers)
                .UsingEntity<Dictionary<string, object>>(
                    "CustomerOrder",
                    r => r.HasOne<Order>().WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Customer_Order_Orders"),
                    l => l.HasOne<Customer>().WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Customer_Order_Customer"),
                    j =>
                    {
                        j.HasKey("CustomerId", "OrderId").HasName("PK__Customer__23ACC080D66EBADD");
                        j.ToTable("Customer_Order");
                        j.IndexerProperty<int>("CustomerId").HasColumnName("Customer_ID");
                        j.IndexerProperty<int>("OrderId").HasColumnName("Order_ID");
                    });
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.DeliveryId).HasName("PK__Delivery__AA55A01952BF9524");

            entity.ToTable("Delivery");

            entity.Property(e => e.DeliveryId)
                .ValueGeneratedNever()
                .HasColumnName("Delivery_ID");
            entity.Property(e => e.DeliveryAddress)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("Delivery_Address");
            entity.Property(e => e.DeliveryEmail)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Delivery_Email");
            entity.Property(e => e.DeliveryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Delivery_Name");
            entity.Property(e => e.DeliveryPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Delivery_Phone");
            entity.Property(e => e.UDeliveryId).HasColumnName("U_DeliveryID");

          
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__Invoices__0DE60494F14439C7");

            entity.Property(e => e.InvoiceId)
                .ValueGeneratedNever()
                .HasColumnName("Invoice_ID");
            entity.Property(e => e.DeliveryId).HasColumnName("Delivery_ID");
            entity.Property(e => e.InvoiceDate)
                .HasColumnType("date")
                .HasColumnName("Invoice_date");
            entity.Property(e => e.OrderId).HasColumnName("Order_ID");
            entity.Property(e => e.PaymentId).HasColumnName("Payment_ID");
            entity.Property(e => e.PharmacyId).HasColumnName("Pharmacy_ID");

            entity.HasOne(d => d.Delivery).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.DeliveryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoices_Delivery");

            entity.HasOne(d => d.Order).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoices_Orders");

            entity.HasOne(d => d.Pharmacy).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.PharmacyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoices_Pharmacy");
        });

        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.HasKey(e => e.MediCineId).HasName("PK__Medicine__29A3F3318FE0C250");

            entity.Property(e => e.MediCineId)
                .ValueGeneratedNever()
                .HasColumnName("MediCine_ID");
            entity.Property(e => e.MediCineAvailability)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MediCine_Availability");
            entity.Property(e => e.MediCineCoastPrice).HasColumnName("MediCine_CoastPrice");
            entity.Property(e => e.MediCineEffectiveMaterial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MediCine_EffectiveMaterial");
            entity.Property(e => e.MediCineExpirationDate)
                .HasColumnType("date")
                .HasColumnName("MediCine_ExpirationDate");
            entity.Property(e => e.MediCineName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MediCine_Name");
            entity.Property(e => e.MediCineProductionDate)
                .HasColumnType("date")
                .HasColumnName("MediCine_ProductionDate");
            entity.Property(e => e.MediCineQuantity).HasColumnName("MediCine_Quantity");
            entity.Property(e => e.MediCineSellingPrice).HasColumnName("MediCine_SellingPrice");
            entity.Property(e => e.MediCineType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MediCine_Type");

            entity.HasMany(d => d.Orders).WithMany(p => p.Medicines)
                .UsingEntity<Dictionary<string, object>>(
                    "MedicineOrder",
                    r => r.HasOne<Order>().WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Medicine_Order_Orders"),
                    l => l.HasOne<Medicine>().WithMany()
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Medicine_Order_Medicines"),
                    j =>
                    {
                        j.HasKey("MedicineId", "OrderId").HasName("PK__Medicine__F01F440C5101BE57");
                        j.ToTable("Medicine_Order");
                        j.IndexerProperty<int>("MedicineId").HasColumnName("Medicine_ID");
                        j.IndexerProperty<int>("OrderId").HasColumnName("Order_ID");
                    });
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.OfferId).HasName("PK__Offers__66E8916E2908E76A");

            entity.Property(e => e.OfferId)
                .ValueGeneratedNever()
                .HasColumnName("Offer_ID");
            entity.Property(e => e.OfferDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Offer_Description");
            entity.Property(e => e.OfferDiscount).HasColumnName("Offer_Discount");
            entity.Property(e => e.OfferEndDate)
                .HasColumnType("date")
                .HasColumnName("Offer_EndDAte");
            entity.Property(e => e.OfferName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Offer_Name");
            entity.Property(e => e.OfferPeriod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Offer_Period");
            entity.Property(e => e.OfferStartDate)
                .HasColumnType("date")
                .HasColumnName("Offer_StartDate");

            entity.HasMany(d => d.Medicines).WithMany(p => p.Offers)
                .UsingEntity<Dictionary<string, object>>(
                    "OfferMedicine",
                    r => r.HasOne<Medicine>().WithMany()
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Offer_Medicine_Medicines"),
                    l => l.HasOne<Offer>().WithMany()
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Offer_Medicine_Offers"),
                    j =>
                    {
                        j.HasKey("OfferId", "MedicineId").HasName("PK__Offer_Me__2318814D95613585");
                        j.ToTable("Offer_Medicine");
                        j.IndexerProperty<int>("OfferId").HasColumnName("Offer_ID");
                        j.IndexerProperty<int>("MedicineId").HasColumnName("Medicine_ID");
                    });
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__F1E4639B0610592F");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("Order_ID");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");
            entity.Property(e => e.DeliveryId).HasColumnName("Delivery_ID");
            entity.Property(e => e.OrderDate)
                .HasColumnType("date")
                .HasColumnName("Order_Date");
            entity.Property(e => e.OrderPrice).HasColumnName("Order_Price");
            entity.Property(e => e.PharmacyId).HasColumnName("Pharmacy_ID");

            entity.HasOne(d => d.Delivery).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DeliveryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Delivery");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PayId).HasName("PK__Payment__6F137505152EC252");

            entity.ToTable("Payment");

            entity.Property(e => e.PayId)
                .ValueGeneratedNever()
                .HasColumnName("Pay_ID");
            entity.Property(e => e.InoiceId).HasColumnName("Inoice_ID");
            entity.Property(e => e.PayDate)
                .HasColumnType("date")
                .HasColumnName("Pay_Date");
            entity.Property(e => e.PayMethod)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Pay_Method");
            entity.Property(e => e.PayStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Pay_Status");

            entity.HasOne(d => d.Inoice).WithMany(p => p.Payments)
                .HasForeignKey(d => d.InoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Invoices");
        });

        modelBuilder.Entity<Pharmacy>(entity =>
        {
            entity.HasKey(e => e.PharmacyId).HasName("PK__Pharmacy__726449249C1FFFF4");

            entity.ToTable("Pharmacy");

            entity.Property(e => e.PharmacyId)
                .ValueGeneratedNever()
                .HasColumnName("Pharmacy_ID");
            entity.Property(e => e.PharmacyEmail)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Pharmacy_Email");
            entity.Property(e => e.PharmacyName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Pharmacy_Name");
            entity.Property(e => e.PharmacyPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Pharmacy_Phone");
            entity.Property(e => e.UPharmacyId).HasColumnName("U_PharmacyID");

           

            entity.HasMany(d => d.Medicines).WithMany(p => p.Pharmacies)
                .UsingEntity<Dictionary<string, object>>(
                    "PharmacyMedicine",
                    r => r.HasOne<Medicine>().WithMany()
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Pharmacy_Medicine_Medicines"),
                    l => l.HasOne<Pharmacy>().WithMany()
                        .HasForeignKey("PharmacyId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Pharmacy_Medicine_Pharmacy"),
                    j =>
                    {
                        j.HasKey("PharmacyId", "MedicineId").HasName("PK__Pharmacy__37945907603DEF96");
                        j.ToTable("Pharmacy_Medicine");
                        j.IndexerProperty<int>("PharmacyId").HasColumnName("Pharmacy_ID");
                        j.IndexerProperty<int>("MedicineId").HasColumnName("Medicine_ID");
                    });

            entity.HasMany(d => d.Offers).WithMany(p => p.Pharmacies)
                .UsingEntity<Dictionary<string, object>>(
                    "PharmacyOffer",
                    r => r.HasOne<Offer>().WithMany()
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Pharmacy_Offer_Offers"),
                    l => l.HasOne<Pharmacy>().WithMany()
                        .HasForeignKey("PharmacyId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Pharmacy_Offer_Pharmacy"),
                    j =>
                    {
                        j.HasKey("PharmacyId", "OfferId").HasName("PK__Pharmacy__840AC032AB3E0FEB");
                        j.ToTable("Pharmacy_Offer");
                        j.IndexerProperty<int>("PharmacyId").HasColumnName("Pharmacy_ID");
                        j.IndexerProperty<int>("OfferId").HasColumnName("Offer_ID");
                    });

            entity.HasMany(d => d.Orders).WithMany(p => p.Pharmacies)
                .UsingEntity<Dictionary<string, object>>(
                    "PharmacyOrder",
                    r => r.HasOne<Order>().WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Pharmacy_order_Orders"),
                    l => l.HasOne<Pharmacy>().WithMany()
                        .HasForeignKey("PharmacyId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Pharmacy_order_Pharmacy"),
                    j =>
                    {
                        j.HasKey("PharmacyId", "OrderId").HasName("PK__Pharmacy__DD7A0F1D317B69E2");
                        j.ToTable("Pharmacy_order");
                        j.IndexerProperty<int>("PharmacyId").HasColumnName("Pharmacy_ID");
                        j.IndexerProperty<int>("OrderId").HasColumnName("Order_ID");
                    });
        });

        modelBuilder.Entity<PharmacyLocation>(entity =>
        {
            entity.HasKey(e => new { e.PharmacyId, e.PharmacyLocation1 }).HasName("PK__Pharmacy__D131D73588B21F34");

            entity.ToTable("Pharmacy_Location");

            entity.Property(e => e.PharmacyId).HasColumnName("Pharmacy_ID");
            entity.Property(e => e.PharmacyLocation1)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("Pharmacy_Location");

            entity.HasOne(d => d.Pharmacy).WithMany(p => p.PharmacyLocations)
                .HasForeignKey(d => d.PharmacyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pharmacy_Location_Pharmacy");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.ShiftId).HasName("PK__Shifts__527AD6B753DDCF0E");

            entity.Property(e => e.ShiftId)
                .ValueGeneratedNever()
                .HasColumnName("Shift_ID");
            entity.Property(e => e.ShiftDay)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Shift_Day");
            entity.Property(e => e.ShiftEndTime).HasColumnName("Shift_EndTime");
            entity.Property(e => e.ShiftStartTime).HasColumnName("Shift_StartTime");

            entity.HasMany(d => d.Deliveries).WithMany(p => p.Shifts)
                .UsingEntity<Dictionary<string, object>>(
                    "DeliveryShift",
                    r => r.HasOne<Delivery>().WithMany()
                        .HasForeignKey("DeliveryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Delivery_shift_Delivery"),
                    l => l.HasOne<Shift>().WithMany()
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Delivery_shift_Shifts"),
                    j =>
                    {
                        j.HasKey("ShiftId", "DeliveryId").HasName("PK__Delivery__D8DF8CB62E483601");
                        j.ToTable("Delivery_shift");
                        j.IndexerProperty<int>("ShiftId").HasColumnName("Shift_ID");
                        j.IndexerProperty<int>("DeliveryId").HasColumnName("Delivery_ID");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UId).HasName("PK__Users__5A2040DB206DA6EF");

            entity.Property(e => e.UId).HasColumnName("U_ID");
            entity.Property(e => e.UAdminId).HasColumnName("U_AdminID");
            entity.Property(e => e.UCustomerId).HasColumnName("U_CustomerID");
            entity.Property(e => e.UDeliveryId).HasColumnName("U_DeliveryID");
            entity.Property(e => e.UEmail)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("U_Email");
            entity.Property(e => e.UName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("U_Name");
            entity.Property(e => e.UPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("U_Password");
            entity.Property(e => e.UPharmacyId).HasColumnName("U_PharmacyID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
