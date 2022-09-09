﻿// <auto-generated />
using System;
using LostNelsonFound.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LostNelsonFound.Migrations
{
    [DbContext(typeof(DBCONTEX))]
    [Migration("20210628205626_pql")]
    partial class pql
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LostNelsonFound.Models.DataModel.BankCardModel", b =>
                {
                    b.Property<Guid>("BankCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FoundId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("iniatials")
                        .HasColumnType("int");

                    b.HasKey("BankCardId");

                    b.HasIndex("FoundId");

                    b.ToTable("BankCards");
                });

            modelBuilder.Entity("LostNelsonFound.Models.DataModel.CampusModel", b =>
                {
                    b.Property<Guid>("CampusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Campus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CampusId");

                    b.ToTable("Campus");
                });

            modelBuilder.Entity("LostNelsonFound.Models.DataModel.CategoryLostModel", b =>
                {
                    b.Property<Guid>("CategoryLostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryLostName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryLostId");

                    b.ToTable("Categoryx");
                });

            modelBuilder.Entity("LostNelsonFound.Models.DataModel.CategoryModel", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categorys");
                });

            modelBuilder.Entity("LostNelsonFound.Models.DataModel.ClaimModel", b =>
                {
                    b.Property<Guid>("ClaimId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FoundId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("StudentStaffNo")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClaimId");

                    b.HasIndex("FoundId");

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("LostNelsonFound.Models.DataModel.FoundModel", b =>
                {
                    b.Property<Guid>("FoundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateFound")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PhotoFound")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("StatuseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FoundId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PersonId");

                    b.HasIndex("StatuseId");

                    b.ToTable("Founds");
                });

            modelBuilder.Entity("LostNelsonFound.Models.DataModel.IdentityCardModel", b =>
                {
                    b.Property<Guid>("IdentyCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FoundId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Suname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("iniatials")
                        .HasColumnType("int");

                    b.HasKey("IdentyCardId");

                    b.HasIndex("FoundId");

                    b.ToTable("IdentityCards");
                });

            modelBuilder.Entity("LostNelsonFound.Models.DataModel.ImageModel", b =>
                {
                    b.Property<Guid>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FoundId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ImageId");

                    b.HasIndex("FoundId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("LostNelsonFound.Models.DataModel.LostModel", b =>
                {
                    b.Property<Guid>("LostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CampusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryLostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateFound")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LostDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LostDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StatuseLostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("tip")
                        .HasColumnType("int");

                    b.HasKey("LostId");

                    b.HasIndex("CampusId");

                    b.HasIndex("CategoryLostId");

                    b.HasIndex("PersonId");

                    b.HasIndex("StatuseLostId");

                    b.ToTable("Foundx");
                });

            modelBuilder.Entity("LostNelsonFound.Models.DataModel.PersonModel", b =>
                {
                    b.Property<Guid>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("LostNelsonFound.Models.DataModel.StatuseLostModel", b =>
                {
                    b.Property<Guid>("StatuseLostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LostStatuse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatuseLostId");

                    b.ToTable("Statusex");
                });

            modelBuilder.Entity("LostNelsonFound.Models.DataModel.StatuseModel", b =>
                {
                    b.Property<Guid>("StatuseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Statuse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatuseId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("LostNelsonFound.Models.DataModel.StudentCardModel", b =>
                {
                    b.Property<Guid>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CampusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FoundId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StudentNo")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Suname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("iniatials")
                        .HasColumnType("int");

                    b.Property<int>("staffStudentModel")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.HasIndex("CampusId");

                    b.HasIndex("FoundId");

                    b.ToTable("StudentCards");
                });

            modelBuilder.Entity("LostNelsonFound.Models.DataModel.UserPlusModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("LostNelsonFound.Models.DataModel.BankCardModel", b =>
                {
                    b.HasOne("LostNelsonFound.Models.DataModel.FoundModel", "FoundModel")
                        .WithMany()
                        .HasForeignKey("FoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoundModel");
                });

            modelBuilder.Entity("LostNelsonFound.Models.DataModel.ClaimModel", b =>
                {
                    b.HasOne("LostNelsonFound.Models.DataModel.FoundModel", "FoundModel")
                        .WithMany()
                        .HasForeignKey("FoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoundModel");
                });

            modelBuilder.Entity("LostNelsonFound.Models.DataModel.FoundModel", b =>
                {
                    b.HasOne("LostNelsonFound.Models.DataModel.CategoryModel", "CategoryModel")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LostNelsonFound.Models.DataModel.PersonModel", "PersonModel")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LostNelsonFound.Models.DataModel.StatuseModel", "statuseModel")
                        .WithMany()
                        .HasForeignKey("StatuseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryModel");

                    b.Navigation("PersonModel");

                    b.Navigation("statuseModel");
                });

            modelBuilder.Entity("LostNelsonFound.Models.DataModel.IdentityCardModel", b =>
                {
                    b.HasOne("LostNelsonFound.Models.DataModel.FoundModel", "FoundModel")
                        .WithMany()
                        .HasForeignKey("FoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoundModel");
                });

            modelBuilder.Entity("LostNelsonFound.Models.DataModel.ImageModel", b =>
                {
                    b.HasOne("LostNelsonFound.Models.DataModel.FoundModel", "FoundModel")
                        .WithMany()
                        .HasForeignKey("FoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoundModel");
                });

            modelBuilder.Entity("LostNelsonFound.Models.DataModel.LostModel", b =>
                {
                    b.HasOne("LostNelsonFound.Models.DataModel.CampusModel", "CampusModel")
                        .WithMany()
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LostNelsonFound.Models.DataModel.CategoryLostModel", "CategoryModel")
                        .WithMany()
                        .HasForeignKey("CategoryLostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LostNelsonFound.Models.DataModel.PersonModel", "PersonModel")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LostNelsonFound.Models.DataModel.StatuseLostModel", "statuseModel")
                        .WithMany()
                        .HasForeignKey("StatuseLostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CampusModel");

                    b.Navigation("CategoryModel");

                    b.Navigation("PersonModel");

                    b.Navigation("statuseModel");
                });

            modelBuilder.Entity("LostNelsonFound.Models.DataModel.StudentCardModel", b =>
                {
                    b.HasOne("LostNelsonFound.Models.DataModel.CampusModel", "CampusModel")
                        .WithMany()
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LostNelsonFound.Models.DataModel.FoundModel", "FoundModel")
                        .WithMany()
                        .HasForeignKey("FoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CampusModel");

                    b.Navigation("FoundModel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("LostNelsonFound.Models.DataModel.UserPlusModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("LostNelsonFound.Models.DataModel.UserPlusModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LostNelsonFound.Models.DataModel.UserPlusModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("LostNelsonFound.Models.DataModel.UserPlusModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
