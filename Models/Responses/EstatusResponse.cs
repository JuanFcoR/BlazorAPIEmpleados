using BlazorAPIEmpleados.Data;
using BlazorAPIEmpleados.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAPIEmpleados.Models.Responses
{
    public class EstatusResponse
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }
        public List<Estatus> Lista { get; set; } = new List<Estatus>();
        public Estatus EstatusRespuesta { get; set; }

        public EstatusResponse()
        {
            this.Exito = 0;
        }
    }
}
