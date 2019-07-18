using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimapontoTest.Controller.Data
{
    public class AppGlobal
    {
        public static readonly String conn = "Data Source=MASTRO;Initial Catalog=BDVimaponto;Integrated Security=True";
        public static DSVimaponto dsGlobal = new DSVimaponto();
        public String sQuery = "";
        public static readonly String formatoDataBD = "yyyyMMdd hh:MM:ss";

    }
}
