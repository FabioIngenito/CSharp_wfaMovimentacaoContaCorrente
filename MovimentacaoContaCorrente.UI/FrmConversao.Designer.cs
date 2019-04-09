namespace MovimentacaoContaCorrente.UI
{
    partial class FrmConversao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Timer TmrDolarComercialUOL;
            this.LblContaCorrente = new System.Windows.Forms.Label();
            this.TxtContaCorrente = new System.Windows.Forms.TextBox();
            this.txtSaldoAtualReais = new System.Windows.Forms.TextBox();
            this.txtSaldoAtualDolarCom = new System.Windows.Forms.TextBox();
            this.lblSaldoAtualReais = new System.Windows.Forms.Label();
            this.lblSaldoAtualDolarCom = new System.Windows.Forms.Label();
            this.BtnPesquisar = new System.Windows.Forms.Button();
            this.lblValorDolar = new System.Windows.Forms.Label();
            this.TxtValorDolar = new System.Windows.Forms.TextBox();
            this.CboBanco = new System.Windows.Forms.ComboBox();
            this.gbxBuscaDolarComercial = new System.Windows.Forms.GroupBox();
            this.BtnBuscaDolarComercialToroRadar = new System.Windows.Forms.Button();
            this.BtnBuscaDolarComercialToroInvestimentos = new System.Windows.Forms.Button();
            this.BtnBuscaDolarComercialCalculeNet = new System.Windows.Forms.Button();
            this.BtnBuscaDolarComercialValorEconomico = new System.Windows.Forms.Button();
            this.BtnBuscaDolarComercialInfoMoney = new System.Windows.Forms.Button();
            this.BtnBuscaDolarComercialDolarHoje = new System.Windows.Forms.Button();
            this.BtnBuscaDolarComercialTheMoneyConverter = new System.Windows.Forms.Button();
            this.BtnBuscaDolarComercialUOL = new System.Windows.Forms.Button();
            this.BtnBuscaDolarComercialBancoCentralDoBrasilWR = new System.Windows.Forms.Button();
            this.BtnBuscaDolarComercialBancoCentralDoBrasilCS = new System.Windows.Forms.Button();
            TmrDolarComercialUOL = new System.Windows.Forms.Timer(this.components);
            this.gbxBuscaDolarComercial.SuspendLayout();
            this.SuspendLayout();
            // 
            // TmrDolarComercialUOL
            // 
            TmrDolarComercialUOL.Interval = 120000;
            TmrDolarComercialUOL.Tick += new System.EventHandler(this.TmrDolarComercialUOL_Tick);
            // 
            // LblContaCorrente
            // 
            this.LblContaCorrente.AutoSize = true;
            this.LblContaCorrente.Location = new System.Drawing.Point(13, 42);
            this.LblContaCorrente.Name = "LblContaCorrente";
            this.LblContaCorrente.Size = new System.Drawing.Size(173, 13);
            this.LblContaCorrente.TabIndex = 2;
            this.LblContaCorrente.Text = "Digite o número da Conta Corrente:";
            // 
            // TxtContaCorrente
            // 
            this.TxtContaCorrente.Location = new System.Drawing.Point(192, 39);
            this.TxtContaCorrente.Name = "TxtContaCorrente";
            this.TxtContaCorrente.Size = new System.Drawing.Size(124, 20);
            this.TxtContaCorrente.TabIndex = 3;
            this.TxtContaCorrente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtContaCorrente_KeyPress);
            // 
            // txtSaldoAtualReais
            // 
            this.txtSaldoAtualReais.Location = new System.Drawing.Point(192, 65);
            this.txtSaldoAtualReais.Name = "txtSaldoAtualReais";
            this.txtSaldoAtualReais.ReadOnly = true;
            this.txtSaldoAtualReais.Size = new System.Drawing.Size(124, 20);
            this.txtSaldoAtualReais.TabIndex = 5;
            // 
            // txtSaldoAtualDolarCom
            // 
            this.txtSaldoAtualDolarCom.Location = new System.Drawing.Point(192, 91);
            this.txtSaldoAtualDolarCom.Name = "txtSaldoAtualDolarCom";
            this.txtSaldoAtualDolarCom.ReadOnly = true;
            this.txtSaldoAtualDolarCom.Size = new System.Drawing.Size(124, 20);
            this.txtSaldoAtualDolarCom.TabIndex = 7;
            // 
            // lblSaldoAtualReais
            // 
            this.lblSaldoAtualReais.AutoSize = true;
            this.lblSaldoAtualReais.Location = new System.Drawing.Point(13, 68);
            this.lblSaldoAtualReais.Name = "lblSaldoAtualReais";
            this.lblSaldoAtualReais.Size = new System.Drawing.Size(111, 13);
            this.lblSaldoAtualReais.TabIndex = 4;
            this.lblSaldoAtualReais.Text = "Saldo Atual em Reais:";
            // 
            // lblSaldoAtualDolarCom
            // 
            this.lblSaldoAtualDolarCom.AutoSize = true;
            this.lblSaldoAtualDolarCom.Location = new System.Drawing.Point(13, 94);
            this.lblSaldoAtualDolarCom.Name = "lblSaldoAtualDolarCom";
            this.lblSaldoAtualDolarCom.Size = new System.Drawing.Size(158, 13);
            this.lblSaldoAtualDolarCom.TabIndex = 6;
            this.lblSaldoAtualDolarCom.Text = "Saldo Atual em Dólar Comercial:";
            // 
            // BtnPesquisar
            // 
            this.BtnPesquisar.Location = new System.Drawing.Point(340, 37);
            this.BtnPesquisar.Name = "BtnPesquisar";
            this.BtnPesquisar.Size = new System.Drawing.Size(212, 74);
            this.BtnPesquisar.TabIndex = 8;
            this.BtnPesquisar.Text = "Pesquisar &Conta Corrente";
            this.BtnPesquisar.UseVisualStyleBackColor = true;
            this.BtnPesquisar.Click += new System.EventHandler(this.BtnPesquisar_Click);
            // 
            // lblValorDolar
            // 
            this.lblValorDolar.AutoSize = true;
            this.lblValorDolar.Location = new System.Drawing.Point(13, 19);
            this.lblValorDolar.Name = "lblValorDolar";
            this.lblValorDolar.Size = new System.Drawing.Size(77, 13);
            this.lblValorDolar.TabIndex = 0;
            this.lblValorDolar.Text = "Valor do Dólar:";
            // 
            // TxtValorDolar
            // 
            this.TxtValorDolar.Location = new System.Drawing.Point(192, 12);
            this.TxtValorDolar.Name = "TxtValorDolar";
            this.TxtValorDolar.ReadOnly = true;
            this.TxtValorDolar.Size = new System.Drawing.Size(124, 20);
            this.TxtValorDolar.TabIndex = 1;
            // 
            // CboBanco
            // 
            this.CboBanco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CboBanco.FormattingEnabled = true;
            this.CboBanco.Items.AddRange(new object[] {
            "Access",
            "SQL Server"});
            this.CboBanco.Location = new System.Drawing.Point(431, 10);
            this.CboBanco.Name = "CboBanco";
            this.CboBanco.Size = new System.Drawing.Size(121, 21);
            this.CboBanco.TabIndex = 9;
            this.CboBanco.Text = "Access";
            // 
            // gbxBuscaDolarComercial
            // 
            this.gbxBuscaDolarComercial.Controls.Add(this.BtnBuscaDolarComercialToroRadar);
            this.gbxBuscaDolarComercial.Controls.Add(this.BtnBuscaDolarComercialToroInvestimentos);
            this.gbxBuscaDolarComercial.Controls.Add(this.BtnBuscaDolarComercialCalculeNet);
            this.gbxBuscaDolarComercial.Controls.Add(this.BtnBuscaDolarComercialValorEconomico);
            this.gbxBuscaDolarComercial.Controls.Add(this.BtnBuscaDolarComercialInfoMoney);
            this.gbxBuscaDolarComercial.Controls.Add(this.BtnBuscaDolarComercialDolarHoje);
            this.gbxBuscaDolarComercial.Controls.Add(this.BtnBuscaDolarComercialTheMoneyConverter);
            this.gbxBuscaDolarComercial.Controls.Add(this.BtnBuscaDolarComercialUOL);
            this.gbxBuscaDolarComercial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxBuscaDolarComercial.Location = new System.Drawing.Point(16, 117);
            this.gbxBuscaDolarComercial.Name = "gbxBuscaDolarComercial";
            this.gbxBuscaDolarComercial.Size = new System.Drawing.Size(536, 88);
            this.gbxBuscaDolarComercial.TabIndex = 17;
            this.gbxBuscaDolarComercial.TabStop = false;
            this.gbxBuscaDolarComercial.Text = "Busca Dólar Comercial";
            // 
            // BtnBuscaDolarComercialToroRadar
            // 
            this.BtnBuscaDolarComercialToroRadar.Enabled = false;
            this.BtnBuscaDolarComercialToroRadar.Location = new System.Drawing.Point(401, 50);
            this.BtnBuscaDolarComercialToroRadar.Name = "BtnBuscaDolarComercialToroRadar";
            this.BtnBuscaDolarComercialToroRadar.Size = new System.Drawing.Size(125, 25);
            this.BtnBuscaDolarComercialToroRadar.TabIndex = 19;
            this.BtnBuscaDolarComercialToroRadar.Text = "Toro &Radar";
            this.BtnBuscaDolarComercialToroRadar.UseVisualStyleBackColor = true;
            this.BtnBuscaDolarComercialToroRadar.Click += new System.EventHandler(this.BtnBuscaDolarComercialToroRadar_Click);
            // 
            // BtnBuscaDolarComercialToroInvestimentos
            // 
            this.BtnBuscaDolarComercialToroInvestimentos.Enabled = false;
            this.BtnBuscaDolarComercialToroInvestimentos.Location = new System.Drawing.Point(270, 50);
            this.BtnBuscaDolarComercialToroInvestimentos.Name = "BtnBuscaDolarComercialToroInvestimentos";
            this.BtnBuscaDolarComercialToroInvestimentos.Size = new System.Drawing.Size(125, 25);
            this.BtnBuscaDolarComercialToroInvestimentos.TabIndex = 18;
            this.BtnBuscaDolarComercialToroInvestimentos.Text = "&Toro Investimentos";
            this.BtnBuscaDolarComercialToroInvestimentos.UseVisualStyleBackColor = true;
            this.BtnBuscaDolarComercialToroInvestimentos.Click += new System.EventHandler(this.BtnBuscaDolarComercialToroInvestimentos_Click);
            // 
            // BtnBuscaDolarComercialCalculeNet
            // 
            this.BtnBuscaDolarComercialCalculeNet.Location = new System.Drawing.Point(139, 50);
            this.BtnBuscaDolarComercialCalculeNet.Name = "BtnBuscaDolarComercialCalculeNet";
            this.BtnBuscaDolarComercialCalculeNet.Size = new System.Drawing.Size(125, 25);
            this.BtnBuscaDolarComercialCalculeNet.TabIndex = 17;
            this.BtnBuscaDolarComercialCalculeNet.Text = "&Calcule Net";
            this.BtnBuscaDolarComercialCalculeNet.UseVisualStyleBackColor = true;
            this.BtnBuscaDolarComercialCalculeNet.Click += new System.EventHandler(this.BtnBuscaDolarComercialCalculeNet_Click);
            // 
            // BtnBuscaDolarComercialValorEconomico
            // 
            this.BtnBuscaDolarComercialValorEconomico.Location = new System.Drawing.Point(8, 50);
            this.BtnBuscaDolarComercialValorEconomico.Name = "BtnBuscaDolarComercialValorEconomico";
            this.BtnBuscaDolarComercialValorEconomico.Size = new System.Drawing.Size(125, 25);
            this.BtnBuscaDolarComercialValorEconomico.TabIndex = 15;
            this.BtnBuscaDolarComercialValorEconomico.Text = "&Valor Econômico";
            this.BtnBuscaDolarComercialValorEconomico.UseVisualStyleBackColor = true;
            this.BtnBuscaDolarComercialValorEconomico.Click += new System.EventHandler(this.BtnBuscaDolarComercialValorEconomico_Click);
            // 
            // BtnBuscaDolarComercialInfoMoney
            // 
            this.BtnBuscaDolarComercialInfoMoney.Location = new System.Drawing.Point(401, 19);
            this.BtnBuscaDolarComercialInfoMoney.Name = "BtnBuscaDolarComercialInfoMoney";
            this.BtnBuscaDolarComercialInfoMoney.Size = new System.Drawing.Size(125, 25);
            this.BtnBuscaDolarComercialInfoMoney.TabIndex = 14;
            this.BtnBuscaDolarComercialInfoMoney.Text = "&InfoMoney";
            this.BtnBuscaDolarComercialInfoMoney.UseVisualStyleBackColor = true;
            this.BtnBuscaDolarComercialInfoMoney.Click += new System.EventHandler(this.BtnBuscaDolarComercialInfoMoney_Click);
            // 
            // BtnBuscaDolarComercialDolarHoje
            // 
            this.BtnBuscaDolarComercialDolarHoje.Location = new System.Drawing.Point(270, 19);
            this.BtnBuscaDolarComercialDolarHoje.Name = "BtnBuscaDolarComercialDolarHoje";
            this.BtnBuscaDolarComercialDolarHoje.Size = new System.Drawing.Size(125, 25);
            this.BtnBuscaDolarComercialDolarHoje.TabIndex = 13;
            this.BtnBuscaDolarComercialDolarHoje.Text = "&Dólar Hoje";
            this.BtnBuscaDolarComercialDolarHoje.UseVisualStyleBackColor = true;
            this.BtnBuscaDolarComercialDolarHoje.Click += new System.EventHandler(this.BtnBuscaDolarComercialDolarHoje_Click);
            // 
            // BtnBuscaDolarComercialTheMoneyConverter
            // 
            this.BtnBuscaDolarComercialTheMoneyConverter.Location = new System.Drawing.Point(139, 19);
            this.BtnBuscaDolarComercialTheMoneyConverter.Name = "BtnBuscaDolarComercialTheMoneyConverter";
            this.BtnBuscaDolarComercialTheMoneyConverter.Size = new System.Drawing.Size(125, 25);
            this.BtnBuscaDolarComercialTheMoneyConverter.TabIndex = 12;
            this.BtnBuscaDolarComercialTheMoneyConverter.Text = "&The Money Converter";
            this.BtnBuscaDolarComercialTheMoneyConverter.UseVisualStyleBackColor = true;
            this.BtnBuscaDolarComercialTheMoneyConverter.Click += new System.EventHandler(this.BtnBuscaDolarComercialTheMoneyConverter_Click);
            // 
            // BtnBuscaDolarComercialUOL
            // 
            this.BtnBuscaDolarComercialUOL.Enabled = false;
            this.BtnBuscaDolarComercialUOL.Location = new System.Drawing.Point(8, 19);
            this.BtnBuscaDolarComercialUOL.Name = "BtnBuscaDolarComercialUOL";
            this.BtnBuscaDolarComercialUOL.Size = new System.Drawing.Size(125, 25);
            this.BtnBuscaDolarComercialUOL.TabIndex = 11;
            this.BtnBuscaDolarComercialUOL.Text = "&UOL";
            this.BtnBuscaDolarComercialUOL.UseVisualStyleBackColor = true;
            this.BtnBuscaDolarComercialUOL.Click += new System.EventHandler(this.BtnBuscaDolarComercialUOL_Click);
            // 
            // BtnBuscaDolarComercialBancoCentralDoBrasilWR
            // 
            this.BtnBuscaDolarComercialBancoCentralDoBrasilWR.Location = new System.Drawing.Point(24, 223);
            this.BtnBuscaDolarComercialBancoCentralDoBrasilWR.Name = "BtnBuscaDolarComercialBancoCentralDoBrasilWR";
            this.BtnBuscaDolarComercialBancoCentralDoBrasilWR.Size = new System.Drawing.Size(256, 25);
            this.BtnBuscaDolarComercialBancoCentralDoBrasilWR.TabIndex = 18;
            this.BtnBuscaDolarComercialBancoCentralDoBrasilWR.Text = "&Banco Central do Brasil - Web References";
            this.BtnBuscaDolarComercialBancoCentralDoBrasilWR.UseVisualStyleBackColor = true;
            this.BtnBuscaDolarComercialBancoCentralDoBrasilWR.Click += new System.EventHandler(this.BtnBuscaDolarComercialBancoCentralDoBrasilWR_Click);
            // 
            // BtnBuscaDolarComercialBancoCentralDoBrasilCS
            // 
            this.BtnBuscaDolarComercialBancoCentralDoBrasilCS.Location = new System.Drawing.Point(286, 223);
            this.BtnBuscaDolarComercialBancoCentralDoBrasilCS.Name = "BtnBuscaDolarComercialBancoCentralDoBrasilCS";
            this.BtnBuscaDolarComercialBancoCentralDoBrasilCS.Size = new System.Drawing.Size(256, 25);
            this.BtnBuscaDolarComercialBancoCentralDoBrasilCS.TabIndex = 19;
            this.BtnBuscaDolarComercialBancoCentralDoBrasilCS.Text = "&Banco Central do Brasil - Connected Services";
            this.BtnBuscaDolarComercialBancoCentralDoBrasilCS.UseVisualStyleBackColor = true;
            this.BtnBuscaDolarComercialBancoCentralDoBrasilCS.Click += new System.EventHandler(this.BtnBuscaDolarComercialBancoCentralDoBrasilCS_Click);
            // 
            // FrmConversao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 260);
            this.Controls.Add(this.BtnBuscaDolarComercialBancoCentralDoBrasilCS);
            this.Controls.Add(this.BtnBuscaDolarComercialBancoCentralDoBrasilWR);
            this.Controls.Add(this.gbxBuscaDolarComercial);
            this.Controls.Add(this.CboBanco);
            this.Controls.Add(this.TxtValorDolar);
            this.Controls.Add(this.lblValorDolar);
            this.Controls.Add(this.BtnPesquisar);
            this.Controls.Add(this.lblSaldoAtualDolarCom);
            this.Controls.Add(this.lblSaldoAtualReais);
            this.Controls.Add(this.txtSaldoAtualDolarCom);
            this.Controls.Add(this.txtSaldoAtualReais);
            this.Controls.Add(this.TxtContaCorrente);
            this.Controls.Add(this.LblContaCorrente);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConversao";
            this.ShowIcon = false;
            this.Text = "Conversão";
            this.Load += new System.EventHandler(this.FrmConversao_Load);
            this.gbxBuscaDolarComercial.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblContaCorrente;
        private System.Windows.Forms.TextBox TxtContaCorrente;
        private System.Windows.Forms.TextBox txtSaldoAtualReais;
        private System.Windows.Forms.TextBox txtSaldoAtualDolarCom;
        private System.Windows.Forms.Label lblSaldoAtualReais;
        private System.Windows.Forms.Label lblSaldoAtualDolarCom;
        private System.Windows.Forms.Button BtnPesquisar;
        private System.Windows.Forms.Label lblValorDolar;
        private System.Windows.Forms.TextBox TxtValorDolar;
        private System.Windows.Forms.ComboBox CboBanco;
        private System.Windows.Forms.GroupBox gbxBuscaDolarComercial;
        private System.Windows.Forms.Button BtnBuscaDolarComercialCalculeNet;
        private System.Windows.Forms.Button BtnBuscaDolarComercialValorEconomico;
        private System.Windows.Forms.Button BtnBuscaDolarComercialInfoMoney;
        private System.Windows.Forms.Button BtnBuscaDolarComercialDolarHoje;
        private System.Windows.Forms.Button BtnBuscaDolarComercialTheMoneyConverter;
        private System.Windows.Forms.Button BtnBuscaDolarComercialUOL;
        private System.Windows.Forms.Button BtnBuscaDolarComercialToroInvestimentos;
        private System.Windows.Forms.Button BtnBuscaDolarComercialToroRadar;
        private System.Windows.Forms.Button BtnBuscaDolarComercialBancoCentralDoBrasilWR;
        private System.Windows.Forms.Button BtnBuscaDolarComercialBancoCentralDoBrasilCS;
    }
}