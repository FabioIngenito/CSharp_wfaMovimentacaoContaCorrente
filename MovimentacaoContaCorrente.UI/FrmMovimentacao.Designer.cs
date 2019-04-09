namespace MovimentacaoContaCorrente.UI
{
    partial class FrmMovimentacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMovimentacao));
            this.TxtMovimentacao = new System.Windows.Forms.TextBox();
            this.LblMovimentacao = new System.Windows.Forms.Label();
            this.gbxCreditoDebito = new System.Windows.Forms.GroupBox();
            this.rbDebito = new System.Windows.Forms.RadioButton();
            this.rbCredito = new System.Windows.Forms.RadioButton();
            this.dtpDataHora = new System.Windows.Forms.DateTimePicker();
            this.lblDataHora = new System.Windows.Forms.Label();
            this.BtnAjuda = new System.Windows.Forms.Button();
            this.DgvMovimentacao = new System.Windows.Forms.DataGridView();
            this.BtnFiltro = new System.Windows.Forms.Button();
            this.TxtFiltro = new System.Windows.Forms.TextBox();
            this.BtnPesquisar = new System.Windows.Forms.Button();
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.BtnAlterar = new System.Windows.Forms.Button();
            this.BtnLimpar = new System.Windows.Forms.Button();
            this.TxtContaCorrente = new System.Windows.Forms.TextBox();
            this.LblValorMovimentacao = new System.Windows.Forms.Label();
            this.LblContaCorrente = new System.Windows.Forms.Label();
            this.BtnIncluir = new System.Windows.Forms.Button();
            this.CboBanco = new System.Windows.Forms.ComboBox();
            this.TxtValorMovimentacao = new System.Windows.Forms.TextBox();
            this.gbxCreditoDebito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMovimentacao)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtMovimentacao
            // 
            this.TxtMovimentacao.Enabled = false;
            this.TxtMovimentacao.Location = new System.Drawing.Point(125, 12);
            this.TxtMovimentacao.Name = "TxtMovimentacao";
            this.TxtMovimentacao.ReadOnly = true;
            this.TxtMovimentacao.Size = new System.Drawing.Size(119, 20);
            this.TxtMovimentacao.TabIndex = 1;
            this.TxtMovimentacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMovimentacao_KeyPress);
            // 
            // LblMovimentacao
            // 
            this.LblMovimentacao.AutoSize = true;
            this.LblMovimentacao.Location = new System.Drawing.Point(12, 15);
            this.LblMovimentacao.Name = "LblMovimentacao";
            this.LblMovimentacao.Size = new System.Drawing.Size(80, 13);
            this.LblMovimentacao.TabIndex = 0;
            this.LblMovimentacao.Text = "Movimentação:";
            // 
            // gbxCreditoDebito
            // 
            this.gbxCreditoDebito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxCreditoDebito.Controls.Add(this.rbDebito);
            this.gbxCreditoDebito.Controls.Add(this.rbCredito);
            this.gbxCreditoDebito.Location = new System.Drawing.Point(413, 61);
            this.gbxCreditoDebito.Name = "gbxCreditoDebito";
            this.gbxCreditoDebito.Size = new System.Drawing.Size(139, 32);
            this.gbxCreditoDebito.TabIndex = 9;
            this.gbxCreditoDebito.TabStop = false;
            // 
            // rbDebito
            // 
            this.rbDebito.AutoSize = true;
            this.rbDebito.Location = new System.Drawing.Point(70, 10);
            this.rbDebito.Name = "rbDebito";
            this.rbDebito.Size = new System.Drawing.Size(56, 17);
            this.rbDebito.TabIndex = 11;
            this.rbDebito.Text = "Débito";
            this.rbDebito.UseVisualStyleBackColor = true;
            // 
            // rbCredito
            // 
            this.rbCredito.AutoSize = true;
            this.rbCredito.Checked = true;
            this.rbCredito.Location = new System.Drawing.Point(6, 10);
            this.rbCredito.Name = "rbCredito";
            this.rbCredito.Size = new System.Drawing.Size(58, 17);
            this.rbCredito.TabIndex = 10;
            this.rbCredito.TabStop = true;
            this.rbCredito.Text = "Crédito";
            this.rbCredito.UseVisualStyleBackColor = true;
            // 
            // dtpDataHora
            // 
            this.dtpDataHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDataHora.Checked = false;
            this.dtpDataHora.CustomFormat = "dd/MMMM/yyyy  HH:mm:ss";
            this.dtpDataHora.Enabled = false;
            this.dtpDataHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataHora.Location = new System.Drawing.Point(324, 39);
            this.dtpDataHora.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dtpDataHora.MinDate = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            this.dtpDataHora.Name = "dtpDataHora";
            this.dtpDataHora.Size = new System.Drawing.Size(228, 20);
            this.dtpDataHora.TabIndex = 5;
            this.dtpDataHora.Value = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            // 
            // lblDataHora
            // 
            this.lblDataHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataHora.AutoSize = true;
            this.lblDataHora.Location = new System.Drawing.Point(250, 42);
            this.lblDataHora.Name = "lblDataHora";
            this.lblDataHora.Size = new System.Drawing.Size(68, 13);
            this.lblDataHora.TabIndex = 4;
            this.lblDataHora.Text = "Data e Hora:";
            // 
            // BtnAjuda
            // 
            this.BtnAjuda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAjuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAjuda.Image = ((System.Drawing.Image)(resources.GetObject("BtnAjuda.Image")));
            this.BtnAjuda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAjuda.Location = new System.Drawing.Point(456, 398);
            this.BtnAjuda.Name = "BtnAjuda";
            this.BtnAjuda.Size = new System.Drawing.Size(96, 31);
            this.BtnAjuda.TabIndex = 20;
            this.BtnAjuda.Text = "&Ajuda";
            this.BtnAjuda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAjuda.UseVisualStyleBackColor = true;
            this.BtnAjuda.Click += new System.EventHandler(this.BtnAjuda_Click);
            // 
            // DgvMovimentacao
            // 
            this.DgvMovimentacao.AllowUserToAddRows = false;
            this.DgvMovimentacao.AllowUserToDeleteRows = false;
            this.DgvMovimentacao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvMovimentacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMovimentacao.Location = new System.Drawing.Point(15, 140);
            this.DgvMovimentacao.MultiSelect = false;
            this.DgvMovimentacao.Name = "DgvMovimentacao";
            this.DgvMovimentacao.ReadOnly = true;
            this.DgvMovimentacao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMovimentacao.Size = new System.Drawing.Size(537, 252);
            this.DgvMovimentacao.TabIndex = 12;
            this.DgvMovimentacao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMovimentacao_CellClick);
            this.DgvMovimentacao.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DgvMovimentacao_KeyUp);
            // 
            // BtnFiltro
            // 
            this.BtnFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFiltro.Image = ((System.Drawing.Image)(resources.GetObject("BtnFiltro.Image")));
            this.BtnFiltro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFiltro.Location = new System.Drawing.Point(169, 398);
            this.BtnFiltro.Name = "BtnFiltro";
            this.BtnFiltro.Size = new System.Drawing.Size(96, 31);
            this.BtnFiltro.TabIndex = 19;
            this.BtnFiltro.Text = "&Filtrar";
            this.BtnFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnFiltro.UseVisualStyleBackColor = true;
            this.BtnFiltro.Click += new System.EventHandler(this.BtnFiltro_Click);
            // 
            // TxtFiltro
            // 
            this.TxtFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtFiltro.Location = new System.Drawing.Point(15, 404);
            this.TxtFiltro.Name = "TxtFiltro";
            this.TxtFiltro.Size = new System.Drawing.Size(148, 20);
            this.TxtFiltro.TabIndex = 18;
            // 
            // BtnPesquisar
            // 
            this.BtnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("BtnPesquisar.Image")));
            this.BtnPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPesquisar.Location = new System.Drawing.Point(321, 103);
            this.BtnPesquisar.Name = "BtnPesquisar";
            this.BtnPesquisar.Size = new System.Drawing.Size(96, 31);
            this.BtnPesquisar.TabIndex = 16;
            this.BtnPesquisar.Text = "&Pesquisar";
            this.BtnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPesquisar.UseVisualStyleBackColor = true;
            this.BtnPesquisar.Click += new System.EventHandler(this.BtnPesquisar_Click);
            // 
            // BtnExcluir
            // 
            this.BtnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("BtnExcluir.Image")));
            this.BtnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExcluir.Location = new System.Drawing.Point(456, 103);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.Size = new System.Drawing.Size(96, 31);
            this.BtnExcluir.TabIndex = 17;
            this.BtnExcluir.Text = "&Excluir";
            this.BtnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExcluir.UseVisualStyleBackColor = true;
            this.BtnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // BtnAlterar
            // 
            this.BtnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("BtnAlterar.Image")));
            this.BtnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAlterar.Location = new System.Drawing.Point(117, 103);
            this.BtnAlterar.Name = "BtnAlterar";
            this.BtnAlterar.Size = new System.Drawing.Size(96, 31);
            this.BtnAlterar.TabIndex = 14;
            this.BtnAlterar.Text = "&Alterar";
            this.BtnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAlterar.UseVisualStyleBackColor = true;
            this.BtnAlterar.Click += new System.EventHandler(this.BtnAlterar_Click);
            // 
            // BtnLimpar
            // 
            this.BtnLimpar.Enabled = false;
            this.BtnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpar.Image = ((System.Drawing.Image)(resources.GetObject("BtnLimpar.Image")));
            this.BtnLimpar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLimpar.Location = new System.Drawing.Point(219, 103);
            this.BtnLimpar.Name = "BtnLimpar";
            this.BtnLimpar.Size = new System.Drawing.Size(96, 31);
            this.BtnLimpar.TabIndex = 15;
            this.BtnLimpar.Text = "&Limpar";
            this.BtnLimpar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnLimpar.UseVisualStyleBackColor = true;
            this.BtnLimpar.Click += new System.EventHandler(this.BtnLimpar_Click);
            // 
            // TxtContaCorrente
            // 
            this.TxtContaCorrente.Location = new System.Drawing.Point(125, 38);
            this.TxtContaCorrente.Name = "TxtContaCorrente";
            this.TxtContaCorrente.ReadOnly = true;
            this.TxtContaCorrente.Size = new System.Drawing.Size(119, 20);
            this.TxtContaCorrente.TabIndex = 3;
            // 
            // LblValorMovimentacao
            // 
            this.LblValorMovimentacao.AutoSize = true;
            this.LblValorMovimentacao.Location = new System.Drawing.Point(12, 67);
            this.LblValorMovimentacao.Name = "LblValorMovimentacao";
            this.LblValorMovimentacao.Size = new System.Drawing.Size(107, 13);
            this.LblValorMovimentacao.TabIndex = 6;
            this.LblValorMovimentacao.Text = "Valor Movimentação:";
            // 
            // LblContaCorrente
            // 
            this.LblContaCorrente.AutoSize = true;
            this.LblContaCorrente.Location = new System.Drawing.Point(12, 41);
            this.LblContaCorrente.Name = "LblContaCorrente";
            this.LblContaCorrente.Size = new System.Drawing.Size(81, 13);
            this.LblContaCorrente.TabIndex = 2;
            this.LblContaCorrente.Text = "Conta Corrente:";
            // 
            // BtnIncluir
            // 
            this.BtnIncluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIncluir.Image = ((System.Drawing.Image)(resources.GetObject("BtnIncluir.Image")));
            this.BtnIncluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnIncluir.Location = new System.Drawing.Point(15, 103);
            this.BtnIncluir.Name = "BtnIncluir";
            this.BtnIncluir.Size = new System.Drawing.Size(96, 31);
            this.BtnIncluir.TabIndex = 13;
            this.BtnIncluir.Tag = "";
            this.BtnIncluir.Text = "&Incluir";
            this.BtnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnIncluir.UseVisualStyleBackColor = true;
            this.BtnIncluir.Click += new System.EventHandler(this.BtnIncluir_Click);
            // 
            // CboBanco
            // 
            this.CboBanco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CboBanco.FormattingEnabled = true;
            this.CboBanco.Items.AddRange(new object[] {
            "Access",
            "SQL Server"});
            this.CboBanco.Location = new System.Drawing.Point(431, 12);
            this.CboBanco.Name = "CboBanco";
            this.CboBanco.Size = new System.Drawing.Size(121, 21);
            this.CboBanco.TabIndex = 21;
            this.CboBanco.Text = "Access";
            // 
            // TxtValorMovimentacao
            // 
            this.TxtValorMovimentacao.Location = new System.Drawing.Point(125, 64);
            this.TxtValorMovimentacao.Name = "TxtValorMovimentacao";
            this.TxtValorMovimentacao.ReadOnly = true;
            this.TxtValorMovimentacao.Size = new System.Drawing.Size(119, 20);
            this.TxtValorMovimentacao.TabIndex = 7;
            this.TxtValorMovimentacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtValorMovimentacao_KeyPress);
            this.TxtValorMovimentacao.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtValorMovimentacao_KeyUp);
            this.TxtValorMovimentacao.Leave += new System.EventHandler(this.TxtValorMovimentacao_Leave);
            // 
            // FrmMovimentacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 441);
            this.Controls.Add(this.TxtValorMovimentacao);
            this.Controls.Add(this.CboBanco);
            this.Controls.Add(this.TxtMovimentacao);
            this.Controls.Add(this.LblMovimentacao);
            this.Controls.Add(this.gbxCreditoDebito);
            this.Controls.Add(this.dtpDataHora);
            this.Controls.Add(this.lblDataHora);
            this.Controls.Add(this.BtnAjuda);
            this.Controls.Add(this.DgvMovimentacao);
            this.Controls.Add(this.BtnFiltro);
            this.Controls.Add(this.TxtFiltro);
            this.Controls.Add(this.BtnPesquisar);
            this.Controls.Add(this.BtnExcluir);
            this.Controls.Add(this.BtnAlterar);
            this.Controls.Add(this.BtnLimpar);
            this.Controls.Add(this.TxtContaCorrente);
            this.Controls.Add(this.LblValorMovimentacao);
            this.Controls.Add(this.LblContaCorrente);
            this.Controls.Add(this.BtnIncluir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMovimentacao";
            this.ShowIcon = false;
            this.Text = "Movimentação";
            this.Activated += new System.EventHandler(this.FrmMovimentacao_Activated);
            this.Load += new System.EventHandler(this.FrmMovimentacao_Load);
            this.gbxCreditoDebito.ResumeLayout(false);
            this.gbxCreditoDebito.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMovimentacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtMovimentacao;
        private System.Windows.Forms.Label LblMovimentacao;
        private System.Windows.Forms.GroupBox gbxCreditoDebito;
        private System.Windows.Forms.RadioButton rbDebito;
        private System.Windows.Forms.RadioButton rbCredito;
        private System.Windows.Forms.DateTimePicker dtpDataHora;
        private System.Windows.Forms.Label lblDataHora;
        private System.Windows.Forms.Button BtnAjuda;
        private System.Windows.Forms.DataGridView DgvMovimentacao;
        private System.Windows.Forms.Button BtnFiltro;
        private System.Windows.Forms.TextBox TxtFiltro;
        private System.Windows.Forms.Button BtnPesquisar;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnAlterar;
        private System.Windows.Forms.Button BtnLimpar;
        private System.Windows.Forms.TextBox TxtContaCorrente;
        private System.Windows.Forms.Label LblValorMovimentacao;
        private System.Windows.Forms.Label LblContaCorrente;
        private System.Windows.Forms.Button BtnIncluir;
        private System.Windows.Forms.ComboBox CboBanco;
        private System.Windows.Forms.TextBox TxtValorMovimentacao;
    }
}