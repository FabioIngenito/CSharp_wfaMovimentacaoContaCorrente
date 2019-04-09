namespace MovimentacaoContaCorrente.UI
{
    partial class FrmPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.manutençãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContaCorrenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LançamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conversãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contaCorrenteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manutençãoToolStripMenuItem,
            this.conversãoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(682, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // manutençãoToolStripMenuItem
            // 
            this.manutençãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContaCorrenteToolStripMenuItem,
            this.LançamentosToolStripMenuItem});
            this.manutençãoToolStripMenuItem.Name = "manutençãoToolStripMenuItem";
            this.manutençãoToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.manutençãoToolStripMenuItem.Text = "Manutenção";
            // 
            // ContaCorrenteToolStripMenuItem
            // 
            this.ContaCorrenteToolStripMenuItem.Name = "ContaCorrenteToolStripMenuItem";
            this.ContaCorrenteToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.ContaCorrenteToolStripMenuItem.Text = "Conta Corrente";
            this.ContaCorrenteToolStripMenuItem.Click += new System.EventHandler(this.ContaCorrenteToolStripMenuItem_Click);
            // 
            // LançamentosToolStripMenuItem
            // 
            this.LançamentosToolStripMenuItem.Name = "LançamentosToolStripMenuItem";
            this.LançamentosToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.LançamentosToolStripMenuItem.Text = "Movimentação";
            this.LançamentosToolStripMenuItem.Click += new System.EventHandler(this.LançamentosToolStripMenuItem_Click);
            // 
            // conversãoToolStripMenuItem
            // 
            this.conversãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contaCorrenteToolStripMenuItem1});
            this.conversãoToolStripMenuItem.Name = "conversãoToolStripMenuItem";
            this.conversãoToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.conversãoToolStripMenuItem.Text = "Conversão";
            // 
            // contaCorrenteToolStripMenuItem1
            // 
            this.contaCorrenteToolStripMenuItem1.Name = "contaCorrenteToolStripMenuItem1";
            this.contaCorrenteToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.contaCorrenteToolStripMenuItem1.Text = "Conta Corrente";
            this.contaCorrenteToolStripMenuItem1.Click += new System.EventHandler(this.contaCorrenteToolStripMenuItem1_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 535);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.ShowIcon = false;
            this.Text = "Menu Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem manutençãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContaCorrenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LançamentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conversãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contaCorrenteToolStripMenuItem1;
    }
}