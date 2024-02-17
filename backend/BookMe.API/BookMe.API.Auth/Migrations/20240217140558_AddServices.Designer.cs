﻿// <auto-generated />
using System;
using BookMe.API.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookMe.API.Auth.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240217140558_AddServices")]
    partial class AddServices
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BookMe.API.Auth.Entities.Booking", b =>
                {
                    b.Property<Guid>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CustomerFirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CustomerLastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("ServiceId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("TimeEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("TimeStart")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("isCancelled")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("BookingId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("BookMe.API.Auth.Entities.Service", b =>
                {
                    b.Property<Guid>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("ServiceMembershipId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("TimeClose")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("TimeOpen")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("hasAutoConfirmation")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isFree")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("ServiceId");

                    b.HasIndex("ServiceMembershipId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("BookMe.API.Auth.Entities.ServiceMembership", b =>
                {
                    b.Property<Guid>("ServiceMembershipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("ServiceMembershipId");

                    b.HasIndex("UserId");

                    b.ToTable("ServicesMembership");
                });

            modelBuilder.Entity("BookMe.API.Auth.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BookMe.API.Auth.Entities.Booking", b =>
                {
                    b.HasOne("BookMe.API.Auth.Entities.Service", null)
                        .WithMany("Bookings")
                        .HasForeignKey("ServiceId");
                });

            modelBuilder.Entity("BookMe.API.Auth.Entities.Service", b =>
                {
                    b.HasOne("BookMe.API.Auth.Entities.ServiceMembership", null)
                        .WithMany("Services")
                        .HasForeignKey("ServiceMembershipId");
                });

            modelBuilder.Entity("BookMe.API.Auth.Entities.ServiceMembership", b =>
                {
                    b.HasOne("BookMe.API.Auth.Entities.User", null)
                        .WithMany("Memberships")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BookMe.API.Auth.Entities.Service", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("BookMe.API.Auth.Entities.ServiceMembership", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("BookMe.API.Auth.Entities.User", b =>
                {
                    b.Navigation("Memberships");
                });
#pragma warning restore 612, 618
        }
    }
}
