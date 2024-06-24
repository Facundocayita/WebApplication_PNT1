﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication_PNT1.Context;

#nullable disable

namespace WebApplication_PNT1.Migrations
{
    [DbContext(typeof(WebAppDatabaseContext))]
    [Migration("20240623221948_Pedido_enlazadoCon_Proyecto")]
    partial class Pedido_enlazadoCon_Proyecto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.HasKey("IdPedido");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("WebApplication_PNT1.Models.Proyecto", b =>
                {
                    b.Property<int>("IdProyecto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProyecto"));

                    b.Property<double>("Alto")
                        .HasColumnType("float");

                    b.Property<double>("Ancho")
                        .HasColumnType("float");

                    b.Property<int>("CantColores")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaPedido")
                        .HasColumnType("datetime2");

                    b.Property<double>("Groso")
                        .HasColumnType("float");

                    b.Property<int?>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("IdProyecto");

                    b.HasIndex("PedidoId");

                    b.ToTable("Proyectos");
                });

            modelBuilder.Entity("WebApplication_PNT1.Models.Proyecto", b =>
                {
                    b.HasOne("WebApplication_PNT1.Models.Pedido", "Pedido")
                        .WithMany("Proyectos")
                        .HasForeignKey("PedidoId");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("WebApplication_PNT1.Models.Pedido", b =>
                {
                    b.Navigation("Proyectos");
                });
#pragma warning restore 612, 618
        }
    }
}
