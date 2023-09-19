
namespace QuanLyQuanCafe
{
    partial class fDoanhThu
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
            this.btnThongKeDoanhThu = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.nupNam = new System.Windows.Forms.NumericUpDown();
            this.chartControl1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.nupThang = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupThang)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnThongKeDoanhThu);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.chartControl1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 525);
            this.panel1.TabIndex = 10;
            // 
            // btnThongKeDoanhThu
            // 
            this.btnThongKeDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKeDoanhThu.Location = new System.Drawing.Point(528, 23);
            this.btnThongKeDoanhThu.Name = "btnThongKeDoanhThu";
            this.btnThongKeDoanhThu.Size = new System.Drawing.Size(120, 45);
            this.btnThongKeDoanhThu.TabIndex = 3;
            this.btnThongKeDoanhThu.Text = "Thống kê";
            this.btnThongKeDoanhThu.UseVisualStyleBackColor = true;
            this.btnThongKeDoanhThu.Click += new System.EventHandler(this.btnThongKeDoanhThu_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.nupNam);
            this.panel3.Location = new System.Drawing.Point(258, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(242, 44);
            this.panel3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Năm: ";
            // 
            // nupNam
            // 
            this.nupNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupNam.Location = new System.Drawing.Point(105, 6);
            this.nupNam.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.nupNam.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nupNam.Name = "nupNam";
            this.nupNam.Size = new System.Drawing.Size(120, 30);
            this.nupNam.TabIndex = 0;
            this.nupNam.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
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
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.nupThang);
            this.panel2.Location = new System.Drawing.Point(10, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(242, 44);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tháng: ";
            // 
            // nupThang
            // 
            this.nupThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupThang.Location = new System.Drawing.Point(105, 6);
            this.nupThang.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nupThang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupThang.Name = "nupThang";
            this.nupThang.Size = new System.Drawing.Size(120, 30);
            this.nupThang.TabIndex = 0;
            this.nupThang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // fDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 525);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "fDoanhThu";
            this.Text = "fDoanhThu";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupThang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nupThang;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartControl1;
        private System.Windows.Forms.Button btnThongKeDoanhThu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nupNam;
    }
}