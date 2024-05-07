namespace CashFlyingServer.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Usuario(int Id, string Email, string Password)
        {
            this.Id = Id;
            this.Email = Email;
            this.Password = Password;
        }
    }
}
