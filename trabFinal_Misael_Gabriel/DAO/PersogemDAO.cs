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

        //adicionar e retornar 
        public static Personagem CadastrarPersonagemEReturnID(Personagem p)
        {
            
                //gravando usuario no banco
                ctx.Personagens.Add(p);
                ctx.SaveChanges();

            return p;

        }
        //rtorna todos
        public static List<Personagem> RetornarPersonagens()
        {
            return ctx.Personagens.ToList();
        }
        //
        public static List<Personagem> RetornarPersonagensUser(int id)
        {
            return ctx.Personagens.Where(x => x.user.IDUsuario == id).ToList();
        }
      

        //retorna os personagem do usuario
        public static List<Personagem> RetornarPersonagensUsuario(Usuario u)
        {
            return ctx.Personagens.Where(x => x.user.IDUsuario==u.IDUsuario).ToList();
        }

        //retorna os chars dos usuarios
        public static List<Personagem> RetornarPersonagensDeUsuarios()
        {
            return ctx.Personagens.Where(x => x.user.Adm == false && !x.user.Login.Equals("Cemitério")).ToList();
        }
        //retorna os char do adm
        public static List<Personagem> returnPAdm()
        {
            return ctx.Personagens.Where(x => x.user.Adm == true).ToList();
        }
        //busca por ID
        public static Personagem BuscarPersonagemPorId(Personagem p)
        {
            return ctx.Personagens.Find(p.IDPesonagem);
        }

       //return feridos
       public static List<Personagem> returnFeridos(int id)
        {
            return ctx.Personagens.Where(x => x.user.IDUsuario == id && x.VidaAtual!=x.VidaTotal).ToList();
        }

        //!!!!!!!!!!!!!!!!
        //usar para a deleção
        //cura todos os personagens feridos dele
        public static void curarFeridos(int id)
        {
            List<Personagem> p =ctx.Personagens.Where(x => x.user.IDUsuario == id && x.VidaAtual != x.VidaTotal).ToList();
            for(int i=0;i<p.Count;i++)
            {
                Personagem pe = p[i];
                pe.VidaAtual = pe.VidaTotal;
                ctx.Entry(pe).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        //deleção da conta 
        //só manda os personagens para o cemit´erio
        public static void DeletarConta(int id)
        {
            Usuario u = new Usuario();
            u.IDUsuario = 9;
            u = UsuarioDAO.BuscarUsuarioPorId(u);

            List<Personagem> p = ctx.Personagens.Where(x => x.user.IDUsuario == id).ToList();
            for (int i = 0; i < p.Count; i++)
            {
                Personagem pe = p[i];
                
                pe.user = u;
                ctx.Entry(pe).State = EntityState.Modified;
                ctx.SaveChanges();
            }
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
            Usuario u = new Usuario();
            u.IDUsuario = 9;
            u= UsuarioDAO.BuscarUsuarioPorId(u);
            p.user = u;
            //vai mandar para o cemitério
            //manda para o id dessa conta
            //cemiterio aq está com id 9
            //trocar dps
            //nome do cemiterio vai ser 666
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

    }
}
