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
                    _cnnStr = "Server=localhost;Port=3306;Database=bd_projetfinal;Uid=root;Pwd=root";
                }
                return _cnnStr;
            }
        }
    }
}
