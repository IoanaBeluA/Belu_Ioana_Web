﻿// <auto-generated />
using System;
using Belu_Ioana_Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Belu_Ioana_Web.Migrations
{
    [DbContext(typeof(Belu_Ioana_WebContext))]
    partial class Belu_Ioana_WebContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Belu_Ioana_Web.Models.Categorie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("Belu_Ioana_Web.Models.CategorieAliment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategorieID")
                        .HasColumnType("int");

                    b.Property<int>("JurnalID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategorieID");

                    b.HasIndex("JurnalID");

                    b.ToTable("CategorieAliment");
                });

            modelBuilder.Entity("Belu_Ioana_Web.Models.Jurnal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Aliment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Calorii")
                        .HasColumnType("decimal(6,2)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Zi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Jurnal");
                });

            modelBuilder.Entity("Belu_Ioana_Web.Models.CategorieAliment", b =>
                {
                    b.HasOne("Belu_Ioana_Web.Models.Categorie", "Categorie")
                        .WithMany("CategorieAlimente")
                        .HasForeignKey("CategorieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Belu_Ioana_Web.Models.Jurnal", "Jurnal")
                        .WithMany("CategorieAlimente")
                        .HasForeignKey("JurnalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("Jurnal");
                });

            modelBuilder.Entity("Belu_Ioana_Web.Models.Categorie", b =>
                {
                    b.Navigation("CategorieAlimente");
                });

            modelBuilder.Entity("Belu_Ioana_Web.Models.Jurnal", b =>
                {
                    b.Navigation("CategorieAlimente");
                });
#pragma warning restore 612, 618
        }
    }
}
