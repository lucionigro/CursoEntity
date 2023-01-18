﻿// <auto-generated />
using System;
using CursoEntity.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CursoEntity.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CursoEntity.Models.Articulo", b =>
                {
                    b.Property<int>("ArticuloID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticuloID"), 1L, 1);

                    b.Property<double>("Calificacion")
                        .HasColumnType("float");

                    b.Property<int>("Categoria_Id")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("TituloArticulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Titulo");

                    b.HasKey("ArticuloID");

                    b.HasIndex("Categoria_Id");

                    b.ToTable("Articulo");
                });

            modelBuilder.Entity("CursoEntity.Models.ArticuloEtiqueta", b =>
                {
                    b.Property<int>("Etiqueta_ID")
                        .HasColumnType("int");

                    b.Property<int>("ArticuloID")
                        .HasColumnType("int");

                    b.HasKey("Etiqueta_ID", "ArticuloID");

                    b.HasIndex("ArticuloID");

                    b.ToTable("ArticuloEtiqueta");
                });

            modelBuilder.Entity("CursoEntity.Models.Categoria", b =>
                {
                    b.Property<int>("Categoria_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Categoria_Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Categoria_Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("CursoEntity.Models.DetalleUsuario", b =>
                {
                    b.Property<int>("DetalleUsuario_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleUsuario_ID"), 1L, 1);

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Deporte")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mascota")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("DetalleUsuario_ID");

                    b.ToTable("DetalleUsuario");
                });

            modelBuilder.Entity("CursoEntity.Models.Etiqueta", b =>
                {
                    b.Property<int>("Etiqueta_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Etiqueta_ID"), 1L, 1);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Etiqueta_ID");

                    b.ToTable("Etiqueta");
                });

            modelBuilder.Entity("CursoEntity.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DetalleUsuario_ID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DetalleUsuario_ID")
                        .IsUnique();

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("CursoEntity.Models.Articulo", b =>
                {
                    b.HasOne("CursoEntity.Models.Categoria", "Categoria")
                        .WithMany("Articulo")
                        .HasForeignKey("Categoria_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("CursoEntity.Models.ArticuloEtiqueta", b =>
                {
                    b.HasOne("CursoEntity.Models.Articulo", "Articulo")
                        .WithMany("ArticuloEtiqueta")
                        .HasForeignKey("ArticuloID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CursoEntity.Models.Etiqueta", "Etiqueta")
                        .WithMany("ArticuloEtiqueta")
                        .HasForeignKey("Etiqueta_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Etiqueta");
                });

            modelBuilder.Entity("CursoEntity.Models.Usuario", b =>
                {
                    b.HasOne("CursoEntity.Models.DetalleUsuario", "DetalleUsuario")
                        .WithOne("Usuario")
                        .HasForeignKey("CursoEntity.Models.Usuario", "DetalleUsuario_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DetalleUsuario");
                });

            modelBuilder.Entity("CursoEntity.Models.Articulo", b =>
                {
                    b.Navigation("ArticuloEtiqueta");
                });

            modelBuilder.Entity("CursoEntity.Models.Categoria", b =>
                {
                    b.Navigation("Articulo");
                });

            modelBuilder.Entity("CursoEntity.Models.DetalleUsuario", b =>
                {
                    b.Navigation("Usuario")
                        .IsRequired();
                });

            modelBuilder.Entity("CursoEntity.Models.Etiqueta", b =>
                {
                    b.Navigation("ArticuloEtiqueta");
                });
#pragma warning restore 612, 618
        }
    }
}
