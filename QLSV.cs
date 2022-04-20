using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DE_THI_THU_2
{
    internal class QLSV
    {
        private List<SinhVienFPOLY> _lstSinhVienFPOLY;
        private SinhVienFPOLY _sinhVienFPOLY;
        private string _input;
        int input;

        public QLSV()
        {
            _lstSinhVienFPOLY = new List<SinhVienFPOLY>();
            fakeData();
        }
        private void fakeData()
        {
            _lstSinhVienFPOLY = new List<SinhVienFPOLY> {new SinhVienFPOLY(1, "Đỗ Ngọc Huy", 1),
            new SinhVienFPOLY(2, "Nguyễn Văn A", 2)};
        }

        public void nhap()
        {
            Console.WriteLine("Mời bạn nhập số sinh viên cần thêm: ");
            _input = Console.ReadLine();
            for (int i = 0; i < Convert.ToInt32(_input); i++)
            {
                _sinhVienFPOLY = new SinhVienFPOLY();

                _sinhVienFPOLY.MSV = _lstSinhVienFPOLY.Max(c => c.MSV) + 1;
                Console.WriteLine("Mời bạn nhập họ tên");
                _sinhVienFPOLY.HoTen = Console.ReadLine();
                Console.WriteLine("Mời bạn nhập chuyên ngành:");
                _sinhVienFPOLY.ChuyenNganh = Convert.ToInt32(Console.ReadLine());
                _lstSinhVienFPOLY.Add(_sinhVienFPOLY);
                Console.WriteLine("Bạn có muốn nhập tiếp hay không(1:có/2:không): ");
                int input = Convert.ToInt32(Console.ReadLine());
                do
                {
                    switch (input)
                    {
                        case 1:
                            nhap();
                            return;
                        case 2:
                            break;
                    }
                } while (!(input==2));
            }
        }
        public void xuat()
        {
            foreach (var x in _lstSinhVienFPOLY)
            {
                x.inThongTin();
            }
        }
        public void tim()
        {
            Console.WriteLine("Mời bạn nhập khoảng mã sinh viên bắt đầu: ");
            int msvbd = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Mời bạn nhập khoảng mã sinh viên kết thúc: ");
            int msvkt = Convert.ToInt32(Console.ReadLine());
            if (msvbd>msvkt)
            {
                int temp = msvbd;
                msvbd = msvkt;
                msvkt = temp;
            }
            
            for (int i = msvbd-1; i < msvkt; i++)
            {
                _lstSinhVienFPOLY[i].inThongTin();
            }
        }
        public void xoa()
        {
            Console.WriteLine("Mời bạn nhập mã số sv cần xóa: ");
            input = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < _lstSinhVienFPOLY.Count; i++)
            {
                if (input == _lstSinhVienFPOLY[i].MSV)
                {
                    _lstSinhVienFPOLY.RemoveAt(i);
                    Console.WriteLine("Xóa thành công");
                    return;
                }
                
            }
            Console.WriteLine("Không tìm thấy");
        }
    }
}
