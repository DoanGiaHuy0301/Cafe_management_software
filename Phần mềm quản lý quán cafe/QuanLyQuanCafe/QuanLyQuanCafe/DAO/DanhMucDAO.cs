﻿using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class DanhMucDAO
    {
        private static DanhMucDAO instance;

        public static DanhMucDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DanhMucDAO();
                return DanhMucDAO.instance;
            }
            private set { DanhMucDAO.instance = value; }
        }

        private DanhMucDAO() { }

        public List<DanhMucSanPham> GetListCategory()
        {
            List<DanhMucSanPham> listDanhMuc = new List<DanhMucSanPham>();

            string query = "Select * from dbo.LoaiSanPham";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DanhMucSanPham category = new DanhMucSanPham(item);
                listDanhMuc.Add(category);
            }

            return listDanhMuc;
        }

        public DanhMucSanPham GetDanhMucById(int id)
        {
            DanhMucSanPham categary = null;

            string query = "Select * from dbo.LoaiSanPham where LoaiSanPhamID = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                categary = new DanhMucSanPham(item);
                return categary;
            }

            return categary;
        }

        public bool InsertCategary(string TenDanhMuc)
        {
            string query = string.Format("INSERT INTO dbo.LoaiSanPham (LoaiSanPham) Values(N'{0}')", TenDanhMuc);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

        public bool UpdateCategary(string TenDanhMuc, int id)
        {
            string query = string.Format("UPDATE dbo.LoaiSanPham SET LoaiSanPham = N'{0}' WHERE LoaiSanPhamID = {1}", TenDanhMuc, id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

        public bool DeleteCategary(int idCategary)
        {
            SanPhamDAO.Instance.DeleteFoodByCategaryId(idCategary);

            string query = string.Format("DELETE dbo.LoaiSanPham WHERE LoaiSanPhamID = " + idCategary);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

    }
}
