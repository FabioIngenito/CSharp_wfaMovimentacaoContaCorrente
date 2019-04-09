using SecureAppC;
using System.Windows.Forms;

namespace MovimentacaoContaCorrente.DAL
{
    public class ClsDadosDAL
    {
        public static string StringDeConexaoSQLServer
        {
            get
            {
                //Chave Pública: teste
                //return "server=SERVER009\SQLEXPRESS;database=ContaCorrente;Trusted_Connection=True";
                return "";
            }
        }

        public static string StringDeConexaoAccess
        {
            get
            {
                DTICrypto objCrypto = new DTICrypto();
                //Chave Pública: teste
                //return objCrypto.Cifrar("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\ContaCorrente.accdb;Persist Security Info=False;", "teste");
                return objCrypto.Cifrar("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\ContaCorrente.mdb;Persist Security Info=False;", "teste");
            }
        }
    }
}
