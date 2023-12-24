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
using WebOlimp.Models.complejoPolideportivo;

namespace WebOlimp.ClientWebApi
{
    public class ComplejoPolideportivoClient
    {
        private static ILog Log { get; set; }
        ILog log = LogManager.GetLogger(typeof(ComplejoPolideportivoClient));
        public string _token { get; set; }
        public bool _isAuthenticated { get; set; }
        readonly int _Timeout = Convert.ToInt32(ConfigurationManager.AppSettings["TIMEOUT"]);
        private string _urlApiAdmin = ConfigurationManager.AppSettings["WEBAPI_URL"];

        public ListadoComplejoPolideportivoResponse GetListarComplejoPolideportivo(string nombre_complejoPoli, int id_sede)
        {
            ListadoComplejoPolideportivoResponse responseMethod = new ListadoComplejoPolideportivoResponse();
            try
            {
                string urlService = $"api/complejo/polideportivo/listado?nombre_complejoPoli={nombre_complejoPoli}&id_sede={id_sede}";

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, _Timeout, 0);
                    if (!String.IsNullOrEmpty(_token))
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                                            _token);
                    }
                    var responseService = httpClient.GetAsync(_urlApiAdmin + urlService).Result;
                    GetListarComplejoPolideportivo_GetDataService(responseService, responseMethod);
                }
            }
            catch (Exception)
            {
                responseMethod.codeHTTP = HttpStatusCode.InternalServerError;
                responseMethod.messageHTTP = "Error en el listado de complejo polideportivos.";
            }
            return responseMethod;
        }
        private void GetListarComplejoPolideportivo_GetDataService(HttpResponseMessage responseService, ListadoComplejoPolideportivoResponse responseMethod)
        {
            if (responseService.StatusCode == HttpStatusCode.OK)
            {
                using (Stream stream = responseService.Content.ReadAsStreamAsync().Result)
                {
                    using (StreamReader re = new StreamReader(stream))
                    {
                        String json = re.ReadToEnd();
                        responseMethod.data = (ListadoComplejoPolideportivoResponse_Ok)JsonConvert.DeserializeObject(json, typeof(ListadoComplejoPolideportivoResponse_Ok));
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
                            var dataBadRequest = (ListadoComplejoPolideportivoResponse_BadRequestYOtros)JsonConvert.DeserializeObject(json, typeof(ListadoComplejoPolideportivoResponse_BadRequestYOtros));
                            responseMethod.data_badquest_otros = dataBadRequest;
                        }
                    }
                }
                else
                {
                    responseMethod.codeHTTP = HttpStatusCode.NotFound;
                    responseMethod.data_badquest_otros = new ListadoComplejoPolideportivoResponse_BadRequestYOtros() { Message = "No se encontraron ComplejoPolideportivos." };
                }
            }
        }

        public DetalleComplejoPolideportivoResponse GetDetalleComplejoPolideportivo(int id)
        {
            DetalleComplejoPolideportivoResponse responseMethod = new DetalleComplejoPolideportivoResponse();
            try
            {
                string urlService = $"api/complejo/polideportivo/detalle?id_complejo_polideportivo={id}";

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, _Timeout, 0);
                    if (!String.IsNullOrEmpty(_token))
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                                            _token);
                    }

                    var responseService = httpClient.GetAsync(_urlApiAdmin + urlService).Result;
                    GetDetalleComplejoPolideportivo_GetDataService(responseService, responseMethod);
                }
            }
            catch (Exception)
            {
                responseMethod.codeHTTP = HttpStatusCode.InternalServerError;
                responseMethod.messageHTTP = "Error en el detalle de complejo polideportivo.";
            }
            return responseMethod;
        }


        private void GetDetalleComplejoPolideportivo_GetDataService(HttpResponseMessage responseService, DetalleComplejoPolideportivoResponse responseMethod)
        {
            if (responseService.StatusCode == HttpStatusCode.OK)
            {
                using (Stream stream = responseService.Content.ReadAsStreamAsync().Result)
                {
                    using (StreamReader re = new StreamReader(stream))
                    {
                        String json = re.ReadToEnd();
                        responseMethod.data = (DetalleComplejoPolideportivoResponse_Ok)JsonConvert.DeserializeObject(json, typeof(DetalleComplejoPolideportivoResponse_Ok));
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
                            var dataBadRequest = (DetalleComplejoPolideportivoResponse_BadRequestYOtros)JsonConvert.DeserializeObject(json, typeof(DetalleComplejoPolideportivoResponse_BadRequestYOtros));
                            responseMethod.data_badquest_otros = dataBadRequest;
                        }
                    }
                }
                else
                {
                    responseMethod.codeHTTP = HttpStatusCode.NotFound;
                    responseMethod.data_badquest_otros = new DetalleComplejoPolideportivoResponse_BadRequestYOtros() { Message = "No se logro obtener el detalle del complejo polideportivo." };
                }
            }
        }

        public EditarComplejoPolideportivoResponse PutEditarComplejoPolideportivo(int id, EditarComplejoPolideportivoRequest dataRequest)
        {
            EditarComplejoPolideportivoResponse responseMethod = new EditarComplejoPolideportivoResponse();
            try
            {
                string urlService = $"api/complejo/polideportivo/editar?id_complejo_polideportivo={id}";
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, _Timeout, 0);
                    if (!String.IsNullOrEmpty(_token))
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                                            _token);
                    }
                    var responseService = httpClient.PutAsJsonAsync(_urlApiAdmin + urlService, dataRequest).Result;
                    PutEditarComplejoPolideportivo_GetDataService(responseService, responseMethod);
                }
            }
            catch (Exception)
            {
                responseMethod.codeHTTP = HttpStatusCode.InternalServerError;
                responseMethod.messageHTTP = "Error en la petición del servicio de editar complejo polideportivo.";
            }
            return responseMethod;
        }
        private void PutEditarComplejoPolideportivo_GetDataService(HttpResponseMessage responseService, EditarComplejoPolideportivoResponse responseMethod)
        {
            if (responseService.StatusCode == HttpStatusCode.OK)
            {
                using (Stream stream = responseService.Content.ReadAsStreamAsync().Result)
                {
                    using (StreamReader re = new StreamReader(stream))
                    {
                        String json = re.ReadToEnd();
                        responseMethod.data = (EditarComplejoPolideportivoResponse_Ok)JsonConvert.DeserializeObject(json, typeof(EditarComplejoPolideportivoResponse_Ok));
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
                            var dataBadRequest = (EditarComplejoPolideportivoResponse_BadRequestYOtros)JsonConvert.DeserializeObject(json, typeof(EditarComplejoPolideportivoResponse_BadRequestYOtros));
                            responseMethod.data_badquest_otros = dataBadRequest;
                        }
                    }
                }
                else
                {
                    responseMethod.codeHTTP = HttpStatusCode.NotFound;
                    responseMethod.data_badquest_otros = new EditarComplejoPolideportivoResponse_BadRequestYOtros() { Message = "No se logro editar el complejo polideportivo" };
                }
            }
            responseMethod.codeHTTP = responseService.StatusCode;
        }

        public CrearComplejoPolideportivoResponse PostCrearComplejoPolideportivo(CrearComplejoPolideportivoRequest dataRequest)
        {
            CrearComplejoPolideportivoResponse responseMethod = new CrearComplejoPolideportivoResponse();
            try
            {
                string urlService = "api/complejo/polideportivo/crear";
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, _Timeout, 0);
                    if (!String.IsNullOrEmpty(_token))
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                                            _token);
                    }
                    var responseService = httpClient.PostAsJsonAsync(_urlApiAdmin + urlService, dataRequest).Result;
                    PostCrearComplejoPolideportivo_GetDataService(responseService, responseMethod);
                }
            }
            catch (Exception)
            {
                responseMethod.codeHTTP = HttpStatusCode.InternalServerError;
                responseMethod.messageHTTP = "Error en la petición del servicio de crear complejo polideportivo.";
            }
            return responseMethod;
        }
        private void PostCrearComplejoPolideportivo_GetDataService(HttpResponseMessage responseService, CrearComplejoPolideportivoResponse responseMethod)
        {
            if (responseService.StatusCode == HttpStatusCode.Created)
            {
                using (Stream stream = responseService.Content.ReadAsStreamAsync().Result)
                {
                    using (StreamReader re = new StreamReader(stream))
                    {
                        String json = re.ReadToEnd();
                        responseMethod.data = (CrearComplejoPolideportivoResponse_Ok)JsonConvert.DeserializeObject(json, typeof(CrearComplejoPolideportivoResponse_Ok));
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
                            var dataBadRequest = (CrearComplejoPolideportivoResponse_BadRequestYOtros)JsonConvert.DeserializeObject(json, typeof(CrearComplejoPolideportivoResponse_BadRequestYOtros));
                            responseMethod.data_badquest_otros = dataBadRequest;
                        }
                    }
                }
                else
                {
                    responseMethod.codeHTTP = HttpStatusCode.NotFound;
                    responseMethod.data_badquest_otros = new CrearComplejoPolideportivoResponse_BadRequestYOtros() { Message = "No se logro crear el complejo polideportivo" };
                }
            }
            responseMethod.codeHTTP = responseService.StatusCode;
        }

        public EliminarComplejoPolideportivoResponse DeleteEliminarComplejoPolideportivo(int id)
        {
            EliminarComplejoPolideportivoResponse responseMethod = new EliminarComplejoPolideportivoResponse();
            try
            {
                string urlService = $"api/complejo/polideportivo/eliminar?id_complejo_deportivo={id}";
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, _Timeout, 0);
                    if (!String.IsNullOrEmpty(_token))
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                                            _token);
                    }
                    var responseService = httpClient.DeleteAsync(_urlApiAdmin + urlService).Result;
                    DeleteEliminarComplejoPolideportivo_GetDataService(responseService, responseMethod);
                }
            }
            catch (Exception)
            {
                responseMethod.codeHTTP = HttpStatusCode.InternalServerError;
                responseMethod.messageHTTP = "Error en la petición del servicio de eliminar el complejo polideportivo.";
            }
            return responseMethod;
        }
        private void DeleteEliminarComplejoPolideportivo_GetDataService(HttpResponseMessage responseService, EliminarComplejoPolideportivoResponse responseMethod)
        {
            if (responseService.StatusCode == HttpStatusCode.OK)
            {
                using (Stream stream = responseService.Content.ReadAsStreamAsync().Result)
                {
                    using (StreamReader re = new StreamReader(stream))
                    {
                        String json = re.ReadToEnd();
                        responseMethod.data = (EliminarComplejoPolideportivoResponse_Ok)JsonConvert.DeserializeObject(json, typeof(EliminarComplejoPolideportivoResponse_Ok));
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
                            var dataBadRequest = (EliminarComplejoPolideportivoResponse_BadRequestYOtros)JsonConvert.DeserializeObject(json, typeof(EliminarComplejoPolideportivoResponse_BadRequestYOtros));
                            responseMethod.data_badquest_otros = dataBadRequest;
                        }
                    }
                }
                else
                {
                    responseMethod.codeHTTP = HttpStatusCode.NotFound;
                    responseMethod.data_badquest_otros = new EliminarComplejoPolideportivoResponse_BadRequestYOtros() { Message = "No se logro eliminar el complejo polideportivo" };
                }
            }
            responseMethod.codeHTTP = responseService.StatusCode;
        }
    }
}