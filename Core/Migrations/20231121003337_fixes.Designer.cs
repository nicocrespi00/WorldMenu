﻿// <auto-generated />
using BackendWM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendWM.Migrations
{
    [DbContext(typeof(WorldMenuContext))]
    [Migration("20231121003337_fixes")]
    partial class fixes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackendWM.Entities.Ingrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("CaloriasX100mg")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FibraX100mg")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LinkFoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PotasioX100mg")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("TieneCalcio")
                        .HasColumnType("bit");

                    b.Property<bool>("TieneYodo")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Ingrediente");
                });

            modelBuilder.Entity("BackendWM.Entities.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pais");
                });

            modelBuilder.Entity("BackendWM.Entities.Plato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdPais")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaisId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaisId");

                    b.ToTable("Plato");
                });

            modelBuilder.Entity("BackendWM.Entities.PlatoIngrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdIngrediente")
                        .HasColumnType("int");

                    b.Property<int>("IdPlato")
                        .HasColumnType("int");

                    b.Property<int>("IngredienteId")
                        .HasColumnType("int");

                    b.Property<int>("PlatoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IngredienteId");

                    b.HasIndex("PlatoId");

                    b.ToTable("PlatoIngrediente");
                });

            modelBuilder.Entity("BackendWM.Entities.Plato", b =>
                {
                    b.HasOne("BackendWM.Entities.Pais", "Pais")
                        .WithMany("Platos")
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("BackendWM.Entities.PlatoIngrediente", b =>
                {
                    b.HasOne("BackendWM.Entities.Ingrediente", "Ingrediente")
                        .WithMany("PlatoIngrediente")
                        .HasForeignKey("IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendWM.Entities.Plato", "Plato")
                        .WithMany("PlatoIngrediente")
                        .HasForeignKey("PlatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingrediente");

                    b.Navigation("Plato");
                });

            modelBuilder.Entity("BackendWM.Entities.Ingrediente", b =>
                {
                    b.Navigation("PlatoIngrediente");
                });

            modelBuilder.Entity("BackendWM.Entities.Pais", b =>
                {
                    b.Navigation("Platos");
                });

            modelBuilder.Entity("BackendWM.Entities.Plato", b =>
                {
                    b.Navigation("PlatoIngrediente");
                });
#pragma warning restore 612, 618
        }
    }
}
