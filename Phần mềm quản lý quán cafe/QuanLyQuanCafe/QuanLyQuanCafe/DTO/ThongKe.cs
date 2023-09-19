using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class ThongKe
    {
        public ThongKe(float totalPrice)
        {
            this.TotalPrice = totalPrice;
        }

        public ThongKe(DataRow row)
        {
            var TotalPriceTemp = row["totalPrice"];

            if (TotalPriceTemp.ToString() != "")
            {
                this.TotalPrice = (float)Convert.ToDouble(TotalPriceTemp.ToString());
            }
        }

        private float totalPrice;
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
