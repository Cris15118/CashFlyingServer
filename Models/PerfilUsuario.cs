namespace CashFlyingServer.Models
{
    public class PerfilUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string Segundo_Apellido { get; set; }
        public int Telefono { get; set; }
        public string Calle {  get; set; }
        public int Numero { get; set; }
        public string Poblacion {  get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }


        public PerfilUsuario(int Id, string Nombre, string Primer_Apellido, string Segundo_Apellido, int Telefono, string Calle, int Numero, string Poblacion, string Provincia, string Pais)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Primer_Apellido = Primer_Apellido;
            this.Segundo_Apellido = Segundo_Apellido;
            this.Telefono = Telefono;
            this.Calle = Calle;
            this.Numero = Numero;
            this.Poblacion = Poblacion;
            this.Provincia = Provincia;
            this.Pais = Pais;


        }
    }
}
