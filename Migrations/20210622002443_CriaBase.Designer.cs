﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Teste_Paschoalott_Back_End.Data;

namespace Teste_Paschoalott_Back_End.Migrations
{
    [DbContext(typeof(TestePaschoalottoContext))]
    [Migration("20210622002443_CriaBase")]
    partial class CriaBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Teste_Paschoalott_Back_End.Models.Parcela", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<long>("NumeroParcela")
                        .HasColumnType("bigint");

                    b.Property<long?>("TituloId")
                        .HasColumnType("bigint");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("TituloId");

                    b.ToTable("Parcelas");
                });

            modelBuilder.Entity("Teste_Paschoalott_Back_End.Models.Titulo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CpfDevedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeDevedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NumeroTitulo")
                        .HasColumnType("bigint");

                    b.Property<double>("PercentualJuros")
                        .HasColumnType("float");

                    b.Property<double>("PercentualMulta")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Titulos");
                });

            modelBuilder.Entity("Teste_Paschoalott_Back_End.Models.Parcela", b =>
                {
                    b.HasOne("Teste_Paschoalott_Back_End.Models.Titulo", null)
                        .WithMany("Parcelas")
                        .HasForeignKey("TituloId");
                });

            modelBuilder.Entity("Teste_Paschoalott_Back_End.Models.Titulo", b =>
                {
                    b.Navigation("Parcelas");
                });
#pragma warning restore 612, 618
        }
    }
}