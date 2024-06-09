using System;
using System.Collections.Generic;
using System.Text;
using TP2ClubDeportivo.Servicios;

namespace TP2ClubDeportivo
{
    internal class Test
    {

        private static Factura factura = new Factura();
        private const int OpcionAgregarServicio = 1;
        private const int OpcionMostrarDetalles = 2;
        private const int OpcionSalir = 3;


        public static void MostrarMenu()
        {
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine(" MENÚ PRINCIPAL ");
                Console.WriteLine($"{OpcionAgregarServicio}. Agregar nuevo servicio");
                Console.WriteLine($"{OpcionMostrarDetalles}. Mostrar detalles de los servicios");
                Console.WriteLine($"{OpcionSalir}. Salir del programa");

                int opcionSeleccionada = LeerOpcion();
                ProcesarOpcion(opcionSeleccionada);
            }
            

        }

        private static int LeerOpcion()
        {
            int opcion;
            bool opcionValida = false;
            do
            {
                Console.Write("Ingrese el número de la opción deseada: ");
                opcionValida = int.TryParse(Console.ReadLine(), out opcion) && (opcion >= OpcionAgregarServicio && opcion <= OpcionSalir);
                if (!opcionValida)
                {
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                }
            } while (!opcionValida);
            return opcion;
        }

        private static void ProcesarOpcion(int opcion)
        {
            switch (opcion)
            {
                case OpcionAgregarServicio:
                    AgregarServicio();
                    break;
                case OpcionMostrarDetalles:
                    MostrarDetalles();
                    break;
                case OpcionSalir: 
                    Salir();
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                   
                    break;
            }
        }

        private static void AgregarServicio()
        {
            Console.Clear();
            Console.WriteLine("--- AGREGAR NUEVO SERVICIO ----");
            Console.WriteLine("1. Entrenamiento Personalizado");
            Console.WriteLine("2. Clases Grupales");
            Console.WriteLine("3. Venta de Suplementos");

            int tipoServicio = LeerOpcion();
            switch (tipoServicio)
            {
                case 1:
                    AgregarEntrenamientoPersonalizado();
                    break;
                case 2:
                    AgregarClasesGrupales();
                    break;
                case 3:
                    AgregarSuplemento();
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
            factura.GuardarEnBaseDeDatos();

        }

        private static void AgregarEntrenamientoPersonalizado()
        {
           
            Console.Write("Ingrese la duración en horas: ");
            int duracionHoras;

            while (!int.TryParse(Console.ReadLine(), out duracionHoras) || duracionHoras <= 0)
            {
                Console.WriteLine("Duración inválida. Intente nuevamente.");
                Console.Write("Ingrese la duración en horas: ");
            }

            EntrenamientoPersonalizado entrenamiento = new EntrenamientoPersonalizado
            {
               
                DuracionHoras = duracionHoras
            };
            factura.Servicios.Add(entrenamiento);
            factura.GuardarEnBaseDeDatos();
        }

        private static void AgregarClasesGrupales()
        {
          
            Console.Write("Ingrese el número de participantes: ");
            int numeroParticipantes;

            while (!int.TryParse(Console.ReadLine(), out numeroParticipantes) || numeroParticipantes <= 0)
            {
                Console.WriteLine("Número de participantes inválido. Intente nuevamente.");
                Console.Write("Ingrese el número de participantes: ");
            }

            Console.Write("Ingrese la duración en minutos: ");
            int duracionMinutos;

            while (!int.TryParse(Console.ReadLine(), out duracionMinutos) || duracionMinutos <= 0)
            {
                Console.WriteLine("Duración inválida. Intente nuevamente.");
                Console.Write("Ingrese la duración en minutos: ");
            }

            ClasesGrupales clase = new ClasesGrupales
            {
                
                NumeroParticipantes = numeroParticipantes,
                DuracionMinutos = duracionMinutos
            };
            factura.Servicios.Add(clase);
            factura.GuardarEnBaseDeDatos();
        }

        private static void AgregarSuplemento()
        {
            Console.Write("Ingrese el nombre del suplemento: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el porcentaje de ganancia: ");
            decimal porcentajeGanancia;
            while (!decimal.TryParse(Console.ReadLine(), out porcentajeGanancia) || porcentajeGanancia <= 0)
            {
                Console.WriteLine("Porcentaje de ganancia inválido. Intente nuevamente.");
                Console.Write("Ingrese el porcentaje de ganancia: ");
            }

            Console.Write("Ingrese el precio de lista: ");
            decimal precioLista;
            while (!decimal.TryParse(Console.ReadLine(), out precioLista) || precioLista <= 0)
            {
                Console.WriteLine("Precio de lista inválido. Intente nuevamente.");
                Console.Write("Ingrese el precio de lista: ");
            }

            Suplementos suplemento = new Suplementos
            {
                Nombre = nombre,
                PorcentajeGanancia = porcentajeGanancia,
                PrecioLista = precioLista
            };
            factura.Suplementos.Add(suplemento);
            factura.GuardarEnBaseDeDatos();
        }

        private static void MostrarDetalles()
        {
            Console.Clear();
            Console.WriteLine("DETALLES DE LOS SERVICIOS");
            foreach (var servicio in factura.Servicios)
            {
                Console.WriteLine($"Tipo: {servicio.Tipo}, Precio: {servicio.CalcularPrecio():C}");
            }

            Console.WriteLine("DETALLES DE LOS SUPLEMENTOS");
            foreach (var suplemento in factura.Suplementos)
            {
                Console.WriteLine($"Nombre: {suplemento.Nombre}, Precio: {suplemento.CalcularPrecioFinal():C}");
            }

            Console.WriteLine($"Monto total facturado: {factura.CalcularTotal():C}");
            Console.WriteLine($"Cantidad de servicios simples: {ContarServiciosSimples()}");

            Console.WriteLine("Presione cualquier tecla para volver al menú");
            Console.ReadKey();
            MostrarMenu();
        }

        private static int ContarServiciosSimples()
        {
            int cantidad = 0;
            foreach (var servicio in factura.Servicios)
            {
                if (servicio is ClasesGrupales clase && clase.NumeroParticipantes < 10)
                {
                    cantidad++;
                }
            }
            return cantidad;
        }
        private static void Salir()
        {
            factura.GuardarEnBaseDeDatos();
            Console.WriteLine("Gracias por usar el programa. ¡Hasta luego!");
            Console.WriteLine("Presiona Enter para salir...");
            Console.ReadLine();
        }
    }
}
