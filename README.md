# Actividad clínica y agregación temporal

La aplicación de consola ha sido diseñada e implementada en .NET 10 y permite consultar los eventos clínicos agrupados con distintos niveles de granularidad solicitados en el ejercicio.

## Cómo ejecutar la solución

Desde la carpeta ActividadClinica, ejecutar en terminal los siguientes comandos (Es necesario tener instalado [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)):

```bash
cd ActividadClinica
dotnet run
```
### Uso del menú

Una vez iniciada la aplicación por consola, se mostrará un menú con tres opciones:

| Tecla | Opción                          |
|-------|---------------------------------|
| `1`   | Granularidad: Detalle completo  |
| `2`   | Granularidad: Por horas         |
| `3`   | Granularidad: Por día           |
| Ctrl+X | Salir                          |

Cada vista muestra los eventos del archivo `ActividadClinica/Datos/Datos.json` ordenados y agrupados según la granularidad seleccionada.

En el caso en el que los datos no sean válidos o el fichero esté vacío, se mostrará en la terminal el mensaje: "No hay eventos disponibles para mostrar."

### Cómo ejecutar test unitarios

```bash
cd ActividadClinicaTest
dotnet test
```

Las test implementados verifican la funcionalidad de agrupación y orden de los datos.

## Análisis del diseño de la aplicación
En el siguiente esquema, se puede observar una vista general de la estructura de la solución implementada.

```
ActividadClinica/
├── ActividadClinica/            
│   ├── Datos/
│   │   └── Datos.json          # Fuente de datos de eventos clínicos
│   ├── DTOs/                   # EventoDTO para deserialización JSON
│   ├── Entidades/              # Clase Evento
│   ├── Vistas/                 # ConsultaCompleta, ConsultaPorHoras, ConsultaPorDias      
│   ├── ActividadClinica.cs     # Carga y parsea los eventos desde JSON
│   ├── FiltrarEventos.cs       # Lógica de ordenación y agrupación
│   ├── MapearEventos.cs        # Transformar los id de los eventos por cada tipo de evento
│   └── Program.cs              # Menú interactivo de consola
└── ActividadClinicaTest/       # Proyecto de tests (NUnit)
    └── FiltrarEventosTest.cs
```

## Datos de entrada

El archivo `ActividadClinica/Datos/Datos.json` contiene los eventos en formato JSON:

```json
[
  {
    "timestamp": "2026-04-14T08:45:00",
    "accion": "llegada_paciente",
    "pacienteId": 1
  }
]
```

Para ello, he definido un identificador único con el fin identificar cada tipo de evento existente:
- `llegada_paciente`
- `inicio_consulta`
- `fin_consulta`
- `observacion_clinica`
- `prueba_diagnostica`

### Regla de orden determinista
Para solucionar la problemática planteada ante el caso de que dos eventos compartan exactamente la misma marca temporal, he decidido establecer un orden por prioridades.
Por tanto, una vez ordenado por el campo de la fecha del evento, si se da el caso de que dos eventos coinciden, se ordenarán en función del tipo de evento. Para ello he determinado las siguientes prioridades (en un caso real negocio sería el responsable de tomar esta decisión). 

- `llegada_paciente: 1`
- `inicio_consulta: 2`
- `fin_consulta: 3`
- `observacion_clinica: 4`
- `prueba_diagnostica: 5`

Si además, se da el caso de que comparten el mismo tipo de evento se pasarían a ordenar por el id del paciente en orden ascendente.

### Añadir nuevas agregaciones o tipos de eventos
Otra decisión, que he considerado importante es que para facilitar en un futuro la incorporación de un nuevo tipo de evento, en he definido una clase llamada Constantes.cs, en la que se permite modificar el identificador del evento o añadir una clave nueva sin necesidad de modificar más ficheros.

Además, si se quiere añadir una nueva agregación, se puede reutilizar el método AgruparPorClave() definido en la clase FiltrarEventos, ya que al tomar la decisión de hacerlo genérico evito la repetición de código y sobre todo añado la posibilidad de agruparlo por cualquier tipo de clave que sea necesaria.
