using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeCidade.Models
{
    public class Cidade
    {
        public Guid Id { get; set; } 
        public string Nome { get; set; }
        public int Populacao { get; set; }
        public float TaxaCriminalidade { get; set; }
        public float ImpostoSobreProduto { get; set; }
        public bool EstadoCalamidade { get; set; }
        public List<Funcionarios> _funcionarios { get; set; }
        public List<PrefeitosAtuais> _prefeitos { get; set; }
    }
}
