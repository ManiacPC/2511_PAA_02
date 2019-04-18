using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMenu
{
    public class Persona
    {
        // Atributos
        private static List<Persona> personas = new List<Persona>()
        {
            new Persona() { Edad = 40, Nombre = "Tulio Triviño", Rut = "12345678-5" },
            new Persona() { Edad = 25, Nombre = "Juan Carlos Bodoque", Rut = "87654321-2" },
            new Persona() { Edad = 32, Nombre = "Mario Hugo", Rut = "11223344-2" }
        };

        private string rut;
        private string nombre;
        private int edad;

        // Propiedades
        public string Rut
        {
            get { return rut; }
            set { rut = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        // Constructor

        // Métodos
        public static bool Add(Persona persona)
        {
            try
            {
                personas.Add(persona);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static List<Persona> List()
        {
            return personas;
        }

        public static int Find(string rut)
        {
            for(int i=0;i<personas.Count;i++)
            {
                if(personas[i].rut == rut)
                {
                    return i;
                }
            }

            return -1;
        }

        public static Persona Find(Persona p)
        {
            for (int i = 0; i < personas.Count; i++)
            {
                if (personas[i].Equals(p)) return personas[i];
            }

            return new Persona();
        }

        public static bool Remove(string rut)
        {
            int r = Find(rut);
            if (r >= 0)
            {
                personas.RemoveAt(r);
                return true;
            }

            return false;
        }
    }
}
