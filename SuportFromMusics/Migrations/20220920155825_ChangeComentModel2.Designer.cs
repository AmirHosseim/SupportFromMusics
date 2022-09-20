﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuportFromMusics.Data;

#nullable disable

namespace SuportFromMusics.Migrations
{
    [DbContext(typeof(SuportContext))]
    [Migration("20220920155825_ChangeComentModel2")]
    partial class ChangeComentModel2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SingServices.Coment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("SingDetailId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("coment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("sendTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Coment");
                });

            modelBuilder.Entity("SingServices.FollowSinger", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("SingerId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int>("songerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("songerId");

                    b.ToTable("FollowSingers");
                });

            modelBuilder.Entity("SingServices.MusicText", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("SingDetailId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("MusicTexts");
                });

            modelBuilder.Entity("SingServices.SaveSing", b =>
                {
                    b.Property<long>("SingDetailId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int>("SingDetailId1")
                        .HasColumnType("int");

                    b.HasKey("SingDetailId", "UserId");

                    b.HasIndex("SingDetailId1");

                    b.HasIndex("UserId");

                    b.ToTable("SaveSing");
                });

            modelBuilder.Entity("SingServices.SingDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long>("MusicTextId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SharedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("SingerId")
                        .HasColumnType("int");

                    b.Property<long>("SuportId")
                        .HasColumnType("bigint");

                    b.Property<int>("singTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SingerId");

                    b.HasIndex("singTypeId");

                    b.ToTable("singDetail");
                });

            modelBuilder.Entity("SingServices.Singer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("singer");
                });

            modelBuilder.Entity("SingServices.SingLike", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("SingDetailId")
                        .HasColumnType("bigint");

                    b.Property<int>("SingDetailId1")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SingDetailId1");

                    b.HasIndex("UserId");

                    b.ToTable("SingLike");
                });

            modelBuilder.Entity("SingServices.SingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("singType");
                });

            modelBuilder.Entity("SingServices.SuportedUsers", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("SuportFormId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("SuportedValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("UserId", "SuportFormId");

                    b.HasIndex("SuportFormId");

                    b.ToTable("SuportedUsers");
                });

            modelBuilder.Entity("SingServices.SuportForm", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("SingDetailId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("SuportValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Suportedvalue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("SuportForm");
                });

            modelBuilder.Entity("SuportFromMusics.Models.SingServices.SongVersies", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long?>("MusicTextId")
                        .HasColumnType("bigint");

                    b.Property<long>("SingDetailId")
                        .HasColumnType("bigint");

                    b.Property<int?>("SingDetailId1")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TextMusciId")
                        .HasColumnType("bigint");

                    b.Property<int>("VersNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MusicTextId");

                    b.HasIndex("SingDetailId1");

                    b.ToTable("SongVersies");
                });

            modelBuilder.Entity("UserServices.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFinishedSubName")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PhonNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("SingServices.Coment", b =>
                {
                    b.HasOne("UserServices.User", "user")
                        .WithMany("Coments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("SingServices.FollowSinger", b =>
                {
                    b.HasOne("UserServices.User", "user")
                        .WithMany("Following")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SingServices.Singer", "songer")
                        .WithMany("Followers")
                        .HasForeignKey("songerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("songer");

                    b.Navigation("user");
                });

            modelBuilder.Entity("SingServices.SaveSing", b =>
                {
                    b.HasOne("SingServices.SingDetail", "SingDetail")
                        .WithMany("Saves")
                        .HasForeignKey("SingDetailId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserServices.User", "User")
                        .WithMany("Saves")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SingDetail");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SingServices.SingDetail", b =>
                {
                    b.HasOne("SingServices.Singer", "singer")
                        .WithMany("singDetails")
                        .HasForeignKey("SingerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SingServices.SingType", "singType")
                        .WithMany("singDetail")
                        .HasForeignKey("singTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("singType");

                    b.Navigation("singer");
                });

            modelBuilder.Entity("SingServices.SingLike", b =>
                {
                    b.HasOne("SingServices.SingDetail", "SingDetail")
                        .WithMany("Likes")
                        .HasForeignKey("SingDetailId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserServices.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SingDetail");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SingServices.SuportedUsers", b =>
                {
                    b.HasOne("SingServices.SuportForm", "SuportForm")
                        .WithMany("SuportedUsers")
                        .HasForeignKey("SuportFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserServices.User", "User")
                        .WithMany("Supoertedusers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SuportForm");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SuportFromMusics.Models.SingServices.SongVersies", b =>
                {
                    b.HasOne("SingServices.MusicText", null)
                        .WithMany("Verses")
                        .HasForeignKey("MusicTextId");

                    b.HasOne("SingServices.SingDetail", null)
                        .WithMany("Versies")
                        .HasForeignKey("SingDetailId1");
                });

            modelBuilder.Entity("SingServices.MusicText", b =>
                {
                    b.Navigation("Verses");
                });

            modelBuilder.Entity("SingServices.SingDetail", b =>
                {
                    b.Navigation("Likes");

                    b.Navigation("Saves");

                    b.Navigation("Versies");
                });

            modelBuilder.Entity("SingServices.Singer", b =>
                {
                    b.Navigation("Followers");

                    b.Navigation("singDetails");
                });

            modelBuilder.Entity("SingServices.SingType", b =>
                {
                    b.Navigation("singDetail");
                });

            modelBuilder.Entity("SingServices.SuportForm", b =>
                {
                    b.Navigation("SuportedUsers");
                });

            modelBuilder.Entity("UserServices.User", b =>
                {
                    b.Navigation("Coments");

                    b.Navigation("Following");

                    b.Navigation("Likes");

                    b.Navigation("Saves");

                    b.Navigation("Supoertedusers");
                });
#pragma warning restore 612, 618
        }
    }
}
