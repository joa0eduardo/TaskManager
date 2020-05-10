using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Atividade
    {
        public int IdAtividade { get; set; }
        public GrupoAtividade GrupoAtividade { get; set; }
        public TipoAtividade TipoAtividade { get; set; }
        public Usuario Usuario { get; set; }
        public string AtividadeDescricao { get; set; }
        public DateTime AtividadeDataHoraCadastro { get; set; }
        public DateTime AtividadeDataHoraInicio { get; set; }
        public DateTime AtividadeDataHoraPausa { get; set; }
        public DateTime AtividadeDataHoraConclusao { get; set; }
        public StatusAtividade StatusAtividade { get; set; }
        public DateTime AtividadeTempoTotal { get; set; }
        public DateTime AtividadeDataHoraReinicio { get; set; }
    }
}
