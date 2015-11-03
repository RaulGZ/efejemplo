using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01.mibd
{
    public class demoEF : DbContext
    {
        public DbSet<Empleado> Empleados { get; set; }
        //para crear la base de datos, DbSet es la palabra reservada
    }
}
