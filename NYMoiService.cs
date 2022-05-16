using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1_0_OnTapNET101_CRUD
{
    internal class NYMoiService
    {
        private List<NYMoi> _lstNYMois;
        private NYMoi _nyMoi;
        private string _input;

        public NYMoiService()
        {
            fakeData();
        }
        private void fakeData()
        {
            _lstNYMois = new List<NYMoi>() { new NYMoi(1, "Nguyễn Thị A", 48, 1995, 100),
                new NYMoi(2, "Hoàng Thị B", 80, 1999, 80) };

        }
        public void themNY1()
        {
            int soluong = Convert.ToInt32(GetInputValue("số lượng"));
            for (int i = 0; i < soluong; i++)
            {
                _nyMoi = new NYMoi();
                _nyMoi.Id = _lstNYMois.Max(c => c.Id) + 1;
                _nyMoi.Ten = GetInputValue("tên");
                _nyMoi.CanNang = Convert.ToDouble(GetInputValue("Cân Nặng"));
                _nyMoi.Ns = Convert.ToInt32(GetInputValue("năm sinh"));
                _nyMoi.Vong3 = Convert.ToInt32(GetInputValue("vòng 3"));
                //Sau khi gán giá trị cho đối tượng tiến thành add đối tuowngjvaof list
                _lstNYMois.Add(_nyMoi);
                Console.WriteLine("Bạn có muốn nhập tiếp không ?:(Yes/No)");
                string luachon = Console.ReadLine();
                if (luachon == "No")
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        public void themNY2()
        {
            int soluong = Convert.ToInt32(GetInputValue("số lượng"));
            for (int i = 0; i < soluong; i++)
            {
                
                //Sau khi gán giá trị cho đối tượng tiến thành add đối tuowngjvaof list
                _lstNYMois.Add(new NYMoi(Convert.ToInt32(GetInputValue("id")),
                    GetInputValue("tên"),
                    Convert.ToDouble(GetInputValue("Cân Nặng")),
                    Convert.ToInt32(GetInputValue("năm sinh")),
                    Convert.ToInt32(GetInputValue("vòng 3"))));
            }
        }
        public void InDs()
        {
            foreach (var x in _lstNYMois)
            {
                x.inRaManHinh();
            }
        }
        /*
         * Sửa, Xóa, Tìm Kiếm tuyệt đối
         */
        public void TimKiem()
        {
            GetInputValue("Id");
            _input=Console.ReadLine(); 
            for (int i = 0; i < _lstNYMois.Count; i++)
            {
                if (_lstNYMois[i].Id==Convert.ToInt16(_input))
                {
                    _lstNYMois[i].inRaManHinh();
                    return;
                }
            }
            Console.WriteLine("Không tìm thấy");
        }
        public void Xoa()
        {
            //GetInputValue("Id");
            //_input = Console.ReadLine();
            //for (int i = 0; i < _lstNYMois.Count; i++)
            //{
            //    if (_lstNYMois[i].Id == Convert.ToInt16(_input))
            //    {
            //        _lstNYMois.RemoveAt(i);
            //        Console.WriteLine("Xóa thành công");
            //        return;
            //    }
            //}
            //Console.WriteLine("Không tìm thấy");
            int temp = FindIndexObj();
            if (temp == -1)
            {
                Console.WriteLine("Không tìm thấy");
                return;
            }
            
            _lstNYMois.RemoveAt(temp);
            Console.WriteLine("Xóa thành công");
        }
        public void Sua()
        {
            //GetInputValue("Id");
            //_input = Console.ReadLine();
            //for (int i = 0; i < _lstNYMois.Count; i++)
            //{
            //    if (_lstNYMois[i].Id == Convert.ToInt16(_input))
            //    {
            //        GetInputValue("lại tên");
            //        _lstNYMois[i].Ten=Console.ReadLine();
            //        Console.WriteLine("Sửa thành công");
            //        return;
            //    }
            //}
            //Console.WriteLine("Không tìm thấy");
            int temp = FindIndexObj();
            if (temp == -1)
            {
                Console.WriteLine("Không tìm thấy");
                return;
            }
            GetInputValue("lại tên");
            _lstNYMois[temp].Ten = Console.ReadLine();
            Console.WriteLine("Sửa thành công");
        }
        //Coi phương thức trả về là 1 tập giá trị hoặc giá trị
        public string GetInputValue(string msg)
        {
            Console.WriteLine($"Mời bạn nhập {msg}: ");
            return Console.ReadLine();
        }
        public int FindIndexObj()
        {
            //GetInputValue("Id");
            //_input = Console.ReadLine();
            //for (int i = 0; i < _lstNYMois.Count; i++)
            //{
            //    if (_lstNYMois[i].Id == Convert.ToInt16(_input))
            //    {
                    
            //        return i;
            //    }
            //}
            //return -1;
            return _lstNYMois.FindIndex(c => c.Id==Convert.ToInt16(_input));
        }
        public int GetAutoId()
        {
            if (_lstNYMois.Count<0)
            {
                return 1;
            }
            return _lstNYMois.Max(c => c.Id)+1;
        }
    }
}
