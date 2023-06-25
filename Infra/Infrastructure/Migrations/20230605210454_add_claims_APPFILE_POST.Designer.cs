﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(IdentityContext))]
    [Migration("20230605210454_add_claims_APPFILE_POST")]
    partial class add_claims_APPFILE_POST
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Application.AppFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AppFile", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Identity.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("__Identity_Role", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("88071f9d-4fa7-4618-9d04-6d430e121e73"),
                            Name = "ROLE_ADMIN",
                            NormalizedName = "ROLE_ADMIN"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Identity.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("__Identity_RoleClaim", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Identity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("__Identity_User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a4a90689-ff12-4cc7-a040-81e38d564959",
                            Email = "admin@admin.admin",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.ADMIN",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEDxk5EthOl3tW2BdXKdmAoxUUAvai68jo1xp7mb1Id0qfBcFB1N+vvHisZ8/TIs9Cw==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Identity.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("__Identity_UserClaim", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "CLAIM_IDENTITY_USER:GETALL",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 2,
                            ClaimType = "CLAIM_IDENTITY_USER:GETBYID",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 3,
                            ClaimType = "CLAIM_IDENTITY_USER:GETLIST",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 4,
                            ClaimType = "CLAIM_IDENTITY_ROLE:GETALL",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 5,
                            ClaimType = "CLAIM_IDENTITY_ROLE:GETBYID",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 6,
                            ClaimType = "CLAIM_IDENTITY_ROLE:GETLIST",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 7,
                            ClaimType = "CLAIM_IDENTITY_ROLECLAIM:GETALL",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 8,
                            ClaimType = "CLAIM_IDENTITY_ROLECLAIM:GETBYID",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 9,
                            ClaimType = "CLAIM_IDENTITY_ROLECLAIM:GETLIST",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 10,
                            ClaimType = "CLAIM_IDENTITY_USERCLAIM:GETALL",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 11,
                            ClaimType = "CLAIM_IDENTITY_USERCLAIM:GETBYID",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 12,
                            ClaimType = "CLAIM_IDENTITY_USERCLAIM:GETLIST",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 13,
                            ClaimType = "CLAIM_IDENTITY_USERLOGIN:GETALL",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 14,
                            ClaimType = "CLAIM_IDENTITY_USERLOGIN:GETBYID",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 15,
                            ClaimType = "CLAIM_IDENTITY_USERLOGIN:GETLIST",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 16,
                            ClaimType = "CLAIM_IDENTITY_USERROLE:GETALL",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 17,
                            ClaimType = "CLAIM_IDENTITY_USERROLE:GETBYID",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 18,
                            ClaimType = "CLAIM_IDENTITY_USERROLE:GETLIST",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 19,
                            ClaimType = "CLAIM_IDENTITY_USERTOKEN:GETALL",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 20,
                            ClaimType = "CLAIM_IDENTITY_USERTOKEN:GETBYID",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 21,
                            ClaimType = "CLAIM_IDENTITY_USERTOKEN:GETLIST",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 22,
                            ClaimType = "CLAIM_APPFILE:GETALL",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 23,
                            ClaimType = "CLAIM_APPFILE:GETBYID",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 24,
                            ClaimType = "CLAIM_APPFILE:GETLIST",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        },
                        new
                        {
                            Id = 25,
                            ClaimType = "CLAIM_APPFILE:POST_APPFILE",
                            ClaimValue = "1",
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd")
                        });
                });

            modelBuilder.Entity("Domain.Entities.Identity.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("__Identity_UserLogin", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Identity.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("__Identity_UserRole", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("d8645da5-5583-4287-9e20-51f8dd6796bd"),
                            RoleId = new Guid("88071f9d-4fa7-4618-9d04-6d430e121e73")
                        });
                });

            modelBuilder.Entity("Domain.Entities.Identity.UserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("__Identity_UserToken", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Application.AppFile", b =>
                {
                    b.HasOne("Domain.Entities.Identity.User", "CreationUser")
                        .WithMany("Files")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreationUser");
                });

            modelBuilder.Entity("Domain.Entities.Identity.RoleClaim", b =>
                {
                    b.HasOne("Domain.Entities.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Identity.UserClaim", b =>
                {
                    b.HasOne("Domain.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Identity.UserLogin", b =>
                {
                    b.HasOne("Domain.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Identity.UserRole", b =>
                {
                    b.HasOne("Domain.Entities.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Identity.UserToken", b =>
                {
                    b.HasOne("Domain.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Identity.User", b =>
                {
                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}
