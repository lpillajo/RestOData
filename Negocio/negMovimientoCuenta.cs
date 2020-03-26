using Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Negocio
{
    public static class negMovimientoCuenta
    {
        public static Collection<modMovimientoCuenta> Movimientos = new Collection<modMovimientoCuenta>();

        public static Collection<modCuenta> Cuentas = new Collection<modCuenta>();

        static negMovimientoCuenta()
        {
            #region agrega cuentas

            Cuentas.Add(new modCuenta()
            {
                Codigo = 1,
                Numero = "09898989898",
                Estado = "ACT",
                Tipo = "AHO"
            });

            Cuentas.Add(new modCuenta()
            {
                Codigo = 2,
                Numero = "09898989899",
                Estado = "ACT",
                Tipo = "COR"
            });

            #endregion agrega cuentas

            #region agrega movimientos

            Movimientos.Add(new modMovimientoCuenta()
            {
                CuentaOrigen = "09898989898",
                CuentaDestino = "12121212121",
                Beneficiario = "Beneficiario1",
                Ordenante = "Ordenante1",
                Descripcion = "Descripcio1",
                Monto = 10,
                Fecha = new DateTime(2019, 01, 01)
            });

            Movimientos.Add(new modMovimientoCuenta()
            {
                CuentaOrigen = "09898989898",
                CuentaDestino = "12121212122",
                Beneficiario = "Beneficiario2",
                Ordenante = "Ordenante1",
                Descripcion = "Descripcio2",
                Monto = 20,
                Fecha = new DateTime(2019, 02, 01)
            });

            Movimientos.Add(new modMovimientoCuenta()
            {
                CuentaOrigen = "09898989899",
                CuentaDestino = "12121212121",
                Beneficiario = "Beneficiario1",
                Ordenante = "Ordenante2",
                Descripcion = "Descripcio3",
                Monto = 15,
                Fecha = new DateTime(2020, 03, 01)
            });

            Movimientos.Add(new modMovimientoCuenta()
            {
                CuentaOrigen = "09898989898",
                CuentaDestino = "12121212121",
                Beneficiario = "Beneficiario1",
                Ordenante = "Ordenante1",
                Descripcion = "Descripcio4",
                Monto = 30,
                Fecha = new DateTime(2019, 01, 01)
            });

            Movimientos.Add(new modMovimientoCuenta()
            {
                CuentaOrigen = "09898989898",
                CuentaDestino = "12121212122",
                Beneficiario = "Beneficiario2",
                Ordenante = "Ordenante1",
                Descripcion = "Descripcio5",
                Monto = 10,
                Fecha = new DateTime(2020, 03, 15)
            });

            Movimientos.Add(new modMovimientoCuenta()
            {
                CuentaOrigen = "09898989898",
                CuentaDestino = "12121212121",
                Beneficiario = "Beneficiario1",
                Ordenante = "Ordenante1",
                Descripcion = "Descripcio6",
                Monto = 100,
                Fecha = new DateTime(2020, 01, 01)
            });

            Movimientos.Add(new modMovimientoCuenta()
            {
                CuentaOrigen = "09898989898",
                CuentaDestino = "12121212121",
                Beneficiario = "Beneficiario1",
                Ordenante = "Ordenante1",
                Descripcion = "Descripcio1",
                Monto = 105,
                Fecha = new DateTime(2020, 02, 01)
            });

            Movimientos.Add(new modMovimientoCuenta()
            {
                CuentaOrigen = "09898989898",
                CuentaDestino = "12121212122",
                Beneficiario = "Beneficiario2",
                Ordenante = "Ordenante1",
                Descripcion = "Descripcio1123",
                Monto = 10,
                Fecha = new DateTime(2020, 03, 01)
            });

            #endregion agrega movimientos
        }

        /// <summary>
        /// Consulta movimientos con fechas por omisión
        /// </summary>
        /// <param name="idCuenta">Código de cuenta para búsqueda</param>
        /// <returns>Listado de movimientos de la cuenta especificada</returns>
        public static async Task<ICollection<modMovimientoCuenta>> ConsultarAsync(int idCuenta)
        {
            DateTime fechaInicial = new DateTime(2020, 03, 01);
            DateTime fechaFinal = DateTime.Now.Date;

            return await ConsultarPorFechaAsync(idCuenta, fechaInicial, fechaFinal).ConfigureAwait(false);
        }

        /// <summary>
        /// Consulta movimientos por fechas
        /// </summary>
        /// <param name="idCuenta">Código de cuenta para búsqueda</param>
        /// <param name="fechaInicio">Fecha inicial de búsqueda</param>
        /// <param name="fechaFinal">Fecha final de búsqueda</param>
        /// <returns>Listado de movimientos de la cuenta especificada</returns>
        public static async Task<ICollection<modMovimientoCuenta>> ConsultarPorFechaAsync(int idCuenta, DateTime fechaInicio, DateTime fechaFinal)
        {
            modCuenta oCuenta = Cuentas.FirstOrDefault(x => x.Codigo.Equals(idCuenta));

            if (oCuenta is null)
            {
                return new Collection<modMovimientoCuenta>();
            }

            ICollection<modMovimientoCuenta> lstMovimientos = Movimientos.Where(x => x.CuentaOrigen == oCuenta.Numero && x.Fecha >= fechaInicio && x.Fecha <= fechaFinal).ToList();

            return lstMovimientos;
        }
    }
}
