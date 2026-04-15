using ActividadClinica.Entidades;
using ActividadClinica.Vistas;

ActividadClinica.ActividadClinica controller = new ();
List<Evento> eventos = controller.ObtenerEventos();

while (true)
{
    if(eventos.Count == 0)
    {
        Console.Clear();
        Console.WriteLine("No hay eventos disponibles para mostrar.");
        Console.WriteLine("Presione cualquier tecla para salir...");
        Console.ReadKey(intercept: true);
        break;
	}

	Console.Clear();
    Console.WriteLine("=== Actividad clínica ===");
    Console.WriteLine("¿Qué desea consultar?");
    Console.WriteLine("  1. Granularidad: Detalle completo");
    Console.WriteLine("  2. Granularidad: Por horas");
    Console.WriteLine("  3. Granularidad: Por día");
    Console.WriteLine();
    Console.Write("Seleccione una opción (Ctrl+X para salir): ");

    var key = Console.ReadKey(intercept: true);

    if (key.Modifiers == ConsoleModifiers.Control && key.Key == ConsoleKey.X)
        break;

    Console.WriteLine();

    switch (key.KeyChar.ToString())
    {
        case "1":
            ConsultaCompleta.Mostrar(eventos);
            break;
        case "2":
            ConsultaPorHoras.Mostrar(eventos);
            break;
        case "3":
            ConsultaPorDias.Mostrar(eventos);
            break;
        default:
            Console.WriteLine("Opción no válida.");
            break;
    }

    Console.WriteLine();
    Console.Write("Presione cualquier tecla para volver al menú...");
    Console.ReadKey(intercept: true);
}
