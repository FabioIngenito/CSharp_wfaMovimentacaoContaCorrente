namespace MovimentacaoContaCorrente.UI
{
    partial class FrmContaCorrente
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
            System.Windows.Forms.Timer TmrDolarComercial;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContaCorrente));
            this.BtnAjuda = new System.Windows.Forms.Button();
            this.DgvContaCorrente = new System.Windows.Forms.DataGridView();
            this.CboBanco = new System.Windows.Forms.ComboBox();
            this.BtnFiltro = new System.Windows.Forms.Button();
            this.TxtFiltro = new System.Windows.Forms.TextBox();
            this.BtnPesquisar = new System.Windows.Forms.Button();
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.BtnAlterar = new System.Windows.Forms.Button();
            this.BtnIncluir = new System.Windows.Forms.Button();
            this.BtnLimpar = new System.Windows.Forms.Button();
            this.TxtContaCorrente = new System.Windows.Forms.TextBox();
            this.LblValorAtual = new System.Windows.Forms.Label();
            this.LblContaCorrente = new System.Windows.Forms.Label();
            this.TxtValorAtual = new System.Windows.Forms.TextBox();
            this.BtnRecalcular = new System.Windows.Forms.Button();
            this.TxtValorDolar = new System.Windows.Forms.TextBox();
            this.lblValorDolar = new System.Windows.Forms.Label();
            this.TxtValorAtualDolar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            TmrDolarComercial = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DgvContaCorrente)).BeginInit();
            this.SuspendLayout();
            // 
            // TmrDolarComercial
            // 
            TmrDolarComercial.Enabled = true;
            TmrDolarComercial.Interval = 120000;
            TmrDolarComercial.Tick += new System.EventHandler(this.TmrDolarComercial_Tick);
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
            this.BtnAjuda.TabIndex = 13;
            this.BtnAjuda.Text = "&Ajuda";
            this.BtnAjuda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAjuda.UseVisualStyleBackColor = true;
            this.BtnAjuda.Click += new System.EventHandler(this.BtnAjuda_Click);
            // 
            // DgvContaCorrente
            // 
            this.DgvContaCorrente.AllowUserToAddRows = false;
            this.DgvContaCorrente.AllowUserToDeleteRows = false;
            this.DgvContaCorrente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvContaCorrente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvContaCorrente.Location = new System.Drawing.Point(16, 115);
            this.DgvContaCorrente.MultiSelect = false;
            this.DgvContaCorrente.Name = "DgvContaCorrente";
            this.DgvContaCorrente.ReadOnly = true;
            this.DgvContaCorrente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvContaCorrente.Size = new System.Drawing.Size(536, 277);
            this.DgvContaCorrente.TabIndex = 5;
            this.DgvContaCorrente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvContaCorrente_CellClick);
            this.DgvContaCorrente.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DgvContaCorrente_KeyUp);
            // 
            // CboBanco
            // 
            this.CboBanco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CboBanco.FormattingEnabled = true;
            this.CboBanco.Items.AddRange(new object[] {
            "Access",
            "SQL Server"});
            this.CboBanco.Location = new System.Drawing.Point(431, 18);
            this.CboBanco.Name = "CboBanco";
            this.CboBanco.Size = new System.Drawing.Size(121, 21);
            this.CboBanco.TabIndex = 14;
            this.CboBanco.Text = "Access";
            this.CboBanco.SelectedIndexChanged += new System.EventHandler(this.CboBanco_SelectedIndexChanged);
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
            this.BtnFiltro.TabIndex = 12;
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
            this.TxtFiltro.TabIndex = 11;
            // 
            // BtnPesquisar
            // 
            this.BtnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("BtnPesquisar.Image")));
            this.BtnPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPesquisar.Location = new System.Drawing.Point(322, 78);
            this.BtnPesquisar.Name = "BtnPesquisar";
            this.BtnPesquisar.Size = new System.Drawing.Size(96, 31);
            this.BtnPesquisar.TabIndex = 9;
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
            this.BtnExcluir.Location = new System.Drawing.Point(457, 78);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.Size = new System.Drawing.Size(96, 31);
            this.BtnExcluir.TabIndex = 10;
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
            this.BtnAlterar.Location = new System.Drawing.Point(118, 78);
            this.BtnAlterar.Name = "BtnAlterar";
            this.BtnAlterar.Size = new System.Drawing.Size(96, 31);
            this.BtnAlterar.TabIndex = 7;
            this.BtnAlterar.Text = "&Alterar";
            this.BtnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAlterar.UseVisualStyleBackColor = true;
            this.BtnAlterar.Click += new System.EventHandler(this.BtnAlterar_Click);
            // 
            // BtnIncluir
            // 
            this.BtnIncluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIncluir.Image = ((System.Drawing.Image)(resources.GetObject("BtnIncluir.Image")));
            this.BtnIncluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnIncluir.Location = new System.Drawing.Point(16, 78);
            this.BtnIncluir.Name = "BtnIncluir";
            this.BtnIncluir.Size = new System.Drawing.Size(96, 31);
            this.BtnIncluir.TabIndex = 6;
            this.BtnIncluir.Tag = "";
            this.BtnIncluir.Text = "&Incluir";
            this.BtnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnIncluir.UseVisualStyleBackColor = true;
            this.BtnIncluir.Click += new System.EventHandler(this.BtnIncluir_Click);
            // 
            // BtnLimpar
            // 
            this.BtnLimpar.Enabled = false;
            this.BtnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpar.Image = ((System.Drawing.Image)(resources.GetObject("BtnLimpar.Image")));
            this.BtnLimpar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLimpar.Location = new System.Drawing.Point(220, 78);
            this.BtnLimpar.Name = "BtnLimpar";
            this.BtnLimpar.Size = new System.Drawing.Size(96, 31);
            this.BtnLimpar.TabIndex = 8;
            this.BtnLimpar.Text = "&Limpar";
            this.BtnLimpar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnLimpar.UseVisualStyleBackColor = true;
            this.BtnLimpar.Click += new System.EventHandler(this.BtnLimpar_Click);
            // 
            // TxtContaCorrente
            // 
            this.TxtContaCorrente.Location = new System.Drawing.Point(96, 18);
            this.TxtContaCorrente.Name = "TxtContaCorrente";
            this.TxtContaCorrente.ReadOnly = true;
            this.TxtContaCorrente.Size = new System.Drawing.Size(114, 20);
            this.TxtContaCorrente.TabIndex = 1;
            // 
            // LblValorAtual
            // 
            this.LblValorAtual.AutoSize = true;
            this.LblValorAtual.Location = new System.Drawing.Point(13, 47);
            this.LblValorAtual.Name = "LblValorAtual";
            this.LblValorAtual.Size = new System.Drawing.Size(61, 13);
            this.LblValorAtual.TabIndex = 2;
            this.LblValorAtual.Text = "Valor Atual:";
            // 
            // LblContaCorrente
            // 
            this.LblContaCorrente.AutoSize = true;
            this.LblContaCorrente.Location = new System.Drawing.Point(13, 21);
            this.LblContaCorrente.Name = "LblContaCorrente";
            this.LblContaCorrente.Size = new System.Drawing.Size(81, 13);
            this.LblContaCorrente.TabIndex = 0;
            this.LblContaCorrente.Text = "Conta Corrente:";
            // 
            // TxtValorAtual
            // 
            this.TxtValorAtual.Location = new System.Drawing.Point(96, 44);
            this.TxtValorAtual.Name = "TxtValorAtual";
            this.TxtValorAtual.ReadOnly = true;
            this.TxtValorAtual.Size = new System.Drawing.Size(114, 20);
            this.TxtValorAtual.TabIndex = 3;
            this.TxtValorAtual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtValorAtual_KeyPress);
            this.TxtValorAtual.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtValorAtual_KeyUp);
            this.TxtValorAtual.Leave += new System.EventHandler(this.TxtValorAtual_Leave);
            // 
            // BtnRecalcular
            // 
            this.BtnRecalcular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BtnRecalcular.Location = new System.Drawing.Point(321, 398);
            this.BtnRecalcular.Name = "BtnRecalcular";
            this.BtnRecalcular.Size = new System.Drawing.Size(96, 31);
            this.BtnRecalcular.TabIndex = 15;
            this.BtnRecalcular.Text = "&Recalcular";
            this.BtnRecalcular.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRecalcular.UseVisualStyleBackColor = true;
            this.BtnRecalcular.Click += new System.EventHandler(this.BtnRecalcular_Click);
            // 
            // TxtValorDolar
            // 
            this.TxtValorDolar.Location = new System.Drawing.Point(308, 18);
            this.TxtValorDolar.Name = "TxtValorDolar";
            this.TxtValorDolar.ReadOnly = true;
            this.TxtValorDolar.Size = new System.Drawing.Size(114, 20);
            this.TxtValorDolar.TabIndex = 17;
            // 
            // lblValorDolar
            // 
            this.lblValorDolar.AutoSize = true;
            this.lblValorDolar.Location = new System.Drawing.Point(218, 21);
            this.lblValorDolar.Name = "lblValorDolar";
            this.lblValorDolar.Size = new System.Drawing.Size(77, 13);
            this.lblValorDolar.TabIndex = 16;
            this.lblValorDolar.Text = "Valor do Dólar:";
            // 
            // TxtValorAtualDolar
            // 
            this.TxtValorAtualDolar.Location = new System.Drawing.Point(308, 44);
            this.TxtValorAtualDolar.Name = "TxtValorAtualDolar";
            this.TxtValorAtualDolar.ReadOnly = true;
            this.TxtValorAtualDolar.Size = new System.Drawing.Size(114, 20);
            this.TxtValorAtualDolar.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Valor Atual Dólar:";
            // 
            // FrmContaCorrente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 441);
            this.Controls.Add(this.TxtValorAtualDolar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtValorDolar);
            this.Controls.Add(this.lblValorDolar);
            this.Controls.Add(this.BtnRecalcular);
            this.Controls.Add(this.TxtValorAtual);
            this.Controls.Add(this.BtnAjuda);
            this.Controls.Add(this.DgvContaCorrente);
            this.Controls.Add(this.CboBanco);
            this.Controls.Add(this.BtnFiltro);
            this.Controls.Add(this.TxtFiltro);
            this.Controls.Add(this.BtnPesquisar);
            this.Controls.Add(this.BtnExcluir);
            this.Controls.Add(this.BtnAlterar);
            this.Controls.Add(this.BtnIncluir);
            this.Controls.Add(this.BtnLimpar);
            this.Controls.Add(this.TxtContaCorrente);
            this.Controls.Add(this.LblValorAtual);
            this.Controls.Add(this.LblContaCorrente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmContaCorrente";
            this.ShowIcon = false;
            this.Text = "Conta Corrente";
            this.Activated += new System.EventHandler(this.FrmContaCorrente_Activated);
            this.Load += new System.EventHandler(this.FrmContaCorrente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvContaCorrente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnAjuda;
        private System.Windows.Forms.DataGridView DgvContaCorrente;
        private System.Windows.Forms.ComboBox CboBanco;
        private System.Windows.Forms.Button BtnFiltro;
        private System.Windows.Forms.TextBox TxtFiltro;
        private System.Windows.Forms.Button BtnPesquisar;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnAlterar;
        private System.Windows.Forms.Button BtnIncluir;
        private System.Windows.Forms.Button BtnLimpar;
        private System.Windows.Forms.TextBox TxtContaCorrente;
        private System.Windows.Forms.Label LblValorAtual;
        private System.Windows.Forms.Label LblContaCorrente;
        private System.Windows.Forms.TextBox TxtValorAtual;
        private System.Windows.Forms.Button BtnRecalcular;
        private System.Windows.Forms.TextBox TxtValorDolar;
        private System.Windows.Forms.Label lblValorDolar;
        private System.Windows.Forms.TextBox TxtValorAtualDolar;
        private System.Windows.Forms.Label label1;
    }
}