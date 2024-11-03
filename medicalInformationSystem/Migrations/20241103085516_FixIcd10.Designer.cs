﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using medicalInformationSystem.Data;

#nullable disable

namespace medicalInformationSystem.Migrations
{
    [DbContext(typeof(MedicalDataContext))]
    [Migration("20241103085516_FixIcd10")]
    partial class FixIcd10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("medicalInformationSystem.Data.Entities.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birthday");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_time");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<int>("Gender")
                        .HasColumnType("integer")
                        .HasColumnName("gender");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)")
                        .HasColumnName("phone");

                    b.Property<Guid>("SpecialityId")
                        .HasColumnType("uuid")
                        .HasColumnName("speciality_id");

                    b.HasKey("Id");

                    b.HasIndex("SpecialityId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("medicalInformationSystem.Data.Entities.Icd10", b =>
                {
                    b.Property<Guid?>("IdGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_guid");

                    b.Property<int>("Actual")
                        .HasColumnType("integer")
                        .HasColumnName("ACTUAL");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_time");

                    b.Property<int>("IdInt")
                        .HasColumnType("integer")
                        .HasColumnName("id_int");

                    b.Property<Guid?>("IdParentGuid")
                        .HasColumnType("uuid")
                        .HasColumnName("id_parent_guid");

                    b.Property<int>("IdParentInt")
                        .HasColumnType("integer")
                        .HasColumnName("id_parent_int");

                    b.Property<string>("McbCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("MKB_CODE");

                    b.Property<string>("McbName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("MKB_NAME");

                    b.Property<string>("RecCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("REC_CODE");

                    b.HasKey("IdGuid");

                    b.ToTable("Icd10");
                });

            modelBuilder.Entity("medicalInformationSystem.Entities.Inspection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Anamnesis")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)")
                        .HasColumnName("anamnesis");

                    b.Property<Guid?>("BaseInspectionId")
                        .HasColumnType("uuid")
                        .HasColumnName("base_inspection_id");

                    b.Property<string>("Complaints")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)")
                        .HasColumnName("complaints");

                    b.Property<int>("Conclusion")
                        .HasColumnType("integer")
                        .HasColumnName("conclusion");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_time");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<DateTime?>("DeathDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("death_date");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uuid")
                        .HasColumnName("doctor_id");

                    b.Property<DateTime?>("NextVisitDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("next_visit_date");

                    b.Property<Guid?>("PreviousInspectionId")
                        .HasColumnType("uuid")
                        .HasColumnName("previous_inspection_id");

                    b.Property<string>("Treatment")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)")
                        .HasColumnName("treatment");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Inspections");
                });

            modelBuilder.Entity("medicalInformationSystem.Entities.Speciality", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Specialities");
                });

            modelBuilder.Entity("medicalInformationSystem.Data.Entities.Doctor", b =>
                {
                    b.HasOne("medicalInformationSystem.Entities.Speciality", "Speciality")
                        .WithMany("Doctors")
                        .HasForeignKey("SpecialityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Speciality");
                });

            modelBuilder.Entity("medicalInformationSystem.Entities.Inspection", b =>
                {
                    b.HasOne("medicalInformationSystem.Data.Entities.Doctor", "Doctor")
                        .WithMany("Inspections")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("medicalInformationSystem.Data.Entities.Doctor", b =>
                {
                    b.Navigation("Inspections");
                });

            modelBuilder.Entity("medicalInformationSystem.Entities.Speciality", b =>
                {
                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}
