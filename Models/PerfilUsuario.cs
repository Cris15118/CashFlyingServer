namespace CashFlyingServer.Models
{
    public class PerfilUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
        public int Telefono { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Poblacion { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }


        public PerfilUsuario(int Id, string Nombre, string Apellidos, string Email, int Edad, int Telefono, string Calle, int Numero, string Poblacion, string Provincia, string Pais)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
            this.Email = Email;
            this.Edad = Edad;
            this.Telefono = Telefono;
            this.Calle = Calle;
            this.Numero = Numero;
            this.Poblacion = Poblacion;
            this.Provincia = Provincia;
            this.Pais = Pais;


        }
    }
}