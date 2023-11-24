﻿// <auto-generated />
using System;
using CustomIdentity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomIdentity.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231114072717_SeedAllClaimsForSuperAdmin")]
    partial class SeedAllClaimsForSuperAdmin
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomIdentity.Data.ApplicationUser", b =>
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
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

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "d66f3123-77d1-4109-b4ec-f11a10dafeae",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1ba95962-fc64-4f77-af4a-8f1c10777754",
                            Email = "basicuser@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            Name = "Basic User",
                            PasswordHash = "AQAAAAIAAYagAAAAEOpAsks/H9fgWXCQapNaxP/ieUGAFH4ojLwJMVTYksRhaiXkeuUzxelFnfoO8AlAzA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "921a8794-ba08-4ece-b365-41673adc1aee",
                            TwoFactorEnabled = false,
                            UserName = "basicuser@gmail.com"
                        },
                        new
                        {
                            Id = "1b9ed3c1-f32a-4b79-91dc-8ffaf3b96e8b",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6e2f5ff5-d58e-4a94-80ce-6658fd7813b7",
                            Email = "superadmin@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            Name = "Super Admin",
                            PasswordHash = "AQAAAAIAAYagAAAAEGGAFDqs5rB8jdyKZeGNQ494AuxvD06iQWiiarKIJUETJ0//pOgcfzRNx1YKtk5wKw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "961fa0cf-3fa1-4445-9b0e-2d4d188d77c0",
                            TwoFactorEnabled = false,
                            UserName = "superadmin@gmail.com"
                        });
                });

            modelBuilder.Entity("CustomIdentity.Models.Category.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CustomIdentity.Models.Category.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubcategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CustomIdentity.Models.Category.Subcategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Subcategories");
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

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "056ca257-19fc-4499-88b5-903cda6bd9d7",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "8974f75b-9037-4f8e-8aaf-4d66fbca5a01",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "0259f383-ab23-44ea-bd3f-9dcdba82b5fa",
                            Name = "SuperAdmin",
                            NormalizedName = "SUPERADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "Permission",
                            ClaimValue = "Permissions.Account.Create",
                            RoleId = "0259f383-ab23-44ea-bd3f-9dcdba82b5fa"
                        },
                        new
                        {
                            Id = 2,
                            ClaimType = "Permission",
                            ClaimValue = "Permissions.Account.View",
                            RoleId = "0259f383-ab23-44ea-bd3f-9dcdba82b5fa"
                        },
                        new
                        {
                            Id = 3,
                            ClaimType = "Permission",
                            ClaimValue = "Permissions.Account.Edit",
                            RoleId = "0259f383-ab23-44ea-bd3f-9dcdba82b5fa"
                        },
                        new
                        {
                            Id = 4,
                            ClaimType = "Permission",
                            ClaimValue = "Permissions.Account.Delete",
                            RoleId = "0259f383-ab23-44ea-bd3f-9dcdba82b5fa"
                        },
                        new
                        {
                            Id = 5,
                            ClaimType = "Permission",
                            ClaimValue = "Permissions.Product.Create",
                            RoleId = "0259f383-ab23-44ea-bd3f-9dcdba82b5fa"
                        },
                        new
                        {
                            Id = 6,
                            ClaimType = "Permission",
                            ClaimValue = "Permissions.Product.View",
                            RoleId = "0259f383-ab23-44ea-bd3f-9dcdba82b5fa"
                        },
                        new
                        {
                            Id = 7,
                            ClaimType = "Permission",
                            ClaimValue = "Permissions.Product.Edit",
                            RoleId = "0259f383-ab23-44ea-bd3f-9dcdba82b5fa"
                        },
                        new
                        {
                            Id = 8,
                            ClaimType = "Permission",
                            ClaimValue = "Permissions.Product.Delete",
                            RoleId = "0259f383-ab23-44ea-bd3f-9dcdba82b5fa"
                        },
                        new
                        {
                            Id = 9,
                            ClaimType = "Permission",
                            ClaimValue = "Permissions.Category.Create",
                            RoleId = "0259f383-ab23-44ea-bd3f-9dcdba82b5fa"
                        },
                        new
                        {
                            Id = 10,
                            ClaimType = "Permission",
                            ClaimValue = "Permissions.Category.View",
                            RoleId = "0259f383-ab23-44ea-bd3f-9dcdba82b5fa"
                        },
                        new
                        {
                            Id = 11,
                            ClaimType = "Permission",
                            ClaimValue = "Permissions.Category.Edit",
                            RoleId = "0259f383-ab23-44ea-bd3f-9dcdba82b5fa"
                        },
                        new
                        {
                            Id = 12,
                            ClaimType = "Permission",
                            ClaimValue = "Permissions.Category.Delete",
                            RoleId = "0259f383-ab23-44ea-bd3f-9dcdba82b5fa"
                        },
                        new
                        {
                            Id = 13,
                            ClaimType = "Permission",
                            ClaimValue = "Permissions.SubCategory.Create",
                            RoleId = "0259f383-ab23-44ea-bd3f-9dcdba82b5fa"
                        },
                        new
                        {
                            Id = 14,
                            ClaimType = "Permission",
                            ClaimValue = "Permissions.SubCategory.View",
                            RoleId = "0259f383-ab23-44ea-bd3f-9dcdba82b5fa"
                        },
                        new
                        {
                            Id = 15,
                            ClaimType = "Permission",
                            ClaimValue = "Permissions.SubCategory.Edit",
                            RoleId = "0259f383-ab23-44ea-bd3f-9dcdba82b5fa"
                        },
                        new
                        {
                            Id = 16,
                            ClaimType = "Permission",
                            ClaimValue = "Permissions.SubCategory.Delete",
                            RoleId = "0259f383-ab23-44ea-bd3f-9dcdba82b5fa"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
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

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "1b9ed3c1-f32a-4b79-91dc-8ffaf3b96e8b",
                            RoleId = "0259f383-ab23-44ea-bd3f-9dcdba82b5fa"
                        },
                        new
                        {
                            UserId = "1b9ed3c1-f32a-4b79-91dc-8ffaf3b96e8b",
                            RoleId = "8974f75b-9037-4f8e-8aaf-4d66fbca5a01"
                        });
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

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CustomIdentity.Models.Category.Product", b =>
                {
                    b.HasOne("CustomIdentity.Models.Category.Subcategory", "Subcategory")
                        .WithMany("Products")
                        .HasForeignKey("SubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subcategory");
                });

            modelBuilder.Entity("CustomIdentity.Models.Category.Subcategory", b =>
                {
                    b.HasOne("CustomIdentity.Models.Category.Category", "Category")
                        .WithMany("Subcategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
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
                    b.HasOne("CustomIdentity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CustomIdentity.Data.ApplicationUser", null)
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

                    b.HasOne("CustomIdentity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CustomIdentity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CustomIdentity.Models.Category.Category", b =>
                {
                    b.Navigation("Subcategories");
                });

            modelBuilder.Entity("CustomIdentity.Models.Category.Subcategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
