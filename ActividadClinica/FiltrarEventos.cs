
using ActividadClinica.Entidades;

namespace ActividadClinica
{
	public class FiltrarEventos
	{
		public Dictionary<TKey, List<Evento>> AgruparPorClave<TKey>(List<Evento> eventos, Func<Evento, TKey> selector) where TKey : notnull =>
			eventos.GroupBy(selector).ToDictionary(e => e.Key, e => e.ToList());

		public List<Evento> OrdenarPorFecha(List<Evento> eventos) =>
			eventos.OrderBy(evento => evento.Fecha)
			.ThenBy(evento => Constantes.PrioridadEventos[evento.TipoEvento])
			.ThenBy(evento => evento.IdPaciente)
			.ToList();	
		
	}
}
