using System;
using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class modMovimientoCuenta
    {
        [Key]
        public int Codigo { get; set; }

        public string CuentaOrigen { get; set; }
        public string CuentaDestino { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public string Ordenante { get; set; }
        public string Beneficiario { get; set; }
        public DateTime Fecha { get; set; }
    }
}
