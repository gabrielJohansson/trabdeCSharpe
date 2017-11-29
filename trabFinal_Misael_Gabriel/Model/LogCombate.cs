using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabFinal_Misael_Gabriel.Model
{
    [Table("LogsDosCombates")]
    class LogCombate
    {
       [Key]
        public int IDLogCombate{ get; set; }
        public DateTime Data { get; set; }     

        public Personagem personagem { get; set; }

        public Missao missao { get; set; }
    }
}
