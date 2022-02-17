using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Ejercicio1_3App.Models
{
    public class Empleados
    {
        [PrimaryKey, AutoIncrement]
        public int codigo { get; set; }

        [MaxLength(100)]
        public String nombres { get; set; }

        [MaxLength(100)]
        public String apellidos { get; set; }

        public Int32 edad { get; set; }

        [MaxLength(120)]
        public String correo { get; set; }

        [MaxLength(150)]
        public String direccion { get; set; }

    }
}
