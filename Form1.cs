using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BtapBuoi4
{
    public partial class ListView1 : Form
    {
        public ListView1()
        {
            InitializeComponent();
        }
        private BindingSource bindingSource;
        private List<NhanVien> nhanviens;

        private void ListView1_Load(object sender, EventArgs e)
        {
            nhanviens = new List<NhanVien>();
            nhanviens.Add(new NhanVien() { ID = 1, Tên = "A", Lương = 20 });
            nhanviens.Add(new NhanVien() { ID = 2, Tên = "B", Lương = 30 });
            nhanviens.Add(new NhanVien() { ID = 3, Tên = "C", Lương = 40 });
            bindingSource = new BindingSource { DataSource = nhanviens };
            dtgNhanVien.DataSource = bindingSource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ListView2 frm2 = new ListView2();
            frm2.OnAddNhanVien += AddNhanVien;
            frm2.ShowDialog();
        }

        private void AddNhanVien(NhanVien nhanvien)
        {
            nhanviens.Add(nhanvien);
            dtgNhanVien.DataSource = null;
            dtgNhanVien.DataSource = nhanviens;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtgNhanVien.SelectedRows.Count > 0)
            {
                var selectedRow = dtgNhanVien.SelectedRows[0];
                var selectedNhanVien = (NhanVien)selectedRow.DataBoundItem;

                ListView2 frm2 = new ListView2(selectedNhanVien);
                frm2.OnSuaNhanVien += UpdateNhanVien;
                frm2.ShowDialog(); 
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa.");
            }
        }

        private void UpdateNhanVien(NhanVien nhanvien)
        {
            var original = nhanviens.FirstOrDefault(nv => nv.ID == nhanvien.ID);
            if (original != null)
            {
                original.Tên = nhanvien.Tên;
                original.Lương = nhanvien.Lương;
            }
            UpdateDataGridView();
        }

        private void UpdateDataGridView()
        {
            dtgNhanVien.DataSource = null; 
            dtgNhanVien.DataSource = nhanviens; 
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtgNhanVien.SelectedRows.Count > 0)
            {
                var selectedRow = dtgNhanVien.SelectedRows[0];
                var selectedNhanVien = (NhanVien)selectedRow.DataBoundItem;
                var result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa nhân viên này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                {
                    nhanviens.Remove(selectedNhanVien);
                    UpdateDataGridView(); 
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
