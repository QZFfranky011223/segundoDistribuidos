using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace _2PSEGUNDO
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        public class Salida
        {
            public int ID { get; set; }
            public string Destino { get; set; }
            public string fecha { get; set; }
            public string Hora { get; set; }
            public string Bus { get; set; }
            public double Precio { get; set; }
            public int Capacidad { get; set; }
            public string AsientosLibres { get; set; }
        }
        public class Boleto
        {
            public string Codigo { get; set; }
            public string NombrePasajero { get; set; }
            public string Destino { get; set; }
            public string Fecha { get; set; }
            public double Hora { get; set; }
            public int NumeroAsiento { get; set; }
            public string Precio { get; set; }
        }
        [WebService(Namespace = "http://terminal.bo")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        public class CentralService : WebService {
            JavaScriptSerializer json = new JavaScriptSerializer();
            [WebMethod]
            public Salida[] Versalidas(string destino, string fecha)
            {
                try
                {
                    string d = Uri.EscapeDataString(destino ?? "");
                    string f = Uri.EscapeDataString(fecha ?? "");
                    string url = $"http:127.0.0.1:8000/api/salidas?destino={d}&fecha={f}";
                    using (var wc = new WebClient { Encoding = Encoding.UTF8 })
                    {
                        string respuesta = wc.DownloadString(url);
                        var lista = json.Deserialize<List<Dictionary<string, object>>>(respuesta);
                        var resultado = new List<Salida>();
                        foreach (var s in lista)
                        {
                            id = Convert.ToInt32(s["id"]),
                           Destino = s["Destino"].ToString(),
                           Fecha = s["Fecha"].ToString(),
                           Hora = s["hora"].ToString(),
                           Bus = s["bus"].ToString(),
                           precio = Convert.ToDouble[s"precio"].ToString(),
                           Capacidad = Convert.ToInt32(s["Destino"]),
                            Asientoslibres = Convert.ToInt32(s["asientos_libres"])
                                });
                    }
                    return
                    resultado.ToArray();
                }
                    }
            Catch(Exception ex)

                }
            throw new
           SoapException("la empresa de Transporte no responde:" + ex.Message, SoapException.ServerFaultCode);
            } 
        }
        [WebMethod]
        public Boleto VendedorBoleto(String ci , int idSalida int asiento)
            {
            if (String.IsNullOrWhiteSpace(ci)) || idSalida <= 0 || asiento <= 0)
            {
            throw new SoapException("Datos invalidos.".SoapException.Cliente)
        }
        }
                    
}
