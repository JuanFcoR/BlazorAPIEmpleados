using BlazorAPIEmpleados.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAPIEmpleados.Models.Responses
{
    public class EmpleadosResponse
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }
        public List<Empleados> Lista { get; set; } = new List<Empleados>();
        public Empleados EmpleadoRespuesta { get; set; }

        public EmpleadosResponse()
        {
            this.Exito = 0;
        }
    }
}
