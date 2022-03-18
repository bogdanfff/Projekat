﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace WebProj.Migrations
{
    [DbContext(typeof(MuzejContext))]
    [Migration("20220316050929_v7")]
    partial class v7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("Models.Karta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BrojRezervacije")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("MuzejID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("MuzejID");

                    b.ToTable("Karta");
                });

            modelBuilder.Entity("Models.Muzej", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Muzej");
                });

            modelBuilder.Entity("Models.Predmet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Era")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("Godina")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<int?>("MuzejID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Tip")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Tvorac")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("MuzejID");

                    b.ToTable("Predmet");
                });

            modelBuilder.Entity("Models.Karta", b =>
                {
                    b.HasOne("Models.Muzej", "Muzej")
                        .WithMany("Karte")
                        .HasForeignKey("MuzejID");

                    b.Navigation("Muzej");
                });

            modelBuilder.Entity("Models.Predmet", b =>
                {
                    b.HasOne("Models.Muzej", "Muzej")
                        .WithMany("Predmeti")
                        .HasForeignKey("MuzejID");

                    b.Navigation("Muzej");
                });

            modelBuilder.Entity("Models.Muzej", b =>
                {
                    b.Navigation("Karte");

                    b.Navigation("Predmeti");
                });
#pragma warning restore 612, 618
        }
    }
}