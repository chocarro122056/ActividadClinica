using ActividadClinica;
using ActividadClinica.Entidades;
using NUnit.Framework;

namespace ActividadClinicaTest
{
    
    public class FiltrarEventosTest
	{

		private List<Evento> eventos = new List<Evento>
			{
				new Evento { IdPaciente = 1, TipoEvento = "inicio_consulta", Fecha = DateTime.Parse("2026-04-14T08:45:00") },
				new Evento { IdPaciente = 1, TipoEvento = "fin_consulta", Fecha = DateTime.Parse("2026-04-14T08:45:00") },
				new Evento { IdPaciente = 1, TipoEvento = "prueba_diagnostica", Fecha = DateTime.Parse("2026-04-14T08:45:00") },
				new Evento { IdPaciente = 2, TipoEvento = "observacion_clinica", Fecha = DateTime.Parse("2026-04-14T08:45:00") },
				new Evento { IdPaciente = 2, TipoEvento = "llegada_paciente", Fecha = DateTime.Parse("2026-04-14T08:45:00") },
				new Evento { IdPaciente = 2, TipoEvento = "inicio_consulta", Fecha = DateTime.Parse("2026-04-14T08:45:00") },
				new Evento { IdPaciente = 2, TipoEvento = "fin_consulta", Fecha = DateTime.Parse("2026-04-14T08:45:00") },
				new Evento { IdPaciente = 2, TipoEvento = "observacion_clinica", Fecha = DateTime.Parse("2026-04-14T08:45:00") },
				new Evento { IdPaciente = 1, TipoEvento = "llegada_paciente", Fecha = DateTime.Parse("2026-04-14T08:45:00") },
		}; 


		[Test]
		public void AplicarReglaOrdenPorFechaTest()
		{
			FiltrarEventos filtrar = new ();
			var eventosOrdenados = filtrar.OrdenarPorFecha(eventos);
			var eventoPrimeroEsperado = new Evento { Fecha = DateTime.Parse("2026-04-14T08:45:00"), TipoEvento = "llegada_paciente", IdPaciente = 1 };

			Assert.Multiple(() =>
			{
				Assert.That(eventosOrdenados.First().Fecha, Is.EqualTo(eventoPrimeroEsperado.Fecha));
				Assert.That(eventosOrdenados.First().TipoEvento, Is.EqualTo(eventoPrimeroEsperado.TipoEvento));
				Assert.That(eventosOrdenados.First().IdPaciente, Is.EqualTo(eventoPrimeroEsperado.IdPaciente));
			});
		}

		[Test]
		public void AplicarAgruparPorTipoEventoTest()
		{
			FiltrarEventos filtrar = new ();
			var eventosAgrupados = filtrar.AgruparPorClave(eventos, eventos => eventos.TipoEvento);

			Assert.Multiple(() =>
			{
				Assert.That(eventosAgrupados["inicio_consulta"].Count, Is.EqualTo(2));
				Assert.That(eventosAgrupados["llegada_paciente"].Count, Is.EqualTo(2));
				Assert.That(eventosAgrupados["observacion_clinica"].Count, Is.EqualTo(2));
				Assert.That(eventosAgrupados["fin_consulta"].Count, Is.EqualTo(2));
				Assert.That(eventosAgrupados["prueba_diagnostica"].Count, Is.EqualTo(1));

			});
		}

	}
}
