using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class IngredienteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal CaloriasX100mg { get; set; }
        public decimal FibraX100mg { get; set; }
        public decimal PotasioX100mg { get; set; }
        public bool TieneYodo { get; set; }
        public bool TieneCalcio { get; set; }
        public string LinkFoto { get; set; }
    }
}
