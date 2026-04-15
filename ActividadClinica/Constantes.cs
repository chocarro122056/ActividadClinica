namespace ActividadClinica
{
    public class Constantes
    {
		public const string LlegadaPaciente = "llegada_paciente";
		public const string InicioConsulta = "inicio_consulta";
		public const string FinConsulta = "fin_consulta";
		public const string ObservacionClinica = "observacion_clinica";
		public const string PruebaDiagnostica = "prueba_diagnostica";

		public static readonly Dictionary<string, int> PrioridadEventos = new Dictionary<string, int>
		{
			{ LlegadaPaciente, 1 },
			{ InicioConsulta, 2 },
			{ FinConsulta, 3 },
			{ ObservacionClinica, 4 },
			{ PruebaDiagnostica, 5 }
		};

	}
}
