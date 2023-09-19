using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class SanPhamDAO
    {
        private static SanPhamDAO instance;

        public static SanPhamDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new SanPhamDAO();
                return SanPhamDAO.instance;
            }
            private set { SanPhamDAO.instance = value; }
        }

        private SanPhamDAO() { }

        public List<Food> GetFoodBycategoryId(int id)
        {
            List<Food> listFood = new List<Food>();

            string query = "SELECT * FROM dbo.SanPham WHERE ID_LoaiSanPham = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }

            return listFood;
        }

        public List<Food> GetlistFood()
        {
            List<Food> list = new List<Food>();

            string query = "Select * from dbo.SanPham";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }

        public bool InsertFood(string TenSanPham, string DonViTinh, float DonGia, int categaryId, string size)
        {
            string query = string.Format("INSERT INTO dbo.SanPham (TenSanPham, DonViTinh, DonGia, ID_LoaiSanPham, Size) VALUES (N'{0}', N'{1}', {2}, {3}, N'{4}')", TenSanPham, DonViTinh, DonGia, categaryId, size);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

        public bool UpdateFood(string TenSanPham, string DonViTinh, float DonGia, int categaryId, string size, int idFood)
        {
            string query = string.Format("UPDATE dbo.SanPham SET TenSanPham = N'{0}', DonViTinh = N'{1}',DonGia = {2}, ID_LoaiSanPham = {3}, Size = N'{4}' WHERE SanPhamID = {5}", TenSanPham, DonViTinh, DonGia, categaryId, size, idFood);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

        public bool DeleteFood(int idFood)
        {
            BillInfoDAO.Instance.DeleteBillInfoByIdFood(idFood);

            string query = string.Format("DELETE dbo.SanPham WHERE SanPhamID = " + idFood);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

        public int GetFoodIdByCategaryId(int idCategary)
        {
            string query = "SELECT * FROM dbo.SanPham WHERE ID_LoaiSanPham = " + idCategary;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                Food id = new Food(data.Rows[0]);
                return id.FoodId;
            }

            return -1;

        }

        public bool DeleteFoodByCategaryId(int idcategary)
        {
            DeleteFood(GetFoodIdByCategaryId(idcategary));

            string query = string.Format("DELETE dbo.SanPham WHERE ID_LoaiSanPham = " + idcategary);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

        
        public List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = new List<Food>();

            string query = string.Format("SELECT * FROM dbo.SanPham WHERE dbo.fuConvertToUnsign1(TenSanPham) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }

            return listFood;
        }

    }
}
