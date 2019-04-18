using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AppMenu.DTO; // Opcion 1

namespace AppMenu
{
    class Program
    {
        private Persona persona = new Persona();

        static void Main(string[] args)
        {
            while(Menu()) {};

            Console.ReadKey(); // Pausa
        }

        static bool Menu()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
         
            Console.Title = "Personas Manager";
            bool continuar = true;
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1) Agregar persona");
            Console.WriteLine("2) Eliminar persona");
            Console.WriteLine("3) Listar personas");
            Console.WriteLine("4) Buscar persona");
            Console.WriteLine("-------------------");
            Console.WriteLine("0) Salir");
            // 1

            string o = Console.ReadLine().Trim();

            switch (o)
            {
                case "1":
                    Agregar();
                    // Hay que agregar
                    break;
                case "2":
                    Eliminar();
                    // Hay que eliminar
                    break;
                case "3":
                    Listar();
                    // Hay que listar
                    break;
                case "4":
                    Buscar();
                    // Hay que buscar
                    break;    
                case "0":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("La opción ingresada no es válida");
                    Console.ReadKey();
                    break;
            }
           
            return continuar;
        }

        private static void Eliminar()
        {
            throw new NotImplementedException();
        }

        private static void Buscar()
        {
            Console.Write("Ingrese un rut a buscar:");
            string b = Console.ReadLine().Trim();

            int i = Persona.Find(b);
            string mensaje = 
                (i >= 0 
                ? $"Persona: {Persona.List()[i].Nombre} encontrada" 
                : $"No encontrado ({b})"
                );
            Console.WriteLine(mensaje);
            Console.ReadKey();
            //if(i >= 0)
            //{
            //    Console.WriteLine($"Persona: {Persona.List()[i].Nombre} encontrada");
            //}
            //else
            //{
            //    Console.WriteLine($"No encotrado ({b})");
            //}
        }

        private static void Listar()
        {
            List<Persona> personas = Persona.List();

            foreach(Persona p in personas)
            {
                Console.WriteLine($"Rut: {p.Rut} || Nombre: {p.Nombre} || Edad: {p.Edad}");
            }
            Console.ReadKey();
        }

        private static void Agregar()
        {
            Console.WriteLine("-- Ingrese los datos de persona --");
            Console.Write("Rut: ");
            string rut = Console.ReadLine().Trim();

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine().TrimStart().TrimEnd();

            Console.Write("Edad: ");
            int edad = 0;

            // Forma 1
            //int edad = Int32.Parse(Console.ReadLine().Trim());
            //try
            //{
            //    edad = Convert.ToInt32(Console.ReadLine().Trim());
            //}
            //catch (Exception) {}

            //Persona p = new Persona();
            //p.Rut = rut;
            //p.Nombre = nombre;
            //p.Edad = edad;

            // Forma 2
            string r = Console.ReadLine().Trim();
            if(!int.TryParse(r, out edad))  // TryParse -> bool
            {
                edad = -1;
            }

            if(!Persona.Add(
                new Persona()
                {
                    Rut = rut,
                    Nombre = nombre,
                    Edad = edad
                }))
            {
                Console.WriteLine("Ocurrió un error al ingresar persona");
            }

            Console.WriteLine($"{nombre} fue agregado exitosamente");
            Console.ReadKey();
        }
    }
}
