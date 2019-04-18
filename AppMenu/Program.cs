using AppMenuModel.DAL;
using AppMenuModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMenu
{
    class Program
    {
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
                    new PersonaDAL().Agregar();
                    // Hay que agregar
                    break;
                case "2":
                    new PersonaDAL().Eliminar();
                    // Hay que eliminar
                    break;
                case "3":
                    new PersonaDAL().Listar();
                    // Hay que listar
                    break;
                case "4":
                    new PersonaDAL().Buscar();
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

        
    }
}
