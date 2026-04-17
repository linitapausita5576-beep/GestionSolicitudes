namespace Enumeradores
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Solicitud> Listasolicitud = new List<Solicitud>();
            Double opcion = 0;

            while (opcion != 5)
            {
                Console.WriteLine("\nMENU");
                Console.WriteLine("1. Registrar una nueva solicitud");
                Console.WriteLine("2. Mostrar Todas las solicitudes registradas");
                Console.WriteLine("3. Cambiar el estado de una solicitud existente");
                Console.WriteLine("4. Buscar una solicitud por el ID ");
                Console.WriteLine("5. Finalizar");
                Console.Write("Selecciona: ");
                opcion = Convert.ToDouble(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Solicitud nueva = new Solicitud();
                        Console.Write("Ingresa el ID: ");
                        nueva.id = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Ingresa el nombre: ");
                        nueva.nombre = Console.ReadLine();
                        Console.Write("Ingresa la descripcion: ");
                        nueva.descripcion = Console.ReadLine();
                        Console.WriteLine("Estado (0:Pendiente, 1:En proceso, 2:Completada, 3:Cancelada): ");
                        nueva.estado = (EstadoSolicitud)Convert.ToDouble(Console.ReadLine());
                        Listasolicitud.Add(nueva);
                        break;

                    case 2:
                        foreach (var t in Listasolicitud) t.MostrarInformacion();
                        break;

                    case 3:
                        Console.WriteLine("Ingresa el ID de la solicitud a modificar");
                        Double idmodificar = Convert.ToDouble(Console.ReadLine());
                        Solicitud solicitudModificar = Listasolicitud.Find(t => t.id == idmodificar);

                        if (solicitudModificar != null)
                        {
                            Console.WriteLine($"Tarea actual: {solicitudModificar.nombre} ({solicitudModificar.estado})");
                            Console.WriteLine("Nuevo Estado (0:Pendiente, 1:En proceso, 2:Completada, 3:Cancelada): ");
                            Double nuevaP = Convert.ToDouble(Console.ReadLine());
                            solicitudModificar.estado = (EstadoSolicitud)nuevaP;
                            Console.WriteLine("Estado actualizado con mucho exito!");
                        }
                        else
                        {
                            Console.WriteLine("ID no valido.");
                        }
                        break;

                    case 4:
                        Console.Write("Ingresa el ID a buscar: ");
                        Double idBuscar = Convert.ToDouble(Console.ReadLine());
                        Solicitud encontrada = Listasolicitud.Find(t => t.id == idBuscar);

                        if (encontrada != null)
                        {
                            Console.WriteLine("Resultado: ");
                            encontrada.MostrarInformacion();
                        }
                        else
                        {
                            Console.WriteLine("No se encontro ninguna solicitud con ese ID.");
                        }
                        break;
                }
            }
        }
    }

    class Solicitud
    {
        public double id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public EstadoSolicitud estado { get; set; }
        public void MostrarInformacion()
        {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"NOMBRE DEL CLIENTE: {nombre}");
            Console.WriteLine($"DESCRIPCION DE LA SOLICITUD: {descripcion}");
            Console.WriteLine($"ESTADO DE LA SOLICITUD: {estado}");
        }
    }

    enum EstadoSolicitud
    {
        Pendiente,
        Enproceso,
        Completada,
        Cancelada
    }
}