﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SelfieAWookies.Core.Selfies.Infrastructures.Data;

namespace SelfieAWookies.Core.Selfies.Data.Migrations.Migrations
{
    [DbContext(typeof(SelfiesContext))]
    partial class SelfiesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SelfieAWookies.Core.Selfies.Domain.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("SelfieAWookies.Core.Selfies.Domain.Selfie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PictureId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WookieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PictureId");

                    b.HasIndex("WookieId");

                    b.ToTable("Selfie");
                });

            modelBuilder.Entity("SelfieAWookies.Core.Selfies.Domain.Wookie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Wookie");
                });

            modelBuilder.Entity("SelfieAWookies.Core.Selfies.Domain.Selfie", b =>
                {
                    b.HasOne("SelfieAWookies.Core.Selfies.Domain.Picture", "Picture")
                        .WithMany("Selfies")
                        .HasForeignKey("PictureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SelfieAWookies.Core.Selfies.Domain.Wookie", "Wookie")
                        .WithMany("Selfies")
                        .HasForeignKey("WookieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Picture");

                    b.Navigation("Wookie");
                });

            modelBuilder.Entity("SelfieAWookies.Core.Selfies.Domain.Picture", b =>
                {
                    b.Navigation("Selfies");
                });

            modelBuilder.Entity("SelfieAWookies.Core.Selfies.Domain.Wookie", b =>
                {
                    b.Navigation("Selfies");
                });
#pragma warning restore 612, 618
        }
    }
}