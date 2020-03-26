using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;

namespace RestOData.Controllers
{
    public class MovimientosCuentaController : ApiController
    {
        [HttpGet]
        [EnableQuery]
        [Route("Cuentas/{idCuenta:int}/Movimientos")]
        public async Task<ICollection<modMovimientoCuenta>> ConsultaMovimientosAsync(int idCuenta)
        {
            if (RequestContext.Url.Request.RequestUri.Query.Contains("fechaInicio")
                && RequestContext.Url.Request.RequestUri.Query.Contains("fechaFin"))
            {
                string cadenaFechaInicio = System.Web.HttpContext.Current.Request.QueryString.GetValues("fechaInicio")?[0];
                string cadenaFechaFin = System.Web.HttpContext.Current.Request.QueryString.GetValues("fechaFin")?[0];

                DateTime fechaInicio = Convert.ToDateTime(cadenaFechaInicio.Insert(6, "-").Insert(4, "-"));
                DateTime fechaFin = Convert.ToDateTime(cadenaFechaFin.Insert(6, "-").Insert(4, "-"));

                return await negMovimientoCuenta.ConsultarPorFechaAsync(idCuenta, fechaInicio, fechaFin).ConfigureAwait(false);
            }
            else
            {
                return await negMovimientoCuenta.ConsultarAsync(idCuenta).ConfigureAwait(false);
            }
        }
    }
}
