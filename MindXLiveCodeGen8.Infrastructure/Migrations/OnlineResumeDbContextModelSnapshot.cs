﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MindXLiveCodeGen8.Infrastructure;

#nullable disable

namespace MindXLiveCodeGen8.Infrastructure.Migrations
{
    [DbContext(typeof(OnlineResumeDbContext))]
    partial class OnlineResumeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("MindXLiveCodeGen8.Domain.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Token")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("MindXLiveCodeGen8.Domain.Entities.Resume", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Github")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LinkedIn")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Resume", (string)null);
                });

            modelBuilder.Entity("MindXLiveCodeGen8.Domain.Entities.ResumeEducation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Faculty")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Gpa")
                        .HasColumnType("REAL");

                    b.Property<int>("ResumeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("University")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("ResumeEducation", (string)null);
                });

            modelBuilder.Entity("MindXLiveCodeGen8.Domain.Entities.ResumeExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("From")
                        .HasColumnType("TEXT");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ResumeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("To")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("ResumeExperience", (string)null);
                });

            modelBuilder.Entity("MindXLiveCodeGen8.Domain.Entities.ResumeSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ResumeSkill", (string)null);
                });

            modelBuilder.Entity("ResumeResumeSkill", b =>
                {
                    b.Property<int>("ResumeSkillsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ResumesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ResumeSkillsId", "ResumesId");

                    b.HasIndex("ResumesId");

                    b.ToTable("ResumeResumeSkill");
                });

            modelBuilder.Entity("MindXLiveCodeGen8.Domain.Entities.Resume", b =>
                {
                    b.HasOne("MindXLiveCodeGen8.Domain.Entities.Account", "Account")
                        .WithMany("Resumes")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("MindXLiveCodeGen8.Domain.Entities.ResumeEducation", b =>
                {
                    b.HasOne("MindXLiveCodeGen8.Domain.Entities.Resume", "Resume")
                        .WithMany("ResumeEducations")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("MindXLiveCodeGen8.Domain.Entities.ResumeExperience", b =>
                {
                    b.HasOne("MindXLiveCodeGen8.Domain.Entities.Resume", "Resume")
                        .WithMany("ResumeExperiences")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("ResumeResumeSkill", b =>
                {
                    b.HasOne("MindXLiveCodeGen8.Domain.Entities.ResumeSkill", null)
                        .WithMany()
                        .HasForeignKey("ResumeSkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MindXLiveCodeGen8.Domain.Entities.Resume", null)
                        .WithMany()
                        .HasForeignKey("ResumesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MindXLiveCodeGen8.Domain.Entities.Account", b =>
                {
                    b.Navigation("Resumes");
                });

            modelBuilder.Entity("MindXLiveCodeGen8.Domain.Entities.Resume", b =>
                {
                    b.Navigation("ResumeEducations");

                    b.Navigation("ResumeExperiences");
                });
#pragma warning restore 612, 618
        }
    }
}
