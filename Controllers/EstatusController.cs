using BlazorAPIEmpleados.Data;
using BlazorAPIEmpleados.Models.Request;
using BlazorAPIEmpleados.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorAPIEstatus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstatusController : ControllerBase
    {
        // GET: api/<EstatusController>
        [HttpGet]
        public IActionResult Get()
        {
            EstatusResponse oRespuesta = new EstatusResponse();
            try
            {

                using (Contexto db = new Contexto())
                {
                    var lst = db.Estatus.ToList();
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
        [HttpGet("{EstatusId}")]
        public IActionResult Get(int EstatusId)
        {
            EstatusResponse oRespuesta = new EstatusResponse();
            try
            {

                using (Contexto db = new Contexto())
                {
                    Estatus estatus = db.Estatus.Find(EstatusId);
                    oRespuesta.Exito = 1;
                    oRespuesta.EstatusRespuesta = estatus;
                }
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }


            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(Estatus estatus)
        {
            EstatusResponse oRespuesta = new EstatusResponse();
            try
            {

                using (Contexto db = new Contexto())
                {
                    db.Estatus.Add(estatus);
                    if (db.SaveChanges() > 0)
                    {
                        db.SaveChanges();
                        oRespuesta.Mensaje = "Exito";
                        oRespuesta.Exito = 1;
                        oRespuesta.EstatusRespuesta = db.Estatus.Find(estatus.EstatusId);

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
        public IActionResult Edit(Estatus estatus)
        {
            EstatusResponse oRespuesta = new EstatusResponse();
            try
            {

                using (Contexto db = new Contexto())
                {
                    db.Entry(estatus).State = EntityState.Modified;
                    if (db.SaveChanges() > 0)
                    {
                        db.SaveChanges();
                        oRespuesta.Mensaje = "Exito";
                        oRespuesta.Exito = 1;
                        oRespuesta.EstatusRespuesta = db.Estatus.Find(estatus.EstatusId);

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
        [HttpDelete("{EstatusId}")]
        public IActionResult Delete(int EstatusId)
        {
            EstatusResponse oRespuesta = new EstatusResponse();
            try
            {

                using (Contexto db = new Contexto())
                {
                    Estatus estatus = db.Estatus.Find(EstatusId);
                    db.Estatus.Remove(estatus);
                    if (db.SaveChanges() > 0)
                    {
                        oRespuesta.Exito = 1;
                        oRespuesta.Mensaje = "estatus eliminado correctamente";

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
