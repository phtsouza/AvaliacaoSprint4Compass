using AuditoriaPedidos.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditoriaPedidos.Operations
{
    public static class MongoOperations
    {
		// Método que conecta no servidor
		private static IMongoClient ConexaoServidorMongoDB(string stringConexao)
		{
			return new MongoClient(stringConexao);
		}

		// Método pelo qual retorna a database do servidor
		private static IMongoDatabase ConexaoBase(IMongoClient Servidor, string nomeBase)
		{
			return Servidor.GetDatabase(nomeBase);
		}

		// Método pelo qual retorna os dados do database
		private static IMongoCollection<Pedido> ConexaoColecao(IMongoDatabase BancoPedidos, string nomeColecao)
		{
			return BancoPedidos.GetCollection<Pedido>(nomeColecao);
		}

		// Método pelo qual retorna a coleção de dados
		private static IMongoCollection<Pedido> ColecaoMongoDB(string StringConexao, string NomeDatabase, string NomeColecao)
		{
			var Servidor = ConexaoServidorMongoDB(StringConexao);
			var BancoPedidos = ConexaoBase(Servidor, NomeDatabase);
			var ColecaoPedidos = ConexaoColecao(BancoPedidos, NomeColecao);
			return ColecaoPedidos;
		}

		// Método pelo qual retorna todos os pedidos
		public static async Task<List<Pedido>> TodosPedidos(string stringConexao, string nomeBase, string nomeColecao)
		{
			var ColecaoPedidos = ColecaoMongoDB(stringConexao, nomeBase, nomeColecao);
			var TodosOsPedidos = await ColecaoPedidos.Find(X => true).ToListAsync();
			return TodosOsPedidos;
		}

		// Método pelo qual insere um pedido dentro da coleção
		public static async Task<Pedido> InserePedidoAsync(string stringConexao, string nomeBase, string nomeColecao, Pedido pedido)
        {
			var ColecaoPedidos = ColecaoMongoDB(stringConexao, nomeBase, nomeColecao);
			await ColecaoPedidos.InsertOneAsync(pedido);
			return pedido;
		}

		// Método pelo qual organiza os pedidos de acordo com o número da página e seu tamanho
		public static async Task<List<Pedido>> PedidosPagina(string stringConexao, string nomeBase, string nomeColecao, int NumeroPagina, int TamPagina)
        {
            var ColecaoPedidos = TodosPedidos(stringConexao, nomeBase, nomeColecao).Result;
            var ColecaoDaPagina = ColecaoPedidos.Skip((NumeroPagina - 1) * TamPagina).Take(TamPagina).ToList();
            return ColecaoDaPagina;
        }

    }
}


