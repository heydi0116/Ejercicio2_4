using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Ejercicio2_4.Modelos
{
    public class Datos
    {
        [PrimaryKey, AutoIncrement]
        public int codigo { get; set; }
        public string direccion { get; set; }
        public string nombre { get; set; }


    }
}
