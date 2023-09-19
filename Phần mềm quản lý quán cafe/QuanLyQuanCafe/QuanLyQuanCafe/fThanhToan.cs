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
    public partial class fThanhToan : Form
    {
        private int id;

        public fThanhToan()
        {
            InitializeComponent();
        }

        public fThanhToan(int id)
        {
            InitializeComponent();
            this.id = id;
            ShowHoaDon(id);
        }

        void ShowHoaDon(int id)
        {
            lvBill.Items.Clear();

            float TongTien = 0;
            int diemTichLuy = KhachHangDAO.Instance.GetDTLByNumberPhone(txtSoDienThoai.Text);

            lbBan.Text = TableDAO.Instance.GetTableByTableId(id);
            lbThoiGian.Text = (DateTime.Now).ToString();

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
            if (diemTichLuy <= 15)
            {
                TongTien = TongTien - TongTien * 0.1f;
            } else if (diemTichLuy <= 30)
            {
                TongTien = TongTien - TongTien * 0.15f;
            } else
            {
                TongTien = TongTien -TongTien * 0.2f;
            }
            lbTongTien.Text = TongTien.ToString() + " VND";

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string name = KhachHangDAO.Instance.GetNameCustomerByNumberPhone(txtSearch.Text);
            if (name != null)
            {
                txtHoTen.Text = KhachHangDAO.Instance.GetNameCustomerByNumberPhone(txtSearch.Text);
                txtSoDienThoai.Text = txtSearch.Text;
                lbThongBao.Text = "";
            } else
            {
                lbThongBao.Text = "Không tìm thấy thông tin khách hàng";
                txtHoTen.Text = "";
                txtSoDienThoai.Text = "";
            }
            ShowHoaDon(id);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

            int idBill = HoaDonDAO.Instance.GetIdByTableId(id);
            double totalPrice = double.Parse(lbTongTien.Text.Split(' ')[0]);
            string name = KhachHangDAO.Instance.GetNameCustomerByNumberPhone(txtSearch.Text);
            int id_KhachHang = KhachHangDAO.Instance.GetCustomerIdByNumberPhone(txtSoDienThoai.Text);

            if (MessageBox.Show("Bạn muốn thanh toán hóa đơn bàn " + lbBan.Text, "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                HoaDonDAO.Instance.checkOutBill(idBill, (float)totalPrice);
                if (txtSoDienThoai.Text != "" && txtHoTen.Text != "")
                {
                    if (name == null)
                    {
                        KhachHangDAO.Instance.InsertKhachHang(txtHoTen.Text, txtSoDienThoai.Text, 5);
                    
                    } else
                    {
                        KhachHangDAO.Instance.UpdateKhachHang(id_KhachHang);
                    }
                }
                MessageBox.Show("Thanh toán thành công!!!!");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
