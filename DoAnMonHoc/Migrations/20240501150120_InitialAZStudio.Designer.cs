﻿// <auto-generated />
using System;
using DoAnMonHoc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoAnMonHoc.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240501150120_InitialAZStudio")]
    partial class InitialAZStudio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DoAnMonHoc.Models.Booking", b =>
                {
                    b.Property<int>("Madatlich")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Madatlich"), 1L, 1);

                    b.Property<string>("Diachi")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ghichu")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Hovaten")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Magoichup")
                        .HasColumnType("int");

                    b.Property<DateTime>("Ngaydukienchup")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sđt")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Tengoichup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Thoigianlienheit")
                        .HasColumnType("datetime2");

                    b.Property<int>("photopackageMagoichup")
                        .HasColumnType("int");

                    b.HasKey("Madatlich");

                    b.HasIndex("photopackageMagoichup");

                    b.ToTable("booking");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.ChiTietDonDatHang", b =>
                {
                    b.Property<string>("MaChiTiet")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<float>("DonGia")
                        .HasColumnType("real");

                    b.Property<string>("MaDonDatHang")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MaSanPham")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("SoLuongSanPhamMua")
                        .HasColumnType("int");

                    b.Property<string>("TenLoaiSanPham")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<double>("TongTien")
                        .HasColumnType("float");

                    b.HasKey("MaChiTiet");

                    b.HasIndex("MaDonDatHang");

                    b.HasIndex("MaSanPham");

                    b.ToTable("chiTietDonDatHangs");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.ChiTietHoaDon", b =>
                {
                    b.Property<int>("MaChiTietHD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaChiTietHD"), 1L, 1);

                    b.Property<string>("DonDatHangMaDonDatHang")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MaHoaDon")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MaSanPham")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TongTien")
                        .HasColumnType("float");

                    b.HasKey("MaChiTietHD");

                    b.HasIndex("DonDatHangMaDonDatHang");

                    b.HasIndex("MaHoaDon");

                    b.HasIndex("MaSanPham");

                    b.ToTable("chiTietHoaDons");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.Comment", b =>
                {
                    b.Property<int>("MaComment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaComment"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("LuotSaoDanhGia")
                        .HasColumnType("int");

                    b.Property<string>("MaSanPham")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("NgayCmt")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("MaComment");

                    b.HasIndex("MaSanPham");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.DonDatHang", b =>
                {
                    b.Property<string>("MaDonDatHang")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("GhiChu")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("MaKhachHang")
                        .HasColumnType("int");

                    b.Property<int>("MaThanhToan")
                        .HasColumnType("int");

                    b.Property<int>("MaTrangThai")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayDatHang")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayGiaoHang")
                        .HasColumnType("datetime2");

                    b.Property<float>("PhiVanChuyen")
                        .HasColumnType("real");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("MaDonDatHang");

                    b.HasIndex("MaKhachHang");

                    b.HasIndex("MaThanhToan");

                    b.HasIndex("MaTrangThai");

                    b.ToTable("DonDatHangs");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.HoaDon", b =>
                {
                    b.Property<string>("MaHoaDon")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaKhachHang")
                        .HasColumnType("int");

                    b.Property<int>("MaThanhToan")
                        .HasColumnType("int");

                    b.Property<int>("MaTrangThai")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayDat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayGiaoDuKien")
                        .HasColumnType("datetime2");

                    b.Property<double>("PhiVanChuyen")
                        .HasColumnType("float");

                    b.Property<string>("PhuongThucThanhToan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("khachHangMaKhachHang")
                        .HasColumnType("int");

                    b.Property<double>("tongTien")
                        .HasColumnType("float");

                    b.HasKey("MaHoaDon");

                    b.HasIndex("MaThanhToan");

                    b.HasIndex("MaTrangThai");

                    b.HasIndex("khachHangMaKhachHang");

                    b.ToTable("hoaDons");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.KhachHang", b =>
                {
                    b.Property<int>("MaKhachHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKhachHang"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("DienThoai")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MaVaiTro")
                        .HasColumnType("int");

                    b.Property<string>("TenDangNhap")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("MaKhachHang");

                    b.HasIndex("MaVaiTro");

                    b.ToTable("KhachHangs");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.MessageCustomerVisit", b =>
                {
                    b.Property<int>("MaTinNhan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTinNhan"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("TinNhan")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("MaTinNhan");

                    b.ToTable("messageCustomerVisit");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.NhaCungCap", b =>
                {
                    b.Property<string>("MaNhaCungCap")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DiaChi")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Logo")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("TenNguoiLienLac")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenNhaCungCap")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("MaNhaCungCap");

                    b.ToTable("nhaCungCaps");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.Photopackage", b =>
                {
                    b.Property<int>("Magoichup")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Magoichup"), 1L, 1);

                    b.Property<string>("Tengoichup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Magoichup");

                    b.ToTable("photopackage");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.Product", b =>
                {
                    b.Property<string>("MaSanPham")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<string>("Hinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaLoai")
                        .HasColumnType("int");

                    b.Property<string>("MaNhaCungCap")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MaSize")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgaySanXuat")
                        .HasColumnType("date");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongBan")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongXem")
                        .HasColumnType("int");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("MaSanPham");

                    b.HasIndex("MaLoai");

                    b.HasIndex("MaNhaCungCap");

                    b.HasIndex("MaSize");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.ProductCategory", b =>
                {
                    b.Property<int>("MaLoai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaLoai"), 1L, 1);

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaLoai");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.ProductImageDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("MaSanPham")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MaSanPham");

                    b.ToTable("ProductImageDetail");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.Size", b =>
                {
                    b.Property<int>("MaSize")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaSize"), 1L, 1);

                    b.Property<string>("TenSize")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("MaSize");

                    b.ToTable("sizes");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.ThanhToan", b =>
                {
                    b.Property<int>("MaThanhToan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaThanhToan"), 1L, 1);

                    b.Property<string>("PhuongThucThanhToan")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("MaThanhToan");

                    b.ToTable("thanhToans");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.TrangThai", b =>
                {
                    b.Property<int>("MaTrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTrangThai"), 1L, 1);

                    b.Property<string>("TenTrangThai")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaTrangThai");

                    b.ToTable("TrangThais");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.VaiTro", b =>
                {
                    b.Property<int>("MaVaiTro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaVaiTro"), 1L, 1);

                    b.Property<string>("TenVaiTro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaVaiTro");

                    b.ToTable("vaiTros");
                });

            modelBuilder.Entity("DoAnMonHoc.ViewModel.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.Booking", b =>
                {
                    b.HasOne("DoAnMonHoc.Models.Photopackage", "photopackage")
                        .WithMany()
                        .HasForeignKey("photopackageMagoichup")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("photopackage");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.ChiTietDonDatHang", b =>
                {
                    b.HasOne("DoAnMonHoc.Models.DonDatHang", "DonDatHang")
                        .WithMany("ChiTietDonDatHangs")
                        .HasForeignKey("MaDonDatHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnMonHoc.Models.Product", "Product")
                        .WithMany("ChiTietDonDatHangs")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonDatHang");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.ChiTietHoaDon", b =>
                {
                    b.HasOne("DoAnMonHoc.Models.DonDatHang", null)
                        .WithMany("ChiTietHoaDons")
                        .HasForeignKey("DonDatHangMaDonDatHang");

                    b.HasOne("DoAnMonHoc.Models.HoaDon", "HoaDon")
                        .WithMany()
                        .HasForeignKey("MaHoaDon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnMonHoc.Models.Product", "Product")
                        .WithMany("ChiTietHoaDons")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HoaDon");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.Comment", b =>
                {
                    b.HasOne("DoAnMonHoc.Models.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.DonDatHang", b =>
                {
                    b.HasOne("DoAnMonHoc.Models.KhachHang", "KhachHang")
                        .WithMany("DonDatHangs")
                        .HasForeignKey("MaKhachHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnMonHoc.Models.ThanhToan", "ThanhToan")
                        .WithMany("DonDatHangs")
                        .HasForeignKey("MaThanhToan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnMonHoc.Models.TrangThai", "TrangThai")
                        .WithMany("DonDatHangs")
                        .HasForeignKey("MaTrangThai")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang");

                    b.Navigation("ThanhToan");

                    b.Navigation("TrangThai");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.HoaDon", b =>
                {
                    b.HasOne("DoAnMonHoc.Models.ThanhToan", "ThanhToan")
                        .WithMany("HoaDons")
                        .HasForeignKey("MaThanhToan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnMonHoc.Models.TrangThai", "TrangThai")
                        .WithMany("HoaDons")
                        .HasForeignKey("MaTrangThai")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnMonHoc.Models.KhachHang", "khachHang")
                        .WithMany("HoaDons")
                        .HasForeignKey("khachHangMaKhachHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ThanhToan");

                    b.Navigation("TrangThai");

                    b.Navigation("khachHang");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.KhachHang", b =>
                {
                    b.HasOne("DoAnMonHoc.Models.VaiTro", "VaiTro")
                        .WithMany("KhachHangs")
                        .HasForeignKey("MaVaiTro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VaiTro");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.Product", b =>
                {
                    b.HasOne("DoAnMonHoc.Models.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("MaLoai")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnMonHoc.Models.NhaCungCap", "NhaCungCap")
                        .WithMany("Products")
                        .HasForeignKey("MaNhaCungCap")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnMonHoc.Models.Size", "Size")
                        .WithMany("Products")
                        .HasForeignKey("MaSize")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NhaCungCap");

                    b.Navigation("ProductCategory");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.ProductImageDetail", b =>
                {
                    b.HasOne("DoAnMonHoc.Models.Product", "Product")
                        .WithMany("HinhAnhChiTiet")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.DonDatHang", b =>
                {
                    b.Navigation("ChiTietDonDatHangs");

                    b.Navigation("ChiTietHoaDons");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.KhachHang", b =>
                {
                    b.Navigation("DonDatHangs");

                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.NhaCungCap", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.Product", b =>
                {
                    b.Navigation("ChiTietDonDatHangs");

                    b.Navigation("ChiTietHoaDons");

                    b.Navigation("Comments");

                    b.Navigation("HinhAnhChiTiet");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.Size", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.ThanhToan", b =>
                {
                    b.Navigation("DonDatHangs");

                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.TrangThai", b =>
                {
                    b.Navigation("DonDatHangs");

                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("DoAnMonHoc.Models.VaiTro", b =>
                {
                    b.Navigation("KhachHangs");
                });
#pragma warning restore 612, 618
        }
    }
}
