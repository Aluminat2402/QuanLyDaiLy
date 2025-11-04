using Microsoft.EntityFrameworkCore;
using QuanLyDaiLy.Models;
using System;

namespace QuanLyDaiLy.Helpers
{
    public static class DatabaseSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedThamSo(modelBuilder);
            SeedQuan(modelBuilder);
            SeedLoaiDaiLy(modelBuilder);
            SeedDaiLy(modelBuilder);
            SeedPhieuXuat(modelBuilder);
            SeedChiTietPhieuXuat(modelBuilder);
        }

        private static void SeedThamSo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ThamSo>().HasData(
                new ThamSo { Id = 1, SoLuongDaiLyToiDa = 4, QuyDinhTienThuTienNo = true }
            );
        }

        private static void SeedQuan(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quan>().HasData(
                new Quan { MaQuan = 1, TenQuan = "Quận 1" }
                //Tương tự với các quận khác
            );
        }

        private static void SeedLoaiDaiLy(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiDaiLy>().HasData(
                new LoaiDaiLy { MaLoaiDaiLy = 1, TenLoaiDaiLy = "Loại 1", NoToiDa = 60_000 }
                //Tương tự với các loại đại lý khác
            );
        }

        private static void SeedDaiLy(ModelBuilder modelBuilder)
        {
            var seedDate = new DateTime(2023, 1, 1);
            modelBuilder.Entity<DaiLy>().HasData(
                new
                {
                    MaDaiLy = 1,
                    TenDaiLy = "Minh Phát",
                    MaLoaiDaiLy = 1,
                    MaQuan = 1,
                    DiaChi = "12 Nguyễn Huệ",
                    DienThoai = "0901234567",
                    Email = "MinhPhat@gmail.com",
                    NgayTiepNhan = seedDate.AddMonths(-3),
                    TienNo = 15000000L
                }
                //Tương tự với các đại lý khác
            );
        }

        private static void SeedPhieuXuat(ModelBuilder modelBuilder)
        {
            var seedDate = new DateTime(2023, 1, 1);

            modelBuilder.Entity<PhieuXuat>().HasData(
                new PhieuXuat { MaPhieuXuat = 1, MaDaiLy = 1, NgayLapPhieu = seedDate.AddDays(22), TongTriGia = 1878538 },
                new PhieuXuat { MaPhieuXuat = 2, MaDaiLy = 1, NgayLapPhieu = seedDate.AddDays(47), TongTriGia = 1003704 }
                );
        }

        private static void SeedChiTietPhieuXuat(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietPhieuXuat>().HasData(
                new ChiTietPhieuXuat { MaChiTietPhieuXuat = 1, MaPhieuXuat = 1, MaMatHang = 55, SoLuongXuat = 21, DonGia = 26233, ThanhTien = 550893 },
                new ChiTietPhieuXuat { MaChiTietPhieuXuat = 2, MaPhieuXuat = 1, MaMatHang = 4, SoLuongXuat = 13, DonGia = 41405, ThanhTien = 538265 },
                new ChiTietPhieuXuat { MaChiTietPhieuXuat = 3, MaPhieuXuat = 1, MaMatHang = 51, SoLuongXuat = 29, DonGia = 27220, ThanhTien = 789380 },
                new ChiTietPhieuXuat { MaChiTietPhieuXuat = 4, MaPhieuXuat = 2, MaMatHang = 11, SoLuongXuat = 22, DonGia = 21093, ThanhTien = 464046 },
                new ChiTietPhieuXuat { MaChiTietPhieuXuat = 5, MaPhieuXuat = 2, MaMatHang = 82, SoLuongXuat = 18, DonGia = 29981, ThanhTien = 539658 }
                );
        }
    }
}
