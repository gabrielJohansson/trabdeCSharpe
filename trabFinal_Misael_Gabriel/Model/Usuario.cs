using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabFinal_Misael_Gabriel.Model
{
    [Table("Usuarios")]
    class Usuario
    {
        [Key]
        public int IDUsuario { get; set; }
        public String Nome { get; set; }
        public String Login { get; set; }
        public String Senha { get; set; }
        public DateTime UltimaConexao { get; set; }
        public Double Gold { get; set; }
        public bool Adm { get; set; }
    }
}
