using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class modCuenta
    {
        [Key]
        public int Codigo { get; set; }

        public string Numero { get; set; }
        public decimal SaldoContable { get; set; }
        public decimal SaldoDisponible { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
    }
}
