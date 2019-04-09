using MovimentacaoContaCorrente.DOMAIN;
using System.Data;

namespace MovimentacaoContaCorrente.DAL
{
    public interface ICrud<T, tipoChave>
    {
        string Incluir(T entidade, ClsBDDomain BDM);
        void Alterar(T entidade, ClsBDDomain BDM);
        void Excluir(T entidade, ClsBDDomain BDM);
        DataTable Listagem(string filtro, ClsBDDomain BDM);
    }
}
