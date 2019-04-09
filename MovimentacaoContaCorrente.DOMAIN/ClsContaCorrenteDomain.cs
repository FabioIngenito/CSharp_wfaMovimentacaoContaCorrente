using System;

namespace MovimentacaoContaCorrente.DOMAIN
{
    public class ClsContaCorrenteDomain
    {
        #region "Construtores"
        /// <summary>
        /// Construtor Principal (CTOR)
        /// </summary>
        public ClsContaCorrenteDomain()
        {

        }
        #endregion

        #region "Atributos"
        private int _IDContaCorrente;
        private Double _ValorAtual;
        #endregion

        #region "Propriedades"

        /// <summary>
        /// Tabela:        tblContaCorrente
        /// Nome do Campo: IDContaCorrente
        /// Tipo de Dados: Número
        /// Descricao:     Chave Primária da Conta Corrente
        /// </summary>
        public int IDContaCorrente
        {
            get { return _IDContaCorrente; }
            set { _IDContaCorrente = value; }
        }

        /// <summary>
        /// Tabela:        tblContaCorrente
        /// Nome do Campo: ValorAtual
        /// Tipo de Dados: Número Grande
        /// Descricao:     Valor Atual da Conta Corrente
        /// </summary>
        public Double ValorAtual
        {
            get { return _ValorAtual; }
            set { _ValorAtual = value; }
        }

        #endregion
    }
}
