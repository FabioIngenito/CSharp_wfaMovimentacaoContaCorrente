using System;
using HtmlAgilityPack;

namespace MovimentacaoContaCorrente.BLL
{
    public class ClsConversaoBLL
    {
        /// <summary>
        /// Faz a busca do Dólar Comercial no site da UOL
        /// Baseado no:
        /// https://dotnetfiddle.net/8rsuym
        /// </summary>
        /// <returns>Retorna Dólar Comercial</returns>
        public static string RetornaDolarComercialUOL()
        {
            try
            {
                string url = @"https://economia.uol.com.br/";
                HtmlDocument doc = new HtmlWeb().Load(url);
                HtmlNode value = doc.DocumentNode.SelectSingleNode(" / html/body/section[1]/div[2]/div/div[1]/div[2]/h3/a[3]");

                return value.InnerText;
            }
            catch (ArgumentNullException)
            {
                return "null";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        /// <summary>
        /// Faz a busca do Dólar Comercial no site da The Money Converter
        /// </summary>
        /// <returns>Retorna Dólar Comercial</returns>
        public static string RetornaDolarComercialTheMoneyConverter()
        {
            string url = @"https://themoneyconverter.com/USD/BRL.aspx";
            HtmlDocument doc = new HtmlWeb().Load(url);
            HtmlNode value = doc.DocumentNode.SelectSingleNode("//*[@id='cc-ratebox']");

            string strValue = value.InnerText;
            // Precisei formatar com vírgula.
            strValue = strValue.Replace('.', ',');
            strValue = "R$ " + strValue.Substring(strValue.IndexOf("=", 0) + 2, 7);

            return strValue;
        }

        /// <summary>
        /// Faz a busca do Dólar Comercial no site da Dólar Hoje
        /// </summary>
        /// <returns>Retorna Dólar Comercial</returns>
        public static string RetornaDolarComercialDolarHoje()
        {
            string url = @"https://www.dolarhoje.net.br/";
            HtmlDocument doc = new HtmlWeb().Load(url);
            HtmlNode value = doc.DocumentNode.SelectSingleNode("//*[@id='divSpdInText']/table/tbody/tr[1]/td[2]");

            return value.InnerText;
        }

        /// <summary>
        /// Faz a busca do Dólar Comercial no site da InfoMoney
        /// </summary>
        /// <returns>Retorna Dólar Comercial</returns>
        public static string RetornaDolarComercialInfoMoney()
        {
            string url = @"https://www.infomoney.com.br/mercados/cambio";
            HtmlDocument doc = new HtmlWeb().Load(url);
            HtmlNode value = doc.DocumentNode.SelectSingleNode("//html/body/div[1]/div[1]/div[2]/div[2]/div/div[2]/div/div[1]/div[2]/div/table/tbody/tr[1]/td[3]/span");

            return "R$ " + value.InnerText;
        }

        /// <summary>
        /// Faz a busca do Dólar Comercial no site da InfoMoney
        /// </summary>
        /// <returns>Retorna Dólar Comercial</returns>
        public static string RetornaDolarComercialValorEconomico()
        {
            string url = @"https://www.valor.com.br/valor-data";
            HtmlDocument doc = new HtmlWeb().Load(url);
            HtmlNode value = doc.DocumentNode.SelectSingleNode("//*[@id='ticker-data']/div[1]/span[1]");

            return "R$ " + value.InnerText;
        }

        /// <summary>
        /// Faz a busca do Dólar Comercial no site da Calcule.Net
        /// </summary>
        /// <returns>Retorna Dólar Comercial</returns>
        public static string RetornaDolarComercialCalculeNet()
        {
            string url = @"https://www.calcule.net/financeiro/dolar-hoje/";
            HtmlDocument doc = new HtmlWeb().Load(url);
            HtmlNode value = doc.DocumentNode.SelectSingleNode("//*[@id='moedas']/table/tbody/tr[1]/td[2]");

            return value.InnerText;
        }

        /// <summary>
        /// Faz a busca do Dólar Comercial no site da Toro Investimentos
        /// </summary>
        /// <returns>Retorna Dólar Comercial</returns>
        public static string RetornaDolarComercialToroInvestimentos()
        {
            string url = @"https://artigos.toroinvestimentos.com.br/dolar-hoje-cotacao-conversor";
            HtmlDocument doc = new HtmlWeb().Load(url);
            HtmlNode value = doc.DocumentNode.SelectSingleNode("/html/body/section[2]/div[1]/div/table/tbody/tr[1]/td[2]/span");

            return value.InnerText;
        }

        /// <summary>
        /// Faz a busca do Dólar Comercial no site da Toro Radar
        /// </summary>
        /// <returns>Retorna Dólar Comercial</returns>
        public static string RetornaDolarComercialToroRadar()
        {
            string url = @"https://www.tororadar.com.br/dolar-cotacao-hoje";
            HtmlDocument doc = new HtmlWeb().Load(url);
            HtmlNode value = doc.DocumentNode.SelectSingleNode("//*[@id='pair_2103']/div[4]");

            return value.InnerText;
        }

        /// <summary>
        /// Web References
        /// Adicionar a Referência WEB / Botão AVANÇADO (Referência de Serviço):
        /// https://www3.bcb.gov.br/sgspub/JSP/sgsgeral/FachadaWSSGS.wsdl
        /// </summary>
        /// <param name="Moeda"></param>
        /// <returns>Retorna Moeda</returns>
        public static string RetornaDolarComercialBancoCentralDoBrasilWR(int Moeda)
        {
            // Chama o Web Reference para retornar o valor
            br.gov.bcb.www3.FachadaWSSGSService wsFachada = new br.gov.bcb.www3.FachadaWSSGSService();

            // Através do código da moeda, atribui a variável valorCotação o resultado da busca
            string valorCotacao = wsFachada.getUltimosValoresSerieVO(Moeda, 1).valores[0].svalor;

            // Precisei formatar com vírgula.
            valorCotacao = valorCotacao.Replace('.', ',');

            // Retorna o resultado
            return "R$ " + valorCotacao;
        }

        /// <summary>
        /// Connected Services
        /// Adicionar a Referência WEB (Referência de Serviço):
        /// https://www3.bcb.gov.br/sgspub/JSP/sgsgeral/FachadaWSSGS.wsdl
        /// </summary>
        /// <param name="Moeda"></param>
        /// <returns>Retorna Moeda</returns>
        public static string RetornaDolarComercialBancoCentralDoBrasilCS(int Moeda)
        {
            // Chama o Web Reference para retornar o valor
            wsCotacao.FachadaWSSGSClient wsClient = new wsCotacao.FachadaWSSGSClient();

            // Através do código da moeda, atribui a variável valorCotação o resultado da busca
            string valorCotacao = wsClient.getUltimosValoresSerieVO(Moeda, 1).valores[0].svalor;

            // Precisei formatar com vírgula.
            valorCotacao = valorCotacao.Replace('.', ',');

            // Retorna o resultado
            return "R$ " + valorCotacao;
        }
    }
}
