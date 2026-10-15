using System.Text.Json.Serialization;

namespace Projetodemecanica.api.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public TimeOnly Hora { get; set; }
        public string Serviço { get; set; }
        public int Veiculoid { get; set; }
        [JsonIgnore]
        public Veiculo? Veiculo { get; set; }
    }
}
