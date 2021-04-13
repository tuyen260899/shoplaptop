using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class HoaDon
    {
        public int mahd { get; set; }
        public string username { get; set; }
        public DateTime ngaylap { get; set; }
        public DateTime ngaythanhtoan { get; set; }
        public int trangthai { get; set; }
        public Boolean active { get; set; }
        public string masp { get; set; }      
        public string tensp { get; set; }
        public int gia { get; set; }
        public string hinh { get; set; }
        public string CPU { get; set; }
    }
}
