using ActividadClinica.Entidades;

namespace ActividadClinica
{
    public static class MapeadorEventos
    {

		public static string MapearEventos(Evento evento)
        {
            return evento.TipoEvento switch
            {
                Constantes.LlegadaPaciente => $"El paciente {evento.IdPaciente} llega a consulta",
                Constantes.InicioConsulta => $"Se inicia consulta con el paciente {evento.IdPaciente}",
                Constantes.FinConsulta => $"Finaliza la consulta del paciente {evento.IdPaciente}",
                Constantes.ObservacionClinica => $"Se registra una observacion clínica para el paciente {evento.IdPaciente}",
                Constantes.PruebaDiagnostica => $"Se realiza una prueba diagnóstica al paciente {evento.IdPaciente}",
                _ => string.Empty,
            };
        }

		public static string MapearEventosAgrupados(String tipoEvento, int total)
		{

			return tipoEvento switch
			{
				Constantes.LlegadaPaciente => total > 1 ? $"{total} pacientes llegaron a la consulta" : $"{total} paciente llegó a la consulta",
				Constantes.InicioConsulta => total > 1 ? $"{total} consultas se iniciaron" : $"{total} consulta se inició",
				Constantes.FinConsulta =>  total > 1 ? $"{total} consultas finalizaron" : $"{total} consulta finalizó",
				Constantes.ObservacionClinica => total > 1 ? $"{total} observaciones clínicas fueron realizadas" : $"{total} observación clínica fue realizada",
				Constantes.PruebaDiagnostica => total > 1 ? $"{total} pruebas diagnósticas fueron realizadas" : $"{total} prueba diagnóstica fue realizada",
				_ => string.Empty
			};

		}
	}
}
