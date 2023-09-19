using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;

        public static KhachHangDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhachHangDAO();
                return KhachHangDAO.instance;
            }
            private set { KhachHangDAO.instance = value; }
        }

        private KhachHangDAO() { }

        public int GetCustomerIdByNumberPhone(string str)
        {
            string query = "SELECT * FROM dbo.KhachHang WHERE SoDienThoai = N'" + str + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                KhachHang id = new KhachHang(data.Rows[0]);
                return id.IdKhachHang;
            }

            return -1;
        }

        public int GetDTLByNumberPhone(string str)
        {
            string query = "SELECT * FROM dbo.KhachHang WHERE SoDienThoai = N'" + str + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                KhachHang diemTichLuy = new KhachHang(data.Rows[0]);
                return diemTichLuy.DiemTichLuy;
            }

            return -1;
        }

        public string GetNameCustomerByNumberPhone(string str)
        {
            string query = "SELECT * FROM dbo.KhachHang WHERE SoDienThoai = N'" + str + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                KhachHang name = new KhachHang(data.Rows[0]);
                return name.HoTen;
            }

            return null;
        }

        public bool InsertKhachHang(string tenKhachHang, string soDienThoai, int diemTichLuy)
        {
            string query = string.Format("INSERT INTO dbo.KhachHang(HoVaTen, SoDienThoai, DiemTichLuy) VALUES (N'{0}', N'{1}', {2})", tenKhachHang, soDienThoai, diemTichLuy);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

        public bool UpdateKhachHang(int id)
        {
            string query = string.Format("UPDATE dbo.KhachHang SET DiemTichLuy += 5 WHERE KhachHangID = {0}", id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }
    }
}
