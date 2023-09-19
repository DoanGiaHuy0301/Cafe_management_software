
namespace QuanLyQuanCafe
{
    partial class fThongKeSanPham
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThongKeSanPham = new System.Windows.Forms.Button();
            this.chartControl1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnThongKeSanPham);
            this.panel1.Controls.Add(this.chartControl1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 525);
            this.panel1.TabIndex = 11;
            // 
            // btnThongKeSanPham
            // 
            this.btnThongKeSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKeSanPham.Location = new System.Drawing.Point(276, 22);
            this.btnThongKeSanPham.Name = "btnThongKeSanPham";
            this.btnThongKeSanPham.Size = new System.Drawing.Size(120, 45);
            this.btnThongKeSanPham.TabIndex = 3;
            this.btnThongKeSanPham.Text = "Thống kê";
            this.btnThongKeSanPham.UseVisualStyleBackColor = true;
            // 
            // chartControl1
            // 
            chartArea1.Name = "ChartArea1";
            this.chartControl1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartControl1.Legends.Add(legend1);
            this.chartControl1.Location = new System.Drawing.Point(10, 108);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.Size = new System.Drawing.Size(665, 401);
            this.chartControl1.TabIndex = 2;
            this.chartControl1.Text = "chart1";
            // 
            // fThongKeSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 546);
            this.Controls.Add(this.panel1);
            this.Name = "fThongKeSanPham";
            this.Text = "fThongKeSanPham";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThongKeSanPham;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartControl1;
    }
}