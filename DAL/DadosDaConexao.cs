using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DadosDaConexao
    {
        public static String StringDaConexao
        {
            get
            {
                return "server=localhost;user id=root;pwd=123456;persistsecurityinfo=True;database=controledeestoque";
            }
        }
    }
}
