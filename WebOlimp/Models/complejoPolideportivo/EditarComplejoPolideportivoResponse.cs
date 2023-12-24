using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebOlimp.Models.complejoPolideportivo
{
    public class EditarComplejoPolideportivoResponse
    {
        public HttpStatusCode codeHTTP { get; set; }
        public string messageHTTP { get; set; }
        public EditarComplejoPolideportivoResponse_Ok data { get; set; }
        public EditarComplejoPolideportivoResponse_BadRequestYOtros data_badquest_otros { get; set; }
    }
    public class EditarComplejoPolideportivoResponse_Ok
    {
        public string Message { get; set; }

    }
    public class EditarComplejoPolideportivoResponse_BadRequestYOtros
    {
        public string Message { get; set; }
    }
}