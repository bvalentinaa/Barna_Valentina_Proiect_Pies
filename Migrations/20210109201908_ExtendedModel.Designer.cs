﻿// <auto-generated />
using System;
using Barna_Valentina_Proiect_Pies.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Barna_Valentina_Proiect_Pies.Migrations
{
    [DbContext(typeof(PieContext))]
    [Migration("20210109201908_ExtendedModel")]
    partial class ExtendedModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Barna_Valentina_Proiect_Pies.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Barna_Valentina_Proiect_Pies.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PieID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("PieID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Barna_Valentina_Proiect_Pies.Models.Pie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Pie");
                });

            modelBuilder.Entity("Barna_Valentina_Proiect_Pies.Models.RetailedPie", b =>
                {
                    b.Property<int>("PieID")
                        .HasColumnType("int");

                    b.Property<int>("RetailerID")
                        .HasColumnType("int");

                    b.HasKey("PieID", "RetailerID");

                    b.HasIndex("RetailerID");

                    b.ToTable("RetailedPie");
                });

            modelBuilder.Entity("Barna_Valentina_Proiect_Pies.Models.Retailer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adress")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("RetailerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Retailer");
                });

            modelBuilder.Entity("Barna_Valentina_Proiect_Pies.Models.Order", b =>
                {
                    b.HasOne("Barna_Valentina_Proiect_Pies.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Barna_Valentina_Proiect_Pies.Models.Pie", "Pie")
                        .WithMany("Orders")
                        .HasForeignKey("PieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Pie");
                });

            modelBuilder.Entity("Barna_Valentina_Proiect_Pies.Models.RetailedPie", b =>
                {
                    b.HasOne("Barna_Valentina_Proiect_Pies.Models.Pie", "Pie")
                        .WithMany("RetailedPies")
                        .HasForeignKey("PieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Barna_Valentina_Proiect_Pies.Models.Retailer", "Retailer")
                        .WithMany("RetailedBooks")
                        .HasForeignKey("RetailerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pie");

                    b.Navigation("Retailer");
                });

            modelBuilder.Entity("Barna_Valentina_Proiect_Pies.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Barna_Valentina_Proiect_Pies.Models.Pie", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("RetailedPies");
                });

            modelBuilder.Entity("Barna_Valentina_Proiect_Pies.Models.Retailer", b =>
                {
                    b.Navigation("RetailedBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
