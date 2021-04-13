using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Filter
    {
        public string maloai { get; set; }
        public string mansx { get; set; }
        public int giaMin { get; set; }
        public int giaMax { get; set; }
        public string sort { get; set; }
    }
}
