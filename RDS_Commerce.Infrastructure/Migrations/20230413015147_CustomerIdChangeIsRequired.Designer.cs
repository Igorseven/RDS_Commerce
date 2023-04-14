﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RDS_Commerce.Infrastructure.ORM.ContextSettings;

#nullable disable

namespace RDSCommerce.Infrastructure.Migrations
{
    [DbContext(typeof(RdsApplicationDbContext))]
    [Migration("20230413015147_CustomerIdChangeIsRequired")]
    partial class CustomerIdChangeIsRequired
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

            modelBuilder.Entity("RDS_Commerce.Domain.Entities.AccountIdentity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id_accountIdentity");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit")
                        .HasColumnName("email_confirmed");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("normalized_login");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("cell_phone");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit")
                        .HasColumnName("cell_phone_confirmed");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("date")
                        .HasColumnName("registration_date");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("login");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[normalized_login] IS NOT NULL");

                    b.ToTable("AccountIdentity", "RDS");
                });

            modelBuilder.Entity("RDS_Commerce.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id_client");

                    b.Property<bool>("AcceptTermsAndPolicy")
                        .HasColumnType("bit")
                        .HasColumnName("accept_terms_policies");

                    b.Property<DateTime>("AcceptanceOfTermsAndPolicies")
                        .HasColumnType("datetime2")
                        .HasColumnName("moment_of_acceptance_Terms_and_policies");

                    b.Property<string>("AccountIdentityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("accountIdentity_id");

                    b.Property<string>("CustomerId")
                        .HasColumnType("varchar(250)")
                        .HasColumnName("asaasCustomer_id");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("document_namber");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("full_name");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("registration_date");

                    b.Property<int>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(3)
                        .HasColumnName("role");

                    b.HasKey("UserId");

                    b.HasIndex("AccountIdentityId")
                        .IsUnique();

                    b.ToTable("Client", "RDS");
                });

            modelBuilder.Entity("RDS_Commerce.Domain.Entities.Genus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Genus");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("GenusName")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("genus_name");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Specie")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("specie");

                    b.HasKey("Id");

                    b.ToTable("Genus", "RDS");
                });

            modelBuilder.Entity("RDS_Commerce.Domain.Entities.Manager", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id_manager");

                    b.Property<string>("AccountIdentityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("accountIdentity_id");

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("active");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("full_name");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("registration_date");

                    b.Property<int>("Role")
                        .HasColumnType("int")
                        .HasColumnName("role");

                    b.HasKey("UserId");

                    b.HasIndex("AccountIdentityId")
                        .IsUnique();

                    b.ToTable("Manager", "RDS");
                });

            modelBuilder.Entity("RDS_Commerce.Domain.Entities.OrderPlant", b =>
                {
                    b.Property<int>("OrderPlantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_orderPlantId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderPlantId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int>("PlantId")
                        .HasColumnType("int")
                        .HasColumnName("plant_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("OrderPlantId");

                    b.HasIndex("OrderId");

                    b.HasIndex("PlantId");

                    b.ToTable("OrderPlant", "RDS");
                });

            modelBuilder.Entity("RDS_Commerce.Domain.Entities.Plant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_plant");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsUnicode(true)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("description");

                    SqlServerPropertyBuilderExtensions.IsSparse(b.Property<string>("Description"));

                    b.Property<int?>("GenusId")
                        .HasColumnType("int")
                        .HasColumnName("genus_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("name");

                    b.Property<int>("PlantType")
                        .HasColumnType("int")
                        .HasColumnName("plant_type");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("price");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("registration_date");

                    b.Property<int>("VaseSize")
                        .HasColumnType("int")
                        .HasColumnName("vase_size");

                    b.HasKey("Id");

                    b.HasIndex("GenusId");

                    b.ToTable("Plant", "RDS");
                });

            modelBuilder.Entity("RDS_Commerce.Domain.Entities.PlantImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_fileImage");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("FileBytes")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("file_bytes");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("file_extension");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("file_name");

                    b.Property<bool>("MainImage")
                        .HasColumnType("bit")
                        .HasColumnName("main_image");

                    b.Property<int>("PlantId")
                        .HasColumnType("int")
                        .HasColumnName("plant_id");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("registration_date");

                    b.HasKey("Id");

                    b.HasIndex("PlantId");

                    b.ToTable("PlantImage", "RDS");
                });

            modelBuilder.Entity("RDS_Commerce.Domain.Entities.PurchaseOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_order");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("amount");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int")
                        .HasColumnName("order_status");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("PurchaseOrder", "RDS");
                });

            modelBuilder.Entity("RDS_Commerce.Domain.Entities.ShippingAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_shippingAddress");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(70)")
                        .HasColumnName("city");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("client_id");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("complement");

                    b.Property<string>("Country")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("country");

                    b.Property<string>("District")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(70)")
                        .HasColumnName("district");

                    b.Property<string>("Number")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("number");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("SelectedForShipping")
                        .HasColumnType("bit")
                        .HasColumnName("selected_for_shipping");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("char(2)")
                        .HasColumnName("state");

                    b.Property<string>("Street")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("street");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("zip_code");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ShippingAddress", "RDS");
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
                    b.HasOne("RDS_Commerce.Domain.Entities.AccountIdentity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RDS_Commerce.Domain.Entities.AccountIdentity", null)
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

                    b.HasOne("RDS_Commerce.Domain.Entities.AccountIdentity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RDS_Commerce.Domain.Entities.AccountIdentity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RDS_Commerce.Domain.Entities.Client", b =>
                {
                    b.HasOne("RDS_Commerce.Domain.Entities.AccountIdentity", "AccountIdentity")
                        .WithOne()
                        .HasForeignKey("RDS_Commerce.Domain.Entities.Client", "AccountIdentityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountIdentity");
                });

            modelBuilder.Entity("RDS_Commerce.Domain.Entities.Manager", b =>
                {
                    b.HasOne("RDS_Commerce.Domain.Entities.AccountIdentity", "AccountIdentity")
                        .WithOne()
                        .HasForeignKey("RDS_Commerce.Domain.Entities.Manager", "AccountIdentityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountIdentity");
                });

            modelBuilder.Entity("RDS_Commerce.Domain.Entities.OrderPlant", b =>
                {
                    b.HasOne("RDS_Commerce.Domain.Entities.PurchaseOrder", "Order")
                        .WithMany("OrderPlants")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RDS_Commerce.Domain.Entities.Plant", "Plant")
                        .WithMany("OrderPlants")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("RDS_Commerce.Domain.Entities.Plant", b =>
                {
                    b.HasOne("RDS_Commerce.Domain.Entities.Genus", "Genus")
                        .WithMany("Plants")
                        .HasForeignKey("GenusId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Genus");
                });

            modelBuilder.Entity("RDS_Commerce.Domain.Entities.PlantImage", b =>
                {
                    b.HasOne("RDS_Commerce.Domain.Entities.Plant", null)
                        .WithMany("Images")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RDS_Commerce.Domain.Entities.PurchaseOrder", b =>
                {
                    b.HasOne("RDS_Commerce.Domain.Entities.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("RDS_Commerce.Domain.Entities.ShippingAddress", b =>
                {
                    b.HasOne("RDS_Commerce.Domain.Entities.Client", null)
                        .WithMany("ShippingAddresses")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RDS_Commerce.Domain.Entities.Client", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("ShippingAddresses");
                });

            modelBuilder.Entity("RDS_Commerce.Domain.Entities.Genus", b =>
                {
                    b.Navigation("Plants");
                });

            modelBuilder.Entity("RDS_Commerce.Domain.Entities.Plant", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("OrderPlants");
                });

            modelBuilder.Entity("RDS_Commerce.Domain.Entities.PurchaseOrder", b =>
                {
                    b.Navigation("OrderPlants");
                });
#pragma warning restore 612, 618
        }
    }
}
