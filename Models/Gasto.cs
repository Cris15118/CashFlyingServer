namespace CashFlyingServer.Models
{
    public class Gasto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public Categoria Categoria { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public Gasto(int Id, string Nombre, int Cantidad, Categoria Categoria, string Descripcion, DateTime Fecha)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Cantidad = Cantidad;
            this.Categoria = Categoria;
            this.Descripcion = Descripcion;
            this.Fecha = Fecha;

        }
    }
}
