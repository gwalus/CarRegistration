﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleRegistration.Data;

namespace VehicleRegistration.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210601130031_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("VehicleRegistration.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Pesel")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("VehicleRegistration.Models.Prefix", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Prefixes");
                });

            modelBuilder.Entity("VehicleRegistration.Models.RegistrationNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Number")
                        .HasColumnType("TEXT");

                    b.Property<int>("VehicleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId")
                        .IsUnique();

                    b.ToTable("RegistrationNumbers");
                });

            modelBuilder.Entity("VehicleRegistration.Models.Reputation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Opinion")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RegistrationNumberId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RegistrationNumberId");

                    b.ToTable("Reputations");
                });

            modelBuilder.Entity("VehicleRegistration.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PersonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PurchaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("VinNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("VehicleRegistration.Models.RegistrationNumber", b =>
                {
                    b.HasOne("VehicleRegistration.Models.Vehicle", "Vehicle")
                        .WithOne("RegistrationNumber")
                        .HasForeignKey("VehicleRegistration.Models.RegistrationNumber", "VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("VehicleRegistration.Models.Reputation", b =>
                {
                    b.HasOne("VehicleRegistration.Models.RegistrationNumber", "RegistrationNumber")
                        .WithMany("Reputations")
                        .HasForeignKey("RegistrationNumberId");

                    b.Navigation("RegistrationNumber");
                });

            modelBuilder.Entity("VehicleRegistration.Models.Vehicle", b =>
                {
                    b.HasOne("VehicleRegistration.Models.Person", "Person")
                        .WithMany("Vehicles")
                        .HasForeignKey("PersonId");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("VehicleRegistration.Models.Person", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("VehicleRegistration.Models.RegistrationNumber", b =>
                {
                    b.Navigation("Reputations");
                });

            modelBuilder.Entity("VehicleRegistration.Models.Vehicle", b =>
                {
                    b.Navigation("RegistrationNumber");
                });
#pragma warning restore 612, 618
        }
    }
}
