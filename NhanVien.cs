using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtapBuoi4
{
    public class NhanVien
    {
        public int ID { get; set; }
        public string Tên { get; set; }
        public double Lương { get; set; }
        public NhanVien() { }
        public NhanVien(int id, string ten, double luong)
        {
            ID = id;
            Tên = ten;
            Lương = luong;
        }
    }
}
