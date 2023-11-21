namespace BackendWM.Entities
{
    public class Plato
    {
        public Plato()
        {
            PlatoIngrediente = new HashSet<PlatoIngrediente>();
        }

        public int Id { get; set; }
        public int PaisId { get; set; }
        public string Nombre { get; set; }
        public virtual Pais Pais { get; set; }
        public virtual ICollection<PlatoIngrediente> PlatoIngrediente { get; set; }
    }

    public class PlatoIngrediente
    {
        public int Id { get; set; }
        public int PlatoId { get; set; }
        public int IngredienteId { get; set; }
        public Plato Plato { get; set; }
        public Ingrediente Ingrediente { get; set; }
    }
}
