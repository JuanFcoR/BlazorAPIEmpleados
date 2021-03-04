using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BlazorAPIEmpleados.Models.Request
{
    public class Estatus
    {
        [Key]
        public int EstatusId { get; set; }
        public string Descripcion { get; set; }
    }
}
