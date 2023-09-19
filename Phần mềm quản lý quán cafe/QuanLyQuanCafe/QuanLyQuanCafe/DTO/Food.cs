using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Food
    {
        public Food(int foodId, string foodName, string  donViTinh, string size, float donGia, int danhMucId)
        {
            this.FoodId = foodId;
            this.FoodName = foodName;
            this.DonViTinh = donViTinh;
            this.Size = size;
            this.DonGia = donGia;
            this.DanhMucId = danhMucId;
        }

        public Food(DataRow row)
        {
            this.FoodId = (int)row["SanPhamID"];
            this.FoodName = row["TenSanPham"].ToString();
            this.DonViTinh = row["DonViTinh"].ToString();
            this.Size = row["Size"].ToString();
            this.DonGia = (float)Convert.ToDouble(row["DonGia"].ToString());
            this.DanhMucId = (int)row["ID_LoaiSanPham"];
        }

        private int foodId;
        private string foodName;
        private string donViTinh;
        private string size;
        private float donGia;
        private int danhMucId;

        public int FoodId { get => foodId; set => foodId = value; }
        public string FoodName { get => foodName; set => foodName = value; }
        public string DonViTinh { get => donViTinh; set => donViTinh = value; }
        public string Size { get => size; set => size = value; }
        public float DonGia { get => donGia; set => donGia = value; }
        public int DanhMucId { get => danhMucId; set => danhMucId = value; }
    }
}
