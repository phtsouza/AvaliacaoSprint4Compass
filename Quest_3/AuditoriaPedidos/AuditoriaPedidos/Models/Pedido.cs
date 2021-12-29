using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace AuditoriaPedidos.Models
{
    public class Pedido
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public string Id { get; set; }
        public string OrderId { get; set; }
        public DateTime EventDate { get; set; }
        public string Description { get; set; }
        public string Api { get; set; }
        public Dictionary<string, string> Conteudo { get; set; }
    }
}