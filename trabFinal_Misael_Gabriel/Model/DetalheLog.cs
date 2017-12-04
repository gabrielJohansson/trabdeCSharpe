using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabFinal_Misael_Gabriel.Model
{
    [Table("DetalheLog")]
    class DetalheLog
    {
        [Key]
        public int IDDetalheLog { get; set; }
        public int Turno { get; set; }
        public String Acao { get; set; }

        public LogCombate log { get; set; }
        public DetalheLog()
        {
            LogCombate log = new LogCombate();
        }
    }
}
