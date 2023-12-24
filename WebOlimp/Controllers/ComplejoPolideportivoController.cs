using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebOlimp.ClientWebApi;
using WebOlimp.Entities;
using WebOlimp.Models.complejoPolideportivo;

namespace WebOlimp.Controllers
{
    [RoutePrefix("ComplejoPolideportivo")]
    public class ComplejoPolideportivoController : Controller
    {
        public ActionResult ListaComplejoPolideportivo()
        {
            return View();
        }

        public ActionResult EditarComplejoPolideportivo(int id)
        {
            ViewBag.id = id;
            return View();
        }

        public ActionResult CrearComplejoPolideportivo()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetListadoComplejoPolideportivo(string nombre_complejoPoli, int id_sede, int draw)
        {
            var responseError = new { recordsTotal = 0, recordsFiltered = 0, data = new List<ItemComplejoPolideportivo>(), sesionActiva = false };

            ResponseTokenModel sesionActual = (ResponseTokenModel)Session["sesion"];
            if (sesionActual == null) return Json(responseError, JsonRequestBehavior.AllowGet);


            var complejoPolideportivoCliente = new ComplejoPolideportivoClient();
            complejoPolideportivoCliente._token = sesionActual.access_token;

            var listado = complejoPolideportivoCliente.GetListarComplejoPolideportivo(nombre_complejoPoli, id_sede);

            if (listado.codeHTTP == HttpStatusCode.OK)
            {
                Request.RequestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(new
                {
                    recordsTotal = listado != null ? listado.data.data.Count : 0,
                    recordsFiltered = listado != null ? listado.data.data.Count : 0,
                    data = listado != null && listado.data != null ? listado.data.data : new List<ItemComplejoPolideportivo>(),
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
        public ActionResult GetDetalleComplejoPolideportivo(int id)
        {
            var responseError = new { recordsTotal = 0, recordsFiltered = 0, data = new ItemComplejoPolideportivoDetalle(), sesionActiva = false };

            ResponseTokenModel sesionActual = (ResponseTokenModel)Session["sesion"];
            if (sesionActual == null) return Json(responseError, JsonRequestBehavior.AllowGet);


            var complejoPolideportivoCliente = new ComplejoPolideportivoClient();
            complejoPolideportivoCliente._token = sesionActual.access_token;

            var detalle = complejoPolideportivoCliente.GetDetalleComplejoPolideportivo(id);

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
        public JsonResult PutEditarComplejoPolideportivo(int id, EditarComplejoPolideportivoRequest request)
        {

            ResponseTokenModel sesionActual = (ResponseTokenModel)Session["sesion"];
            if (sesionActual == null) return Json(JsonRequestBehavior.AllowGet);

            var complejoPolideportivoCliente = new ComplejoPolideportivoClient();
            complejoPolideportivoCliente._token = sesionActual.access_token;

            var Edicion = complejoPolideportivoCliente.PutEditarComplejoPolideportivo(id, request);
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
        public JsonResult PostCrearComplejoPolideportivo(CrearComplejoPolideportivoRequest datos)
        {

            ResponseTokenModel sesionActual = (ResponseTokenModel)Session["sesion"];
            if (sesionActual == null) return Json(JsonRequestBehavior.AllowGet);

            var complejoPolideportivoCliente = new ComplejoPolideportivoClient();
            complejoPolideportivoCliente._token = sesionActual.access_token;

            var Creacion = complejoPolideportivoCliente.PostCrearComplejoPolideportivo(datos);
            if (Creacion.codeHTTP == HttpStatusCode.OK || Creacion.codeHTTP == HttpStatusCode.Created)
            {
                Request.RequestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;
                return Json(new
                {
                    Creacion.data.Message,
                    Creacion.data.id_complejo_poli
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
        public JsonResult DeleteEliminarComplejoPolideportivo(int id)
        {

            ResponseTokenModel sesionActual = (ResponseTokenModel)Session["sesion"];
            if (sesionActual == null) return Json(JsonRequestBehavior.AllowGet);

            var complejoPolideportivoCliente = new ComplejoPolideportivoClient();
            complejoPolideportivoCliente._token = sesionActual.access_token;

            var eliminacion = complejoPolideportivoCliente.DeleteEliminarComplejoPolideportivo(id);
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
