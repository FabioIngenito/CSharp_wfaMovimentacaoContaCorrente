using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovimentacaoContaCorrente.UI
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void ContaCorrenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmContaCorrente frmCC = new FrmContaCorrente
            {
                WindowState = FormWindowState.Normal,
                MdiParent = this
            };

            frmCC.Show();
        }

        private void LançamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMovimentacao frmMov = new FrmMovimentacao
            {
                WindowState = FormWindowState.Normal,
                MdiParent = this
            };

            frmMov.Show();
        }

        private void contaCorrenteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmConversao frmMov = new FrmConversao
            {
                WindowState = FormWindowState.Normal,
                MdiParent = this
            };

            frmMov.Show();
        }
    }
}
