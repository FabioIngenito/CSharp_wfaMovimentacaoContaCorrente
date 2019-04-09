using System;

namespace MovimentacaoContaCorrente.DOMAIN
{
    public class ClsMovimentacaoDomain
    {
        #region "Construtores"
        /// <summary>
        /// Construtor Principal (CTOR)
        /// </summary>
        public ClsMovimentacaoDomain()
        {

        }
        #endregion

        #region "Atributos"
        private int _IDMovimentacao;
        private DateTime _DataHora;
        private char _DebitoCredito;
        private Double _ValorMovimentacao;
        private int _IDContaCorrente;
        #endregion

        #region "Propriedades"

        /// <summary>
        /// Tabela:        tblMovimentacoes
        /// Nome do Campo: IDMovimentacao
        /// Tipo de Dados: Numeração Automática
        /// Descricao:     ID da Movimentação(identity)
        /// </summary>
        public int IDMovimentacao
        {
            get { return _IDMovimentacao; }
            set { _IDMovimentacao = value; }
        }

        /// <summary>
        /// Tabela:        tblMovimentacoes
        /// Nome do Campo: DataHora
        /// Tipo de Dados: Data/Hora
        /// Descricao:     Data e Hora da Movimentação
        /// </summary>
        public DateTime DataHora
        {
            get { return _DataHora; }
            set { _DataHora = value; }
        }

        /// <summary>
        /// Tabela:        tblMovimentacoes
        /// Nome do Campo: DebitoCredito
        /// Tipo de Dados: Texto Curto
        /// Descricao:     Se a Movimentação é "C"rédito ou "D"ébito
        /// </summary>
        public char DebitoCredito
        {
            get { return _DebitoCredito; }
            set { _DebitoCredito = value; }
        }

        /// <summary>
        /// Tabela:        tblMovimentacoes
        /// Nome do Campo: ValorMovimentacao
        /// Tipo de Dados: Número Grande
        /// Descricao:     Valor da Movimentação
        /// </summary>
        public Double ValorMovimentacao
        {
            get { return _ValorMovimentacao; }
            set { _ValorMovimentacao = value; }
        }

        /// <summary>
        /// Tabela:        tblMovimentacoes
        /// Nome do Campo: IDContaCorrente
        /// Tipo de Dados: Número
        /// Descricao:     Chave Primária da tabela tblContaCorrente (FK - Chave Estrangeira)
        /// </summary>
        public int IDContaCorrente
        {
            get { return _IDContaCorrente; }
            set { _IDContaCorrente = value; }
        }

        #endregion
    }
}
