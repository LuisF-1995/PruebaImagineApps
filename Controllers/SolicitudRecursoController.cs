using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;
using PnP.Core.Auth;
using PnP.Core.QueryModel;
using PnP.Core.Services;
using PnP.Core.Services.Builder.Configuration;
using PruebaImagineApps.Models;
using System;
using System.Threading.Tasks;

namespace PruebaImagineApps.Controllers
{
    public class SolicitudRecursoController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IPnPContextFactory _pnpContextFactory;
        private readonly ITokenAcquisition _tokenAcquisition;
        private readonly PnPCoreOptions _pnpCoreOptions;

        public SolicitudRecursoController(
            IConfiguration configuration,
            IPnPContextFactory pnpContextFactory,
            ITokenAcquisition tokenAcquisition,
            IOptions<PnPCoreOptions> pnpCoreOptions)
        {
            _configuration = configuration;
            _pnpContextFactory = pnpContextFactory;
            _tokenAcquisition = tokenAcquisition;
            _pnpCoreOptions = pnpCoreOptions?.Value;
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(SolicitudRecurso solicitud)
        {
            if (!ModelState.IsValid)
            {
                return View(solicitud);
            }

            try
            {
                using (var context = await createSiteContext())
                {
                    var lista = await context.Web.Lists.GetByTitleAsync("SolicitudesRecursos");

                    var newItemData = new Dictionary<string, object>
                    {
                        { "NombreSolicitante", solicitud.NombreSolicitante },
                        { "Departamento", solicitud.Departamento },
                        { "TipoRecurso", solicitud.TipoRecurso },
                        { "Descripcion", solicitud.Descripcion },
                        { "FechaRequerimiento", solicitud.FechaRequerimiento }
                    };

                    var newItem = await lista.Items.AddAsync(newItemData);

                    TempData["Mensaje"] = "Solicitud creada correctamente.";
                    return RedirectToAction("Crear");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al enviar la solicitud: " + ex.Message);
                TempData["Mensaje"] = "Ha ocurrido un problema al cargar la solicitud, favor intente de nuevo.";
                return View(solicitud);
            }
        }

        private async Task<PnPContext> createSiteContext()
        {
            Uri siteUrl = new Uri(_configuration["SharePoint:SiteUrl"]);

            return await _pnpContextFactory.CreateAsync(siteUrl,
                            new ExternalAuthenticationProvider((resourceUri, scopes) =>
                            {
                                return _tokenAcquisition.GetAccessTokenForUserAsync(scopes);
                            }
                            ));
        }

    }
}
