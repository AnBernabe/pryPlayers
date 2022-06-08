using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;

namespace pryPlayers_API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        /// <summary>
        /// Devuelve el error generado en algun end-point en el ambiente de desarrollo
        /// </summary>
        /// <returns>Devuelve el detalle del error</returns>
        //[ProducesResponseType(200)] //Correcto
        //[HttpGet]
        [Route("/Error-dev")]
        public IActionResult ErrorDev([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (!webHostEnvironment.IsDevelopment())
            {
                throw new InvalidOperationException(
                    "Esto no deberia ser invocado en un entorno de producción.");
            }

            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ex = feature?.Error;

            var problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = feature?.Path,
                Title = $"{ex.GetType().Name}: {ex.Message}",
                Detail = ex.StackTrace
            };

            return StatusCode(problemDetails.Status.Value, problemDetails);
        }

        /// <summary>
        /// Devuelve el error generado en algun end-point en el ambiente de producción
        /// </summary>
        /// <returns>Devuelve el detalle del error</returns>
        //[ProducesResponseType(200)] //Correcto
        //[HttpGet]
        [Route("/Error")]
        public ActionResult Error([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ex = feature?.Error;
            var isDev = webHostEnvironment.IsDevelopment();

            var problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = feature?.Path,
                Title = isDev ? $"{ex.GetType().Name}: {ex.Message}" : "Ocurrió un error.",
                Detail = isDev ? ex.StackTrace : "Si el problema persiste, pongase en contacto con nuestro equipo de soporte técnico."
            };

            return StatusCode(problemDetails.Status.Value, problemDetails);
        }
    }
}
