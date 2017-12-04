using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trabFinal_Misael_Gabriel.Model;

namespace trabFinal_Misael_Gabriel.DAO
{

    class DetalheLogDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static bool CadastrarLogDet(DetalheLog dtg)
        {
           
                ctx.DetalheLog.Add(dtg);
                ctx.SaveChanges();
                return true;          
        }
    }
}
