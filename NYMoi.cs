using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1_0_OnTapNET101_CRUD
{
    //Khi kế thừa lớp cha là abstract và có phương thức abstract thì lớp con bắt buộc phải ghi đè lại tất cả các phương thức đó nếu không thì không thể trở thành con của lớp abstract
    internal class NYMoi:Nguoi
    {
        //Phần 1 : Khai báo các thuộc tính mà đối tượng cần có 
        //Phần 2: Contructor
        //Phần 3: Property
        //Phần 4: Phương thức đối tượng
        //Giai doạn C#1 sang đến C#2 sử dụng Property
        //-----------------------------------
        //Phần 1: Khai báo các property mà đối tượng cần có
        //prop + tab
        public double Vong3 { get; set; }
        //Phần 2:
        public NYMoi()//Contructer không tham số
        {

        }

        public NYMoi(int id, string ten, double canNang, int ns, double vong3) : base(id, ten, canNang, ns)
        {
            Vong3 = vong3;
        }

        





        //Phần 3: Phương thức đối tượng
        public override void Method1()
        {
            base.Method1();
        }

        public override void inRaManHinh()//Ghi đè lại phương thức abstract của lớp cha
        {
            Console.WriteLine($"{Id}  {Ten}  {CanNang}  {Ns}  {Vong3}  {(CanNang<=50?"Gầy": CanNang <= 80 ? "Béo":"Đáng yêu")}");
        }
    }
}
