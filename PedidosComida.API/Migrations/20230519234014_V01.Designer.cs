﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace PedidosComida.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230519234014_V01")]
    partial class V01
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("PedidosComida.Modelos.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("cedula")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("PedidosComida.Modelos.PedidoComida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClienteCedula")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ClienteIdCliente")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Total")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ClienteIdCliente");

                    b.ToTable("PedidoComida");
                });

            modelBuilder.Entity("PedidosComida.Modelos.PedidoComida", b =>
                {
                    b.HasOne("PedidosComida.Modelos.Cliente", "Cliente")
                        .WithMany("pedidos")
                        .HasForeignKey("ClienteIdCliente");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("PedidosComida.Modelos.Cliente", b =>
                {
                    b.Navigation("pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
