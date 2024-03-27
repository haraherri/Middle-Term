using System;
using System.Collections.Generic;
using System.Linq;

namespace HoGiaHuy_GiuaKy
{
    class Nguoi
    {
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string NgheNghiep { get; set; }
        public string CMND { get; set; }

        public Nguoi(string hoTen, int tuoi, string ngheNghiep, string cmnd)
        {
            HoTen = hoTen;
            Tuoi = tuoi;
            NgheNghiep = ngheNghiep;
            CMND = cmnd;
        }
    }

    // Lớp HoGiaDinh để quản lý thông tin hộ gia đình
    class HoGiaDinh
    {
        public int SoThanVien { get; set; }
        public int SoConTrai { get; set; }
        public int SoConGai { get; set; }
        public int SoNha { get; set; }
        public List<Nguoi> ThanhVien { get; set; }

        public HoGiaDinh(int soThanVien, int soConTrai, int soConGai, int soNha, List<Nguoi> thanhVien)
        {
            SoThanVien = soThanVien;
            SoConTrai = soConTrai;
            SoConGai = soConGai;
            SoNha = soNha;
            ThanhVien = thanhVien;
        }
    }

    // Lớp KhuPho để quản lý các hộ gia đình
    class KhuPho
    {
        public List<HoGiaDinh> DanhSachHoGiaDinh { get; set; }

        public KhuPho()
        {
            DanhSachHoGiaDinh = new List<HoGiaDinh>();
        }

        public void NhapHoGiaDinh()
        {
            Console.Write("Nhap so ho gia dinh: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap thong tin ho gia dinh thu {i + 1}:");
                Console.Write("Nhap so thanh vien: ");
                int soThanVien = int.Parse(Console.ReadLine());
                Console.Write("Nhap so con trai: ");
                int soConTrai = int.Parse(Console.ReadLine());
                Console.Write("Nhap so con gai: ");
                int soConGai = int.Parse(Console.ReadLine());
                Console.Write("Nhap so nha: ");
                int soNha = int.Parse(Console.ReadLine());

                List<Nguoi> thanhVien = new List<Nguoi>();
                for (int j = 0; j < soThanVien; j++)
                {
                    Console.WriteLine($"Nhap thong tin thanh vien thu {j + 1}:");
                    Console.Write("Nhap ho ten: ");
                    string hoTen = Console.ReadLine();
                    Console.Write("Nhap tuoi: ");
                    int tuoi = int.Parse(Console.ReadLine());
                    Console.Write("Nhap nghe nghiep: ");
                    string ngheNghiep = Console.ReadLine();
                    Console.Write("Nhap so CMND: ");
                    string cmnd = Console.ReadLine();

                    thanhVien.Add(new Nguoi(hoTen, tuoi, ngheNghiep, cmnd));
                }

                DanhSachHoGiaDinh.Add(new HoGiaDinh(soThanVien, soConTrai, soConGai, soNha, thanhVien));
            }
        }

        public void HienThiThongTinKhuPho()
        {
            Console.WriteLine("Thong tin cac ho gia dinh trong khu pho:");
            foreach (var hoGiaDinh in DanhSachHoGiaDinh)
            {
                Console.WriteLine($"So nha: {hoGiaDinh.SoNha}");
                Console.WriteLine($"So thanh vien: {hoGiaDinh.SoThanVien}");
                Console.WriteLine($"So con trai: {hoGiaDinh.SoConTrai}");
                Console.WriteLine($"So con gai: {hoGiaDinh.SoConGai}");
                Console.WriteLine("Thanh vien:");
                foreach (var thanhVien in hoGiaDinh.ThanhVien)
                {
                    Console.WriteLine($"Ho ten: {thanhVien.HoTen}, Tuoi: {thanhVien.Tuoi}, Nghe nghiep: {thanhVien.NgheNghiep}, CMND: {thanhVien.CMND}");
                }
                Console.WriteLine();
            }
        }

        public int TongSoThanhVien()
        {
            return DanhSachHoGiaDinh.Sum(hgd => hgd.SoThanVien);
        }

        public List<HoGiaDinh> TimHoGiaDinhCoNguoiTenHung()
        {
            return DanhSachHoGiaDinh.Where(hgd => hgd.ThanhVien.Any(tv => tv.HoTen.Contains("Hùng"))).ToList();
        }

        public void ThongKeSoConNamNu()
        {
            int tongSoConNam = DanhSachHoGiaDinh.Sum(hgd => hgd.SoConTrai);
            int tongSoConNu = DanhSachHoGiaDinh.Sum(hgd => hgd.SoConGai);

            Console.WriteLine($"Tong so con nam trong khu pho: {tongSoConNam}");
            Console.WriteLine($"Tong so con nu trong khu pho: {tongSoConNu}");
        }

        public void TimHoGiaDinhCoSoConTrai()
        {
            var hoGiaDinhCoSoConTrai = DanhSachHoGiaDinh.Where(hgd => hgd.SoConTrai >= 2);
            Console.WriteLine("Cac ho gia dinh co so con trai >= 2:");
            foreach (var hoGiaDinh in hoGiaDinhCoSoConTrai)
            {
                Console.WriteLine($"So nha: {hoGiaDinh.SoNha}, So con trai: {hoGiaDinh.SoConTrai}");
            }
        }

        public void TimHoGiaDinhCoSoConTu5Den10()
        {
            var hoGiaDinhCoSoConTu5Den10 = DanhSachHoGiaDinh.Where(hgd => hgd.SoConTrai + hgd.SoConGai >= 5 && hgd.SoConTrai + hgd.SoConGai <= 10);
            Console.WriteLine("Cac ho gia dinh co so con tu 5 den 10:");
            foreach (var hoGiaDinh in hoGiaDinhCoSoConTu5Den10)
            {
                Console.WriteLine($"So nha: {hoGiaDinh.SoNha}, So con: {hoGiaDinh.SoConTrai + hoGiaDinh.SoConGai}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            KhuPho khuPho = new KhuPho();
            khuPho.NhapHoGiaDinh();

            khuPho.HienThiThongTinKhuPho();

            int tongSoThanhVien = khuPho.TongSoThanhVien();
            Console.WriteLine($"Tong so thanh vien trong khu pho: {tongSoThanhVien}");

            List<HoGiaDinh> dsHoGiaDinhCoNguoiTenHung = khuPho.TimHoGiaDinhCoNguoiTenHung();
            Console.WriteLine("Danh sach ho gia dinh co nguoi ten Hung:");
            foreach (var hoGiaDinh in dsHoGiaDinhCoNguoiTenHung)
            {
                Console.WriteLine($"So nha: {hoGiaDinh.SoNha}");
            }

            khuPho.ThongKeSoConNamNu();

            khuPho.TimHoGiaDinhCoSoConTrai();

            khuPho.TimHoGiaDinhCoSoConTu5Den10();

            Console.ReadLine();
        }
    }
}
