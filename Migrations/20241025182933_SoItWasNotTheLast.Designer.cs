﻿// <auto-generated />
using System;
using DCA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DCA.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241025182933_SoItWasNotTheLast")]
    partial class SoItWasNotTheLast
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DCA.Data.Entities.CoinPriceHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 5)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Symbol", "Date")
                        .IsUnique();

                    b.ToTable("CoinPriceHistory");
                });

            modelBuilder.Entity("DCA.Data.Entities.Investment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CoinPriceHistoryId")
                        .HasColumnType("int");

                    b.Property<decimal>("CryptoAmount")
                        .HasColumnType("decimal(18, 5)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("FiatAmount")
                        .HasColumnType("int");

                    b.Property<int?>("InvestmentSummaryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoinPriceHistoryId");

                    b.HasIndex("InvestmentSummaryId");

                    b.ToTable("Investment");
                });

            modelBuilder.Entity("DCA.Data.Entities.InvestmentSummary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Days")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("InvestmentSummary");
                });

            modelBuilder.Entity("DCA.Data.Entities.Investment", b =>
                {
                    b.HasOne("DCA.Data.Entities.CoinPriceHistory", null)
                        .WithMany("Investments")
                        .HasForeignKey("CoinPriceHistoryId");

                    b.HasOne("DCA.Data.Entities.InvestmentSummary", null)
                        .WithMany("Investments")
                        .HasForeignKey("InvestmentSummaryId");
                });

            modelBuilder.Entity("DCA.Data.Entities.CoinPriceHistory", b =>
                {
                    b.Navigation("Investments");
                });

            modelBuilder.Entity("DCA.Data.Entities.InvestmentSummary", b =>
                {
                    b.Navigation("Investments");
                });
#pragma warning restore 612, 618
        }
    }
}