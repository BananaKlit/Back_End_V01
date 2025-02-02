﻿// <auto-generated />
using System;
using BackEnd.Api.DAL.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEnd.Api.DAL.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20220806015042_myMigrations")]
    partial class myMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Back_End_V0.1.Models.Admin", b =>
                {
                    b.Property<int>("id_admin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_admin"), 1L, 1);

                    b.Property<string>("log")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_admin");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Back_End_V0.1.Models.Client", b =>
                {
                    b.Property<int>("id_client")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_client"), 1L, 1);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_client");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Back_End_V0.1.Models.Recu", b =>
                {
                    b.Property<int>("Id_recu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_recu"), 1L, 1);

                    b.Property<int>("reservationId_Reservation")
                        .HasColumnType("int");

                    b.HasKey("Id_recu");

                    b.HasIndex("reservationId_Reservation");

                    b.ToTable("Recus");
                });

            modelBuilder.Entity("Back_End_V0.1.Models.Reservation", b =>
                {
                    b.Property<int>("Id_Reservation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Reservation"), 1L, 1);

                    b.Property<int>("clientid_client")
                        .HasColumnType("int");

                    b.Property<DateTime?>("date_reservation")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<float?>("montant")
                        .IsRequired()
                        .HasColumnType("real");

                    b.Property<int>("voitureId_Voiture")
                        .HasColumnType("int");

                    b.HasKey("Id_Reservation");

                    b.HasIndex("clientid_client");

                    b.HasIndex("voitureId_Voiture");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Back_End_V0.1.Models.Voiture", b =>
                {
                    b.Property<int>("Id_Voiture")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Voiture"), 1L, 1);

                    b.Property<string>("carburant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("matricule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("modele")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Voiture");

                    b.ToTable("Voitures");
                });

            modelBuilder.Entity("Back_End_V0.1.Models.Recu", b =>
                {
                    b.HasOne("Back_End_V0.1.Models.Reservation", "reservation")
                        .WithMany()
                        .HasForeignKey("reservationId_Reservation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("reservation");
                });

            modelBuilder.Entity("Back_End_V0.1.Models.Reservation", b =>
                {
                    b.HasOne("Back_End_V0.1.Models.Client", "client")
                        .WithMany()
                        .HasForeignKey("clientid_client")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Back_End_V0.1.Models.Voiture", "voiture")
                        .WithMany()
                        .HasForeignKey("voitureId_Voiture")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("client");

                    b.Navigation("voiture");
                });
#pragma warning restore 612, 618
        }
    }
}
