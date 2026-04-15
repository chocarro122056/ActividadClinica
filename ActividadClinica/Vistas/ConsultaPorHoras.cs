using ActividadClinica.Entidades;

namespace ActividadClinica.Vistas
{
    public class ConsultaPorHoras
    {
        public static void Mostrar(List<Evento> eventos)
        {
            Console.WriteLine("Granularidad: detalle por horas");

            FiltrarEventos filtrar = new();

			var eventosPorHora = filtrar.AgruparPorClave(eventos, evento => evento.Fecha.Hour);
		
			foreach (var hora in eventosPorHora)
			{
				var lineas = filtrar.AgruparPorClave(hora.Value, e => e.TipoEvento)
					.OrderBy(e => Constantes.PrioridadEventos[e.Key])
					.Select(g => $"- {MapeadorEventos.MapearEventosAgrupados(g.Key, g.Value.Count)}");

				Console.Write($"{hora.Key}:00\n");
				Console.WriteLine(string.Join("\n", lineas));
			}
			
        }
    }
}
