using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApi.Views
{
    internal class Conta_view
    {

        //propriedade estática, para gerar sozinho os codigos da conta. Essa classe é acessivel atraves da classe e não do objeto. 
        static public int proximaConta = 321;
        static public int contasCriadas = 0;


        //propriedades
        public string NumeroConta { get; set; }
        public string Titular {  get; set; }
        private decimal Saldo;
        private List<Transacao_view> Transacoes;



        //método construtor
        public Conta_view(string NumeroConta, string titular)
        {
            this.NumeroConta = NumeroConta;
            this.Titular = titular;
            this.Saldo = 0;
            proximaConta ++;
            contasCriadas ++;
        }


        //outros métodos
        public string ConsultarConta()
        {
            string info = "";
            info += "Conta numero";
            info += this.NumeroConta;
            info += "de";
            info += this.Titular;
            info += ", \npossui saldo de ";
            info += this.Saldo.ToString();
            info += "reais. ";
            return info;
        }

        public void fazerDeposito(decimal val, DateTime dat, string desc)
        {
            this.Transacoes.Add(new Transacao_view(val, dat, desc, "C"));
            this.Saldo += val;

        }


        public void fazerRetirada(decimal val, DateTime dat, string desc)
        {
            if (val <= this.Saldo)
            {
                this.Transacoes.Add( new Transacao_view(val, dat, desc, "D"));
                this.Saldo -= val;
            }

        }


        public string recuperarExtrato()
        {
            var extrato = new System.Text.StringBuilder();
            decimal saldo = 0;

            //gerar arquivo de texto. 
            extrato.AppendLine("Data\tValor\tTipo\tSaldo\tDescrição");
            extrato.AppendLine("-----------------------------");

            foreach(Transacao_view t in Transacoes)
            {
                if( t.Tipo == "C") { saldo += t.Valor; }
                else { saldo -= t.Valor; }

                extrato.AppendLine($"{t.Data.ToShortDateString()} \t {t.Valor} \t {t.Tipo} \t {t.saldo} \t {t.Descricao}");
            }

            return extrato.ToString();
        }
    }
}
