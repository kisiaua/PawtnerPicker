﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PawtnerPicker.Data;

#nullable disable

namespace PawtnerPicker.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<float>("DemeanorValue")
                        .HasColumnType("REAL");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<float>("EnergyLevelValue")
                        .HasColumnType("REAL");

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

                    b.Property<float>("SheddingValue")
                        .HasColumnType("REAL");

                    b.Property<string>("Temperament")
                        .HasColumnType("TEXT");

                    b.Property<float>("TrainabilityValue")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("DemeanorValue");

                    b.HasIndex("EnergyLevelValue");

                    b.HasIndex("GroomingFrequencyValue");

                    b.HasIndex("SheddingValue");

                    b.HasIndex("TrainabilityValue");

                    b.ToTable("Breeds");
                });

            modelBuilder.Entity("PawtnerPicker.Models.Domain.Demeanor", b =>
                {
                    b.Property<float>("DemeanorValue")
                        .HasColumnType("REAL");

                    b.Property<string>("DemeanorCategory")
                        .HasColumnType("TEXT");

                    b.HasKey("DemeanorValue");

                    b.ToTable("Demeanors");
                });

            modelBuilder.Entity("PawtnerPicker.Models.Domain.EnergyLevel", b =>
                {
                    b.Property<float>("EnergyLevelValue")
                        .HasColumnType("REAL");

                    b.Property<string>("EnergyLevelCategory")
                        .HasColumnType("TEXT");

                    b.HasKey("EnergyLevelValue");

                    b.ToTable("EnergyLevels");
                });

            modelBuilder.Entity("PawtnerPicker.Models.Domain.GroomingFrequency", b =>
                {
                    b.Property<float>("GroomingFrequencyValue")
                        .HasColumnType("REAL");

                    b.Property<string>("GroomingFrequencyCategory")
                        .HasColumnType("TEXT");

                    b.HasKey("GroomingFrequencyValue");

                    b.ToTable("GroomingFrequencies");
                });

            modelBuilder.Entity("PawtnerPicker.Models.Domain.Shedding", b =>
                {
                    b.Property<float>("SheddingValue")
                        .HasColumnType("REAL");

                    b.Property<string>("SheddingCategory")
                        .HasColumnType("TEXT");

                    b.HasKey("SheddingValue");

                    b.ToTable("Sheddings");
                });

            modelBuilder.Entity("PawtnerPicker.Models.Domain.Trainability", b =>
                {
                    b.Property<float>("TrainabilityValue")
                        .HasColumnType("REAL");

                    b.Property<string>("TrainabilityCategory")
                        .HasColumnType("TEXT");

                    b.HasKey("TrainabilityValue");

                    b.ToTable("Trainabilities");
                });

            modelBuilder.Entity("PawtnerPicker.Models.Domain.Breed", b =>
                {
                    b.HasOne("PawtnerPicker.Models.Domain.Demeanor", "Demeanor")
                        .WithMany()
                        .HasForeignKey("DemeanorValue")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawtnerPicker.Models.Domain.EnergyLevel", "EnergyLevel")
                        .WithMany()
                        .HasForeignKey("EnergyLevelValue")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawtnerPicker.Models.Domain.GroomingFrequency", "GroomingFrequency")
                        .WithMany()
                        .HasForeignKey("GroomingFrequencyValue")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawtnerPicker.Models.Domain.Shedding", "Shedding")
                        .WithMany()
                        .HasForeignKey("SheddingValue")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawtnerPicker.Models.Domain.Trainability", "Trainability")
                        .WithMany()
                        .HasForeignKey("TrainabilityValue")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Demeanor");

                    b.Navigation("EnergyLevel");

                    b.Navigation("GroomingFrequency");

                    b.Navigation("Shedding");

                    b.Navigation("Trainability");
                });
#pragma warning restore 612, 618
        }
    }
}
