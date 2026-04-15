using ActividadClinica.Entidades;

namespace ActividadClinica.Vistas
{
	public static class ConsultaPorDias
	{
		public static void Mostrar(List<Evento> eventos)
		{
			Console.WriteLine("Granularidad: detalle por día");

			FiltrarEventos filtrar = new ();
			var eventosPorDia = filtrar.AgruparPorClave(eventos, e => e.Fecha.Date);

			foreach (var dia in eventosPorDia)
			{
				var lineas = filtrar.AgruparPorClave(dia.Value, e => e.TipoEvento)
								.OrderBy(e => Constantes.PrioridadEventos[e.Key])
								.Select(g => $"- {MapeadorEventos.MapearEventosAgrupados(g.Key, g.Value.Count)}");

				Console.WriteLine(dia.Key.ToString("dd/MM/yyyy"));
				Console.WriteLine(string.Join("\n", lineas));
			}
		}

	}

}

