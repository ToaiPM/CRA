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
using System.IO;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-834A1N8\SQLEXPRESS;Initial Catalog=QLBH;Integrated Security=True");
                conn.Open();
                string sql = "insert into HangHoa(TenHang,SoLuong,Anh) values(@TenHang, @SoLuong,@Anh)";
                SqlCommand com = new SqlCommand(sql, conn);
                com.Parameters.AddWithValue("@TenHang", txtTenHang.Text);
                com.Parameters.AddWithValue("@SoLuong", numSoLuong.Text);
                com.Parameters.AddWithValue("@Anh", converImagesToBytes());
                com.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Thêm thành công");
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private byte[] converImagesToBytes()
        {
            FileStream fs = new FileStream(txtDuongDanAnh.Text, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return picbyte;
        }
        private Image byteArrayToImages(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image image = Image.FromStream(ms);
            return image;
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "JPG files (*.jpg)|*.jpg|All files (*.*)|*.*";
            f.FilterIndex = 1;
            f.RestoreDirectory = true;
            if (f.ShowDialog() == DialogResult.OK)
            {
                ptbAnh.ImageLocation = f.FileName;
                txtDuongDanAnh.Text = f.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-834A1N8\SQLEXPRESS;Initial Catalog=QLBH;Integrated Security=True");
                conn.Open();
                string sql = "select * from HangHoa";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                int imageIndex = 0;
                for(int i = 0; i< dt.Rows.Count; i++)
                {
                    imageList1.Images.Add(byteArrayToImages((byte[])dt.Rows[i]["Anh"]));
                    ListViewItem viewItem1 = new ListViewItem(dt.Rows[i]["TenHang"].ToString());
                    viewItem1.ImageIndex = imageIndex;
                    listView1.Items.Add(viewItem1);
                    imageIndex++;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
