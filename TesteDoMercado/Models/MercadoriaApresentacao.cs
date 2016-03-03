using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteDoMercado.Enum;

namespace TesteDoMercado.Models
{
    public class MercadoriaApresentacao
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public string Preco { get; set; }
        public TipoNegocio TipoNegocio { get; set; }
        public TipoManutencao TipoManutencao { get; set; }
        public List<Mercadoria> ListaMercadoria { get; set; }


        public MercadoriaApresentacao()
        {
            ListaMercadoria = new List<Mercadoria>();
        }

    }
}