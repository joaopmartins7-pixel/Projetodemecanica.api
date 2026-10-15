using System.Text.Json.Serialization;

namespace Projetodemecanica.api.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int ClienteId { get; set; }
        [JsonIgnore]
        public Cliente? Cliente { get; set; }
    }
}
