namespace MovimentacaoContaCorrente.DOMAIN
{
    /// <summary>
    /// Base de Dados Usada. Pode ser incluído novas bases.
    /// </summary>
    public class ClsBDDomain
    {
        #region "Construtores"

        public ClsBDDomain()
        {
        }

        //public clsBDModel(SqlDataReader dr) : base()
        //{
        //}

        #endregion

        #region "Atributos"
        private string _banco;
        #endregion

        #region "Propriedades"
        /// <summary>
        /// A = Access
        /// S = SQL Server
        /// </summary>
        public string Banco
        {
            get { return _banco; }
            set { _banco = value; }
        }
        #endregion
    }
}
