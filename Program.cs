using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1_0_OnTapNET101_CRUD
{
    internal class Program
    {
        //CRUD người yêu mới
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            NYMoiService ny = new NYMoiService();
            string _input;
            do
            {
                Console.WriteLine(Guid.NewGuid());
                Console.WriteLine("1.Thêm");
                Console.WriteLine("2.Sửa");
                Console.WriteLine("3.Tìm Kiếm");
                Console.WriteLine("4.In Danh Sách");
                Console.WriteLine("5.Xóa");
                Console.WriteLine("0.Thoát");
                Console.WriteLine("Mời bạn chọn:");
                 _input = Console.ReadLine();
                switch (_input)
                {
                    case "1":
                        ny.themNY1();
                        break;
                    case "2":
                        ny.Sua();
                        break;
                    case "3":
                        ny.TimKiem();
                        break;
                    case "4":
                        ny.InDs();
                        break;
                    case "5":
                        ny.Xoa();
                        break;
                    case "0":
                        Console.WriteLine("Bạn chọn thoát");
                        return;
                    default:
                        Console.WriteLine("Chức năng không tồn tại chọn lại");
                        break;
                }

            } while (!(_input=="5"));
        }
    }
}
