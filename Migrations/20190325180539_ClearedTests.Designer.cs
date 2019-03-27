﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using adventuretimeapi;

namespace adventuretimeapi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190325180539_ClearedTests")]
    partial class ClearedTests
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("AdventureTimeAPI.Models.Character", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PlaceId");

                    b.Property<int>("age");

                    b.Property<string>("allegiance");

                    b.Property<string>("name");

                    b.Property<string>("placeOfOrigin");

                    b.Property<string>("species");

                    b.HasKey("id");

                    b.HasIndex("PlaceId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("AdventureTimeAPI.Models.Place", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("currentRuler");

                    b.Property<string>("greatestAlly");

                    b.Property<string>("name");

                    b.Property<int>("typeOfGovernment");

                    b.HasKey("id");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("AdventureTimeAPI.Models.Character", b =>
                {
                    b.HasOne("AdventureTimeAPI.Models.Place", "Place")
                        .WithMany("Characters")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
