using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trabFinal_Misael_Gabriel.Model;

namespace trabFinal_Misael_Gabriel.DAO
{
    class UsuarioDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        //Create
        public static bool CadastrarUsuario(Usuario usuario)
        {
            usuario.Adm = false;
            usuario.Gold = 100;
            //tava dando erro nisso,ver para proximos!!!
            usuario.UltimaConexao = DateTime.Now;
            try
            {
                //gravando usuario no banco
               
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
           }
        }
        //read
        public static List<Usuario> RetornarUsuarios()
        {
            //retorna apenas usuers,n adms
            Usuario f = new Usuario();
            f.Adm = false;
            return ctx.Usuarios.Where(x => x.Adm==f.Adm && !x.Login.Equals("Cemitério")).ToList();
        }
        //busca por ID
        public static Usuario BuscarUsuarioPorId(Usuario s)
        {
            return ctx.Usuarios.Find(s.IDUsuario);
        }
        //busca por login
        public static Usuario BuscarUsuarioPorLogin(Usuario s)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Login.Equals(s.Login));
        }
        //validar o login
        public static Usuario Logar(Usuario s)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Login.Equals(s.Login) && x.Senha.Equals(s.Senha));
        }
        //update
        public static bool AlterarUsuario(Usuario s)
        {
            try
            {
                ctx.Entry(s).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
        //delete
        public static bool RemoverUsuario(Usuario s)
        {
            try
            {
                ctx.Usuarios.Remove(s);
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
