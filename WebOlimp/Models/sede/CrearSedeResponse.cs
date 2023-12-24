using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebOlimp.Models.sede
{
    public class CrearSedeResponse
    {
        public HttpStatusCode codeHTTP { get; set; }
        public string messageHTTP { get; set; }
        public CrearSedeResponse_Ok data { get; set; }
        public CrearSedeResponse_BadRequestYOtros data_badquest_otros { get; set; }
    }
    public class CrearSedeResponse_Ok
    {
        public string Message { get; set; }
        public int id_sede { get; set; }

    }
    public class CrearSedeResponse_BadRequestYOtros
    {
        public string Message { get; set; }
    }
}
