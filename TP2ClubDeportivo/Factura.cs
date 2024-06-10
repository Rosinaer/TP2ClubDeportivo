using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TP2ClubDeportivo.Datos;
using TP2ClubDeportivo.Servicios;

namespace TP2ClubDeportivo
{
    internal class Factura
    {
        public List<Suplementos> Suplementos { get; set; }
        public List<ServicioDeportivo> Servicios { get; set; }
        public DateTime Fecha { get; set; }

        public Factura()
        {
            Suplementos = new List<Suplementos>();
            Servicios = new List<ServicioDeportivo>();
            Fecha = DateTime.Now;
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (Suplementos suplementos in Suplementos)
            {
                total += suplementos.CalcularPrecioFinal();
            }
            foreach (ServicioDeportivo servicios in Servicios)
            {
                total += servicios.CalcularPrecio();
            }
            return total;
        }
        public void GuardarEnBaseDeDatos()
        {
            Conexion miConexion = Conexion.getInstancia();
            MySqlConnection sqlCon = miConexion.CrearConexion();

            //MySqlConnection sqlCon = new MySqlConnection();

            try
            {
                //sqlCon.Open();
                // Crear un comando SQL para insertar datos en la tabla Facturas
                string query = "INSERT INTO suplementos (Id,Nombre,PorcentajeGanancia,PrecioLista) VALUES (null,'Colageno', 0.05, 36000)";
                //string query = "INSERT INTO facturas (Id,Fecha, Total) VALUES (null,'2024-06-03', 102.50)";
                MySqlCommand comando = new MySqlCommand(query, sqlCon);
                sqlCon.Open();
                // comando.Parameters.AddWithValue("@Fecha", Fecha);
                // comando.Parameters.AddWithValue("@Total", CalcularTotal());


                comando.ExecuteNonQuery();
                Console.WriteLine("Datos guardados en la base de datos.");
                Console.WriteLine("Presiona Enter para continuar...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar en la base de datos: " + ex.Message);
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                { sqlCon.Close(); };
            }
        }
    }
}
