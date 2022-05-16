using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1_0_OnTapNET101_CRUD
{
    //Đã là lớp abstract thì phải có phương thức abstract
    //Nghe đến lớp abstract thì nó sẽ là lớp cha

    internal abstract class Nguoi//Lớp cha abstract
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public double CanNang { get; set; }
        public int Ns { get; set; }
        public Nguoi()
        {
                
        }

        protected Nguoi(int id, string ten, double canNang, int ns)
        {
            Id = id;
            Ten = ten;
            CanNang = canNang;
            Ns = ns;
        }
        //this: dùng để tham chiếu đến thuộc tính , phương thức của lớp hiện tại
        //base: dùng để tham chiếu đến thuộc tính , phương thức của lớp cha
        public virtual void Method1()
        {

        }
        //Phân biệt ghi đè và nạp chồng
        /*
         * 1. Overloading (Nạp chồng phương thức): Cùng tên nhưng khác tham số
         * 2.Overriding (Ghi đè phương thức): Phải nhớ đến ké thừa , Phương thức lớp con ghi đè lại phương thức lớp cha và phương thức lớp con phải giống tuyệt đối của lớp cha.
         * 
         */
        //Phương thức abstract : Không body code 
        public abstract void inRaManHinh();
    }
}
