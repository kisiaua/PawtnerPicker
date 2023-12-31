﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PawtnerPicker.Data;

#nullable disable

namespace PawtnerPicker.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230704092840_AddRoles")]
    partial class AddRoles
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0-preview.5.23280.1");

            modelBuilder.Entity("PawtnerPicker.Models.Domain.Authentication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Login")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Authentications");
                });

            modelBuilder.Entity("PawtnerPicker.Models.Domain.Breed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BreedName")
                        .HasColumnType("TEXT");

                    b.Property<string>("DemeanorCategory")
                        .HasColumnType("TEXT");

                    b.Property<float>("DemeanorValue")
                        .HasColumnType("REAL");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("EnergyLevelCategory")
                        .HasColumnType("TEXT");

                    b.Property<float>("EnergyLevelValue")
                        .HasColumnType("REAL");

                    b.Property<string>("GroomingFrequencyCategory")
                        .HasColumnType("TEXT");

                    b.Property<float>("GroomingFrequencyValue")
                        .HasColumnType("REAL");

                    b.Property<string>("Group")
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxExpectancy")
                        .HasColumnType("INTEGER");

                    b.Property<float>("MaxHeight")
                        .HasColumnType("REAL");

                    b.Property<float>("MaxWeight")
                        .HasColumnType("REAL");

                    b.Property<int>("MinExpectancy")
                        .HasColumnType("INTEGER");

                    b.Property<float>("MinHeight")
                        .HasColumnType("REAL");

                    b.Property<float>("MinWeight")
                        .HasColumnType("REAL");

                    b.Property<int>("Popularity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SheddingCategory")
                        .HasColumnType("TEXT");

                    b.Property<float>("SheddingValue")
                        .HasColumnType("REAL");

                    b.Property<string>("Temperament")
                        .HasColumnType("TEXT");

                    b.Property<string>("TrainabilityCategory")
                        .HasColumnType("TEXT");

                    b.Property<float>("TrainabilityValue")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Breeds");
                });
#pragma warning restore 612, 618
        }
    }
}
