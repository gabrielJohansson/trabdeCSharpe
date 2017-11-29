using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabFinal_Misael_Gabriel.Model
{
    [Table("Missoes")]
    class Missao
    {
        [Key]
        public int IDMissao { get; set; }
        public Double ExperienciaConcedida { get; set; }
        public Double GoldConcedido { get; set; }
        public String Name { get; set; }
        public String Descricao { get; set; }
        public Personagem personagem { get; set; }
    }
}
