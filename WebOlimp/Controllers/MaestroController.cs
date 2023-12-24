using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebOlimp.ClientWebApi;
using WebOlimp.Entities;
using WebOlimp.Models.maestro;

namespace WebOlimp.Controllers
{
    [RoutePrefix("Maestro")]
    public class MaestroController : Controller
    {
        [HttpGet]
        public ActionResult GetListadoMaestro()
        {
            var responseError = new { recordsTotal = 0, recordsFiltered = 0, data = new List<ItemMaestroSede>(), sesionActiva = false };

            ResponseTokenModel sesionActual = (ResponseTokenModel)Session["sesion"];
            if (sesionActual == null) return Json(responseError, JsonRequestBehavior.AllowGet);


            var maestroCliente = new MaestroClient();
            maestroCliente._token = sesionActual.access_token;

            var listado = maestroCliente.GetListarMaestro();

            if (listado.codeHTTP == HttpStatusCode.OK)
            {
                Request.RequestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(new
                {
                    recordsTotal = listado != null ? listado.data.data.Count : 0,
                    recordsFiltered = listado != null ? listado.data.data.Count : 0,
                    data = listado != null && listado.data != null ? listado.data.data : new List<ItemMaestroSede>(),
                    sesionActiva = true
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Request.RequestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new
                {
                    Message = listado.data_badquest_otros.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}