﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01.mibd
{
    public class Empleado
    {
        public int id { get; set; }
        public String Nombre { get; set; }
        public int Sueldo { get; set; }
        public virtual int DepartamentoId { get; set; }
    }
}
