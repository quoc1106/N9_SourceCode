using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TRANGTHAI
    {
        public bool _value { set; get; }
        public string _display { set; get; }
        public TRANGTHAI()
        {

        }
        public TRANGTHAI(bool _val, string _dis)
        {
            this._value = _val;
            this._display = _dis;
        }
        public static List<TRANGTHAI> getList()
        {
            List<TRANGTHAI> lst = new List<TRANGTHAI>();
            TRANGTHAI[] collect = new TRANGTHAI[2]
            {
                new TRANGTHAI(false, "Not complete"),
                new TRANGTHAI(true, "Complete")
            };
            lst.AddRange(collect);
            return lst;
        }
    }
}
