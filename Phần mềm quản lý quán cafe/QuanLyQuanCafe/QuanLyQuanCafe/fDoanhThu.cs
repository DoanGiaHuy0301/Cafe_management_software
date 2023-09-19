using QuanLyQuanCafe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyQuanCafe
{
    public partial class fDoanhThu : Form
    {
        public fDoanhThu()
        {
            InitializeComponent();
            load_Char();
        }

        private void btnThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            chartControl1.Series.ToList().ForEach(s => s.Points.Clear());
            int thang = int.Parse(nupThang.Value.ToString());
            int nam = int.Parse(nupNam.Value.ToString());

            float giaTri = HoaDonDAO.Instance.GetTotalPriceByMonthAndYear(thang, nam);
            // Tạo bộ dữ liệu
            var series = new Series();
            series.ChartType = SeriesChartType.Bar;
            series.Points.AddXY("Tháng " + thang, giaTri);

            // Thêm bộ dữ liệu vào biểu đồ cột
            chartControl1.Series.Add(series);

            chartControl1.Series[0].Name = "Tổng doanh thu";
            chartControl1.BackColor = Color.WhiteSmoke;
            chartControl1.Series[0].Color = Color.FromArgb(255, 128, 128);
            chartControl1.Series[0].Font = new Font("Arial", 10f);

            
        }

        void load_Char()
        {
            // Tạo bộ dữ liệu
            var series = new Series();
            series.ChartType = SeriesChartType.Bar;
            for(int i = 1; i <= 12; i++)
            {
                float giaTri = HoaDonDAO.Instance.GetTotalPriceByMonthAndYear(i, 2023);
                series.Points.AddXY("Tháng " + i, giaTri);
            }

            // Thêm bộ dữ liệu vào biểu đồ cột
            chartControl1.Series.Add(series);

            chartControl1.Titles.Add("Biểu đồ cột");

            chartControl1.Series[0].Name = "Tổng doanh thu";
            chartControl1.BackColor = Color.WhiteSmoke;
            chartControl1.Series[0].Color = Color.FromArgb(255, 128, 128);
            chartControl1.Series[0].Font = new Font("Arial", 10f);
        }
    }
}
