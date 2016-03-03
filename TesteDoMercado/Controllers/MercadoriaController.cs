using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteDoMercado.Database;
using TesteDoMercado.Database.Ado;
using TesteDoMercado.Enum;
using TesteDoMercado.Models;

namespace TesteDoMercado.Controllers
{
    public class MercadoriaController : Controller
    {
        private MercadoriaBd _database = new MercadoriaBd();

        public ActionResult Index(int? id)
        {
            MercadoriaApresentacao apresentacao;
            var dados = _database.ListarMercadorias();

            if (id.HasValue)
                apresentacao = MapearParaApresentacao(dados.FirstOrDefault(x => x.Id == id));
            else 
                apresentacao = new MercadoriaApresentacao();
 
            apresentacao.ListaMercadoria = dados;
            
            return View(apresentacao);
        }

        [HttpPost]
        public ActionResult CriarMercadoria(MercadoriaApresentacao apresentacao)
        {
            try 
            {
               var dados = MapearParaMercadoria(apresentacao);            
                _database.AdicionarMercadoria(dados);            
                
                return RedirectToAction("Index");
 
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public ActionResult AlterarMercadoria(MercadoriaApresentacao apresentacao)
        {
            try 
            {
                var mercadoria = MapearParaMercadoria(apresentacao);
                _database.AlterarMercadoria(mercadoria);
            
                return RedirectToAction("Index");
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }


        private Mercadoria MapearParaMercadoria(MercadoriaApresentacao apresentacao)
        {
            return new Mercadoria
            {
                Id = apresentacao.Id,
                Codigo = apresentacao.Codigo,
                Nome = apresentacao.Nome,
                Preco = Convert.ToDecimal(apresentacao.Preco),
                Quantidade = apresentacao.Quantidade,
                Tipo = apresentacao.Tipo,
                TipoNegocio = apresentacao.TipoNegocio
            };
        }

        private MercadoriaApresentacao MapearParaApresentacao(Mercadoria mercadoria)
        {
            return new MercadoriaApresentacao
            {
                Id = mercadoria.Id,
                Codigo = mercadoria.Codigo,
                Nome = mercadoria.Nome,
                Preco = mercadoria.Preco.ToString("N2"),
                Quantidade = mercadoria.Quantidade,
                TipoNegocio = mercadoria.TipoNegocio,
                Tipo = mercadoria.Tipo
            };
        }
    }
}
