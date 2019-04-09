namespace wfaTesteInputBox
{
    partial class frmTestaInputBox
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
            this.lblCaixaDeTexto = new System.Windows.Forms.Label();
            this.txtCaixaDeTexto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCaixaDeTexto
            // 
            this.lblCaixaDeTexto.AutoSize = true;
            this.lblCaixaDeTexto.Location = new System.Drawing.Point(12, 15);
            this.lblCaixaDeTexto.Name = "lblCaixaDeTexto";
            this.lblCaixaDeTexto.Size = new System.Drawing.Size(81, 13);
            this.lblCaixaDeTexto.TabIndex = 0;
            this.lblCaixaDeTexto.Text = "Caixa de Texto:";
            // 
            // txtCaixaDeTexto
            // 
            this.txtCaixaDeTexto.Location = new System.Drawing.Point(99, 12);
            this.txtCaixaDeTexto.Name = "txtCaixaDeTexto";
            this.txtCaixaDeTexto.Size = new System.Drawing.Size(280, 20);
            this.txtCaixaDeTexto.TabIndex = 1;
            // 
            // frmTestaInputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 41);
            this.Controls.Add(this.txtCaixaDeTexto);
            this.Controls.Add(this.lblCaixaDeTexto);
            this.Name = "frmTestaInputBox";
            this.Text = "Testar InputBox";
            this.Load += new System.EventHandler(this.frmTestaInputBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaixaDeTexto;
        private System.Windows.Forms.TextBox txtCaixaDeTexto;
    }
}

