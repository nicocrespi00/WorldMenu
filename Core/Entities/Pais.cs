namespace BackendWM.Entities
{
    public class Pais
    {
        public Pais()
        {
            Platos = new HashSet<Plato>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Plato> Platos { get; set; }
    }
}
