using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class FAddFood : Form
    {
        public FAddFood()
        {
            InitializeComponent();
            LoadDanhMucSanPham();
        }

        void LoadDanhMucSanPham()
        {
            List<DanhMucSanPham> listDanhMuc = DanhMucDAO.Instance.GetListCategory();
            cbDanhMuc.DataSource = listDanhMuc;
            cbDanhMuc.DisplayMember = "tenDanhMucSanPham";
        }


        private void btnThemSP_Click(object sender, EventArgs e)
        {
            int categogyID = (cbDanhMuc.SelectedItem as DanhMucSanPham).LoaiSanPhamId;
            string tenSanPham = txtTenSanPham.Text;
            string donViTinh = cbDonVi.Text;
            float price = (float)nudGia.Value;
            string size = cbSize.Text;

            if (SanPhamDAO.Instance.InsertFood(tenSanPham, donViTinh, price, categogyID, size))
            {
                MessageBox.Show("Thêm món thành công");
                if (insertFood != null)
                {
                    insertFood(this, new EventArgs());
                    txtTenSanPham.Text = "";
                    nudGia.Value = 0;
                }
            } else
            {
                MessageBox.Show("Thêm món thất bại");
            }

        }

        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
