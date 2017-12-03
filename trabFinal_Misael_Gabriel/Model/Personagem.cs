using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabFinal_Misael_Gabriel.Model
{
    [Table("Personagens")]
    class Personagem
    { 
     
        [Key]
        public int IDPesonagem { get; set; }
        public String Nome { get; set; }
        public DateTime UltimaConexao { get; set; }
        public Double VidaTotal { get; set; }
        public Double VidaAtual { get; set; }
        public int Ataque { get; set; }
        public String Elemento { get; set; }
        public int Iniciativa { get; set; }
        public int Missao { get; set; }
        public int Level { get; set; }
        public Double Experiencia { get; set; }
        public int Modelo { get; set; }

        public Usuario user { get; set; }

     public Personagem()
        {
            Usuario user = new Usuario();
        }
    }
}
