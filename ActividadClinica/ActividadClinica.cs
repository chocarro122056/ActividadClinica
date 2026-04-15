using System.Text.Json;
using ActividadClinica.DTOs;
using ActividadClinica.Entidades;

namespace ActividadClinica
{
	public class ActividadClinica
	{
		private const string RutaJSON = "Datos\\Datos.json";

		public List<Evento> ObtenerEventos()
		{
			string rutaJson = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, RutaJSON);
			string json = File.ReadAllText(rutaJson);

			try
			{
				var rawEventos = JsonSerializer.Deserialize<List<EventoDTO>>(json) ?? [];
				List<Evento> eventos = new List<Evento>();

				foreach (var raw in rawEventos)
				{
					if (!string.IsNullOrEmpty(raw.Accion))
					{
						eventos.Add(new Evento
						{
							Fecha = raw.Timestamp,
							TipoEvento = raw.Accion,
							IdPaciente = raw.PacienteId
						});
					}
				}

				return eventos;
			}
			catch (Exception)
			{
				return new List<Evento>();
			}
		}
	}
}

