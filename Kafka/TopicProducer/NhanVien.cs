using System;
using System.Collections.Generic;

namespace TopicProducer
{
    public class NhanVien
    {
        public string name { get; set; }
        public string exp { get; set; }
        public string point { get; set; }
        public string hoctap { get; set; }
        public string time { get; set; }
        public string field { get; set; }
        public string salary { get; set; }
        public string information { get; set; }
        public List<string> Jobs { get; set; } = new List<string>();
        public List<string> images { get; set; }
        public List<string> Addresss { get; set; } = new List<string>();
    }
}
