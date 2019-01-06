﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Searcher.Context;

namespace Searcher.Migrations
{
    [DbContext(typeof(ShronContext))]
    [Migration("20190106120453_Add data")]
    partial class Adddata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Searcher.Domain.Dict", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Ident");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Dicts");
                });

            modelBuilder.Entity("Searcher.Domain.DictItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("DictId");

                    b.Property<string>("Ident");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DictId");

                    b.ToTable("DictItems");
                });

            modelBuilder.Entity("Searcher.Domain.Dimension", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("DictId");

                    b.Property<int?>("DictItemId");

                    b.Property<string>("Name");

                    b.Property<int>("TechIndId");

                    b.HasKey("Id");

                    b.HasIndex("DictId");

                    b.HasIndex("DictItemId");

                    b.HasIndex("TechIndId");

                    b.ToTable("Dimensions");
                });

            modelBuilder.Entity("Searcher.Domain.Indicator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Ident");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Indicators");
                });

            modelBuilder.Entity("Searcher.Domain.IndicatorValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateLoad");

                    b.Property<int>("TechIndId");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("TechIndId");

                    b.ToTable("IndicatorValues");
                });

            modelBuilder.Entity("Searcher.Domain.TechnicalIndicator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IndId");

                    b.HasKey("Id");

                    b.HasIndex("IndId");

                    b.ToTable("TechnicalIndicators");
                });

            modelBuilder.Entity("Searcher.Domain.DictItem", b =>
                {
                    b.HasOne("Searcher.Domain.Dict", "Dict")
                        .WithMany("DictItems")
                        .HasForeignKey("DictId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Searcher.Domain.Dimension", b =>
                {
                    b.HasOne("Searcher.Domain.Dict", "Dict")
                        .WithMany()
                        .HasForeignKey("DictId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Searcher.Domain.DictItem")
                        .WithMany("Dimensions")
                        .HasForeignKey("DictItemId");

                    b.HasOne("Searcher.Domain.TechnicalIndicator", "TechnicalIndicator")
                        .WithMany("Dimensions")
                        .HasForeignKey("TechIndId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Searcher.Domain.IndicatorValue", b =>
                {
                    b.HasOne("Searcher.Domain.TechnicalIndicator", "TechnicalIndicator")
                        .WithMany("IndicatorValues")
                        .HasForeignKey("TechIndId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Searcher.Domain.TechnicalIndicator", b =>
                {
                    b.HasOne("Searcher.Domain.Indicator", "Indicator")
                        .WithMany("TechnicalIndicators")
                        .HasForeignKey("IndId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
