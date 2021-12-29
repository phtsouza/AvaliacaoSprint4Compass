using AuditoriaPedidos.Models;
using AuditoriaPedidos.Operations;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace AuditoriaPedidos.Configuration
{
    [ApiController]
    [Route("api/[controller]")]
    public class MongoDBConfiguration : ControllerBase
    {
        string stringConexao = "mongodb://localhost:27017";
        string nomeBase = "PedidosDatabase";
        string nomeColecao = "Pedidos";

        // Método pelo qual adiciona um pedido na coleção de pedidos
        [HttpPost]
        public IActionResult Post([FromBody]Pedido pedido)
        {
            Console.WriteLine("Adicionando pedido");
            var retorno = MongoOperations.InserePedidoAsync(stringConexao, nomeBase, nomeColecao, pedido).Result;
            return Ok();
        }

        // Método pelo qual retorna todos os pedidos
        [HttpGet("Todos")]
        public IActionResult Get()
        {
            Console.WriteLine("Mostrando Pedidos");
            var listaPedidos = MongoOperations.TodosPedidos(stringConexao, nomeBase, nomeColecao).Result;
            return Ok(listaPedidos);
        }

        // Método pelo qual retorna os pedidos, porém em relação ao número da página e ao tamanho dela
        [HttpGet]
        public IActionResult GetPagina([FromQuery(Name = "numeroPagina")]int NumeroPagina, [FromQuery(Name ="tamanhoPagina")]int TamPagina)
        {
            var colecaoPagina = MongoOperations.PedidosPagina(stringConexao, nomeBase, nomeColecao, NumeroPagina, TamPagina).Result;
            var retornoPagina = new PaginaPedido(NumeroPagina, TamPagina, colecaoPagina);
            return Ok(retornoPagina);
        }
    }
}
