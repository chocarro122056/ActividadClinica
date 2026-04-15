using System.Text.Json.Serialization;

namespace ActividadClinica.DTOs
{
    public class EventoDTO
    {
		[JsonPropertyName("timestamp")]
		public DateTime Timestamp { get; set; }

		[JsonPropertyName("accion")]
		public required string Accion { get; set; }

		[JsonPropertyName("paciente_id")]
		public int PacienteId { get; set; }
	}
}
