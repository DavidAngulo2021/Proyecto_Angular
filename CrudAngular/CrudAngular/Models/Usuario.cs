using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudAngular.Models
{
    public class Usuario
    {
        public  int id_usuario { get; set; }

        public string nombre { get; set; }

        public int edad { get; set; }

        public string descripcion { get; set; }



        public Usuario() { }

        public Usuario(int id, string Nombre ,int Edad, string desc)
        {
            id_usuario = id;
            nombre = Nombre;
            edad = Edad; 
            descripcion= desc;
        }

        public Usuario(string Nombre, int Edad, string desc)
        {
            nombre = Nombre;
            edad = Edad;
            descripcion = desc;
        }


    }
}