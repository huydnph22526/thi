using DE_THI_THU_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De_Thi_Thu_2
{
    
    internal class SinhVienUDPM :SinhVienFPOLY
    {
        private int chuyenNganhHep;

        public SinhVienUDPM()
        {

        }

        public SinhVienUDPM(int mSV, string hoTen, int chuyenNganh, int chuyenNganhHep) : base(mSV, hoTen, chuyenNganh)
        {
            this.ChuyenNganhHep = chuyenNganhHep;
        }

        public int ChuyenNganhHep { get => chuyenNganhHep; set => chuyenNganhHep = value; }

        public override void inThongTin()
        {
            base.inThongTin();
        }
        public string SinhVienFPOLY(int chuyenNganhHep)
        {
            if (chuyenNganhHep==1)
            {
                return "Chuyên ngành JAVA";
            }
            else
            {
                return "Chuyên ngành WEB";
            }
        }
    }
}
