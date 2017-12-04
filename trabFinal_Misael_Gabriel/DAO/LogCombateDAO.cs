using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trabFinal_Misael_Gabriel.Model;

namespace trabFinal_Misael_Gabriel.DAO
{
    class LogCombateDAO
    {
        
        private static Context ctx = Singleton.Instance.Context;

        //Create
        public static LogCombate CadastrarLogCombate(LogCombate lg)
        {
            
                //gravando usuario no banco
                ctx.LogsDosCombates.Add(lg);
                ctx.SaveChanges();
                return lg;

        }      

        //read
        public static List<LogCombate> RetornarLogsDosCombates()
        {
            return ctx.LogsDosCombates.ToList();
        }
        //busca por ID
        public static LogCombate BuscarLogsDosCombatesPorId(LogCombate lg)
        {
            return ctx.LogsDosCombates.Find(lg.IDLogCombate);
        }       

    }
}

    

