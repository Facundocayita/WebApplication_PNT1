﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication_PNT1.Context;

#nullable disable

namespace WebApplication_PNT1.Migrations
{
    [DbContext(typeof(WebAppDatabaseContext))]
    partial class WebAppDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication_PNT1.Models.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPedido"));

                    b.Property<string>("Cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CostoTotal")
                        .HasColumnType("float");

                    b.Property<string>("DireccionEntrega")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProyectoId")
                        .HasColumnType("int");

                    b.Property<int>("TipoEntrega")
                        .HasColumnType("int");

                    b.HasKey("IdPedido");

                    b.HasIndex("ProyectoId")
                        .IsUnique();

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("WebApplication_PNT1.Models.Proyecto", b =>
                {
                    b.Property<int?>("IdProyecto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdProyecto"));

                    b.Property<double>("Alto")
                        .HasColumnType("float");

                    b.Property<double>("Ancho")
                        .HasColumnType("float");

                    b.Property<int>("CantColores")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<double>("CostoTotal")
                        .HasColumnType("float");

                    b.Property<double>("CostoUnitario")
                        .HasColumnType("float");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaPedido")
                        .HasColumnType("datetime2");

                    b.Property<double>("Groso")
                        .HasColumnType("float");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("IdProyecto");

                    b.ToTable("Proyectos");
                });

            modelBuilder.Entity("WebApplication_PNT1.Models.Pedido", b =>
                {
                    b.HasOne("WebApplication_PNT1.Models.Proyecto", "Proyecto")
                        .WithOne("Pedido")
                        .HasForeignKey("WebApplication_PNT1.Models.Pedido", "ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyecto");
                });

            modelBuilder.Entity("WebApplication_PNT1.Models.Proyecto", b =>
                {
                    b.Navigation("Pedido");
                });
#pragma warning restore 612, 618
        }
    }
}
