

namespace BancoApi.Views
{
    internal class Transacao_view
    {

        //movimentacoes
        public decimal valor { get; set; }
        private DateTime data { get; set; }
        private string descricao { get; set; }
        private string tipo { get; set; }

        public Transacao_view(decimal valor, DateTime data, string descricao, string tipo)
        {
            this.valor = valor;
            this.data = data;
            this.descricao = descricao;
            this.tipo = tipo;
        }
    }
}
