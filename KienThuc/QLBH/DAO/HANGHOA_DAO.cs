using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using DTO;

namespace DAO
{
    public class HANGHOA_DAO
    {
        public static List<HANGHOA_DTO> LayHangHoa()
        {
            string sql = "SELECT * FROM HangHoa";
            DataTable dt = DataProvider.TruyVanLayDuLieu(sql, DataProvider.MoKetNoi());
            if(dt.Rows.Count == 0)
            {
                return null;
            }
            List<HANGHOA_DTO> list = new List<HANGHOA_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HANGHOA_DTO hanghoa = new HANGHOA_DTO();
                hanghoa.IID = int.Parse(dt.Rows[i]["ID"].ToString());
                hanghoa.STenHang = dt.Rows[i]["TenHang"].ToString();
                hanghoa.ISoLuong = int.Parse(dt.Rows[i]["SoLuong"].ToString());
                hanghoa.BHinhAnh = (byte[])(dt.Rows[i]["Anh"]);
                list.Add(hanghoa);
            }
            return list;
        }
    }
}
