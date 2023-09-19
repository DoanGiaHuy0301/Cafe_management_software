using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fManager : Form
    {
        BindingSource foodList = new BindingSource();
        BindingSource categaryList = new BindingSource();
        BindingSource tableList = new BindingSource();
        BindingSource accountStaffList = new BindingSource();
        public fManager()
        {
            InitializeComponent();

            LoadAllTable();
        }

        #region Method

        List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = SanPhamDAO.Instance.SearchFoodByName(name);

            return listFood;
        }

        List<AccountStaff> SearchStaffByName(string name)
        {
            List<AccountStaff> listStaff = AccountStaffDAO.Instance.SearchStaffByName(name);

            return listStaff;
        }
        void LoadAllTable()
        {
            dgvTableSanPham.DataSource = foodList;
            dgvTableDanhMuc.DataSource = categaryList;
            dgvTableBan.DataSource = tableList;
            dgvNV_TK.DataSource = accountStaffList;

            LoadListFood();
            LoadDanhMuc();
            Loadtable();
            AddFoodBinding();
            AddcategaryBinding();
            AddTableBinding();
            AddTableAccountStaff();
            LoadStaffAndAccount();
            LoadDanhMucComboBox(cbDanhMuc);
        }
        void LoadListFood()
        {
            foodList.DataSource = SanPhamDAO.Instance.GetlistFood();
        }

        void LoadDanhMuc()
        {
            categaryList.DataSource = DanhMucDAO.Instance.GetListCategory();
        }

        void Loadtable()
        {
            tableList.DataSource = TableDAO.Instance.LoadTableList();
        }


        void LoadStaffAndAccount()
        {
            accountStaffList.DataSource = AccountStaffDAO.Instance.GetListStaffAndAccountByTableStaffAccount();
        }

        void AddFoodBinding()
        {
            txtSanPhamID.DataBindings.Add(new Binding("Text", dgvTableSanPham.DataSource, "foodId"));
            txtTenSanPham.DataBindings.Add(new Binding("Text", dgvTableSanPham.DataSource, "foodName"));
            txtDonViTinh.DataBindings.Add(new Binding("Text", dgvTableSanPham.DataSource, "donViTinh"));
            nudGia.DataBindings.Add(new Binding("Value", dgvTableSanPham.DataSource, "donGia"));
            txtSize.DataBindings.Add(new Binding("Text", dgvTableSanPham.DataSource, "size"));
        }

        void AddcategaryBinding()
        {
            txtDanhMucID.DataBindings.Add(new Binding("Text", dgvTableDanhMuc.DataSource, "loaiSanPhamId"));
            txtTenDanhMuc.DataBindings.Add(new Binding("Text", dgvTableDanhMuc.DataSource, "tenDanhMucSanPham"));
        }

        void AddTableBinding()
        {
            txtBanID.DataBindings.Add(new Binding("Text", dgvTableBan.DataSource, "id"));
            txtBan.DataBindings.Add(new Binding("Text", dgvTableBan.DataSource, "name"));
            txtTrangThaiBan.DataBindings.Add(new Binding("Text", dgvTableBan.DataSource, "trangThai"));
        }

        void AddTableAccountStaff()
        {
            txtNVTK_ID.DataBindings.Add(new Binding("Text", dgvNV_TK.DataSource, "nhanVienID"));
            txtNVTK_HoVaTen.DataBindings.Add(new Binding("Text", dgvNV_TK.DataSource, "hoVaTen"));
            txtNVTK_GioiTinh.DataBindings.Add(new Binding("Text", dgvNV_TK.DataSource, "gioiTinh"));
            txtNVTK_NgaySinh.DataBindings.Add(new Binding("Text", dgvNV_TK.DataSource, "ngaySinh")); ;
            txtNVTK_NgayVaoLam.DataBindings.Add(new Binding("Text", dgvNV_TK.DataSource, "ngayVaoLam"));
            txtNVTK_ChucVu.DataBindings.Add(new Binding("Text", dgvNV_TK.DataSource, "chucVu"));
            txtNVTK_SoDienThoai.DataBindings.Add(new Binding("Text", dgvNV_TK.DataSource, "soDienThoai"));
            txtNVTK_Username.DataBindings.Add(new Binding("Text", dgvNV_TK.DataSource, "username"));
            txtNVTK_PassWord.DataBindings.Add(new Binding("Text", dgvNV_TK.DataSource, "password"));
        }

        void LoadDanhMucComboBox(ComboBox cb)
        {
            cb.DataSource = DanhMucDAO.Instance.GetListCategory();
            cb.DisplayMember = "tenDanhMucSanPham";
        }

        #endregion


        #region Event
        private void btnXemDanhMuc_Click(object sender, EventArgs e)
        {
            LoadDanhMuc();
        }

        private void btnXemSanPham_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

 
        private void btnXemBan_Click(object sender, EventArgs e)
        {
            Loadtable();
        }

        private void btnXemNV_TK_Click(object sender, EventArgs e)
        {
            LoadStaffAndAccount();
        }

        private void txtSanPhamID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvTableSanPham.SelectedCells.Count > 1)
                {

                    int id = (int)dgvTableSanPham.SelectedCells[0].OwningRow.Cells["danhMucId"].Value;

                    DanhMucSanPham categary = DanhMucDAO.Instance.GetDanhMucById(id);

                    cbDanhMuc.SelectedItem = categary;

                    int index = -1;
                    int i = 0;

                    foreach (DanhMucSanPham item in cbDanhMuc.Items)
                    {
                        if (item.LoaiSanPhamId == categary.LoaiSanPhamId)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    cbDanhMuc.SelectedIndex = index;
                }
            } catch { }
        }

        //Thêm sửa xóa sản phẩm
        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            FAddFood f = new FAddFood();
            this.Hide();
            f.ShowDialog();
            this.Show();
            LoadListFood();
        }

        private void btnSuaSanPham_Click(object sender, EventArgs e)
        {
            int categogyID = (cbDanhMuc.SelectedItem as DanhMucSanPham).LoaiSanPhamId;
            string tenSanPham = txtTenSanPham.Text;
            string donViTinh = txtDonViTinh.Text;
            float price = (float)nudGia.Value;
            string size = txtSize.Text;
            int idFood = Convert.ToInt32(txtSanPhamID.Text);

            if (SanPhamDAO.Instance.UpdateFood(tenSanPham, donViTinh, price, categogyID, size, idFood))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListFood();
                if(updateFood != null)
                {
                    updateFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Sửa món thất bại");
            }
        }

        private void btnXoaSanPham_Click(object sender, EventArgs e)
        {
            int idFood = Convert.ToInt32(txtSanPhamID.Text);

            if (SanPhamDAO.Instance.DeleteFood(idFood))
            {
                MessageBox.Show("Xóa món thành công");
                LoadListFood();
                if (deleteFood != null)
                {
                    deleteFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Xóa món thất bại");
            }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        //Thêm sửa xóa danh mục
        private void btnThemDanhMuc_Click(object sender, EventArgs e)
        {
            fAddCategary f = new fAddCategary();
            f.ShowDialog();
            LoadDanhMuc();
        }
        private void btnSuaDanhMuc_Click(object sender, EventArgs e)
        {
            int idCategary = Convert.ToInt32(txtDanhMucID.Text);
            string tenDanhMuc = txtTenDanhMuc.Text;

            if (DanhMucDAO.Instance.UpdateCategary(tenDanhMuc, idCategary))
            {
                MessageBox.Show("Sửa danh mục thành công");
                LoadDanhMuc();
                if (updateCategary != null)
                {
                    updateCategary(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Sửa danh mục thất bại");
            }
        }
        #endregion

        private void btnXoaDanhMuc_Click(object sender, EventArgs e)
        {
            int idCategary = Convert.ToInt32(txtDanhMucID.Text);
            if (SanPhamDAO.Instance.DeleteFoodByCategaryId(idCategary))
            {
                if (DanhMucDAO.Instance.DeleteCategary(idCategary))
                {
                    MessageBox.Show("Xóa danh mục thành công");
                    LoadDanhMuc();
                    if (deleteCategary != null)
                    {
                        deleteCategary(this, new EventArgs());
                    }
                }
            }
            else
            {
                MessageBox.Show("Xóa danh mục thất bại");
            }
        }

        private event EventHandler updateCategary;
        public event EventHandler UpdateCategary
        {
            add { updateCategary += value; }
            remove { updateCategary -= value; }
        }

        private event EventHandler deleteCategary;
        public event EventHandler DeleteCategary
        {
            add { deleteCategary += value; }
            remove { deleteCategary -= value; }
        }

        //Thêm sửa xóa thông tin bàn
        private void btnThemBan_Click(object sender, EventArgs e)
        {
            fAddTable f = new fAddTable();
            f.ShowDialog();
            Loadtable();
        }

        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            int idBan = Convert.ToInt32(txtBanID.Text);
            string tenban = txtBan.Text;
            string trangThai = txtTrangThaiBan.Text;

            if (TableDAO.Instance.UpdateTable(tenban, trangThai, idBan))
            {
                MessageBox.Show("Sửa thông tin bàn thành công");
                Loadtable();
            }
            else
            {
                MessageBox.Show("Sửa thông tin bàn thất bại");
            }
        }

        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            int idBan = Convert.ToInt32(txtBanID.Text);
            if (TableDAO.Instance.DeleteTable(idBan))
            {
                MessageBox.Show("Xóa bàn thành công");
                Loadtable();
                
            }
            else
            {
                MessageBox.Show("Xóa bàn thất bại");
            }
        }

        // Thêm sửa xóa nhân viên và tài khoản
        private void btnThemNV_TK_Click(object sender, EventArgs e)
        {
            fAddStaff f = new fAddStaff();
            f.ShowDialog();
            LoadStaffAndAccount();
        }

        private void btnSuaNVTK_Click(object sender, EventArgs e)
        {
            int idNV = Convert.ToInt32(txtNVTK_ID.Text);
            string hoVaTen = txtNVTK_HoVaTen.Text;
            string ngaySinh = txtNVTK_NgaySinh.Text;
            string ngayVaoLam = txtNVTK_NgayVaoLam.Text;
            string gioiTinh = txtNVTK_GioiTinh.Text;
            string soDienThoai = txtNVTK_SoDienThoai.Text;
            string chucVu = txtNVTK_ChucVu.Text;

            if (NhanVienDAO.Instance.UpdateStaff(hoVaTen, ngaySinh, gioiTinh, soDienThoai, ngayVaoLam, chucVu, idNV))
            {
                MessageBox.Show("Sửa thông tin thành công");
                LoadStaffAndAccount();
            }
            else
            {
                MessageBox.Show("Sửa thông tin thất bại");
            }
        }

        private void btnXoaNVTK_Click(object sender, EventArgs e)
        {
            int idStaff = Convert.ToInt32(txtNVTK_ID.Text);

            if (NhanVienDAO.Instance.DeleteStaff(idStaff))
            {
                MessageBox.Show("Xóa thành công");
                LoadStaffAndAccount();

            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnTimSanPham_Click(object sender, EventArgs e)
        {
          foodList.DataSource = SearchFoodByName(txtTimKiemFood.Text);
        }

        private void btnTimKiemNV_TK_Click(object sender, EventArgs e)
        {
            accountStaffList.DataSource = SearchStaffByName(txtNVTK_tìmKiem.Text);
        }

        private void btnThongKe_DoanhThu_Click(object sender, EventArgs e)
        {
            fDoanhThu frmDoanhThu = new fDoanhThu();

            frmDoanhThu.TopLevel = false;

            frmDoanhThu.FormBorderStyle = FormBorderStyle.None;

            pnHienThiThongKe.Controls.Add(frmDoanhThu);

            frmDoanhThu.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
