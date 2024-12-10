using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BtapBuoi4.ListView2;

namespace BtapBuoi4
{
    public partial class ListView2 : Form
    {
        public delegate void AddNhanVien(NhanVien nhanvien);
        public delegate void SuaNhanVien(NhanVien nhanvien);
        private NhanVien _nhanVien;
        private Mode _currentMode;
        public enum Mode
        {
            Add,
            Edit
        }
        public ListView2()
        {
            InitializeComponent();
            _currentMode = Mode.Add;
        }

        public ListView2(NhanVien nhanVien) : this()
        {
            _nhanVien = nhanVien; 
            InitializeNhanVien(nhanVien);
            _currentMode = Mode.Edit; 
        }

        private void InitializeNhanVien(NhanVien nhanVien)
        {
            txtID.Text = nhanVien.ID.ToString(); 
            txtTên.Text = nhanVien.Tên; 
            txtLương.Text = nhanVien.Lương.ToString();
            txtID.ReadOnly = true; 
        }

        public AddNhanVien OnAddNhanVien;

        public SuaNhanVien OnSuaNhanVien;

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ListView2_Load(object sender, EventArgs e)
        {

        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (_currentMode == Mode.Add) 
            {
                var nhanvien = new NhanVien(int.Parse(txtID.Text), txtTên.Text, double.Parse(txtLương.Text));
                OnAddNhanVien?.Invoke(nhanvien);
            }
            else if (_currentMode == Mode.Edit) 
            {
                _nhanVien.Tên = txtTên.Text; 
                _nhanVien.Lương = double.Parse(txtLương.Text);
                OnSuaNhanVien?.Invoke(_nhanVien);
            }
            this.Close(); 
        }
    }
}
