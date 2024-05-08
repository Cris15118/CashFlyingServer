using System.Text.Json.Serialization;

namespace CashFlyingServer.Models
{

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Categoria
    {
        Casa = 1,
        Gastos,
        Ocio,
        Comida,
        Salud,
        Suscripciones
    }
}
