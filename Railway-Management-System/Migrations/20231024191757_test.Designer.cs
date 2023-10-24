﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Railway_Management_System.Models;

#nullable disable

namespace Railway_Management_System.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20231024191757_test")]
    partial class test
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Railway_Management_System.Models.RMSpassengers", b =>
                {
                    b.Property<int>("Passenger_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Passenger_Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("remember_Me")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Passenger_Id");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("Railway_Management_System.Models.stationMaster", b =>
                {
                    b.Property<int>("stationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("stationId"));

                    b.Property<string>("stationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("stationDivision")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("stationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("stationId");

                    b.ToTable("StationMasters");
                });

            modelBuilder.Entity("Railway_Management_System.Models.trainMaster", b =>
                {
                    b.Property<int>("trainNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("trainNumber"));

                    b.Property<string>("routeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("trainCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("trainName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("trainNumber");

                    b.ToTable("TrainMasters");
                });
#pragma warning restore 612, 618
        }
    }
}