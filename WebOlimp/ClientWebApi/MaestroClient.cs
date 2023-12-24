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
using WebOlimp.Models.maestro;

namespace WebOlimp.ClientWebApi
{
    public class MaestroClient
    {
        private static ILog Log { get; set; }
        ILog log = LogManager.GetLogger(typeof(SedeClient));
        public string _token { get; set; }
        public bool _isAuthenticated { get; set; }
        readonly int _Timeout = Convert.ToInt32(ConfigurationManager.AppSettings["TIMEOUT"]);
        private string _urlApiAdmin = ConfigurationManager.AppSettings["WEBAPI_URL"];

        public ListadoMaestroResponse GetListarMaestro()
        {
            ListadoMaestroResponse responseMethod = new ListadoMaestroResponse();
            try
            {
                string urlService = "api/maestro/listado";

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
                responseMethod.messageHTTP = "Error en el listado de maestros.";
            }
            return responseMethod;
        }
        private void GetListarSede_GetDataService(HttpResponseMessage responseService, ListadoMaestroResponse responseMethod)
        {
            if (responseService.StatusCode == HttpStatusCode.OK)
            {
                using (Stream stream = responseService.Content.ReadAsStreamAsync().Result)
                {
                    using (StreamReader re = new StreamReader(stream))
                    {
                        String json = re.ReadToEnd();
                        responseMethod.data = (ListadoMaestroResponse_Ok)JsonConvert.DeserializeObject(json, typeof(ListadoMaestroResponse_Ok));
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
                            var dataBadRequest = (ListadoMaestroResponse_BadRequestYOtros)JsonConvert.DeserializeObject(json, typeof(ListadoMaestroResponse_BadRequestYOtros));
                            responseMethod.data_badquest_otros = dataBadRequest;
                        }
                    }
                }
                else
                {
                    responseMethod.codeHTTP = HttpStatusCode.NotFound;
                    responseMethod.data_badquest_otros = new ListadoMaestroResponse_BadRequestYOtros() { Message = "No se encontraron Maestros." };
                }
            }
        }
    }
}