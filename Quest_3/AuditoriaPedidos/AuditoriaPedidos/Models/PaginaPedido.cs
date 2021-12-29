using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace AuditoriaPedidos.Models
{
    public class PaginaPedido
    {
        public List<Pedido> ListaPedidos { get; set; }
        public int NumeroPagina { get; set; }
        public int TamPagina { get; set; }

        public PaginaPedido() { }
        public PaginaPedido(int NumeroPagina, int TamPagina, List<Pedido> ListaPedidos)
        {
            this.ListaPedidos = ListaPedidos;
            this.NumeroPagina = NumeroPagina;
            this.TamPagina = TamPagina;
        }
    }
}
