using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class PlatoDto
    {
        public int Id { get; set; }
        public int PaisId { get; set; }
        public string Nombre { get; set; }
        public string? Ingrediente_Nombre { get; set; }
        public List<IngredientePlatoDto> IngredientePlatoSeleccionados { get; set; }
    }

    public class IngredientePlatoDto
    {
        public int Idingrediente { get; set; }
        public string Nombre { get; set; }
        public bool Seleccionado { get; set; }
    }
}
