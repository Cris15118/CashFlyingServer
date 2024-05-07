namespace CashFlyingServer.Models
{
    public class Presupuesto
    {
        public int Id { get; set; }
        public int Saldo { get; set; }
        public Presupuesto(int Saldo, int Id)

        {
            this.Id = Id;
            this.Saldo = Saldo;
        }
    }
}
