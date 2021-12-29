using AtividadeCidades.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Cidades
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var contexto = new CidadesContext())
            {
                Console.WriteLine("Listando todos funcionários");
                Console.WriteLine("========================================");
                MostraFuncionarios(contexto);
                Console.WriteLine("========================================");
                Console.WriteLine("Funcionários listados, pressione enter para continuar");
                Console.ReadLine();
                Console.WriteLine("Adicionando cidade teste");
                AdicionaCidade(contexto);
                Console.WriteLine("Cidade teste adicionada com sucesso, pressione enter para encerrar");
                Console.ReadLine();
            }
        }

        // Método para mostrar os funcionários
        static void MostraFuncionarios(CidadesContext context)
        {
            var comando = "select * from VW_ALL_FUNCIONARIOS";
            var retorno = context._VWALLFUNCIONARIOS.FromSqlRaw(comando);

            foreach(var item in retorno)
            {
                //Console.WriteLine("========================================");
                //Console.WriteLine($"Id = {item.Id}");
                Console.WriteLine($"{item.Nome}");
                //Console.WriteLine($"DataNascimento = {item.DataNascimento}");
                //Console.WriteLine($"CidadeId = {item.CidadeId}");
                //Console.WriteLine($"UltimaAtualizacao = {item.UltimaAtualizacao}");
            }
        }

        // Método para adicionar cidade teste
        static void AdicionaCidade(CidadesContext context)
        {
            string comando = "DECLARE @P_Id uniqueidentifier; SET @P_Id = NEWID();" +
                "exec SP_ADD_CIDADE @P_Id, @P_Nome, @P_Populacao, @P_TaxaCriminalidade, @P_ImpostoSobreProduto, @P_EstadoCalamidade";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter{ParameterName = "@P_Nome", Value = "Vitória Teste"},
                new SqlParameter{ParameterName = "@P_Populacao", Value = 123456},
                new SqlParameter{ParameterName = "@P_TaxaCriminalidade", Value = 34.3},
                new SqlParameter{ParameterName = "@P_ImpostoSobreProduto", Value = 4.88},
                new SqlParameter{ParameterName = "@P_EstadoCalamidade", Value = true},
            };
            var retorno = context.Database.ExecuteSqlRaw(comando, parameters);
        }
    }
}
