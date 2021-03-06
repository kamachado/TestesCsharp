// <auto-generated />
using System;
using FilmesApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FilmsAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220704194906_Implementação Manager e Session 2")]
    partial class ImplementaçãoManagereSession2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FilmsAPI.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("FilmsAPI.Models.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("ManagerId");

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("FilmsAPI.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Classification")
                        .HasColumnType("int");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("FilmsAPI.Models.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("FilmsAPI.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CinemaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.HasIndex("FilmId");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("FilmsAPI.Models.Cinema", b =>
                {
                    b.HasOne("FilmsAPI.Models.Address", "Address")
                        .WithOne("Cinema")
                        .HasForeignKey("FilmsAPI.Models.Cinema", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilmsAPI.Models.Manager", "Manager")
                        .WithMany("Cinemas")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("FilmsAPI.Models.Session", b =>
                {
                    b.HasOne("FilmsAPI.Models.Cinema", "Cinema")
                        .WithMany("Session")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilmsAPI.Models.Film", "Film")
                        .WithMany("Session")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("FilmsAPI.Models.Address", b =>
                {
                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("FilmsAPI.Models.Cinema", b =>
                {
                    b.Navigation("Session");
                });

            modelBuilder.Entity("FilmsAPI.Models.Film", b =>
                {
                    b.Navigation("Session");
                });

            modelBuilder.Entity("FilmsAPI.Models.Manager", b =>
                {
                    b.Navigation("Cinemas");
                });
#pragma warning restore 612, 618
        }
    }
}
