using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    class DataProvider
    {
        public static SqlConnection MoKetNoi()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-834A1N8\SQLEXPRESS;Initial Catalog=QLBH;Integrated Security=True");
            conn.Open();
            return conn;
        }
        public static void DongKetNoi()
        {
            MoKetNoi().Close();
        }
        public static DataTable TruyVanLayDuLieu(string sql, SqlConnection conn)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static bool TruyVanKhongLayDuLieu(string sql, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}
