using System;
using System.Windows.Forms;

namespace MovimentacaoContaCorrente.BLL
{
    public class ClsFormularioBLL
    {
        /// <summary>
        /// Ajustar os estados dos botões de acordo com o evento disparado.
        /// </summary>
        /// <param name="parent">Formulário chamado.</param>
        /// <param name="bytBotoes">Código do tipo de ação.</param>
        public void AjustaBotoes(Control parent, byte bytBotoes)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    switch (bytBotoes)
                    {
                        //1 - Entrada de dados
                        case 1:
                            if (c.Name == "BtnIncluir") { c.Text = "&Salvar"; }

                            if (c.Name == "BtnAlterar")
                            {
                                c.Text = "&Cancelar";
                                c.Enabled = true;
                            }

                            if (c.Name == "BtnLimpar") { c.Enabled = true; }
                            if (c.Name == "BtnPesquisar") { c.Enabled = false; }
                            if (c.Name == "BtnExcluir") { c.Enabled = false; }
                            if (c.Name == "BtnFiltro") { c.Enabled = false; }

                            break;

                        //2 - Existe algo cadastrado
                        case 2:
                            if (c.Name == "BtnIncluir") { c.Text = "&Incluir"; }

                            if (c.Name == "BtnAlterar")
                            {
                                c.Text = "&Alterar";
                                c.Enabled = true;
                            }

                            if (c.Name == "BtnLimpar") { c.Enabled = false; }
                            if (c.Name == "BtnPesquisar") { c.Enabled = true; }
                            if (c.Name == "BtnExcluir") { c.Enabled = true; }
                            if (c.Name == "BtnFiltro") { c.Enabled = true; }

                            break;

                        //3 - Não existe nada cadastrado
                        case 3:
                            if (c.Name == "BtnIncluir") { c.Text = "&Incluir"; }

                            if (c.Name == "BtnAlterar")
                            {
                                c.Text = "&Alterar";
                                c.Enabled = false;
                            }

                            if (c.Name == "BtnLimpar") { c.Enabled = false; }
                            if (c.Name == "BtnPesquisar") { c.Enabled = false; }
                            if (c.Name == "BtnExcluir") { c.Enabled = false; }
                            if (c.Name == "BtnFiltro") { c.Enabled = false; }

                            break;

                        //4 - Não existe nada cadastrado na Tabela Pai 
                        //  -> Obrigatório preenchimento da Chave Estrangeira, não deixa trabalhar no formulário.
                        case 4:
                            if (c.Name == "BtnIncluir") { c.Enabled = false; }
                            if (c.Name == "BtnAlterar") { c.Enabled = false; }
                            if (c.Name == "BtnLimpar") { c.Enabled = false; }
                            if (c.Name == "BtnPesquisar") { c.Enabled = false; }
                            if (c.Name == "BtnExcluir") { c.Enabled = false; }
                            if (c.Name == "BtnFiltro") { c.Enabled = false; }

                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Limpar a caixas de texto.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="tb"></param>
        public void EmptyTextBoxes(Control parent, TextBox tb)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox)                   //if (c.GetType() == typeof(TextBox))
                {
                    if (c.Name != tb.Name)
                    {
                        c.Text = "";                //((TextBox)(c)).Text = string.Empty;
                    }
                    else
                    {
                        tb.Focus();
                    }
                }

                if (c is MaskedTextBox)             //if (c.GetType() == typeof(MaskedTextBox))
                {
                    c.Text = "";                    //((MaskedTextBox)(c)).Text = string.Empty;
                }

                //if (c is ComboBox) c.Text = "";
            }
        }

        /// <summary>
        /// Site:
        /// http://www.macoratti.net/10/10/c_inbox.htm
        /// </summary>
        /// <param name="prompt">Texto que aparece para o usuário.</param>
        /// <param name="title">Título de formulário</param>
        /// <param name="defaultValue">Valor Padrão da caixa de texto - opcional</param>
        /// <returns>Retorna o valor digitado na caixa de texto.</returns>
        public static string InputBox(string prompt, string title, string defaultValue)
        {
            InputBoxDialog ib = new InputBoxDialog
            {
                FormPrompt = prompt,
                FormCaption = title,
                DefaultValue = defaultValue
            };

            ib.ShowDialog();

            string s = ib.InputResponse;

            ib.Close();

            if (s == string.Empty)
                return "";
            else
                return s;
        }

        /// <summary>
        /// Do site:
        /// http://support.microsoft.com/kb/329488
        /// </summary>
        /// <param name="Expression">Número ou nome</param>
        /// <returns>True = É Número or False = NÃO é Número</returns>
        public static bool IsNumeric(object Expression)
        {
            bool isNum;

            isNum = double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out double retNum);
            return isNum;
        }

        /// <summary>
        /// Trata a aspas simples em todos os campos exto para gravá-lo.
        /// </summary>
        /// <param name="Telefone">Campo.</param>
        /// <returns>Campo com aspa sim ples tratada.</returns>
        public static string TrataAspa(string Campo)
        {
            Campo = Campo.Replace("'", "''");
            return Campo;
        }

        /// <summary>
        /// Trata a aspas simples em todos os campos exto para gravá-lo.
        /// </summary>
        /// <param name="Telefone">Campo.</param>
        /// <returns>Campo com aspa sim ples tratada.</returns>
        public static string LimpaAspa(string Campo)
        {
            Campo = Campo.Replace("'", "");
            return Campo;
        }
    }
}
