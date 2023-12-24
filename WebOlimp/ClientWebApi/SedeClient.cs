using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using WebOlimp.Models.sede;

namespace WebOlimp.ClientWebApi
{
    public class SedeClient
    {
        private static ILog Log { get; set; }
        ILog log = LogManager.GetLogger(typeof(SedeClient));
        public string _token { get; set; }
        public bool _isAuthenticated { get; set; }
        readonly int _Timeout = Convert.ToInt32(ConfigurationManager.AppSettings["TIMEOUT"]);
        private string _urlApiAdmin = ConfigurationManager.AppSettings["WEBAPI_URL"];

        public ListadoSedeResponse GetListarSede(string nombre_sede)
        {
            ListadoSedeResponse responseMethod = new ListadoSedeResponse();
            try
            {
                string urlService = $"api/sede/listado?nombre_sede={nombre_sede}";

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, _Timeout, 0);
                    if (!String.IsNullOrEmpty(_token))
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                                            _token);
                    }
                    var responseService = httpClient.GetAsync(_urlApiAdmin + urlService).Result;
                    GetListarSede_GetDataService(responseService, responseMethod);
                }
            }
            catch (Exception)
            {
                responseMethod.codeHTTP = HttpStatusCode.InternalServerError;
                responseMethod.messageHTTP = "Error en el listado de sedes.";
            }
            return responseMethod;
        }
        private void GetListarSede_GetDataService(HttpResponseMessage responseService, ListadoSedeResponse responseMethod)
        {
            if (responseService.StatusCode == HttpStatusCode.OK)
            {
                using (Stream stream = responseService.Content.ReadAsStreamAsync().Result)
                {
                    using (StreamReader re = new StreamReader(stream))
                    {
                        String json = re.ReadToEnd();
                        responseMethod.data = (ListadoSedeResponse_Ok)JsonConvert.DeserializeObject(json, typeof(ListadoSedeResponse_Ok));
                    }
                }
                responseMethod.codeHTTP = responseService.StatusCode;
            }
            else
            {
                responseMethod.codeHTTP = responseService.StatusCode;
                if (responseService.StatusCode != HttpStatusCode.NoContent)
                {
                    using (Stream stream = responseService.Content.ReadAsStreamAsync().Result)
                    {
                        using (StreamReader re = new StreamReader(stream))
                        {
                            String json = re.ReadToEnd();
                            var dataBadRequest = (ListadoSedeResponse_BadRequestYOtros)JsonConvert.DeserializeObject(json, typeof(ListadoSedeResponse_BadRequestYOtros));
                            responseMethod.data_badquest_otros = dataBadRequest;
                        }
                    }
                }
                else
                {
                    responseMethod.codeHTTP = HttpStatusCode.NotFound;
                    responseMethod.data_badquest_otros = new ListadoSedeResponse_BadRequestYOtros() { Message = "No se encontraron Sedes." };
                }
            }
        }

        public DetalleSedeResponse GetDetalleSede(int id)
        {
            DetalleSedeResponse responseMethod = new DetalleSedeResponse();
            try
            {
                string urlService = $"api/sede/detalle?id_sede={id}";

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, _Timeout, 0);
                    if (!String.IsNullOrEmpty(_token))
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                                            _token);
                    }

                    var responseService = httpClient.GetAsync(_urlApiAdmin + urlService).Result;
                    GetDetalleSede_GetDataService(responseService, responseMethod);
                }
            }
            catch (Exception)
            {
                responseMethod.codeHTTP = HttpStatusCode.InternalServerError;
                responseMethod.messageHTTP = "Error en el detalle de sedes.";
            }
            return responseMethod;
        }


        private void GetDetalleSede_GetDataService(HttpResponseMessage responseService, DetalleSedeResponse responseMethod)
        {
            if (responseService.StatusCode == HttpStatusCode.OK)
            {
                using (Stream stream = responseService.Content.ReadAsStreamAsync().Result)
                {
                    using (StreamReader re = new StreamReader(stream))
                    {
                        String json = re.ReadToEnd();
                        responseMethod.data = (DetalleSedeResponse_Ok)JsonConvert.DeserializeObject(json, typeof(DetalleSedeResponse_Ok));
                    }
                }
                responseMethod.codeHTTP = responseService.StatusCode;
            }
            else
            {
                responseMethod.codeHTTP = responseService.StatusCode;
                if (responseService.StatusCode != HttpStatusCode.NoContent)
                {
                    using (Stream stream = responseService.Content.ReadAsStreamAsync().Result)
                    {
                        using (StreamReader re = new StreamReader(stream))
                        {
                            String json = re.ReadToEnd();
                            var dataBadRequest = (DetalleSedeResponse_BadRequestYOtros)JsonConvert.DeserializeObject(json, typeof(DetalleSedeResponse_BadRequestYOtros));
                            responseMethod.data_badquest_otros = dataBadRequest;
                        }
                    }
                }
                else
                {
                    responseMethod.codeHTTP = HttpStatusCode.NotFound;
                    responseMethod.data_badquest_otros = new DetalleSedeResponse_BadRequestYOtros() { Message = "No se logro obtener el detalle de la sede." };
                }
            }
        }

        public EditarSedeResponse PutEditarSede(int id, EditarSedeRequest dataRequest)
        {
            EditarSedeResponse responseMethod = new EditarSedeResponse();
            try
            {
                string urlService = $"api/sede/editar?id_sede={id}";
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, _Timeout, 0);
                    if (!String.IsNullOrEmpty(_token))
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                                            _token);
                    }
                    var responseService = httpClient.PutAsJsonAsync(_urlApiAdmin + urlService, dataRequest).Result;
                    PutEditarSede_GetDataService(responseService, responseMethod);
                }
            }
            catch (Exception)
            {
                responseMethod.codeHTTP = HttpStatusCode.InternalServerError;
                responseMethod.messageHTTP = "Error en la petición del servicio de editar sedes.";
            }
            return responseMethod;
        }
        private void PutEditarSede_GetDataService(HttpResponseMessage responseService, EditarSedeResponse responseMethod)
        {
            if (responseService.StatusCode == HttpStatusCode.OK)
            {
                using (Stream stream = responseService.Content.ReadAsStreamAsync().Result)
                {
                    using (StreamReader re = new StreamReader(stream))
                    {
                        String json = re.ReadToEnd();
                        responseMethod.data = (EditarSedeResponse_Ok)JsonConvert.DeserializeObject(json, typeof(EditarSedeResponse_Ok));
                    }
                }
            }
            else
            {
                if (responseService.StatusCode != HttpStatusCode.NoContent)
                {
                    using (Stream stream = responseService.Content.ReadAsStreamAsync().Result)
                    {
                        using (StreamReader re = new StreamReader(stream))
                        {
                            String json = re.ReadToEnd();
                            var dataBadRequest = (EditarSedeResponse_BadRequestYOtros)JsonConvert.DeserializeObject(json, typeof(EditarSedeResponse_BadRequestYOtros));
                            responseMethod.data_badquest_otros = dataBadRequest;
                        }
                    }
                }
                else
                {
                    responseMethod.codeHTTP = HttpStatusCode.NotFound;
                    responseMethod.data_badquest_otros = new EditarSedeResponse_BadRequestYOtros() { Message = "No se logro editar la sede" };
                }
            }
            responseMethod.codeHTTP = responseService.StatusCode;
        }

        public CrearSedeResponse PostCrearSede(CrearSedeRequest dataRequest)
        {
            CrearSedeResponse responseMethod = new CrearSedeResponse();
            try
            {
                string urlService = "api/sede/crear";
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, _Timeout, 0);
                    if (!String.IsNullOrEmpty(_token))
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                                            _token);
                    }
                    var responseService = httpClient.PostAsJsonAsync(_urlApiAdmin + urlService, dataRequest).Result;
                    PostCrearSede_GetDataService(responseService, responseMethod);
                }
            }
            catch (Exception)
            {
                responseMethod.codeHTTP = HttpStatusCode.InternalServerError;
                responseMethod.messageHTTP = "Error en la petición del servicio de crear sedes.";
            }
            return responseMethod;
        }
        private void PostCrearSede_GetDataService(HttpResponseMessage responseService, CrearSedeResponse responseMethod)
        {
            if (responseService.StatusCode == HttpStatusCode.Created)
            {
                using (Stream stream = responseService.Content.ReadAsStreamAsync().Result)
                {
                    using (StreamReader re = new StreamReader(stream))
                    {
                        String json = re.ReadToEnd();
                        responseMethod.data = (CrearSedeResponse_Ok)JsonConvert.DeserializeObject(json, typeof(CrearSedeResponse_Ok));
                    }
                }
            }
            else
            {
                if (responseService.StatusCode != HttpStatusCode.NoContent)
                {
                    using (Stream stream = responseService.Content.ReadAsStreamAsync().Result)
                    {
                        using (StreamReader re = new StreamReader(stream))
                        {
                            String json = re.ReadToEnd();
                            var dataBadRequest = (CrearSedeResponse_BadRequestYOtros)JsonConvert.DeserializeObject(json, typeof(CrearSedeResponse_BadRequestYOtros));
                            responseMethod.data_badquest_otros = dataBadRequest;
                        }
                    }
                }
                else
                {
                    responseMethod.codeHTTP = HttpStatusCode.NotFound;
                    responseMethod.data_badquest_otros = new CrearSedeResponse_BadRequestYOtros() { Message = "No se logro crear la sede" };
                }
            }
            responseMethod.codeHTTP = responseService.StatusCode;
        }

        public EliminarSedeResponse DeleteEliminarSede(int id)
        {
            EliminarSedeResponse responseMethod = new EliminarSedeResponse();
            try
            {
                string urlService = $"api/sede/eliminar?id_sede={id}";
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, _Timeout, 0);
                    if (!String.IsNullOrEmpty(_token))
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                                            _token);
                    }
                    var responseService = httpClient.DeleteAsync(_urlApiAdmin + urlService).Result;
                    DeleteEliminarSede_GetDataService(responseService, responseMethod);
                }
            }
            catch (Exception)
            {
                responseMethod.codeHTTP = HttpStatusCode.InternalServerError;
                responseMethod.messageHTTP = "Error en la petición del servicio de eliminar sede.";
            }
            return responseMethod;
        }
        private void DeleteEliminarSede_GetDataService(HttpResponseMessage responseService, EliminarSedeResponse responseMethod)
        {
            if (responseService.StatusCode == HttpStatusCode.OK)
            {
                using (Stream stream = responseService.Content.ReadAsStreamAsync().Result)
                {
                    using (StreamReader re = new StreamReader(stream))
                    {
                        String json = re.ReadToEnd();
                        responseMethod.data = (EliminarSedeResponse_Ok)JsonConvert.DeserializeObject(json, typeof(EliminarSedeResponse_Ok));
                    }
                }
            }
            else
            {
                if (responseService.StatusCode != HttpStatusCode.NoContent)
                {
                    using (Stream stream = responseService.Content.ReadAsStreamAsync().Result)
                    {
                        using (StreamReader re = new StreamReader(stream))
                        {
                            String json = re.ReadToEnd();
                            var dataBadRequest = (EliminarSedeResponse_BadRequestYOtros)JsonConvert.DeserializeObject(json, typeof(EliminarSedeResponse_BadRequestYOtros));
                            responseMethod.data_badquest_otros = dataBadRequest;
                        }
                    }
                }
                else
                {
                    responseMethod.codeHTTP = HttpStatusCode.NotFound;
                    responseMethod.data_badquest_otros = new EliminarSedeResponse_BadRequestYOtros() { Message = "No se logro eliminar la sede" };
                }
            }
            responseMethod.codeHTTP = responseService.StatusCode;
        }
    }
}