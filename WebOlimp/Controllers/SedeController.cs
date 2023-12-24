using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebOlimp.Attribute;
using WebOlimp.ClientWebApi;
using WebOlimp.Entities;
using WebOlimp.Models.sede;

namespace WebOlimp.Controllers
{
    [RoutePrefix("Sede")]
    public class SedeController : Controller
    {
        // GET: Sede
        public ActionResult ListaSede()
        {
            return View();
        }

        public ActionResult EditarSede(int id)
        {
            ViewBag.id = id;
            return View();
        }

        public ActionResult CrearSede()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetListadoSede(string nombre_sede, int draw)
        {
            var responseError = new { recordsTotal = 0, recordsFiltered = 0, data = new List<ItemSede>(), sesionActiva = false };

            ResponseTokenModel sesionActual = (ResponseTokenModel)Session["sesion"];
            if (sesionActual == null) return Json(responseError, JsonRequestBehavior.AllowGet);


            var sedeCliente = new SedeClient();
            sedeCliente._token = sesionActual.access_token;

            var listado = sedeCliente.GetListarSede(nombre_sede);

            if (listado.codeHTTP == HttpStatusCode.OK)
            {
                Request.RequestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(new
                {
                    recordsTotal = listado != null ? listado.data.data.Count : 0,
                    recordsFiltered = listado != null ? listado.data.data.Count : 0,
                    data = listado != null && listado.data != null ? listado.data.data : new List<ItemSede>(),
                    draw = draw,
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

        [HttpGet]
        public ActionResult GetDetalleSede(int id)
        {
            var responseError = new { recordsTotal = 0, recordsFiltered = 0, data = new ItemSedeDetalle(), sesionActiva = false };

            ResponseTokenModel sesionActual = (ResponseTokenModel)Session["sesion"];
            if (sesionActual == null) return Json(responseError, JsonRequestBehavior.AllowGet);


            var sedeCliente = new SedeClient();
            sedeCliente._token = sesionActual.access_token;

            var detalle = sedeCliente.GetDetalleSede(id);

            if (detalle.codeHTTP == HttpStatusCode.OK)
            {
                Request.RequestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(detalle, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Request.RequestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new
                {
                    Message = detalle.data_badquest_otros.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPut]
        public JsonResult PutEditarSede(int id, EditarSedeRequest request)
        {

            ResponseTokenModel sesionActual = (ResponseTokenModel)Session["sesion"];
            if (sesionActual == null) return Json(JsonRequestBehavior.AllowGet);

            var sedeCliente = new SedeClient();
            sedeCliente._token = sesionActual.access_token;

            var Edicion = sedeCliente.PutEditarSede(id, request);
            if (Edicion.codeHTTP == HttpStatusCode.OK)
            {
                Request.RequestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(new
                {
                    Edicion.data.Message
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Request.RequestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new
                {
                    Message = Edicion.data_badquest_otros.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult PostCrearSede(CrearSedeRequest datos)
        {

            ResponseTokenModel sesionActual = (ResponseTokenModel)Session["sesion"];
            if (sesionActual == null) return Json(JsonRequestBehavior.AllowGet);

            var sedeCliente = new SedeClient();
            sedeCliente._token = sesionActual.access_token;

            var Creacion = sedeCliente.PostCrearSede(datos);
            if (Creacion.codeHTTP == HttpStatusCode.OK || Creacion.codeHTTP == HttpStatusCode.Created)
            {
                Request.RequestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;
                return Json(new
                {
                    Creacion.data.Message,
                    Creacion.data.id_sede
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Request.RequestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new
                {
                    Message = Creacion.data_badquest_otros.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpDelete]
        public JsonResult DeleteEliminarSede(int id)
        {

            ResponseTokenModel sesionActual = (ResponseTokenModel)Session["sesion"];
            if (sesionActual == null) return Json(JsonRequestBehavior.AllowGet);

            var sedeCliente = new SedeClient();
            sedeCliente._token = sesionActual.access_token;

            var eliminacion = sedeCliente.DeleteEliminarSede(id);
            if (eliminacion.codeHTTP == HttpStatusCode.OK)
            {
                Request.RequestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(new
                {
                    eliminacion.data.Message
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Request.RequestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new
                {
                    Message = eliminacion.data_badquest_otros.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
