using BlazorAPIEmpleados.Models.Request;
using BlazorAPIEmpleados.Data;
using BlazorAPIEmpleados.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorAPIEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            EmpleadosResponse oRespuesta = new EmpleadosResponse();
            try
            {

                using (Contexto db = new Contexto())
                {
                    var lst = db.Empleados.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Lista = lst;
                }
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }


            return Ok(oRespuesta);
        }
        [HttpGet("{EmpleadoId}")]
        public IActionResult Get(int EmpleadoId)
        {
            EmpleadosResponse oRespuesta = new EmpleadosResponse();
            try
            {

                using (Contexto db = new Contexto())
                {
                    Empleados Empleado = db.Empleados.Find(EmpleadoId);
                    oRespuesta.Exito = 1;
                    oRespuesta.EmpleadoRespuesta= Empleado;
                }
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }


            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(Empleados Empleado)
        {
            EmpleadosResponse oRespuesta = new EmpleadosResponse();
            try
            {

                using (Contexto db = new Contexto())
                {
                    db.Empleados.Add(Empleado);
                    if(db.SaveChanges()>0)
                    {
                        db.SaveChanges();
                        oRespuesta.Mensaje = "Exito";
                        oRespuesta.Exito = 1;
                        oRespuesta.EmpleadoRespuesta = db.Empleados.Find(Empleado.EmpleadoId);

                    }

                }
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
                throw;
            }


            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Edit(Empleados Empleado)
        {
            EmpleadosResponse oRespuesta = new EmpleadosResponse();
            try
            {

                using (Contexto db = new Contexto())
                {
                    db.Entry(Empleado).State = EntityState.Modified;
                    if (db.SaveChanges() > 0)
                    {
                        db.SaveChanges();
                        oRespuesta.Mensaje = "Exito";
                        oRespuesta.Exito = 1;
                        oRespuesta.EmpleadoRespuesta = db.Empleados.Find(Empleado.EmpleadoId);

                    }

                }
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
                throw;
            }


            return Ok(oRespuesta);
        }
        [HttpDelete("{EmpleadoId}")]
        public IActionResult Delete(int EmpleadoId)
        {
            EmpleadosResponse oRespuesta = new EmpleadosResponse();
            try
            {

                using (Contexto db = new Contexto())
                {
                    Empleados Empleado = db.Empleados.Find(EmpleadoId);
                    db.Empleados.Remove(Empleado);
                    if(db.SaveChanges()>0)
                    {
                        oRespuesta.Exito = 1;
                        oRespuesta.Mensaje = "empleado eliminado correctamente";
                        
                    }
                    else
                    {
                        oRespuesta.Exito = 0;
                        oRespuesta.Mensaje = "hubo un error";
                    }
                    
                }
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }


            return Ok(oRespuesta);
        }
    }
}
