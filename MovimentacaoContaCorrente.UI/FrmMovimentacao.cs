using MovimentacaoContaCorrente.BLL;
using MovimentacaoContaCorrente.DOMAIN;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MovimentacaoContaCorrente.UI
{
    public partial class FrmMovimentacao : Form
    {
        ClsBDDomain BDModel = new ClsBDDomain();
        ClsSistemaBLL SistemasBLL = new ClsSistemaBLL();
        ClsMovimentacaoBLL ContaCorrenteBLL = new ClsMovimentacaoBLL();
        ClsFormularioBLL FormBLL = new ClsFormularioBLL();
        public string strMovimentacao = "";

        public FrmMovimentacao()
        {
            InitializeComponent();
        }

        private void FrmMovimentacao_Load(object sender, EventArgs e)
        {
            BDModel.Banco = SistemasBLL.ValidarBancoDados(CboBanco.Text);
            AtualizaGrid(strMovimentacao);
            dtpDataHora.Value = DateTime.Now.ToLocalTime();
        }

        private void FrmMovimentacao_Activated(object sender, EventArgs e)
        {
            if (DgvMovimentacao.CurrentRow == null)
            {
                AcertaBotoes(3);
                BtnIncluir.Focus();
            }
            else
            {
                AcertaBotoes(2);
                TxtValorMovimentacao_Leave(sender, e);
                DgvMovimentacao.Focus();
            }
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
                strMovimentacao = TxtMovimentacao.Text;
                TxtMovimentacao.Text = "";
                BtnIncluir.Tag = "I";
                BtnLimpar_Click(sender, e);
                AcertaBotoes(1);
                TxtMovimentacao.Focus();
            }
            else
            {
                try
                {
                    //Monta uma "estrutura" de Movimentação para passar para classe BLL
                    ClsMovimentacaoDomain ClsMVDomain = new ClsMovimentacaoDomain();
                    ClsMovimentacaoBLL obj = new ClsMovimentacaoBLL();

                    if (TxtMovimentacao.Text.Length > 0)
                        ClsMVDomain.IDMovimentacao = int.Parse(TxtMovimentacao.Text);

                    dtpDataHora.Value = DateTime.Now.ToLocalTime();
                    ClsMVDomain.DataHora = Convert.ToDateTime(dtpDataHora.Value);

                    if (rbCredito.Checked)
                        ClsMVDomain.DebitoCredito = 'C';
                    else
                        ClsMVDomain.DebitoCredito = 'D';

                    if (!(string.IsNullOrEmpty(TxtValorMovimentacao.Text.Trim())))
                        ClsMVDomain.ValorMovimentacao = double.Parse(TxtValorMovimentacao.Text.Replace("R$", ""));

                    if (TxtContaCorrente.Text.Length > 0)
                        ClsMVDomain.IDContaCorrente = int.Parse(TxtContaCorrente.Text);

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
                            strMovimentacao = obj.Incluir(ClsMVDomain, BDModel);
                            MessageBox.Show("A Movimentação foi incluída com sucesso!", "OKAY!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            TxtMovimentacao.Text = Convert.ToString(ClsMVDomain.IDMovimentacao);
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
                            if (TxtMovimentacao.Text.Length == 0)
                                MessageBox.Show("Uma das Movimentações deve ser selecionada para alteração.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            else
                                obj.Alterar(ClsMVDomain, BDModel);
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
                    AtualizaGrid(strMovimentacao);
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
                strMovimentacao = TxtMovimentacao.Text;
                AcertaBotoes(1);
            }
            else
            {
                BtnIncluir.Tag = "";
                AtualizaGrid(strMovimentacao);
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
            FormBLL.EmptyTextBoxes(this, TxtMovimentacao);
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
            resposta = ClsFormularioBLL.InputBox("Digite um número ou um nome, \n se for número pesquisará por Código, \n se for nome, pesquisará por parte do resgistro ", "Pesquisar registro", "");

            if (ClsFormularioBLL.IsNumeric(resposta))
            {
                for (int i = 0; i < DgvMovimentacao.Rows.Count; i++)
                {
                    if (resposta == DgvMovimentacao[0, i].Value.ToString())
                    {
                        //faz a célula atual e seleciona a linha
                        DgvMovimentacao.ClearSelection();
                        DgvMovimentacao.CurrentCell = DgvMovimentacao.Rows[i].Cells[0];
                        DgvMovimentacao.Rows[i].Selected = true;
                        //Preenche os dados das textbox
                        DgvMovimentacao_CellClick(null, null);

                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < DgvMovimentacao.Rows.Count; i++)
                {
                    string conteudo = DgvMovimentacao[1, i].Value.ToString().ToUpper();

                    if (conteudo.IndexOf(resposta.ToUpper()) > -1)
                    {
                        //faz a célula atual e seleciona a linha
                        DgvMovimentacao.ClearSelection();
                        DgvMovimentacao.CurrentCell = DgvMovimentacao.Rows[i].Cells[0];
                        DgvMovimentacao.Rows[i].Selected = true;
                        //Preenche os dados das textbox
                        DgvMovimentacao_CellClick(null, null);

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
                if (TxtMovimentacao.Text.Length == 0)
                {
                    MessageBox.Show("Um registro deve ser selecionado antes da exclusão.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else

                    try
                    {
                        //Monta uma "estrutura" de Movimentação para passar para classe BLL
                        ClsMovimentacaoDomain ClsMVDomain = new ClsMovimentacaoDomain();

                        if (TxtMovimentacao.Text.Length > 0)
                            ClsMVDomain.IDMovimentacao = int.Parse(TxtMovimentacao.Text);

                        dtpDataHora.Value = DateTime.Now.ToLocalTime();
                        ClsMVDomain.DataHora = Convert.ToDateTime(dtpDataHora.Value);

                        if (rbCredito.Checked)
                            ClsMVDomain.DebitoCredito = 'C';
                        else
                            ClsMVDomain.DebitoCredito = 'D';

                        if (!(string.IsNullOrEmpty(TxtValorMovimentacao.Text.Trim())))
                            ClsMVDomain.ValorMovimentacao = double.Parse(TxtValorMovimentacao.Text.Replace("R$", "").Replace("-", ""));

                        if (TxtContaCorrente.Text.Length > 0)
                            ClsMVDomain.IDContaCorrente = int.Parse(TxtContaCorrente.Text);


                        //Em qual banco de dados devo guardar? Aqui mostra:
                        //Bom ... eu gostaria que esta variável fosse tipo "global", mas como fazer isto com várias camadas (projetos)?
                        //Quem souber pode me falar... burlei um pouco as regras?
                        BDModel.Banco = SistemasBLL.ValidarBancoDados(CboBanco.Text);

                        ClsMovimentacaoBLL obj = new ClsMovimentacaoBLL();
                        obj.Excluir(ClsMVDomain, BDModel);

                        MessageBox.Show("O registro foi excluido com sucesso!", "OKAY!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        AtualizaGrid(strMovimentacao);
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
            ClsMovimentacaoBLL obj = new ClsMovimentacaoBLL();
            DgvMovimentacao.DataSource = obj.Listagem(TxtFiltro.Text, BDModel);

            // Atualizando os objetos TextBox
            if (DgvMovimentacao.RowCount > 0)
            {
                try
                {
                    AtualizaTela();
                }
                catch
                {
                    FormBLL.EmptyTextBoxes(this, TxtMovimentacao);
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
        private void DgvMovimentacao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AtualizaTela();
            TxtValorMovimentacao_Leave(sender, e);
        }

        /// <summary>
        /// Ao clicar em um campo da grid, atualiza os campos da tela.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvMovimentacao_KeyUp(object sender, KeyEventArgs e)
        {
            AtualizaTela();
            TxtValorMovimentacao_Leave(sender, e);
        }

        /// <summary>
        /// Ao pressionar uma tecla, é necessário garantir que só receberá números e backspace.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtMovimentacao_KeyPress(object sender, KeyPressEventArgs e)
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
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtContaCorrente_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtValorMovimentacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',')
                    e.Handled = (TxtValorMovimentacao.Text.Contains(","));
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
        private void TxtValorMovimentacao_Leave(object sender, EventArgs e)
        {
            string valor;

            valor = TxtValorMovimentacao.Text.Replace("R$", "");

            if (valor != "")
                TxtValorMovimentacao.Text = string.Format("{0:C}", Convert.ToDouble(valor));

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
        private void TxtValorMovimentacao_KeyUp(object sender, KeyEventArgs e)
        {
            string valor;

            valor = TxtValorMovimentacao.Text.Replace("R$", "").Replace(",", "").Replace(" ", "").Replace("00,", "");

            if (valor.Length == 0)
                TxtValorMovimentacao.Text = "0,00" + valor;

            if (valor.Length == 1)
                TxtValorMovimentacao.Text = "0,0" + valor;

            if (valor.Length == 2)
                TxtValorMovimentacao.Text = "0," + valor;
            else if (valor.Length >= 3)
            {
                if (TxtValorMovimentacao.Text.StartsWith("0,"))
                    TxtValorMovimentacao.Text = valor.Insert(valor.Length - 2, ",").Replace("0,", "");
                else if (TxtValorMovimentacao.Text.Contains("00,"))
                    TxtValorMovimentacao.Text = valor.Insert(valor.Length - 2, ",").Replace("00,", "");
                else
                    TxtValorMovimentacao.Text = valor.Insert(valor.Length - 2, ",");
            }

            valor = TxtValorMovimentacao.Text;
            TxtValorMovimentacao.Text = string.Format("{0:C}", Convert.ToDouble(valor));
            TxtValorMovimentacao.Select(TxtValorMovimentacao.Text.Length, 0);
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
                    TxtMovimentacao.ReadOnly = false;
                    dtpDataHora.Enabled = true;
                    gbxCreditoDebito.Enabled = true;
                    TxtValorMovimentacao.ReadOnly = false;
                    TxtContaCorrente.ReadOnly = false;


                    TxtMovimentacao.ForeColor = Color.Navy;
                    dtpDataHora.CalendarForeColor = Color.Navy;
                    gbxCreditoDebito.ForeColor = Color.Navy;
                    TxtValorMovimentacao.ForeColor = Color.Navy;
                    TxtContaCorrente.ForeColor = Color.Navy;

                    break;

                //2 - Existe algo cadastrado (o mesmo que o 3 neste caso)
                case 2:
                //3 - Não existe nada cadastrado
                case 3:
                    TxtMovimentacao.ReadOnly = true;
                    dtpDataHora.Enabled = true;
                    gbxCreditoDebito.Enabled = true;
                    TxtValorMovimentacao.ReadOnly = true;
                    TxtContaCorrente.ReadOnly = true;
                    break;
            }
        }

        /// <summary>
        /// Atualiza a grid.
        /// </summary>
        /// <param name="Movimentação"></param>
        private void AtualizaGrid(string Movimentacao)
        {
            //comunicação com a camada BLL
            ClsMovimentacaoBLL obj = new ClsMovimentacaoBLL();

            DgvMovimentacao.DataSource = obj.Listagem(TxtFiltro.Text, BDModel);
            DgvMovimentacao.Columns[0].Width = 50;

            //Atualizando os objetos TextBox
            try
            {
                AtualizaTela();
            }
            catch
            {
                BtnLimpar_Click(null, null);
            }

            //Pesquisar dentro da grid onde está o "Movimentação"
            if (Movimentacao != "")
            {
                for (int i = 0; i < DgvMovimentacao.Rows.Count; i++)
                {
                    if (Movimentacao == DgvMovimentacao[0, i].Value.ToString())
                    {
                        //faz a célula atual e seleciona a linha
                        DgvMovimentacao.ClearSelection();
                        DgvMovimentacao.CurrentCell = DgvMovimentacao.Rows[i].Cells[0];
                        DgvMovimentacao.Rows[i].Selected = true;
                        //Preenche os dados das textbox
                        DgvMovimentacao_CellClick(null, null);

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Atualiza dados da tela.
        /// </summary>
        private void AtualizaTela()
        {
            if (DgvMovimentacao.CurrentRow != null)
            {
                TxtMovimentacao.Text = DgvMovimentacao[0, DgvMovimentacao.CurrentRow.Index].Value.ToString();
                dtpDataHora.Text = DgvMovimentacao[1, DgvMovimentacao.CurrentRow.Index].Value.ToString();

                if (DgvMovimentacao[2, DgvMovimentacao.CurrentRow.Index].Value.ToString() == "C")
                    rbCredito.Checked = true;
                else
                    rbDebito.Checked = true;

                TxtValorMovimentacao.Text = DgvMovimentacao[3, DgvMovimentacao.CurrentRow.Index].Value.ToString();
                TxtContaCorrente.Text = DgvMovimentacao[4, DgvMovimentacao.CurrentRow.Index].Value.ToString();
            }
        }

        #endregion
    }
}
