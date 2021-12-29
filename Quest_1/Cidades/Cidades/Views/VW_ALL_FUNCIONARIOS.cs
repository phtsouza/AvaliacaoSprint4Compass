using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeCidades.Views
{
    public class VW_ALL_FUNCIONARIOS
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Guid CidadeId { get; set; }
        public DateTime? UltimaAtualizacao { get; set; }

    }
}
