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
        public static bool CadastrarLogCombate(LogCombate lg)
        {
            try
            {
                //gravando usuario no banco
                ctx.LogsDosCombates.Add(lg);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
        //update
        public static bool AlterarLogCombate(LogCombate lg)
        {
            try
            {
                ctx.Entry(lg).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
        //delete
        public static bool RemoverLogCombate(LogCombate lg)
        {
            try
            {
                ctx.LogsDosCombates.Remove(lg);
                ctx.SaveChanges();
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }


    }
}

    

