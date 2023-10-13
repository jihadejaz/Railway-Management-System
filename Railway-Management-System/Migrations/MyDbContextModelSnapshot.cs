﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Railway_Management_System.Models;

#nullable disable

namespace Railway_Management_System.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Railway_Management_System.Models.RMScomplaints", b =>
                {
                    b.Property<int>("complaintId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("complaintId"));

                    b.Property<string>("complaintDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("complaintName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("complaintType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("complaintId");

                    b.ToTable("complaints");
                });

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

                    b.Property<int>("stationCode")
                        .HasColumnType("int");

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

                    b.Property<int>("routeId")
                        .HasColumnType("int");

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

                    b.HasIndex("routeId");

                    b.ToTable("TrainMasters");
                });

            modelBuilder.Entity("Railway_Management_System.Models.trainMaster", b =>
                {
                    b.HasOne("Railway_Management_System.Models.stationMaster", "stationMaster")
                        .WithMany("TrainMasters")
                        .HasForeignKey("routeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("stationMaster");
                });

            modelBuilder.Entity("Railway_Management_System.Models.stationMaster", b =>
                {
                    b.Navigation("TrainMasters");
                });
#pragma warning restore 612, 618
        }
    }
}
