﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class NhanVien
    {
        public NhanVien(int nhanVienID, string hoVaTen, DateTime ngaySinh, string gioiTinh, string soDienThoai, DateTime ngayVaoLam, string chucVu)
        {
            this.NhanVienID = nhanVienID;
            this.HoVaTen = hoVaTen;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
            this.SoDienThoai = soDienThoai;
            this.NgayVaoLam = ngayVaoLam;
            this.ChucVu = chucVu;
        }

        public NhanVien(DataRow row)
        {
            this.NhanVienID = (int)row["NhanVienID"] ;
            this.HoVaTen = row["HoVaTen"].ToString();
            this.NgaySinh = (DateTime)row["NgaySinh"];
            this.GioiTinh = row["GioiTinh"].ToString();
            this.SoDienThoai = row["SoDienThoai"].ToString();
            this.NgayVaoLam = (DateTime)row["NgayVaoLam"];
            this.ChucVu = row["ChucVu"].ToString();
        }

        private int nhanVienID;
        private string hoVaTen;
        private DateTime ngaySinh;
        private string gioiTinh;
        private string soDienThoai;
        private DateTime ngayVaoLam;
        private string chucVu;

        public int NhanVienID { get => nhanVienID; set => nhanVienID = value; }
        public string HoVaTen { get => hoVaTen; set => hoVaTen = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public DateTime NgayVaoLam { get => ngayVaoLam; set => ngayVaoLam = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
    }
}
