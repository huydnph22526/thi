using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DE_THI_THU_2
{
    internal class SinhVienFPOLY
    {
        private int mSV;
        private string hoTen;
        private int chuyenNganh;

        public SinhVienFPOLY()
        {

        }

        public SinhVienFPOLY(int mSV, string hoTen, int chuyenNganh)
        {
            this.MSV = mSV;
            this.HoTen = hoTen;
            this.ChuyenNganh = chuyenNganh;
        }

        public int MSV { get => mSV; set => mSV = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public int ChuyenNganh { get => chuyenNganh; set => chuyenNganh = value; }

        public virtual void inThongTin()
        {
            Console.WriteLine($"{mSV}  {hoTen}  {(chuyenNganh == 2 ? "WEB" : "JAVA")}");
        }
    }
}
