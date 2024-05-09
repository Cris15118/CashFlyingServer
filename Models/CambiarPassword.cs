namespace CashFlyingServer.Models
{
    public class CambiarPassword
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public CambiarPassword(int Id, string Password, string NewPassword)
        {
            this.Id = Id;
            this.Password = Password;
            this.NewPassword = NewPassword;
        }
    }
}
<<<<<<< HEAD
=======

>>>>>>> 1f578c02a6a71625a97c506874dc5773847de47e
