using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trabFinal_Misael_Gabriel.Model;

namespace trabFinal_Misael_Gabriel.DAO
{
    class MissaoDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        //Create
        public static bool CadastrarMissao(Missao m)
        {
            try
            {
                //gravando usuario no banco
                ctx.Missoes.Add(m);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //retorna com o personagem
        public static List<Missao> RetornarMissoes()
        {
            return ctx.Missoes.Include(x => x.personagem).ToList();
        }
        //busca por ID
        public static Missao BuscarMissaoPorId(Missao m)
        {
            return ctx.Missoes.Find(m.IDMissao);
        }

        //update
        public static bool AlterarMissao(Missao m)
        {
            try
            {
                ctx.Entry(m).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
        //delete
        public static bool RemoverMissao(Missao m)
        {
            try
            {
                ctx.Missoes.Remove(m);
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

