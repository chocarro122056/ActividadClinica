using ActividadClinica.Entidades;

namespace ActividadClinica.Vistas
{
    public static class ConsultaCompleta
    {
        public static void Mostrar(List<Evento> eventos)
        {
           
            Console.WriteLine("Granularidad: detalle completo");

            FiltrarEventos filtro = new FiltrarEventos();

			var eventosOrdenados = filtro.OrdenarPorFecha(eventos);

			foreach (var evento in eventosOrdenados)
            {
				Console.WriteLine($"{evento.Fecha} - {MapeadorEventos.MapearEventos(evento)}");
            }
        }
    }
}
