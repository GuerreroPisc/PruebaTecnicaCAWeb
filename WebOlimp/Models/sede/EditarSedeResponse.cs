using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebOlimp.Models.sede
{
    public class EditarSedeResponse
    {
        public HttpStatusCode codeHTTP { get; set; }
        public string messageHTTP { get; set; }
        public EditarSedeResponse_Ok data { get; set; }
        public EditarSedeResponse_BadRequestYOtros data_badquest_otros { get; set; }
    }
    public class EditarSedeResponse_Ok
    {
        public string Message { get; set; }

    }
    public class EditarSedeResponse_BadRequestYOtros
    {
        public string Message { get; set; }
    }
}