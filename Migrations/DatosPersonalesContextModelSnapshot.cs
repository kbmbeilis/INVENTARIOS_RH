﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using actualizar_curp.Models;

#nullable disable

namespace actualizar_curp.Migrations
{
    [DbContext(typeof(DatosPersonalesContext))]
    partial class DatosPersonalesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("actualizar_curp.Models.empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CALLESAT")
                        .HasColumnType("TEXT");

                    b.Property<string>("CPSAT")
                        .HasColumnType("TEXT");

                    b.Property<string>("Capturo")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Celular")
                        .HasColumnType("REAL");

                    b.Property<string>("DCTO")
                        .HasColumnType("TEXT");

                    b.Property<string>("DE")
                        .HasColumnType("TEXT");

                    b.Property<string>("ESTATUSENELPADRON")
                        .HasColumnType("TEXT");

                    b.Property<string>("Escolaridad")
                        .HasColumnType("TEXT");

                    b.Property<string>("Escolaridad2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Especialidad")
                        .HasColumnType("TEXT");

                    b.Property<string>("NOMINA")
                        .HasColumnType("TEXT");

                    b.Property<string>("NOTAS")
                        .HasColumnType("TEXT");

                    b.Property<string>("NUMEROSAT")
                        .HasColumnType("TEXT");

                    b.Property<string>("OpcionesEscolaridad")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.Property<string>("calle")
                        .HasColumnType("TEXT");

                    b.Property<string>("correo")
                        .HasColumnType("TEXT");

                    b.Property<int?>("cp")
                        .HasColumnType("INTEGER");

                    b.Property<string>("curp")
                        .HasColumnType("TEXT");

                    b.Property<int>("nemp")
                        .HasColumnType("INTEGER");

                    b.Property<string>("nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("numero")
                        .HasColumnType("TEXT");

                    b.Property<string>("rfc")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("empleado");
                });
#pragma warning restore 612, 618
        }
    }
}
