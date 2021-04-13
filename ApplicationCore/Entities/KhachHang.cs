using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class KhachHang
    {
        public string username { get; set; }
        public string password { get; set; }
        public string hoten { get; set; }
        public string gioitinh { get; set; }
        public DateTime namsinh { get; set; }
        public string diachi { get; set; }
        public string sodienthoai { get; set; }
        public Boolean quyenhan { get; set; }
        public Boolean active { get; set; }
    }
}
