﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PWEB_TP_A_M.Data;

namespace PWEB_TP_A_M.Migrations
{
    [DbContext(typeof(TpCodeFirstDbContext))]
    partial class TpCodeFirstDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PWEB_TP_A_M.Models.Administracao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Laboratorios")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Administracao");
                });

            modelBuilder.Entity("PWEB_TP_A_M.Models.Analises", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Analises");
                });

            modelBuilder.Entity("PWEB_TP_A_M.Models.CentroTeste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnalisesId")
                        .HasColumnType("int");

                    b.Property<string>("Horario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LimTestes")
                        .HasColumnType("int");

                    b.Property<string>("Localidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocalidadeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocalizacoesId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tecnico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TecnicosId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TecnicosId1")
                        .HasColumnType("int");

                    b.Property<int>("Vagas")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnalisesId");

                    b.HasIndex("LocalizacoesId");

                    b.HasIndex("TecnicosId1");

                    b.ToTable("CentroTeste");
                });

            modelBuilder.Entity("PWEB_TP_A_M.Models.Gestores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Centro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CentroId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CentroTesteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CentroTesteId");

                    b.ToTable("Gestores");
                });

            modelBuilder.Entity("PWEB_TP_A_M.Models.Localizacoes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo_Postal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Local")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Localizacoes");
                });

            modelBuilder.Entity("PWEB_TP_A_M.Models.Tecnicos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tecnicos");
                });

            modelBuilder.Entity("PWEB_TP_A_M.Models.CentroTeste", b =>
                {
                    b.HasOne("PWEB_TP_A_M.Models.Analises", "Analises")
                        .WithMany()
                        .HasForeignKey("AnalisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PWEB_TP_A_M.Models.Localizacoes", "Localizacoes")
                        .WithMany()
                        .HasForeignKey("LocalizacoesId");

                    b.HasOne("PWEB_TP_A_M.Models.Tecnicos", "Tecnicos")
                        .WithMany()
                        .HasForeignKey("TecnicosId1");

                    b.Navigation("Analises");

                    b.Navigation("Localizacoes");

                    b.Navigation("Tecnicos");
                });

            modelBuilder.Entity("PWEB_TP_A_M.Models.Gestores", b =>
                {
                    b.HasOne("PWEB_TP_A_M.Models.CentroTeste", "CentroTeste")
                        .WithMany()
                        .HasForeignKey("CentroTesteId");

                    b.Navigation("CentroTeste");
                });
#pragma warning restore 612, 618
        }
    }
}
