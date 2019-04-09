using MovimentacaoContaCorrente.BLL;
using MovimentacaoContaCorrente.DOMAIN;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace MovimentacaoContaCorrente.UI
{
    public partial class FrmConversao : Form
    {
        ClsBDDomain BDModel = new ClsBDDomain();
        ClsSistemaBLL SistemasBLL = new ClsSistemaBLL();
        ClsMovimentacaoBLL MovimentacaoBLL = new ClsMovimentacaoBLL();

        public FrmConversao()
        {
            InitializeComponent();
        }

        private void FrmConversao_Load(object sender, EventArgs e)
        {
            TxtValorDolar.Text = ClsConversaoBLL.RetornaDolarComercialTheMoneyConverter();
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            int CC = 0;
            double valorAtual;
            double valorDolar;

            txtSaldoAtualReais.Text = "";
            txtSaldoAtualDolarCom.Text = "";

            try
            {
                if (TxtContaCorrente.Text != string.Empty && TxtValorDolar.Text != string.Empty)
                {
                    //Em qual banco de dados devo guardar? Aqui mostra:
                    //Bom ... eu gostaria que esta variável fosse tipo "global", mas como fazer isto com várias camadas (projetos)?
                    //Quem souber pode me falar... burlei um pouco as regras?
                    BDModel.Banco = SistemasBLL.ValidarBancoDados(CboBanco.Text);

                    CC = Convert.ToInt32(TxtContaCorrente.Text);

                    valorAtual = MovimentacaoBLL.SomaValores(CC, BDModel);

                    txtSaldoAtualReais.Text = String.Format("{0:C2}", valorAtual);

                    valorDolar = double.Parse(TxtValorDolar.Text.Replace("R$", ""));

                    string temp = (valorAtual / valorDolar).ToString();
                    CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
                    txtSaldoAtualDolarCom.Text = "US" + Decimal.Parse(temp).ToString("C", culture);
                }
                else
                {
                    MessageBox.Show("Obrigatório preencher a Conta Corrente.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void TxtContaCorrente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !(Convert.ToInt32(e.KeyChar) == Convert.ToInt32(Keys.Back))) e.Handled = true;
        }

        private void TmrDolarComercialUOL_Tick(object sender, EventArgs e)
        {
            TxtValorDolar.Text = ClsConversaoBLL.RetornaDolarComercialUOL();
        }

        private void LimpaTextos()
        {
            txtSaldoAtualReais.Text = "";
            txtSaldoAtualDolarCom.Text = "";
        }

        #region Botões de Busca Dólar Comercial

        private void BtnBuscaDolarComercialUOL_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                TxtValorDolar.Text = ClsConversaoBLL.RetornaDolarComercialUOL();
                LimpaTextos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnBuscaDolarComercialTheMoneyConverter_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                TxtValorDolar.Text = ClsConversaoBLL.RetornaDolarComercialTheMoneyConverter();
                LimpaTextos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnBuscaDolarComercialDolarHoje_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                TxtValorDolar.Text = ClsConversaoBLL.RetornaDolarComercialDolarHoje();
                LimpaTextos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnBuscaDolarComercialInfoMoney_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                TxtValorDolar.Text = ClsConversaoBLL.RetornaDolarComercialInfoMoney();
                LimpaTextos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnBuscaDolarComercialMelhorCambio_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                TxtValorDolar.Text = ClsConversaoBLL.RetornaDolarComercialInfoMoney();
                LimpaTextos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnBuscaDolarComercialValorEconomico_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                TxtValorDolar.Text = ClsConversaoBLL.RetornaDolarComercialValorEconomico();
                LimpaTextos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnBuscaDolarComercialCalculeNet_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                TxtValorDolar.Text = ClsConversaoBLL.RetornaDolarComercialCalculeNet();
                LimpaTextos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnBuscaDolarComercialToroInvestimentos_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                TxtValorDolar.Text = ClsConversaoBLL.RetornaDolarComercialToroInvestimentos();
                LimpaTextos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnBuscaDolarComercialToroRadar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                TxtValorDolar.Text = ClsConversaoBLL.RetornaDolarComercialToroRadar();
                LimpaTextos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Banco Central do Brasil

        private void BtnBuscaDolarComercialBancoCentralDoBrasilWR_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                //Web References
                TxtValorDolar.Text = ClsConversaoBLL.RetornaDolarComercialBancoCentralDoBrasilWR(10813);

                LimpaTextos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnBuscaDolarComercialBancoCentralDoBrasilCS_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                //Connect Services
                TxtValorDolar.Text = ClsConversaoBLL.RetornaDolarComercialBancoCentralDoBrasilCS(10813);

                LimpaTextos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion
    }
}
