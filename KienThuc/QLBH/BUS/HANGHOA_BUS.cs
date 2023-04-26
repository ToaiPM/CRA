using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class HANGHOA_BUS
    {
        public static List<HANGHOA_DTO> LayHangHoa()
        {
            return HANGHOA_DAO.LayHangHoa();
        }
    }
}
