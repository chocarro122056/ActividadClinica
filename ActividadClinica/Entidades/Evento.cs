namespace ActividadClinica.Entidades
{
    public class Evento
    {
        public required DateTime Fecha { get; set; }
        public required string TipoEvento { get; set; }
        public required int IdPaciente { get; set; }
	}
}
