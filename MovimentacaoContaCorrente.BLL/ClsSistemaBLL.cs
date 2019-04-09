using System.Text.RegularExpressions;

namespace MovimentacaoContaCorrente.BLL
{
    public class ClsSistemaBLL
    {
        /// <summary>
        /// A = Access
        /// S = SQL Server
        /// </summary>
        /// <param name="banco">Envia o Banco de Dados que se deseja trabalhar. Exemplo: "Access".</param>
        /// <returns>Retorna um "valor discreto" sobre o banco que se deseja trabalhar. Exemplo: "A".</returns>
        public string ValidarBancoDados(string banco)
        {
            switch (banco)
            {
                case "S":
                case "SQL Server":
                    banco = "S";
                    break;

                default:
                case null:
                case "":
                case "A":
                case "Access":
                    banco = "A";
                    break;
            }
            return banco;
        }

        /// <summary>
        /// Verifica se é numérico
        /// </summary>
        /// <param name="inputString">String de Entradas</param>
        /// <returns>Retorno Booleano</returns>
        public static bool IsNumeric(string inputString)
        {
            return Regex.IsMatch(inputString, "^[0-9]+$");
        }
    }
}
