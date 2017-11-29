using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trabFinal_Misael_Gabriel.Model;

namespace trabFinal_Misael_Gabriel.DAO
{
    class Context : DbContext
    {
        public Context() : base("DBTrabalho")
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Personagem> Personagens { get; set; }
        public DbSet<Missao> Missoes { get; set; }
        public DbSet<LogCombate> LogsDosCombates { get; set; }
        public DbSet<DetalheLog> DetalheLog { get;set; }
    }
}
