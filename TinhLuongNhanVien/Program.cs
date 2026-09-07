namespace TinhLuongNhanVien
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            NhanVien nv1 = new NhanVien();

            nv1.HoTen = "Nguyễn Văn An";
            nv1.LuongCoBan = 6000000;
            nv1.SoNgayLam = 26;

            NhanVien nv2 = new NhanVien(
                "NV002",
                "Trần Thị Bình"
            );

            nv2.LuongCoBan = 7000000;
            nv2.SoNgayLam = 24;

            NhanVien nv3 = new NhanVien(
                "NV003",
                "Lê Văn Cường",
                8000000,
                28,
                1
            );

            NhanVien nv4 = new NhanVien(
                maNV: "NV004",
                hoTen: "Phạm Văn Dũng",
                soNgayLam: 20
            );

            Console.WriteLine("========== THÔNG TIN NHÂN VIÊN ==========\n");
            Console.WriteLine("6551071033");
            HienThiNhanVien(nv1);
            HienThiNhanVien(nv2);
            HienThiNhanVien(nv3);
            HienThiNhanVien(nv4);

            Console.WriteLine("\n========== TÍNH THƯỞNG ==========");

            Console.WriteLine("\nNhân viên: " + nv1.HoTen);

            Console.WriteLine(
                $"TinhThuong(): {nv1.TinhThuong():N0} VND"
            );

            Console.WriteLine(
                $"TinhThuong(0.1): {nv1.TinhThuong(0.1m):N0} VND"
            );

            Console.WriteLine(
                $"TinhThuong(0.1, true): " +
                $"{nv1.TinhThuong(0.1m, true):N0} VND"
            );

            Console.WriteLine("\n========== SO SÁNH ==========");

            decimal thuong1 = nv1.TinhThuong();
            decimal thuong2 = nv1.TinhThuong(0.1m);
            decimal thuong3 = nv1.TinhThuong(0.1m, true);

            Console.WriteLine($"Thưởng cơ bản     : {thuong1:N0} VND");
            Console.WriteLine($"Thưởng theo hệ số : {thuong2:N0} VND");
            Console.WriteLine($"Thưởng + phúc lợi : {thuong3:N0} VND");

            Console.ReadKey();
        }

        static void HienThiNhanVien(NhanVien nv)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Mã NV        : {nv.MaNV}");
            Console.WriteLine($"Họ tên       : {nv.HoTen}");
            Console.WriteLine($"Lương cơ bản : {nv.LuongCoBan:N0} VND");
            Console.WriteLine($"Số ngày làm  : {nv.SoNgayLam}");
            Console.WriteLine($"Nghỉ phép    : {nv.SoNgayNghiPhep}");
            Console.WriteLine($"Thực nhận    : {nv.LuongThucNhan:N0} VND");
            Console.WriteLine("----------------------------------------");
        }

        class NhanVien
        {
            private string _maNV;
            private string _hoTen;
            private decimal _luongCoBan;
            private int _soNgayLam;
            private int _soNgayNghiPhep;

            public NhanVien()
            {
                _maNV = "";
                _hoTen = "";
                _luongCoBan = 5000000;
                _soNgayLam = 26;
                _soNgayNghiPhep = 0;
            }

            public NhanVien(string maNV, string hoTen)
            {
                _maNV = maNV;
                HoTen = hoTen;
                _luongCoBan = 5000000;
                _soNgayLam = 26;
                _soNgayNghiPhep = 0;
            }

            public NhanVien(
                string maNV,
                string hoTen,
                decimal luongCoBan,
                int soNgayLam,
                int soNgayNghiPhep)
            {
                _maNV = maNV;
                HoTen = hoTen;
                LuongCoBan = luongCoBan;
                SoNgayLam = soNgayLam;

                if (soNgayNghiPhep < 0)
                {
                    throw new ArgumentException(
                        "Số ngày nghỉ phép không được âm."
                    );
                }

                _soNgayNghiPhep = soNgayNghiPhep;
            }

            public NhanVien(
                string maNV,
                string hoTen,
                decimal luong = 5_000_000,
                int soNgayLam = 26)
            {
                _maNV = maNV;
                HoTen = hoTen;
                LuongCoBan = luong;
                SoNgayLam = soNgayLam;
                _soNgayNghiPhep = 0;
            }

            public string MaNV
            {
                get { return _maNV; }
            }

            public string HoTen
            {
                get { return _hoTen; }
                set { _hoTen = value; }
            }

            public decimal LuongCoBan
            {
                get { return _luongCoBan; }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException(
                            "Lương cơ bản không được nhỏ hơn 0."
                        );
                    }

                    _luongCoBan = value;
                }
            }

            public int SoNgayLam
            {
                get { return _soNgayLam; }
                set
                {
                    if (value < 0 || value > 31)
                    {
                        throw new ArgumentException(
                            "Số ngày làm phải từ 0 đến 31."
                        );
                    }

                    _soNgayLam = value;
                }
            }

            public int SoNgayNghiPhep
            {
                get { return _soNgayNghiPhep; }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException(
                            "Số ngày nghỉ phép không được âm."
                        );
                    }

                    _soNgayNghiPhep = value;
                }
            }

            public decimal LuongThucNhan
            {
                get
                {
                    decimal khauTruBHXH = LuongCoBan * 0.08m;

                    return LuongCoBan / 26m * SoNgayLam
                           - khauTruBHXH;
                }
            }

            public decimal TinhThuong()
            {
                return 0;
            }

            public decimal TinhThuong(decimal heSo)
            {
                return LuongCoBan * heSo;
            }

            public decimal TinhThuong(decimal heSo, bool coPhucLoi)
            {
                decimal thuong = LuongCoBan * heSo;

                if (coPhucLoi)
                {
                    thuong += 500000;
                }

                return thuong;
            }
        }
    }
}