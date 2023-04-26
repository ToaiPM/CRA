using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using BUS;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "JPG files (*.jpg)|*.jpg|All files (*.*)|*.*";
            f.FilterIndex = 1;
            f.RestoreDirectory = true;
            if(f.ShowDialog() == DialogResult.OK)
            {
                ptbAnh.ImageLocation = f.FileName;
                txtDuongDanAnh.Text = f.FileName;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            List<HANGHOA_DTO> list = HANGHOA_BUS.LayHangHoa();
            dgvHangHoa.DataSource = list;
        }
    }
}
