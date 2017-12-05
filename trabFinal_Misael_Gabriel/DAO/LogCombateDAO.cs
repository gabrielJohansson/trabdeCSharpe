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

        public static List<LogCombate> RetornarLogP(int id)
        {
            return ctx.LogsDosCombates.Where(x => x.personagem.IDPesonagem == id).Include(x => x.personagem).Include(x => x.missao).ToList();
        }

        public static List<LogCombate> RetornarLogM(int id)
        {
            return ctx.LogsDosCombates.Where(x => x.missao.IDMissao== id).Include(x => x.personagem).Include(x => x.missao).ToList();
        }

    }
}

    

