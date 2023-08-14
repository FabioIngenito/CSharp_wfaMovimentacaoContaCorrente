using MovimentacaoContaCorrente.BLL;
using MovimentacaoContaCorrente.DOMAIN;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace MovimentacaoContaCorrente.UI
{
    public partial class FrmContaCorrente : Form
    {
        ClsBDDomain BDModel = new ClsBDDomain();
        ClsSistemaBLL SistemasBLL = new ClsSistemaBLL();
        ClsContaCorrenteBLL ContaCorrenteBLL = new ClsContaCorrenteBLL();
        ClsFormularioBLL FormBLL = new ClsFormularioBLL();
        public string strContaCorrente = "";

        public FrmContaCorrente()
        {
            InitializeComponent();
        }

        private void FrmContaCorrente_Load(object sender, EventArgs e)
        {
            BDModel.Banco = SistemasBLL.ValidarBancoDados(CboBanco.Text);
            AtualizaGrid(strContaCorrente);
        }

        private void FrmContaCorrente_Activated(object sender, EventArgs e)
        {
            if (DgvContaCorrente.CurrentRow == null)
            {
                AcertaBotoes(3);
                BtnIncluir.Focus();
            }
            else
            {
                AcertaBotoes(2);
                TxtValorAtual_Leave(sender, e);
                DgvContaCorrente.Focus();
            }
            TxtValorDolar.Text = BuscaDolarComercial();
            AtualizaTela();
        }

        #region BOTÕES

        /// <summary>
        /// Inclui um novo registro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            //Aqui verifico qual é o nome do botão.
            //Se for "&Incluir", formato o formulário para permitir a inclusão de um novo registro;
            //Se for "&Salvar", disparo uma rotina para salvar a informação no Banco de Dados;
            if (BtnIncluir.Text == "&Incluir")
            {
                strContaCorrente = TxtContaCorrente.Text;
                TxtContaCorrente.Text = "";
                BtnIncluir.Tag = "I";
                BtnLimpar_Click(sender, e);
                AcertaBotoes(1);
                TxtValorDolar.Text = BuscaDolarComercial();
                TxtContaCorrente.Focus();
            }
            else
            {
                try
                {
                    //Monta uma "estrutura" de Conta Corrente para passar para classe BLL
                    ClsContaCorrenteDomain ClsCCDomain = new ClsContaCorrenteDomain();
                    ClsContaCorrenteBLL obj = new ClsContaCorrenteBLL();

                    if (TxtContaCorrente.Text.Length > 0)
                        ClsCCDomain.IDContaCorrente = int.Parse(TxtContaCorrente.Text);

                    //ClsCCDomain.ValorAtual = int.Parse(MtxValorAtual.Text);
                    if (!(string.IsNullOrEmpty(TxtValorAtual.Text.Trim())))
                        ClsCCDomain.ValorAtual = double.Parse(TxtValorAtual.Text.Replace("R$", ""));

                    //Em qual banco de dados devo guardar? Aqui mostra:
                    //Bom ... eu gostaria que esta variável fosse tipo "global", mas como fazer isto com várias camadas (projetos)?
                    //Quem souber pode me falar... burlei um pouco as regras?
                    BDModel.Banco = SistemasBLL.ValidarBancoDados(CboBanco.Text);

                    //De acordo com o que o usuário clicou ("I"ncluir ou "A"lterar) dentro da TAG do botão ...
                    //... se tivesse que digitar a chave, ficaria mais legal, pois basta verificar se a chave existe ou não no 
                    ///banco de dados: Se NÃO existe é "Incluir", se existe é "Alterar".
                    if (BtnIncluir.Tag.ToString() == "I")
                    {
                        try
                        {
                            strContaCorrente = obj.Incluir(ClsCCDomain, BDModel);
                            MessageBox.Show("A Conta Corrente foi incluída com sucesso!", "OKAY!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            TxtContaCorrente.Text = Convert.ToString(ClsCCDomain.IDContaCorrente);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        }
                    }
                    else
                    {
                        try
                        {
                            if (TxtContaCorrente.Text.Length == 0)
                                MessageBox.Show("Uma das Contas Correntes deve ser selecionada para alteração.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            else
                                obj.Alterar(ClsCCDomain, BDModel);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    AtualizaGrid(strContaCorrente);
                    AcertaBotoes(2);
                    BtnIncluir.Tag = "";
                }
            }
        }

        /// <summary>
        /// Altera um registro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            //Aqui verifico qual é o nome do botão.
            //Se for "&Alterar", formato o formulário para permitir a inclusão de um novo registro;
            //Se for "&Cancelar", disparo uma rotina para salvar a informação no Banco de Dados;
            if (BtnAlterar.Text == "&Alterar")
            {
                BtnIncluir.Tag = "A";
                strContaCorrente = TxtContaCorrente.Text;
                AcertaBotoes(1);
            }
            else
            {
                BtnIncluir.Tag = "";
                AtualizaGrid(strContaCorrente);
                AcertaBotoes(2);
            }
        }

        /// <summary>
        /// Limpa as caixas de texto e maskText da tela.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            FormBLL.EmptyTextBoxes(this, TxtContaCorrente);
        }

        /// <summary>
        /// Pesquisa um registro específico.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            string resposta = "";

            //Não existe "inputbox" no C#!!!
            //Então fui perguntar para o Macoratti...
            // http://www.macoratti.net/10/10/c_inbox.htm
            resposta = ClsFormularioBLL.InputBox("Digite um número ou um nome, \n se for número pesquisará por Código, \n se for nome, pesquisará por parte do registro ", "Pesquisar registro", "");

            if (ClsFormularioBLL.IsNumeric(resposta))
            {
                for (int i = 0; i < DgvContaCorrente.Rows.Count; i++)
                {
                    if (resposta == DgvContaCorrente[0, i].Value.ToString())
                    {
                        //faz a célula atual e seleciona a linha
                        DgvContaCorrente.ClearSelection();
                        DgvContaCorrente.CurrentCell = DgvContaCorrente.Rows[i].Cells[0];
                        DgvContaCorrente.Rows[i].Selected = true;
                        //Preenche os dados das textbox
                        DgvContaCorrente_CellClick(null, null);

                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < DgvContaCorrente.Rows.Count; i++)
                {
                    string conteudo = DgvContaCorrente[1, i].Value.ToString().ToUpper();

                    if (conteudo.IndexOf(resposta.ToUpper()) > -1)
                    {
                        //faz a célula atual e seleciona a linha
                        DgvContaCorrente.ClearSelection();
                        DgvContaCorrente.CurrentCell = DgvContaCorrente.Rows[i].Cells[0];
                        DgvContaCorrente.Rows[i].Selected = true;
                        //Preenche os dados das textbox
                        DgvContaCorrente_CellClick(null, null);

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Exclui um campo na tela e dispara exclusão no banco de dados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja excluir? ", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                if (TxtContaCorrente.Text.Length == 0)
                {
                    MessageBox.Show("Um registro deve ser selecionado antes da exclusão.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else

                    try
                    {
                        //Monta uma "estrutura" de Conta Corrente para passar para classe BLL
                        ClsContaCorrenteDomain ClsCCDomain = new ClsContaCorrenteDomain();

                        if (TxtContaCorrente.Text.Length > 0)
                            ClsCCDomain.IDContaCorrente = int.Parse(TxtContaCorrente.Text);

                        //ClsCCDomain.ValorAtual = int.Parse(MtxValorAtual.Text);
                        if (!(string.IsNullOrEmpty(TxtValorAtual.Text.Trim())))
                            ClsCCDomain.ValorAtual = double.Parse(TxtValorAtual.Text.Replace("R$", ""));

                        //Em qual banco de dados devo guardar? Aqui mostra:
                        //Bom ... eu gostaria que esta variável fosse tipo "global", mas como fazer isto com várias camadas (projetos)?
                        //Quem souber pode me falar... burlei um pouco as regras?
                        BDModel.Banco = SistemasBLL.ValidarBancoDados(CboBanco.Text);

                        ClsContaCorrenteBLL obj = new ClsContaCorrenteBLL();
                        obj.Excluir(ClsCCDomain, BDModel);

                        MessageBox.Show("O registro foi excluido com sucesso!", "OKAY!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        AtualizaGrid(strContaCorrente);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
            }
        }

        /// <summary>
        /// Filtra a grade para que só apareço o que está no filtro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFiltro_Click(object sender, EventArgs e)
        {
            //Em qual banco de dados devo guardar? Aqui mostra:
            //Bom ... eu gostaria que esta variável fosse tipo "global", mas como fazer isto com várias camadas (projetos)?
            //Quem souber pode me falar... burlei um pouco as regras?
            BDModel.Banco = SistemasBLL.ValidarBancoDados(CboBanco.Text);

            // Comunicação com a Camada BLL
            ClsContaCorrenteBLL obj = new ClsContaCorrenteBLL();
            DgvContaCorrente.DataSource = obj.Listagem(TxtFiltro.Text, BDModel);

            // Atualizando os objetos TextBox
            if (DgvContaCorrente.RowCount > 0)
            {
                try
                {
                    AtualizaTela();
                }
                catch
                {
                    FormBLL.EmptyTextBoxes(this, TxtContaCorrente);
                }
            }
        }

        /// <summary>
        /// Recalcular a grade
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRecalcular_Click(object sender, EventArgs e)
        {
            // Comunicação com a Camada BLL
            ClsContaCorrenteBLL obj = new ClsContaCorrenteBLL();
            bool atualiza = false;

            if (DgvContaCorrente.RowCount > 0)
            {
                //DgvContaCorrente.Rows.Clear();

                atualiza = obj.AtualizaValorContaCorrente(BDModel);

                DgvContaCorrente.DataSource = obj.Listagem(TxtFiltro.Text, BDModel);

                // Atualizando os objetos TextBox
                if (atualiza)
                {
                    try
                    {
                        AtualizaTela();
                    }
                    catch
                    {
                        FormBLL.EmptyTextBoxes(this, TxtContaCorrente);
                    }

                }
            }
        }

        /// <summary>
        /// Abre o formulário de ajuda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAjuda_Click(object sender, EventArgs e)
        {
            FrmAjuda obj = new FrmAjuda();
            obj.Show();
        }

        #endregion

        #region OBJETOS

        /// <summary>
        /// Seleciona um banco de dados para trabalhar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CboBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnFiltro_Click(sender, e);
        }

        /// <summary>
        /// Ao clicar em um campo da grid, atualiza os campos da tela.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvContaCorrente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AtualizaTela();
            TxtValorAtual_Leave(sender, e);
        }

        /// <summary>
        /// Ao clicar em um campo da grid, atualiza os campos da tela.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvContaCorrente_KeyUp(object sender, KeyEventArgs e)
        {
            AtualizaTela();
            TxtValorAtual_Leave(sender, e);
        }

        /// <summary>
        /// Ao pressionar uma tecla, é necessário garantir que só receberá números e backspace.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtContaCorrente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !(Convert.ToInt32(e.KeyChar) == Convert.ToInt32(Keys.Back))) e.Handled = true;
        }

        /// <summary>
        /// Ao pressionar uma tecla, é necessário garantir que só receberá números e backspace.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MtxValorAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !(Convert.ToInt32(e.KeyChar) == Convert.ToInt32(Keys.Back))) e.Handled = true;
        }

        /// <summary>
        /// Ao pressionar uma tecla, é necessário garantir que só receberá números e backspace.
        /// No caso de uma "Currency" é uma combinação de KeyPress + Leave + KeyUp.
        /// ----------------------------------------
        /// MaskedTextBox Currency Input Mask Limits
        /// https://stackoverflow.com/questions/30881539/maskedtextbox-currency-input-mask-limits
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtValorAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',')
                    e.Handled = (TxtValorAtual.Text.Contains(","));
                else
                    e.Handled = true;
            }
        }

        /// <summary>
        /// Ao pressionar uma tecla, é necessário garantir que só receberá números e backspace.
        /// No caso de uma "Currency" é uma combinação de KeyPress + Leave + KeyUp.
        /// ----------------------------------------
        /// MaskedTextBox Currency Input Mask Limits
        /// https://stackoverflow.com/questions/30881539/maskedtextbox-currency-input-mask-limits
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtValorAtual_Leave(object sender, EventArgs e)
        {
            string valor;

            valor = TxtValorAtual.Text.Replace("R$", "");

            if (valor != "")
                TxtValorAtual.Text = string.Format("{0:C}", Convert.ToDouble(valor));
        }

        /// <summary>
        /// Ao pressionar uma tecla, é necessário garantir que só receberá números e backspace.
        /// No caso de uma "Currency" é uma combinação de KeyPress + Leave + KeyUp.
        /// ----------------------------------------
        /// MaskedTextBox Currency Input Mask Limits
        /// https://stackoverflow.com/questions/30881539/maskedtextbox-currency-input-mask-limits
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtValorAtual_KeyUp(object sender, KeyEventArgs e)
        {
            string valor;

            valor = TxtValorAtual.Text.Replace("R$", "").Replace(",", "").Replace(" ", "").Replace("00,", "");
            if (valor.Length == 0)
                TxtValorAtual.Text = "0,00" + valor;

            if (valor.Length == 1)
                TxtValorAtual.Text = "0,0" + valor;

            if (valor.Length == 2)
                TxtValorAtual.Text = "0," + valor;
            else if (valor.Length >= 3)
            {
                if (TxtValorAtual.Text.StartsWith("0,"))
                    TxtValorAtual.Text = valor.Insert(valor.Length - 2, ",").Replace("0,", "");
                else if (TxtValorAtual.Text.Contains("00,"))
                    TxtValorAtual.Text = valor.Insert(valor.Length - 2, ",").Replace("00,", "");
                else
                    TxtValorAtual.Text = valor.Insert(valor.Length - 2, ",");
            }

            valor = TxtValorAtual.Text;
            TxtValorAtual.Text = string.Format("{0:C}", Convert.ToDouble(valor));
            TxtValorAtual.Select(TxtValorAtual.Text.Length, 0);
        }

        #endregion

        #region EXTRAS

        /// <summary>
        /// Faz o gereneciamento do botões da tela.
        /// </summary>
        /// <param name="bytBotoes"></param>
        public void AcertaBotoes(byte bytBotoes)
        {
            //Abaixo um ajuste de tela para todas as telas que tem o mesmo padrão!
            FormBLL.AjustaBotoes(this, bytBotoes);

            //2019/02/05 - Fabio I. - Retirar o "ALTERAR", mas manter o "CANCELAR"
            if (BtnAlterar.Text == "&Alterar")
                BtnAlterar.Visible = false;
            else
                BtnAlterar.Visible = true;

            switch (bytBotoes)
            {
                //1 - Entrada de dados
                case 1:
                    TxtContaCorrente.ReadOnly = false;
                    TxtValorAtual.ReadOnly = false;
                    TxtContaCorrente.ForeColor = Color.Navy;
                    TxtValorAtual.ForeColor = Color.Navy;
                    break;

                //2 - Existe algo cadastrado (o mesmo que o 3 neste caso)
                case 2:
                //3 - Não existe nada cadastrado
                case 3:
                    TxtContaCorrente.ReadOnly = true;
                    TxtValorAtual.ReadOnly = true;
                    break;
            }
        }

        /// <summary>
        /// Atualiza a grid.
        /// </summary>
        /// <param name="ContaCorrente"></param>
        private void AtualizaGrid(string ContaCorrente)
        {
            //comunicação com a camada BLL
            ClsContaCorrenteBLL obj = new ClsContaCorrenteBLL();

            DgvContaCorrente.DataSource = obj.Listagem(TxtFiltro.Text, BDModel);
            DgvContaCorrente.Columns[0].Width = 50;

            //Atualizando os objetos TextBox
            try
            {
                AtualizaTela();
            }
            catch
            {
                BtnLimpar_Click(null, null);
            }

            //Pesquisar dentro da grid onde está o "ContaCorrente"
            if (ContaCorrente != "")
            {
                for (int i = 0; i < DgvContaCorrente.Rows.Count; i++)
                {
                    if (ContaCorrente == DgvContaCorrente[0, i].Value.ToString())
                    {
                        //faz a célula atual e seleciona a linha
                        DgvContaCorrente.ClearSelection();
                        DgvContaCorrente.CurrentCell = DgvContaCorrente.Rows[i].Cells[0];
                        DgvContaCorrente.Rows[i].Selected = true;
                        //Preenche os dados das textbox
                        DgvContaCorrente_CellClick(null, null);

                        break;
                    }
                }
            }
            
            if (DgvContaCorrente.Rows.Count == 0)
            {
                BtnLimpar_Click(null, null);
                AcertaBotoes(3);
                TxtContaCorrente.Text = "";
                BtnIncluir.Focus();
            }
        }

        /// <summary>
        /// Atualiza dados da tela.
        /// </summary>
        private void AtualizaTela()
        {
            if (DgvContaCorrente.CurrentRow != null)
            {
                TxtContaCorrente.Text = DgvContaCorrente[0, DgvContaCorrente.CurrentRow.Index].Value.ToString();
                TxtValorAtual.Text = DgvContaCorrente[1, DgvContaCorrente.CurrentRow.Index].Value.ToString();

                AtualizaValorAtual();
            }
        }

        private void AtualizaValorAtual()
        {
            double valorAtual;
            double valorDolar;

            if (!( string.IsNullOrEmpty(TxtValorAtual.Text) || string.IsNullOrEmpty(TxtValorDolar.Text) ))
            {
                valorAtual = double.Parse(TxtValorAtual.Text.Replace("R$", ""));
                valorDolar = double.Parse(TxtValorDolar.Text.Replace("R$", ""));

                string temp = (valorAtual / valorDolar).ToString();
                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
                TxtValorAtualDolar.Text = "US" + Decimal.Parse(temp).ToString("C", culture);
            }
        }

        /// <summary>
        /// Busca valor do Dólar Comercial no site escolhido
        /// </summary>
        /// <returns>Retorna valor do Dólar Comecial no site escolhido</returns>
        private string BuscaDolarComercial()
        {
            //return ClsConversaoBLL.RetornaDolarComercialBancoCentralDoBrasilWR(0);
            //return ClsConversaoBLL.RetornaDolarComercialBancoCentralDoBrasilCS(0);
            //return ClsConversaoBLL.RetornaDolarComercialCalculeNet();
            //return ClsConversaoBLL.RetornaDolarComercialDolarHoje();
            //return ClsConversaoBLL.RetornaDolarComercialInfoMoney();
            //return ClsConversaoBLL.RetornaDolarComercialTheMoneyConverter();
            //return ClsConversaoBLL.RetornaDolarComercialToroInvestimentos();
            return ClsConversaoBLL.RetornaDolarComercialUOL();
        }

        /// <summary>
        /// Timer de atualização do campo do Valor Comercial do Dólar da UOL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmrDolarComercial_Tick(object sender, EventArgs e)
        {
            TxtValorDolar.Text = BuscaDolarComercial();

            AtualizaValorAtual();
        }

        #endregion

    }
}
