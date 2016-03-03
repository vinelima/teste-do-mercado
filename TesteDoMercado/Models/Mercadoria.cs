using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteDoMercado.Enum;

namespace TesteDoMercado.Models
{
    public class Mercadoria
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public TipoNegocio TipoNegocio { get; set; }
    }
}