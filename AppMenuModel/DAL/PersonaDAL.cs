using AppMenuModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMenuModel.DAL
{
    public class PersonaDAL
    {
        public void Listar()
        {
            List<Persona> personas = Persona.List();

            foreach (Persona p in personas)
            {
                Console.WriteLine($"Rut: {p.Rut} || Nombre: {p.Nombre} || Edad: {p.Edad}");
            }
            Console.ReadKey();
        }

        public void Buscar()
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


        public void Eliminar()
        {
            Console.WriteLine("Ingrese el rut de la persona a eliminar:");
            string rut = Console.ReadLine().Trim();
            if (Persona.Remove(rut))
            {
                Console.WriteLine($"La persona con el rut: {rut} fue eliminada!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("ERROR: La persona no pudo ser eliminada");
                Console.ReadKey();
            }
        }


        public void Agregar()
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
            if (!int.TryParse(r, out edad))  // TryParse -> bool
            {
                edad = -1;
            }

            if (!Persona.Add(
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
