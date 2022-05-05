using System.ComponentModel;

namespace Core.Enumerators
{
    public enum TipoEstatisticaEnum : byte
    {
        [Description("atendimentoPostos")]
        AtendimentoPostos = 1,

        [Description("gruposVacinados")]
        GruposVacinados = 2,

        [Description("agendamentosTurno")]
        AgendamentosTurno = 3,

        [Description("utilizacaoLotes")]
        UtilizacaoLotes = 4,
        
        [Description("agendamentosHoje")]
        AgendamentosHoje = 5
    }
}
