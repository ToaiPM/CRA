using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HANGHOA_DTO
    {
        private int iID;
        private string sTenHang;
        private int iSoLuong;
        private byte[] bHinhAnh;

        public int IID
        {
            get
            {
                return iID;
            }

            set
            {
                iID = value;
            }
        }

        public string STenHang
        {
            get
            {
                return sTenHang;
            }

            set
            {
                sTenHang = value;
            }
        }

        public int ISoLuong
        {
            get
            {
                return iSoLuong;
            }

            set
            {
                iSoLuong = value;
            }
        }

        public byte[] BHinhAnh
        {
            get
            {
                return bHinhAnh;
            }

            set
            {
                bHinhAnh = value;
            }
        }
    }
}
