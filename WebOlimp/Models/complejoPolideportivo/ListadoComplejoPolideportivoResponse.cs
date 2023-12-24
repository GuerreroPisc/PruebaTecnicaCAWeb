using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebOlimp.Models.complejoPolideportivo
{
    public class ListadoComplejoPolideportivoResponse
    {
        public HttpStatusCode codeHTTP { get; set; }
        public string messageHTTP { get; set; }
        public ListadoComplejoPolideportivoResponse_Ok data { get; set; }
        public ListadoComplejoPolideportivoResponse_BadRequestYOtros data_badquest_otros { get; set; }
    }
    public class ListadoComplejoPolideportivoResponse_Ok
    {
        public string Message { get; set; }
        public List<ItemComplejoPolideportivo> data { get; set; }
    }
    public class ItemComplejoPolideportivo
    {
        public int id_complejo_poli { get; set; }
        public string nombre_sede { get; set; }
        public string cod_complejo_poli { get; set; }
        public string nombre_complejo_poli { get; set; }
        public Nullable<bool> estado { get; set; }
        public string fecha_actualizacion { get; set; }
    }

    public class ListadoComplejoPolideportivoResponse_BadRequestYOtros
    {
        public string Message { get; set; }
    }
}