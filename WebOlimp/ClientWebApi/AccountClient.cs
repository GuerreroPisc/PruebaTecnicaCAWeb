using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WebOlimp.ClientWebApi.PeticionesHttpClient;
using WebOlimp.Entities;

namespace WebOlimp.ClientWebApi
{
    public class AccountClient
    {
        public string _token { get; set; }
       

        public ResponseTokenModel IniciarSesion(string usuario, string password)
        {
            string webApiUrl = "Token";
            var values = new Dictionary<string, string>
                  {
                     { "grant_type", "password" },
                     { "username", usuario},
                     { "password", password}
                  };

            try
            {
                IWebApiClient<ResponseTokenModel> _WebAPICliente = new WebApiClient<ResponseTokenModel>();
                _WebAPICliente._token = "token";
                var lista = _WebAPICliente.postReturnClassEncoded(webApiUrl, values);
                return lista;
            }
            catch (Exception)
            {

            }

            return new ResponseTokenModel();
        }

    }
}