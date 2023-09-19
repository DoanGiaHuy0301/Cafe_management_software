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
    public partial class fStaff : Form
    {
        private AccountLogin loginAccount;

        public AccountLogin LoginAccount 
        { 
            get => loginAccount; 
            set => loginAccount = value; 
        }

        public fStaff(AccountLogin acc)
        {
            InitializeComponent();

            this.loginAccount = acc;

            LoadPage();
            LoadTable();
            LoadDanhMucSanPham();
            LoadComboBoxTable(cbChuyenban);
        }

        //Phần load các hàm
        #region Method

        void LoadPage()
        {
            thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + NhanVienDAO.Instance.GetStaffByUsername(LoginAccount.Username).HoVaTen + ")";
            thôngTinCáNhânToolStripMenuItem.Text = NhanVienDAO.Instance.GetStaffByUsername(LoginAccount.Username).HoVaTen;
        }
        void LoadDanhMucSanPham()
        {
            List<DanhMucSanPham> listDanhMuc = DanhMucDAO.Instance.GetListCategory();
            cbLoaiSanPham.DataSource = listDanhMuc;
            cbLoaiSanPham.DisplayMember = "tenDanhMucSanPham";
        }

        void LoadSanPham(int id)
        {
            List<Food> listFood = SanPhamDAO.Instance.GetFoodBycategoryId(id);
            cbSanPham.DataSource = listFood;
            cbSanPham.DisplayMember = "foodName";
        }

        void LoadTable()
        {
            flpDanhSachBan.Controls.Clear();

            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach(Table item in tableList)
            {
                Button btn = new Button()
                {
                    Width = TableDAO.TableWidth,
                    Height = TableDAO.TableHeight
                };

                btn.Text = item.Name + Environment.NewLine + item.TrangThai;
                btn.Click += btn_Click;
                btn.Tag = item;

                switch (item.TrangThai)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.LightBlue;
                        break;
                }

                flpDanhSachBan.Controls.Add(btn);
            }
        }

        void ShowHoaDon(int id)
        {
            lvBill.Items.Clear();
            float TongTien = 0;
            List<MenuTable> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
        
            foreach (MenuTable item in listBillInfo)
            {
                ListViewItem lvItem = new ListViewItem(item.FoodName.ToString());
                lvItem.SubItems.Add(item.DonViTinh.ToString());
                lvItem.SubItems.Add(item.Size.ToString());
                lvItem.SubItems.Add(item.Price.ToString());
                lvItem.SubItems.Add(item.FoodTotal.ToString());
                lvItem.SubItems.Add(item.PriceTotal.ToString());

                TongTien += item.PriceTotal;

                lvBill.Items.Add(lvItem);
            }

            txtTongTien.Text = TongTien.ToString() + " VND";

        }

        void LoadComboBoxTable(ComboBox cd)
        {
            cbChuyenban.DataSource = TableDAO.Instance.LoadTableList();
            cbChuyenban.DisplayMember = "name";
        }
        #endregion



        //Phần chạy sự kiện
        #region Event
        private void btn_Click(object sender, EventArgs e)
        {
            int tableId = ((sender as Button).Tag as Table).Id;
            lvBill.Tag = (sender as Button).Tag;
            ShowHoaDon(tableId);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fLogin f = new fLogin();
            this.Close();
            f.Show();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fStaffInfo f = new fStaffInfo(LoginAccount);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void cbLoaiSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            DanhMucSanPham selected = cb.SelectedItem as DanhMucSanPham;

            id = selected.LoaiSanPhamId;

            LoadSanPham(id);
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            Table table = lvBill.Tag as Table;

            if (table == null)
            {
                MessageBox.Show("Vui lòng chọn bàn");
            } else { 
                int idBill = HoaDonDAO.Instance.GetIdByTableId(table.Id);

                int idFood = (cbSanPham.SelectedItem as Food).FoodId;

                int count = (int)nudSoLuong.Value;

                if (idBill == -1)
                {
                    HoaDonDAO.Instance.InsertBill(table.Id);
                    BillInfoDAO.Instance.InsertBillInfo(HoaDonDAO.Instance.GetMaxBill(), idFood, count);
                }
                else
                {
                    BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, count);
                }

                ShowHoaDon(table.Id);
                LoadTable();
            }

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

            Table table = lvBill.Tag as Table;

            int idBill = HoaDonDAO.Instance.GetIdByTableId(table.Id);

            if (idBill != -1)
            {
                fThanhToan f = new fThanhToan(table.Id);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }

            ShowHoaDon(table.Id);
            LoadTable();
        }

        private void btnChuyenban_Click(object sender, EventArgs e)
        {
            int id1 = (lvBill.Tag as Table).Id;

            int id2 = (cbChuyenban.SelectedItem as Table).Id;

            if (MessageBox.Show(string.Format("Bạn có muốn chuyển bàn {0} qua bàn {1}", (lvBill.Tag as Table).Name, (cbChuyenban.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK);
            {
                TableDAO.Instance.SwitchTable(id1, id2);

                LoadTable();
            }

        }
        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fManager f = new fManager();
            FAddFood fa = new FAddFood();
            fAddCategary fc = new fAddCategary();
            f.UpdateFood += F_UpdateFood;
            f.DeleteFood += F_DeleteFood;
            fa.InsertFood += Fa_InsertFood;
            f.UpdateCategary += F_UpdateCategary;
            f.DeleteCategary += F_DeleteCategary;
            fc.InsertCategary += Fc_InsertCategary;
        }

        private void Fc_InsertCategary(object sender, EventArgs e)
        {
            LoadDanhMucSanPham();
            LoadSanPham((cbLoaiSanPham.SelectedItem as DanhMucSanPham).LoaiSanPhamId);
            if (lvBill.Tag != null)
            {
                ShowHoaDon((lvBill.Tag as Table).Id);
            }
        }

        private void F_DeleteCategary(object sender, EventArgs e)
        {
            LoadDanhMucSanPham();
            LoadSanPham((cbLoaiSanPham.SelectedItem as DanhMucSanPham).LoaiSanPhamId);
            if (lvBill.Tag != null)
            {
                ShowHoaDon((lvBill.Tag as Table).Id);
            }
            LoadTable();
        }

        private void F_UpdateCategary(object sender, EventArgs e)
        {
            LoadDanhMucSanPham();
            LoadSanPham((cbLoaiSanPham.SelectedItem as DanhMucSanPham).LoaiSanPhamId);
            if (lvBill.Tag != null)
            {
                ShowHoaDon((lvBill.Tag as Table).Id);
            }
        }

        private void Fa_InsertFood(object sender, EventArgs e)
        {
            LoadSanPham((cbLoaiSanPham.SelectedItem as DanhMucSanPham).LoaiSanPhamId);
            if (lvBill.Tag != null)
            {
                ShowHoaDon((lvBill.Tag as Table).Id);
            }
        }

        private void F_UpdateFood(object sender, EventArgs e)
        {
            LoadSanPham((cbLoaiSanPham.SelectedItem as DanhMucSanPham).LoaiSanPhamId);
            if (lvBill.Tag != null)
            {
                ShowHoaDon((lvBill.Tag as Table).Id);
            }
        }

        private void F_DeleteFood(object sender, EventArgs e)
        {
            LoadSanPham((cbLoaiSanPham.SelectedItem as DanhMucSanPham).LoaiSanPhamId);
            if (lvBill.Tag != null)
            {
                ShowHoaDon((lvBill.Tag as Table).Id);
            }
            LoadTable();
        }



        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
