﻿// <auto-generated />
using System;
using DataLayer.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(TutorDbContext))]
    [Migration("20240619084912_UpdateDB_V8_06192024")]
    partial class UpdateDB_V8_06192024
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataLayer.Entities.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AccountId");

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountId = new Guid("975e166f-1d2b-45f1-98e1-95f511269481"),
                            Address = "Ho Chi Minh, Viet Name",
                            Email = "admin@gmail.com",
                            Fullname = "ADMIN",
                            Gender = 1,
                            Password = "admin123",
                            Phone = "0945677876",
                            RoleId = 1,
                            Username = "admin"
                        },
                        new
                        {
                            AccountId = new Guid("200ed418-8249-4f80-97a7-930bba1b046f"),
                            Address = "Ho Chi Minh, Viet Name",
                            Email = "staff@gmail.com",
                            Fullname = "STAFF",
                            Gender = 0,
                            Password = "staff123",
                            Phone = "0912377890",
                            RoleId = 2,
                            Username = "staff"
                        },
                        new
                        {
                            AccountId = new Guid("a15eda6d-b90b-45b8-8778-10cdc3719013"),
                            Address = "Ho Chi Minh, Viet Name",
                            Email = "vana@gmail.com",
                            Fullname = "Tran Van A",
                            Gender = 0,
                            Password = "@123",
                            Phone = "0978988768",
                            RoleId = 4,
                            Username = "parent1"
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.Apply", b =>
                {
                    b.Property<Guid>("ApplyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("TutorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ApplyId");

                    b.HasIndex("PostId");

                    b.HasIndex("TutorId");

                    b.ToTable("Applies");
                });

            modelBuilder.Entity("DataLayer.Entities.AppointmentFeedback", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentId"));

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("AppointmentTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExpiredDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsSuccessful")
                        .HasColumnType("bit");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid?>("TutorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AppointmentId");

                    b.HasIndex("AccountId");

                    b.HasIndex("PostId");

                    b.HasIndex("TutorId");

                    b.ToTable("AppointmentFeedbacks");
                });

            modelBuilder.Entity("DataLayer.Entities.Deposit", b =>
                {
                    b.Property<Guid>("DepositId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("DepositDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Method")
                        .HasColumnType("int");

                    b.Property<Guid>("WalletId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DepositId");

                    b.HasIndex("WalletId");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("DataLayer.Entities.PostRequest", b =>
                {
                    b.Property<Guid>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Mode")
                        .HasColumnType("int");

                    b.Property<string>("PreferredTime")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RequestSkill")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Schedule")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("PostId");

                    b.HasIndex("CreatedBy");

                    b.ToTable("PostRequests");
                });

            modelBuilder.Entity("DataLayer.Entities.Proficiency", b =>
                {
                    b.Property<int>("ProficiencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProficiencyId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProficiencyCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("ProficiencyId");

                    b.ToTable("Proficiencies");

                    b.HasData(
                        new
                        {
                            ProficiencyId = 1,
                            Description = "Basic level of proficiency",
                            ProficiencyCode = "A1"
                        },
                        new
                        {
                            ProficiencyId = 2,
                            Description = "Elementary level of proficiency",
                            ProficiencyCode = "A2"
                        },
                        new
                        {
                            ProficiencyId = 3,
                            Description = "Intermediate level of proficiency",
                            ProficiencyCode = "B1"
                        },
                        new
                        {
                            ProficiencyId = 4,
                            Description = "Upper Intermediate level of proficiency",
                            ProficiencyCode = "B2"
                        },
                        new
                        {
                            ProficiencyId = 5,
                            Description = "Advanced level of proficiency",
                            ProficiencyCode = "C1"
                        },
                        new
                        {
                            ProficiencyId = 6,
                            Description = "Proficient/native-like level of proficiency",
                            ProficiencyCode = "C2"
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.Qualification", b =>
                {
                    b.Property<Guid>("QualificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("InstitutionName")
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)");

                    b.Property<int?>("ProficiencyId")
                        .HasColumnType("int");

                    b.Property<string>("QualificationName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("QualificationType")
                        .HasColumnType("int");

                    b.Property<int?>("SkillId")
                        .HasColumnType("int");

                    b.Property<Guid>("TutorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("YearObtained")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("QualificationId");

                    b.HasIndex("ProficiencyId");

                    b.HasIndex("SkillId");

                    b.HasIndex("TutorId");

                    b.ToTable("Qualifications");
                });

            modelBuilder.Entity("DataLayer.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            RoleName = "Staff"
                        },
                        new
                        {
                            RoleId = 3,
                            RoleName = "Tutor"
                        },
                        new
                        {
                            RoleId = 4,
                            RoleName = "Parent"
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillId"));

                    b.Property<string>("SkillName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("SkillId");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            SkillId = 1,
                            SkillName = "English"
                        },
                        new
                        {
                            SkillId = 2,
                            SkillName = "Japanese"
                        },
                        new
                        {
                            SkillId = 3,
                            SkillName = "Korean"
                        },
                        new
                        {
                            SkillId = 4,
                            SkillName = "Chinese"
                        },
                        new
                        {
                            SkillId = 5,
                            SkillName = "Spanish"
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.Tutor", b =>
                {
                    b.Property<Guid>("TutorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TutorId");

                    b.HasIndex("RoleId");

                    b.ToTable("Tutors");
                });

            modelBuilder.Entity("DataLayer.Entities.Wallet", b =>
                {
                    b.Property<Guid>("WalletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<Guid>("TutorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("WalletId");

                    b.HasIndex("TutorId")
                        .IsUnique();

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("DataLayer.Entities.WalletTransaction", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<Guid?>("DepositId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<Guid>("WalletId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TransactionId");

                    b.HasIndex("DepositId");

                    b.HasIndex("WalletId");

                    b.ToTable("WalletTransactions");
                });

            modelBuilder.Entity("DataLayer.Entities.Account", b =>
                {
                    b.HasOne("DataLayer.Entities.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DataLayer.Entities.Apply", b =>
                {
                    b.HasOne("DataLayer.Entities.PostRequest", "PostRequest")
                        .WithMany("Applies")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataLayer.Entities.Tutor", "Tutor")
                        .WithMany("Applies")
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PostRequest");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("DataLayer.Entities.AppointmentFeedback", b =>
                {
                    b.HasOne("DataLayer.Entities.Account", "Account")
                        .WithMany("AppointmentFeedbacks")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("DataLayer.Entities.PostRequest", "PostRequest")
                        .WithMany("AppointmentFeedbacks")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("DataLayer.Entities.Tutor", "Tutor")
                        .WithMany("AppointmentFeedbacks")
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Account");

                    b.Navigation("PostRequest");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("DataLayer.Entities.Deposit", b =>
                {
                    b.HasOne("DataLayer.Entities.Wallet", "Wallet")
                        .WithMany("Deposits")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("DataLayer.Entities.PostRequest", b =>
                {
                    b.HasOne("DataLayer.Entities.Account", "Account")
                        .WithMany("PostRequests")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DataLayer.Entities.Qualification", b =>
                {
                    b.HasOne("DataLayer.Entities.Proficiency", "Proficiency")
                        .WithMany("Qualifications")
                        .HasForeignKey("ProficiencyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DataLayer.Entities.Skill", "Skill")
                        .WithMany("Qualifications")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DataLayer.Entities.Tutor", "Tutor")
                        .WithMany("Qualifications")
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Proficiency");

                    b.Navigation("Skill");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("DataLayer.Entities.Tutor", b =>
                {
                    b.HasOne("DataLayer.Entities.Role", "Role")
                        .WithMany("Tutors")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DataLayer.Entities.Wallet", b =>
                {
                    b.HasOne("DataLayer.Entities.Tutor", "Tutor")
                        .WithOne("Wallet")
                        .HasForeignKey("DataLayer.Entities.Wallet", "TutorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("DataLayer.Entities.WalletTransaction", b =>
                {
                    b.HasOne("DataLayer.Entities.Deposit", "Deposit")
                        .WithMany("WalletTransactions")
                        .HasForeignKey("DepositId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DataLayer.Entities.Wallet", "Wallet")
                        .WithMany("WalletTransactions")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Deposit");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("DataLayer.Entities.Account", b =>
                {
                    b.Navigation("AppointmentFeedbacks");

                    b.Navigation("PostRequests");
                });

            modelBuilder.Entity("DataLayer.Entities.Deposit", b =>
                {
                    b.Navigation("WalletTransactions");
                });

            modelBuilder.Entity("DataLayer.Entities.PostRequest", b =>
                {
                    b.Navigation("Applies");

                    b.Navigation("AppointmentFeedbacks");
                });

            modelBuilder.Entity("DataLayer.Entities.Proficiency", b =>
                {
                    b.Navigation("Qualifications");
                });

            modelBuilder.Entity("DataLayer.Entities.Role", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Tutors");
                });

            modelBuilder.Entity("DataLayer.Entities.Skill", b =>
                {
                    b.Navigation("Qualifications");
                });

            modelBuilder.Entity("DataLayer.Entities.Tutor", b =>
                {
                    b.Navigation("Applies");

                    b.Navigation("AppointmentFeedbacks");

                    b.Navigation("Qualifications");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("DataLayer.Entities.Wallet", b =>
                {
                    b.Navigation("Deposits");

                    b.Navigation("WalletTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
