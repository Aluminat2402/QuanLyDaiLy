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
            SeedDonViTinh(modelBuilder);
            SeedLoaiDaiLy(modelBuilder);
            SeedDaiLy(modelBuilder);
            SeedMatHang(modelBuilder);
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
                new ChiTietPhieuXuat { MaChiTietPhieuXuat = 3, MaPhieuXuat = 1, MaMatHang = 51, SoLuongXuat = 29, DonGia = 27220, ThanhTien = 789380 }
                
            );
        }

        private static void SeedMatHang(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MatHang>().HasData(
                // 1-3: Original mat hang
                new
                {
                    MaMatHang = 1,
                    TenMatHang = "Gạo",
                    MaDonViTinh = 1,
                    SoLuongTon = 7500
                },
                new
                {
                    MaMatHang = 2,
                    TenMatHang = "Nước ngọt",
                    MaDonViTinh = 5,
                    SoLuongTon = 8500
                },
                new
                {
                    MaMatHang = 3,
                    TenMatHang = "Mì tôm",
                    MaDonViTinh = 3,
                    SoLuongTon = 5500
                },
                // 4-23: Additional mat hang
                new
                {
                    MaMatHang = 4,
                    TenMatHang = "Đường",
                    MaDonViTinh = 1,
                    SoLuongTon = 8500
                },
                new
                {
                    MaMatHang = 5,
                    TenMatHang = "Muối",
                    MaDonViTinh = 1,
                    SoLuongTon = 5500
                },
                new
                {
                    MaMatHang = 6,
                    TenMatHang = "Bột giặt",
                    MaDonViTinh = 3,
                    SoLuongTon = 9500
                },
                new
                {
                    MaMatHang = 7,
                    TenMatHang = "Nước mắm",
                    MaDonViTinh = 5,
                    SoLuongTon = 80000
                },
                new
                {
                    MaMatHang = 8,
                    TenMatHang = "Dầu ăn",
                    MaDonViTinh = 5,
                    SoLuongTon = 8000
                },
                new
                {
                    MaMatHang = 9,
                    TenMatHang = "Sữa tươi",
                    MaDonViTinh = 5,
                    SoLuongTon = 7009
                },
                new
                {
                    MaMatHang = 10,
                    TenMatHang = "Bánh kẹo",
                    MaDonViTinh = 2,
                    SoLuongTon = 6000
                },
                new
                {
                    MaMatHang = 11,
                    TenMatHang = "Nước rửa chén",
                    MaDonViTinh = 5,
                    SoLuongTon = 9000
                },
                new
                {
                    MaMatHang = 12,
                    TenMatHang = "Bia",
                    MaDonViTinh = 3,
                    SoLuongTon = 6000
                },
                new
                {
                    MaMatHang = 13,
                    TenMatHang = "Nước suối",
                    MaDonViTinh = 5,
                    SoLuongTon = 7000
                },
                new
                {
                    MaMatHang = 14,
                    TenMatHang = "Bột ngọt",
                    MaDonViTinh = 1,
                    SoLuongTon = 9888
                },
                new
                {
                    MaMatHang = 15,
                    TenMatHang = "Giấy vệ sinh",
                    MaDonViTinh = 3,
                    SoLuongTon = 7600
                },
                new
                {
                    MaMatHang = 16,
                    TenMatHang = "Khăn giấy",
                    MaDonViTinh = 2,
                    SoLuongTon = 8500
                },
                new
                {
                    MaMatHang = 17,
                    TenMatHang = "Nước tương",
                    MaDonViTinh = 5,
                    SoLuongTon = 10000
                },
                new
                {
                    MaMatHang = 18,
                    TenMatHang = "Tương ớt",
                    MaDonViTinh = 5,
                    SoLuongTon = 9000
                },
                new
                {
                    MaMatHang = 19,
                    TenMatHang = "Bột canh",
                    MaDonViTinh = 1,
                    SoLuongTon = 8000
                },
                new
                {
                    MaMatHang = 20,
                    TenMatHang = "Dầu gội",
                    MaDonViTinh = 5,
                    SoLuongTon = 5000
                },
                new
                {
                    MaMatHang = 21,
                    TenMatHang = "Sữa tắm",
                    MaDonViTinh = 5,
                    SoLuongTon = 6000
                },
                new
                {
                    MaMatHang = 22,
                    TenMatHang = "Kem đánh răng",
                    MaDonViTinh = 2,
                    SoLuongTon = 9086
                },
                new
                {
                    MaMatHang = 23,
                    TenMatHang = "Cafe",
                    MaDonViTinh = 1,
                    SoLuongTon = 8005
                },
                // 24-100 : thêm 77 mặt hàng mới
                new
                {
                    MaMatHang = 24,
                    TenMatHang = "Khoai tây",
                    MaDonViTinh = 1,
                    SoLuongTon = 9569
                },
                new
                {
                    MaMatHang = 25,
                    TenMatHang = "Cà rốt",
                    MaDonViTinh = 1,
                    SoLuongTon = 8238
                },
                new
                {
                    MaMatHang = 26,
                    TenMatHang = "Hành tây",
                    MaDonViTinh = 1,
                    SoLuongTon = 7173
                },
                new
                {
                    MaMatHang = 27,
                    TenMatHang = "Ớt chuông",
                    MaDonViTinh = 1,
                    SoLuongTon = 9473
                },
                new
                {
                    MaMatHang = 28,
                    TenMatHang = "Bắp cải",
                    MaDonViTinh = 1,
                    SoLuongTon = 5886
                },
                new
                {
                    MaMatHang = 29,
                    TenMatHang = "Rau muống",
                    MaDonViTinh = 1,
                    SoLuongTon = 8324
                },
                new
                {
                    MaMatHang = 30,
                    TenMatHang = "Măng tây",
                    MaDonViTinh = 1,
                    SoLuongTon = 9391
                },
                new
                {
                    MaMatHang = 31,
                    TenMatHang = "Bông cải xanh",
                    MaDonViTinh = 1,
                    SoLuongTon = 7706
                },
                new
                {
                    MaMatHang = 32,
                    TenMatHang = "Dưa chuột",
                    MaDonViTinh = 1,
                    SoLuongTon = 6424
                },
                new
                {
                    MaMatHang = 33,
                    TenMatHang = "Bí đỏ",
                    MaDonViTinh = 1,
                    SoLuongTon = 7356
                },
                new
                {
                    MaMatHang = 34,
                    TenMatHang = "Cải bó xôi",
                    MaDonViTinh = 1,
                    SoLuongTon = 9912
                },
                new
                {
                    MaMatHang = 35,
                    TenMatHang = "Gừng",
                    MaDonViTinh = 1,
                    SoLuongTon = 5982
                },
                new
                {
                    MaMatHang = 36,
                    TenMatHang = "Tỏi",
                    MaDonViTinh = 1,
                    SoLuongTon = 8970
                },
                new
                {
                    MaMatHang = 37,
                    TenMatHang = "Chanh",
                    MaDonViTinh = 1,
                    SoLuongTon = 7001
                },
                new
                {
                    MaMatHang = 38,
                    TenMatHang = "Dứa",
                    MaDonViTinh = 1,
                    SoLuongTon = 6311
                },
                new
                {
                    MaMatHang = 39,
                    TenMatHang = "Xoài",
                    MaDonViTinh = 1,
                    SoLuongTon = 7998
                },
                new
                {
                    MaMatHang = 40,
                    TenMatHang = "Dưa hấu",
                    MaDonViTinh = 1,
                    SoLuongTon = 6632
                },
                new
                {
                    MaMatHang = 41,
                    TenMatHang = "Đu đủ",
                    MaDonViTinh = 1,
                    SoLuongTon = 7329
                },
                new
                {
                    MaMatHang = 42,
                    TenMatHang = "Dâu tây",
                    MaDonViTinh = 1,
                    SoLuongTon = 6798
                },
                new
                {
                    MaMatHang = 43,
                    TenMatHang = "Việt quất",
                    MaDonViTinh = 1,
                    SoLuongTon = 9622
                },
                new
                {
                    MaMatHang = 44,
                    TenMatHang = "Thịt bò",
                    MaDonViTinh = 1,
                    SoLuongTon = 8092
                },
                new
                {
                    MaMatHang = 45,
                    TenMatHang = "Thịt heo",
                    MaDonViTinh = 1,
                    SoLuongTon = 9508
                },
                new
                {
                    MaMatHang = 46,
                    TenMatHang = "Thịt gà",
                    MaDonViTinh = 1,
                    SoLuongTon = 6439
                },
                new
                {
                    MaMatHang = 47,
                    TenMatHang = "Cá hồi",
                    MaDonViTinh = 1,
                    SoLuongTon = 8422
                },
                new
                {
                    MaMatHang = 48,
                    TenMatHang = "Cá ngừ",
                    MaDonViTinh = 1,
                    SoLuongTon = 6570
                },
                new
                {
                    MaMatHang = 49,
                    TenMatHang = "Tôm",
                    MaDonViTinh = 1,
                    SoLuongTon = 7901
                },
                new
                {
                    MaMatHang = 50,
                    TenMatHang = "Cua",
                    MaDonViTinh = 1,
                    SoLuongTon = 7350
                },
                new
                {
                    MaMatHang = 51,
                    TenMatHang = "Mực",
                    MaDonViTinh = 1,
                    SoLuongTon = 6155
                },
                new
                {
                    MaMatHang = 52,
                    TenMatHang = "Mật ong",
                    MaDonViTinh = 5,
                    SoLuongTon = 6738
                },
                new
                {
                    MaMatHang = 53,
                    TenMatHang = "Nước khoáng",
                    MaDonViTinh = 5,
                    SoLuongTon = 5954
                },
                new
                {
                    MaMatHang = 54,
                    TenMatHang = "Nước tăng lực",
                    MaDonViTinh = 5,
                    SoLuongTon = 7564
                },
                new
                {
                    MaMatHang = 55,
                    TenMatHang = "Nước dừa",
                    MaDonViTinh = 5,
                    SoLuongTon = 8077
                },
                new
                {
                    MaMatHang = 56,
                    TenMatHang = "Nước cam",
                    MaDonViTinh = 4,
                    SoLuongTon = 5269
                },
                new
                {
                    MaMatHang = 57,
                    TenMatHang = "Trà sữa",
                    MaDonViTinh = 5,
                    SoLuongTon = 7489
                },
                new
                {
                    MaMatHang = 58,
                    TenMatHang = "Trà đào",
                    MaDonViTinh = 5,
                    SoLuongTon = 5492
                },
                new
                {
                    MaMatHang = 59,
                    TenMatHang = "Trà chanh",
                    MaDonViTinh = 5,
                    SoLuongTon = 5928
                },
                new
                {
                    MaMatHang = 60,
                    TenMatHang = "Nước ép cà rốt",
                    MaDonViTinh = 4,
                    SoLuongTon = 9939
                },
                new
                {
                    MaMatHang = 61,
                    TenMatHang = "Nước ép dưa hấu",
                    MaDonViTinh = 4,
                    SoLuongTon = 8384
                },
                new
                {
                    MaMatHang = 62,
                    TenMatHang = "Bia không cồn",
                    MaDonViTinh = 5,
                    SoLuongTon = 9562
                },
                new
                {
                    MaMatHang = 63,
                    TenMatHang = "Bia lon",
                    MaDonViTinh = 5,
                    SoLuongTon = 9384
                },
                new
                {
                    MaMatHang = 64,
                    TenMatHang = "Bia chai lớn",
                    MaDonViTinh = 5,
                    SoLuongTon = 8224
                },
                new
                {
                    MaMatHang = 65,
                    TenMatHang = "Rượu vang đỏ",
                    MaDonViTinh = 5,
                    SoLuongTon = 9839
                },
                new
                {
                    MaMatHang = 66,
                    TenMatHang = "Rượu vang trắng",
                    MaDonViTinh = 5,
                    SoLuongTon = 5136
                },
                new
                {
                    MaMatHang = 67,
                    TenMatHang = "Rượu gạo",
                    MaDonViTinh = 5,
                    SoLuongTon = 9810
                },
                new
                {
                    MaMatHang = 68,
                    TenMatHang = "Rượu trắng",
                    MaDonViTinh = 5,
                    SoLuongTon = 6367
                },
                new
                {
                    MaMatHang = 69,
                    TenMatHang = "Rượu nếp",
                    MaDonViTinh = 5,
                    SoLuongTon = 7126
                },
                new
                {
                    MaMatHang = 70,
                    TenMatHang = "Dầu ô-liu",
                    MaDonViTinh = 5,
                    SoLuongTon = 9546
                },
                new
                {
                    MaMatHang = 71,
                    TenMatHang = "Dầu mè",
                    MaDonViTinh = 5,
                    SoLuongTon = 8149
                },
                new
                {
                    MaMatHang = 72,
                    TenMatHang = "Dầu hướng dương",
                    MaDonViTinh = 5,
                    SoLuongTon = 9092
                },
                new
                {
                    MaMatHang = 73,
                    TenMatHang = "Giấm táo",
                    MaDonViTinh = 5,
                    SoLuongTon = 7324
                },
                new
                {
                    MaMatHang = 74,
                    TenMatHang = "Giấm gạo",
                    MaDonViTinh = 5,
                    SoLuongTon = 8977
                },
                new
                {
                    MaMatHang = 75,
                    TenMatHang = "Cà chua",
                    MaDonViTinh = 1,
                    SoLuongTon = 6463
                },
                new
                {
                    MaMatHang = 76,
                    TenMatHang = "Ớt cay",
                    MaDonViTinh = 1,
                    SoLuongTon = 8854
                },
                new
                {
                    MaMatHang = 77,
                    TenMatHang = "Hạt điều",
                    MaDonViTinh = 1,
                    SoLuongTon = 9781
                },
                new
                {
                    MaMatHang = 78,
                    TenMatHang = "Hạt bí",
                    MaDonViTinh = 1,
                    SoLuongTon = 9938
                },
                new
                {
                    MaMatHang = 79,
                    TenMatHang = "Hạt dẻ",
                    MaDonViTinh = 1,
                    SoLuongTon = 5281
                },
                new
                {
                    MaMatHang = 80,
                    TenMatHang = "Ngô ngọt",
                    MaDonViTinh = 1,
                    SoLuongTon = 8512
                },
                new
                {
                    MaMatHang = 81,
                    TenMatHang = "Bột sắn",
                    MaDonViTinh = 1,
                    SoLuongTon = 5986
                },
                new
                {
                    MaMatHang = 82,
                    TenMatHang = "Tương đậu nành",
                    MaDonViTinh = 5,
                    SoLuongTon = 5275
                },
                new
                {
                    MaMatHang = 83,
                    TenMatHang = "Nước súc miệng",
                    MaDonViTinh = 5,
                    SoLuongTon = 6450
                },
                new
                {
                    MaMatHang = 84,
                    TenMatHang = "Kem dưỡng da",
                    MaDonViTinh = 5,
                    SoLuongTon = 8428
                },
                new
                {
                    MaMatHang = 85,
                    TenMatHang = "Bánh đa",
                    MaDonViTinh = 2,
                    SoLuongTon = 6025
                },
                new
                {
                    MaMatHang = 86,
                    TenMatHang = "Bánh phở",
                    MaDonViTinh = 2,
                    SoLuongTon = 6714
                },
                new
                {
                    MaMatHang = 87,
                    TenMatHang = "Bắp rang",
                    MaDonViTinh = 2,
                    SoLuongTon = 9699
                },
                new
                {
                    MaMatHang = 88,
                    TenMatHang = "Bột chiên xù",
                    MaDonViTinh = 1,
                    SoLuongTon = 9867
                },
                new
                {
                    MaMatHang = 89,
                    TenMatHang = "Sốt BBQ",
                    MaDonViTinh = 5,
                    SoLuongTon = 6308
                },
                new
                {
                    MaMatHang = 90,
                    TenMatHang = "Tỏi băm",
                    MaDonViTinh = 1,
                    SoLuongTon = 8923
                },
                new
                {
                    MaMatHang = 91,
                    TenMatHang = "Hành phi",
                    MaDonViTinh = 1,
                    SoLuongTon = 6811
                },
                new
                {
                    MaMatHang = 92,
                    TenMatHang = "Muối tiêu chanh",
                    MaDonViTinh = 1,
                    SoLuongTon = 5264
                },
                new
                {
                    MaMatHang = 93,
                    TenMatHang = "Gia vị nấu phở",
                    MaDonViTinh = 1,
                    SoLuongTon = 9104
                },
                new
                {
                    MaMatHang = 94,
                    TenMatHang = "Dầu đậu nành",
                    MaDonViTinh = 5,
                    SoLuongTon = 7958
                },
                new
                {
                    MaMatHang = 95,
                    TenMatHang = "Xúc xích Đức",
                    MaDonViTinh = 2,
                    SoLuongTon = 6935
                },
                new
                {
                    MaMatHang = 96,
                    TenMatHang = "Thịt xông khói",
                    MaDonViTinh = 2,
                    SoLuongTon = 7513
                },
                new
                {
                    MaMatHang = 97,
                    TenMatHang = "Phô mai que",
                    MaDonViTinh = 2,
                    SoLuongTon = 9917
                },
                new
                {
                    MaMatHang = 98,
                    TenMatHang = "Bánh quy mặn",
                    MaDonViTinh = 2,
                    SoLuongTon = 9349
                },
                new
                {
                    MaMatHang = 99,
                    TenMatHang = "Bánh quy ngọt",
                    MaDonViTinh = 2,
                    SoLuongTon = 6794
                },
                new
                {
                    MaMatHang = 100,
                    TenMatHang = "Bánh pía",
                    MaDonViTinh = 2,
                    SoLuongTon = 7160
                }

            );
        }

        private static void SeedDonViTinh(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonViTinh>().HasData(
                new DonViTinh { MaDonViTinh = 1, TenDonViTinh = "Kg" },
                new DonViTinh { MaDonViTinh = 2, TenDonViTinh = "Cái" },
                new DonViTinh { MaDonViTinh = 3, TenDonViTinh = "Thùng" },
                new DonViTinh { MaDonViTinh = 4, TenDonViTinh = "Lít" },
                new DonViTinh { MaDonViTinh = 5, TenDonViTinh = "Chai" }
            );
        }

    }
}
