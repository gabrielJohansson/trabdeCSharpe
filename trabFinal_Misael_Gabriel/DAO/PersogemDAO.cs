using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trabFinal_Misael_Gabriel.Model;

namespace trabFinal_Misael_Gabriel.DAO
{
    class PersogemDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        //Create
        public static bool CadastrarPersonagem(Personagem p)
        {
            try
            {
                //gravando usuario no banco
                ctx.Personagens.Add(p);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //rtorna todos
        public static List<Personagem> RetornarPersonagens()
        {
            return ctx.Personagens.ToList();
        }

        //retorna os personagem do usuario
        public static List<Personagem> RetornarPersonagensUsuario(Usuario u)
        {
            return ctx.Personagens.Where(x => x.user.IDUsuario==u.IDUsuario).ToList();
        }
        //busca por ID
        public static Personagem BuscarPersonagemPorId(Personagem p)
        {
            return ctx.Personagens.Find(p.IDPesonagem);
        }
        //update
        public static bool AlterarPersonagem(Personagem p)
        {
            try
            {
                ctx.Entry(p).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
        //delete
        public static bool RemoverPersonagem(Personagem p)
        {
            try
            {
                ctx.Personagens.Remove(p);
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
