using System;
using System.Collections.Generic;
using System.Linq;

namespace examenGestiónDeVehículos
{
    public class Vehiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string VIN { get; set; }
        public string NombrePropietario { get; set; }

        public Vehiculo(string marca, string modelo, int anio, string vin, string nombrePropietario)
        {
            Marca = marca;
            Modelo = modelo;
            Anio = anio;
            VIN = vin;
            NombrePropietario = nombrePropietario;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Marca: {Marca}, Modelo: {Modelo}, Año: {Anio}, VIN: {VIN}, Propietario: {NombrePropietario}");
        }
    }


    internal class Program
    {
        static List<Vehiculo> vehiculos = new List<Vehiculo>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Registrar Vehículo");
                Console.WriteLine("2. Actualizar Vehículo");
                Console.WriteLine("3. Eliminar Vehículo");
                Console.WriteLine("4. Mostrar Vehículos");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarVehiculo();
                        break;
                    case "2":
                        ActualizarVehiculo();
                        break;
                    case "3":
                        EliminarVehiculo();
                        break;
                    case "4":
                        MostrarVehiculos();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opción no válida, intente de nuevo.");
                        break;
                }
            }
        }

        static void RegistrarVehiculo()
        {
            Console.Write("Ingrese la marca del vehículo: ");
            string marca = Console.ReadLine();

            Console.Write("Ingrese el modelo del vehículo: ");
            string modelo = Console.ReadLine();

            Console.Write("Ingrese el año del vehículo: ");
            int anio = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el VIN del vehículo: ");
            string vin = Console.ReadLine();

            Console.Write("Ingrese el nombre del propietario: ");
            string nombrePropietario = Console.ReadLine();

            Vehiculo vehiculo = new Vehiculo(marca, modelo, anio, vin, nombrePropietario);
            vehiculos.Add(vehiculo);

            Console.WriteLine("Vehículo registrado exitosamente.");
        }


        static void ActualizarVehiculo()
        {
            Console.Write("Ingrese el VIN del vehículo a actualizar: ");
            string vin = Console.ReadLine();

            Vehiculo vehiculo = vehiculos.FirstOrDefault(v => v.VIN == vin);
            if (vehiculo == null)
            {
                Console.WriteLine("Vehículo no encontrado.");
                return;
            }

            Console.Write("Ingrese la nueva marca del vehículo (dejar en blanco para no cambiar): ");
            string marca = Console.ReadLine();
            if (!string.IsNullOrEmpty(marca))
            {
                vehiculo.Marca = marca;
            }

            Console.Write("Ingrese el nuevo modelo del vehículo (dejar en blanco para no cambiar): ");
            string modelo = Console.ReadLine();
            if (!string.IsNullOrEmpty(modelo))
            {
                vehiculo.Modelo = modelo;
            }

            Console.Write("Ingrese el nuevo año del vehículo (dejar en blanco para no cambiar): ");
            string anioInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(anioInput))
            {
                vehiculo.Anio = int.Parse(anioInput);
            }

            Console.WriteLine("Vehículo actualizado exitosamente.");
        }

        static void EliminarVehiculo()
        {
            Console.Write("Ingrese el VIN del vehículo a eliminar: ");
            string vin = Console.ReadLine();

            Vehiculo vehiculo = vehiculos.FirstOrDefault(v => v.VIN == vin);
            if (vehiculo == null)
            {
                Console.WriteLine("Vehículo no encontrado.");
                return;
            }

            vehiculos.Remove(vehiculo);
            Console.WriteLine("Vehículo eliminado exitosamente.");
        }

        static void MostrarVehiculos()
        {
            if (vehiculos.Count == 0)
            {
                Console.WriteLine("No hay vehículos registrados.");
                return;
            }

            foreach (var vehiculo in vehiculos)
            {
                vehiculo.MostrarInformacion();
            }
        }
    }
}
