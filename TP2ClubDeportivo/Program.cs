using MySql.Data.MySqlClient;
using System;
using TP2ClubDeportivo.Datos;

namespace TP2ClubDeportivo
{
    internal class Program
    {
        private const int OpcionAgregarServicio = 1;
        private const int OpcionMostrarDetalles = 2;
        private const int OpcionSalir = 3;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Conexion miConexion = Conexion.getInstancia();

            // Obtener una conexión a la base de datos
            MySqlConnection conexion = miConexion.CrearConexion();

            try
            {
                // Abrir la conexión
                conexion.Open();

                Console.WriteLine("¡Conexión exitosa a la base de datos!");
               
                Console.WriteLine("Presiona Enter para continuar...");
                Console.ReadLine(); // Espera a que el usuario presione Enter

                // Aca se pueden realizar consultas o realizar otras operaciones en la base de datos
                Test.MostrarMenu();

                // Cerrar la conexión
                conexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            //Test.MostrarMenu();
        }

    }
}







