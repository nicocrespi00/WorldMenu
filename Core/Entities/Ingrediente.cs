namespace BackendWM.Entities
{
    public class Ingrediente
    {
        public Ingrediente()
        {
            PlatoIngrediente = new HashSet<PlatoIngrediente>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal CaloriasX100mg { get; set; }
        public decimal FibraX100mg { get; set; }
        public decimal PotasioX100mg { get; set; }
        public bool TieneYodo { get; set; }
        public bool TieneCalcio { get; set; }
        public string LinkFoto { get; set; }
        public virtual ICollection<PlatoIngrediente> PlatoIngrediente { get; set; }
    }
}
