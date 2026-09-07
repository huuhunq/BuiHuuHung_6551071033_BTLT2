using System;
using System.Collections.Generic;

namespace QuanLySanPhamCuaHang
{
    class SanPham
    {
        private string _maSP;
        private string _tenSP;
        private decimal _gia;
        private int _soLuongTon;

        // Property
        public string MaSP
        {
            get { return _maSP; }
            set { _maSP = value; }
        }

        public string TenSP
        {
            get { return _tenSP; }
            set { _tenSP = value; }
        }

        public decimal Gia
        {
            get { return _gia; }
            set { _gia = value; }
        }

        public int SoLuongTon
        {
            get { return _soLuongTon; }
            set { _soLuongTon = value; }
        }

        // Constructor đầy đủ
        public SanPham(string maSP, string tenSP, decimal gia, int soLuongTon)
        {
            _maSP = maSP;
            _tenSP = tenSP;
            _gia = gia;
            _soLuongTon = soLuongTon;
        }

        // Tính giá bán
        public virtual decimal TinhGiaBan()
        {
            return _gia;
        }

        // Mô tả sản phẩm
        public virtual string MoTa()
        {
            return $"Mã SP: {_maSP}, Tên SP: {_tenSP}, Giá: {_gia:N0} VNĐ, " +
                   $"Số lượng tồn: {_soLuongTon}";
        }
    }


    class SanPhamThucPham : SanPham
    {
        private DateTime _ngayHetHan;
        private int _nhietDoBaoQuan;

        public DateTime NgayHetHan
        {
            get { return _ngayHetHan; }
            set { _ngayHetHan = value; }
        }

        public int NhietDoBaoQuan
        {
            get { return _nhietDoBaoQuan; }
            set { _nhietDoBaoQuan = value; }
        }

        // Constructor gọi base()
        public SanPhamThucPham(
            string maSP,
            string tenSP,
            decimal gia,
            int soLuongTon,
            DateTime ngayHetHan,
            int nhietDoBaoQuan)
            : base(maSP, tenSP, gia, soLuongTon)
        {
            _ngayHetHan = ngayHetHan;
            _nhietDoBaoQuan = nhietDoBaoQuan;
        }

        // Override TinhGiaBan
        public override decimal TinhGiaBan()
        {
            int soNgayConLai = (_ngayHetHan.Date - DateTime.Now.Date).Days;

            // Nếu còn 3 ngày hoặc ít hơn thì giảm 30%
            if (soNgayConLai <= 3 && soNgayConLai >= 0)
            {
                return Gia * 0.7m;
            }

            return Gia;
        }

        // Override MoTa
        public override string MoTa()
        {
            return $"[THỰC PHẨM] Mã SP: {MaSP}, " +
                   $"Tên SP: {TenSP}, " +
                   $"Giá gốc: {Gia:N0} VNĐ, " +
                   $"Giá bán: {TinhGiaBan():N0} VNĐ, " +
                   $"Số lượng tồn: {SoLuongTon}, " +
                   $"Hết hạn: {NgayHetHan:dd/MM/yyyy}, " +
$"Nhiệt độ bảo quản: {NhietDoBaoQuan}°C";
        }
    }

    class SanPhamDienTu : SanPham
    {
        private int _baoHanhThang;
        private string _hangSanXuat;

        public int BaoHanhThang
        {
            get { return _baoHanhThang; }
            set { _baoHanhThang = value; }
        }

        public string HangSanXuat
        {
            get { return _hangSanXuat; }
            set { _hangSanXuat = value; }
        }

        public SanPhamDienTu(
            string maSP,
            string tenSP,
            decimal gia,
            int soLuongTon,
            int baoHanhThang,
            string hangSanXuat)
            : base(maSP, tenSP, gia, soLuongTon)
        {
            _baoHanhThang = baoHanhThang;
            _hangSanXuat = hangSanXuat;
        }

        // Override TinhGiaBan
        public override decimal TinhGiaBan()
        {
            // Nếu bảo hành > 12 tháng thì cộng thêm 10%
            if (_baoHanhThang > 12)
            {
                return Gia * 1.1m;
            }

            return Gia;
        }

        // Override MoTa
        public override string MoTa()
        {
            return $"[ĐIỆN TỬ] Mã SP: {MaSP}, " +
                   $"Tên SP: {TenSP}, " +
                   $"Giá gốc: {Gia:N0} VNĐ, " +
                   $"Giá bán: {TinhGiaBan():N0} VNĐ, " +
                   $"Số lượng tồn: {SoLuongTon}, " +
                   $"Bảo hành: {BaoHanhThang} tháng, " +
                   $"Hãng sản xuất: {HangSanXuat}";
        }
    }


    // =========================
    // PROGRAM
    // =========================
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // List chứa hỗn hợp 3 loại đối tượng
            List<SanPham> danhSach = new List<SanPham>
            {
                // Object Initializer
                new SanPham("SP001", "Nước suối", 10000m, 50),

                new SanPhamThucPham(
                    "TP001",
                    "Sữa tươi",
                    30000m,
                    20,
                    DateTime.Now.AddDays(2),
                    4),

                new SanPhamThucPham(
                    "TP002",
                    "Bánh mì",
                    20000m,
                    30,
                    DateTime.Now.AddDays(10),
                    25),

                new SanPhamDienTu(
                    "DT001",
                    "Tai nghe Bluetooth",
                    500000m,
                    10,
                    24,
                    "Sony"),

                new SanPhamDienTu(
                    "DT002",
                    "Chuột máy tính",
                    300000m,
                    15,
                    12,
                    "Logitech")
            };

            decimal tongGiaTriKho = 0;
            Console.WriteLine("========== DANH SÁCH SẢN PHẨM ==========\n");

            // foreach gọi phương thức đa hình
            foreach (SanPham sp in danhSach)
            {
                Console.WriteLine(sp.MoTa());
                Console.WriteLine($"Giá bán thực tế: {sp.TinhGiaBan():N0} VNĐ");

                // Giá trị kho = giá bán x số lượng tồn
                tongGiaTriKho += sp.TinhGiaBan() * sp.SoLuongTon;

                Console.WriteLine("------------------------------------------");
            }

            Console.WriteLine();
            Console.WriteLine("========== TỔNG GIÁ TRỊ KHO ==========");
            Console.WriteLine($"Tổng giá trị kho hàng: {tongGiaTriKho:N0} VNĐ");
            Console.WriteLine("6551071033");
            Console.ReadKey();
        }
    }
}
