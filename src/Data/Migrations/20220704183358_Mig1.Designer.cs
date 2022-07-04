﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220704183358_Mig1")]
    partial class Mig1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Objects.Expense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DateTime")
                        .HasColumnName("create_at");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("created_by");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("DateTime")
                        .HasColumnName("modified_at");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("modified_by");

                    b.Property<Guid>("PeriodId")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PeriodId");

                    b.ToTable("Expenses", (string)null);
                });

            modelBuilder.Entity("Domain.Objects.ExpenseCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DateTime")
                        .HasColumnName("create_at");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("created_by");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("DateTime")
                        .HasColumnName("modified_at");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("modified_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ExpenseCategories", (string)null);
                });

            modelBuilder.Entity("Domain.Objects.Period", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DateTime")
                        .HasColumnName("create_at");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("DateTime")
                        .HasColumnName("modified_at");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("modified_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Periods", (string)null);
                });

            modelBuilder.Entity("Domain.Objects.Expense", b =>
                {
                    b.HasOne("Domain.Objects.ExpenseCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Objects.Period", "Period")
                        .WithMany("Expenses")
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Period");
                });

            modelBuilder.Entity("Domain.Objects.Period", b =>
                {
                    b.Navigation("Expenses");
                });
#pragma warning restore 612, 618
        }
    }
}