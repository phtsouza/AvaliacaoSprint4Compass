using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeCidades.Procedures
{
    public class SP_ADD_CIDADE
    {
		public Guid Id { get; set; }
		public string Nome { get; set; }
		public int Populacao { get; set; }
		public decimal TaxaCriminalidade { get; set; }
		public decimal ImpostoSobreProduto { get; set; }
		public bool EstadoCalamidade { get; set; }
	}
}
