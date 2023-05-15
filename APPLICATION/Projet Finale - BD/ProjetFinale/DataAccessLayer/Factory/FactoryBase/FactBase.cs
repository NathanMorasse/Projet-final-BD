using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinale.DataAccessLayer.Factory.FactoryBase
{
    internal class FactBase
    {
        private string _cnnStr = string.Empty;

        public string CnnStr
        {
            get
            {
                if(_cnnStr == string.Empty)
                {
                    //_cnnStr = "Server=127.0.0.1;Port=3306;Database=bd_projetfinal;Uid=root;Pwd=root";
                    _cnnStr = "Server=sql.decinfo-cchic.ca;Port=33306;Database=h23_web2_2130301;Uid=dev-2130301;Pwd=Nejmeh001";
                }
                return _cnnStr;
            }
        }
    }
}
