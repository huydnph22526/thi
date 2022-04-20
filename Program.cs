using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DE_THI_THU_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            QLSV qLSV = new QLSV();
            string luachon;
            
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1.Nhập");
                Console.WriteLine("2.Xuất");
                Console.WriteLine("3.Tìm");
                Console.WriteLine("4.Xóa");
                Console.WriteLine("0.Thoát");
                Console.WriteLine("Mời bạn lựa chọn: ");
                luachon = Console.ReadLine();
                switch (luachon)
                {
                    case "1":
                        qLSV.nhap();
                        break;
                    case "2":
                        qLSV.xuat();
                        break;
                    case "3":
                        qLSV.tim();
                        break;
                    case "4":
                        qLSV.xoa();
                        break;
                    case "0":
                        Environment.ExitCode = 0;
                        break;
                    default:
                        Console.WriteLine("Mục bạn chọn không có vui lòng chọn lại");
                        break;
                }
            } while (!(luachon == "5"));
        }
    }
}
