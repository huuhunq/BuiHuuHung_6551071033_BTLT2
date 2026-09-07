using System.Text.RegularExpressions;

namespace Cau1_OOP_QuanLySachCoBan
{
    class Sach
    {
        private string _maSach;
        private string _tenSach;
        private string _tacGia;
        private int _namXuatBan;
        private double _giaBan;

        public Sach(string maSach, string tenSach, string tacGia, int namXuatBan, double giaBan)
        {
            _maSach = maSach;
            _tenSach = tenSach;
            _tacGia = tacGia;
            _namXuatBan = namXuatBan;
            _giaBan = giaBan;
        }

        public Sach()
        {
            _maSach = "";
            _tenSach = "";
            _tacGia = "";
            _namXuatBan = 1900;
            _giaBan = 0.0;
        }
        public string MaSach
        {
            get { return _maSach; }
        }
        public string TenSach
        {
            get { return _tenSach; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên sách không được rỗng.");
                _tenSach = value;
            }
        }
        public string TacGia
        {
            get { return _tacGia; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên tác giả không được rỗng.");
                _tacGia = value;
            }
        }
        public int NamXuatBan
        {
            get { return _namXuatBan; }
            set 
            {
                int namHienTai = DateTime.Now.Year;

                if (value < 1900 || value > namHienTai)
                    throw new ArgumentException(
                        $"Năm xuất bản phải từ 1900 đến {namHienTai}."
                    );

                _namXuatBan = value;
            }
        }
        public double GiaBan
        {
            get { return _giaBan; }
        }
        public void HienThiThongTin()
        {
            Console.WriteLine("===== THÔNG TIN SÁCH =====");
            Console.WriteLine("6551071033");
            Console.WriteLine($"Mã sách       : {_maSach}");
            Console.WriteLine($"Tên sách      : {_tenSach}");
            Console.WriteLine($"Tác giả       : {_tacGia}");
            Console.WriteLine($"Năm xuất bản  : {_namXuatBan}");
            Console.WriteLine($"Giá bán       : {_giaBan} VNĐ");
            Console.WriteLine("==========================");
        }
        public override string ToString()
        {
            return $"Mã sách: {_maSach}, Tên sách: {_tenSach}, Tác giả: {_tacGia}, Năm xuất bản: {_namXuatBan}, Giá bán: {_giaBan}";
        }
    }
    internal class Program
    {
    static void Main(string[] args)
        {
            Sach sach1 = new Sach("S001", "Lập trình C#", "Nguyễn Văn A", 2024, 150000);
           // sach1.HienThiThongTin();


           
            Sach sach2 = new Sach();
            sach2.TenSach = "Cơ sở dữ liệu";
            sach2.TacGia = "Trần Văn B";
            sach2.NamXuatBan = 2023;

            //sach2.HienThiThongTin();


            Sach sach3 = new Sach
            {
                TenSach = "Lập trình Java",
                TacGia = "Lê Văn C",
                NamXuatBan = 2022
            };

           // sach3.HienThiThongTin();


            try
            {
                Sach sach4 = new Sach();

                sach4.NamXuatBan = 1800; 

                sach4.HienThiThongTin();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("\nLỗi: " + ex.Message);
            }


            try
            {
                Sach sach5 = new Sach();

                sach5.NamXuatBan = DateTime.Now.Year + 1;

                //sach5.HienThiThongTin();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("\nLỗi: " + ex.Message);
            }
        }

    }
}