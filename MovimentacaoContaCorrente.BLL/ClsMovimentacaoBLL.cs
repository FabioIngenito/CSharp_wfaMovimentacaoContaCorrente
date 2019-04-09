using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovimentacaoContaCorrente.DAL;
using MovimentacaoContaCorrente.DOMAIN;

namespace MovimentacaoContaCorrente.BLL
{
    public class ClsMovimentacaoBLL : ICrud<ClsMovimentacaoDomain, int>
    {
        public string Incluir(ClsMovimentacaoDomain entidade, ClsBDDomain BDM)
        {
            string incluir = "";

            //Regra de Negócio: A Data / Hora é obrigatória.
            if (entidade.DataHora.ToString().Length == 0)
                throw new Exception("A Data e Hora são obrigatórias.");

            //Regra de Negócio: O "D"ébito / "C"rédito é obrigatório.
            if (!(entidade.DebitoCredito == 'D' || entidade.DebitoCredito == 'C'))
                throw new Exception("O preciso informar se é Crédito ou se é Débito.");

            //Regra de Negócio: O ID da Conta Corrente é Obrigatória.
            if (entidade.IDContaCorrente <= 0)
                throw new Exception("O ID da Conta Corrente é obrigatório.");

            //Regra de negócio: O ID da Conta Corrente precisa existir na "tblContaCorrente"
            ClsContaCorrenteDAL objCC = new ClsContaCorrenteDAL();

            if (!(objCC.ExisteChave(entidade.IDContaCorrente, BDM)))
                throw new Exception("O ID da Conta Corrente não existe.");

            //Regra de Negócio: O Valor Atual é obrigatório.
            if (entidade.ValorMovimentacao == 0)
                throw new Exception("O valor é obrigatório.");
            else
            {
                //Regra de Negócio: Caso seja Débito, o valor passado necessita ser negativo.
                if (entidade.DebitoCredito == 'D')
                {
                    entidade.ValorMovimentacao *= -1;

                    //Regra de negócio: O saldo NÃO pode ser negativo.
                    double ValorAtual = SomaValores(entidade.IDContaCorrente, BDM);

                    if (ValorAtual + entidade.ValorMovimentacao < 0)
                        throw new Exception("A Conta Corrente NÃO pode ficar negativa.");
                }
            }

            //Se está tudo okay, chama a rotina de inserção.
            ClsMovimentacaoDAL obj = new ClsMovimentacaoDAL();

            //Passando para inclusão a estrutura do registro (preenchida com os 
            //dados a serem incluídos e o banco que quero que inclua os dados).
            incluir = obj.Incluir(entidade, BDM);

            return incluir;
        }

        public void Alterar(ClsMovimentacaoDomain entidade, ClsBDDomain BDM)
        {
            //Regra de Negócio: O nome do contato é obrigatório.
            if (entidade.IDMovimentacao.ToString().Length == 0)
                throw new Exception("O ID da Movimentação é obrigatória.");

            //Regra de Negócio: A Data / Hora é obrigatória.
            if (entidade.DataHora.ToString().Length == 0)
                throw new Exception("A Data e Hora são obrigatórias.");

            //Regra de Negócio: O "D"ébito / "C"rédito é obrigatório.
            if (entidade.DebitoCredito.ToString().Length == 0)
                throw new Exception("O preciso informar se é Crédito ou se é Débito.");

            //Regra de Negócio: O Valor Atual é obrigatório.
            if (entidade.ValorMovimentacao.ToString().Length == 0)
                throw new Exception("O valor é obrigatório.");

            //Regra de Negócio: O ID da Conta Corrente é Obrigatória.
            if (entidade.IDContaCorrente.ToString().Length == 0)
                throw new Exception("O ID da Conta Corrente é obrigatório.");

            //Se está tudo okay, chama a rotina de alteração.
            ClsMovimentacaoDAL obj = new ClsMovimentacaoDAL();

            obj.Alterar(entidade, BDM);
        }

        public void Excluir(ClsMovimentacaoDomain entidade, ClsBDDomain BDM)
        {
            int chaveCC = 0;

            ///Regra de negócio: O ID da Movimentação é Obrigatório.
            if (entidade.IDMovimentacao < 1)
                throw new Exception("Selecione uma Movimentação antes de excluí-la.");

            ClsMovimentacaoDAL obj = new ClsMovimentacaoDAL();
            chaveCC = obj.BuscaNumeroContaCorrente(entidade.IDMovimentacao, BDM);

            //Regra de negócio: O saldo NÃO pode ser negativo.
            double ValorAtual = SomaValores(chaveCC, BDM);

            if (entidade.DebitoCredito == 'D')
                entidade.ValorMovimentacao *= -1;

            if (ValorAtual - entidade.ValorMovimentacao < 0)
                throw new Exception("A Conta Corrente NÃO pode ficar negativa.");

            obj.Excluir(entidade, BDM);
        }

        public DataTable Listagem(string filtro, ClsBDDomain BDM)
        {
            ClsMovimentacaoDAL obj = new ClsMovimentacaoDAL();
            return obj.Listagem(filtro, BDM);
        }

        public int ContaRegistros(int chave, ClsBDDomain BDM)
        {
            ClsMovimentacaoDAL obj = new ClsMovimentacaoDAL();
            return obj.ContaRegistros(chave, BDM);
        }

        public double SomaValores(int chave, ClsBDDomain BDM)
        {
            ClsMovimentacaoDAL obj = new ClsMovimentacaoDAL();

            //Regra de negócio: O ID da Conta Corrente precisa existir na "tblContaCorrente"
            ClsContaCorrenteDAL objCC = new ClsContaCorrenteDAL();

            if (!(objCC.ExisteChave(chave, BDM)))
                throw new Exception("O ID da Conta Corrente não existe.");

            return obj.SomaValores(chave, BDM);
        }

        //public double ValorMovimentacao(ClsMovimentacaoDomain entidade, ClsBDDomain BDM)
        //{
        //    ClsMovimentacaoDAL obj = new ClsMovimentacaoDAL();

        //    //Regra de negócio: O ID da Conta Corrente precisa existir na "tblContaCorrente"
        //    ClsContaCorrenteDAL objCC = new ClsContaCorrenteDAL();

        //    if (!(objCC.ExisteChave(entidade.IDContaCorrente, BDM)))
        //        throw new Exception("O ID da Conta Corrente não existe.");

        //    return obj.ValorMovimentacao(entidade, BDM);
        //}
    }
}
