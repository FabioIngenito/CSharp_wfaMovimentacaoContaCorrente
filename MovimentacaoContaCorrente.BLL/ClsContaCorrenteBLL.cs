using MovimentacaoContaCorrente.DAL;
using MovimentacaoContaCorrente.DOMAIN;
using System;
using System.Data;

namespace MovimentacaoContaCorrente.BLL
{
    public class ClsContaCorrenteBLL : ICrud<ClsContaCorrenteDomain, int>
    {
        /// <summary>
        /// Incluir da BLL. Aplica as regras de negócio.
        /// </summary>
        /// <param name="entidade">Estrutura DOMAIN de Conta Corrente</param>
        /// <param name="BDM">Sigla do Banco de Dados</param>
        /// <returns>Retorna string com a PK incluída dependendo se o BD suporta fazer isto.</returns>
        public string Incluir(ClsContaCorrenteDomain entidade, ClsBDDomain BDM)
        {
            string incluir = "";

            //Regra de Negócio: O ID da Conta Corrente é Obrigatória.
            if (entidade.IDContaCorrente <= 0)
                throw new Exception("O ID da Conta Corrente é obrigatório.");

            //Regra de Negócio: Verificar se o número da conta já existe.
            if (ExisteChave(entidade.IDContaCorrente, BDM))
                throw new Exception("O ID da Conta Corrente já existe.");

            //Regra de Negócio: O Valor Atual é obrigatório.
            if (entidade.ValorAtual <= 0)
                throw new Exception("O valor é obrigatório.");

            //Se está tudo okay, chama a rotina de inserção.
            ClsContaCorrenteDAL obj = new ClsContaCorrenteDAL();

            //Passando para inclusão a estrutura (preenchida com os 
            //dados a serem incluídos e o banco que quero que inclua os dados).
            incluir = obj.Incluir(entidade, BDM);

            return incluir;
        }

        /// <summary>
        /// Alterar da BLL. Aplica as regras de negócio.
        /// </summary>
        /// <param name="entidade">Estrutura DOMAIN de Conta Corrente</param>
        /// <param name="BDM">Sigla do Banco de Dados</param>
        public void Alterar(ClsContaCorrenteDomain entidade, ClsBDDomain BDM)
        {
            //Regra de Negócio: O ID da Conta Corrente é Obrigatória.
            if (entidade.IDContaCorrente.ToString().Length == 0)
                throw new Exception("O ID da Conta Corrente é obrigatório.");

            //Regra de Negócio: O Valor Atual é obrigatório.
            if (entidade.ValorAtual.ToString().Length == 0)
                throw new Exception("O valor é obrigatório.");

            //Se está tudo okay, chama a rotina de inserção.
            ClsContaCorrenteDAL obj = new ClsContaCorrenteDAL();
            obj.Alterar(entidade, BDM);
        }

        /// <summary>
        /// Excluir Genérico da DAL. Redireciona para o BD Correto.
        /// </summary>
        /// <param name="chave">ID da Conta Corrente</param>
        /// <param name="BDM">Sigla do Banco de Dados</param>
        public void Excluir(ClsContaCorrenteDomain entidade, ClsBDDomain BDM)
        {
            //Regra de Negócio: O ID da Conta Corrente é Obrigatória.
            if (entidade.IDContaCorrente < 1)
                throw new Exception("Selecione uma Conta Corrente antes de excluí-la.");

            ClsMovimentacaoDAL objMov = new ClsMovimentacaoDAL();
            //Regra de Negócio: Se existir Movimentações não é permitida a exclusão da Conta Corrente.
            if (objMov.ExisteChaveEstrangeira(entidade.IDContaCorrente, BDM))
                throw new Exception("Não é possível excluir uma Conta Corrente que tenha Movimentos.");

            ClsContaCorrenteDAL obj = new ClsContaCorrenteDAL();
            obj.Excluir(entidade, BDM);
        }

        /// <summary>
        /// Listagem Genérico da DAL. Redireciona para o BD Correto.
        /// </summary>
        /// <param name="filtro">Filtro do Banco de Dados</param>
        /// <param name="BDM">Sigla do Banco de Dados</param>
        /// <returns>Retorna um DataTable</returns>
        public DataTable Listagem(string filtro, ClsBDDomain BDM)
        {
            ClsContaCorrenteDAL obj = new ClsContaCorrenteDAL();
            return obj.Listagem(filtro, BDM);
        }

        /// <summary>
        /// Conta Registros Genérico da DAL. Redireciona para o BD Correto.
        /// </summary>
        /// <param name="BDM">Sigla do Banco de Dados</param>
        /// <returns>Retorna um Inteiro</returns>
        public int ContaRegistros(ClsBDDomain BDM)
        {
            ClsContaCorrenteDAL obj = new ClsContaCorrenteDAL();
            return obj.ContaRegistros(BDM);
        }

        /// <summary>
        /// Verifica se já existe a chave primária da Conta Corrente
        /// </summary>
        /// <param name="chave">Chave primária da Conta Corrente</param>
        /// <param name="BDM">Sigla do Banco de Dados</param>
        /// <returns></returns>
        public bool ExisteChave(int chave, ClsBDDomain BDM)
        {
            ClsContaCorrenteDAL obj = new ClsContaCorrenteDAL();
            return obj.ExisteChave(chave, BDM);
        }

        /// <summary>
        /// Atualiza todos os valores de todas as Contas Corrente.
        /// </summary>
        /// <param name="BDM">Sigla do Banco de Dados</param>
        /// <returns></returns>
        public bool AtualizaValorContaCorrente(ClsBDDomain BDM)
        {
            ClsContaCorrenteDAL obj = new ClsContaCorrenteDAL();
            return obj.AtualizaValorContaCorrente(BDM);
        }
    }
}
