using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proyecto_SmartCampus.Models;
using System.Net.Http;
using System.Text;
using System.Web;

namespace Proyecto_SmartCampus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<String> sugerenciasDb(string sug)
        {
            using (var client = new HttpClient())
            {
                var jsonData = System.Text.Json.JsonSerializer.Serialize(new
                    {
                        sugerencia=sug
                    });
                var content = new StringContent(jsonData);

                content.Headers.ContentType.CharSet= string.Empty;
                content.Headers.ContentType.MediaType = "application/json";

                var response = await client.PostAsync("https://prod-143.westus.logic.azure.com:443/workflows/b376c38dbbb54a1aa348276ef7fdbf1b/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=wcDWgIaCxx4vZy_C2NmV3nY6MUEUa1lO9YJ4HUVOZ60",content);

                

                var respuesta = "Sugerencia enviada";
                return respuesta;
            }
        }

        public async Task<String> contactar(string apell, string celu, string correo, string mensj, string nomb)
        {
            using (var client = new HttpClient())
            {
                var jsonData = System.Text.Json.JsonSerializer.Serialize(new
                    {
                        apellidos=apell,
                        celular=celu,
                        email=correo,
                        mensaje=mensj,
                        nombres=nomb
                    });
                var content = new StringContent(jsonData);

                content.Headers.ContentType.CharSet= string.Empty;
                content.Headers.ContentType.MediaType = "application/json";

                var response = await client.PostAsync("https://prod-118.westus.logic.azure.com:443/workflows/955e202485134908adace0f785f84f0f/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=C_FDgUOy8xVKBrGRW0YWFl0F9lE7Qus80lbUXo91LPw",content);

                                
                var respuesta = "Nos pondremos en contacto contigo";
                return respuesta;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
