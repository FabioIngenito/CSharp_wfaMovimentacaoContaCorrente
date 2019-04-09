using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace wfaTesteInputBox
{
    public partial class frmTestaInputBox : Form
    {
        public frmTestaInputBox()
        {
            InitializeComponent();
        }

        public static string InputBox(string prompt, string title, string defaultValue)
        {
            InputBoxDialog ib = new InputBoxDialog();
            ib.FormPrompt = prompt;
            ib.FormCaption = title;
            ib.DefaultValue = defaultValue;
            ib.ShowDialog();

            string s = ib.InputResponse;

            ib.Close();

            if (s == string.Empty)
                return "";
            else
                return s;
        }

        /// <summary>
        /// http://www.macoratti.net/10/10/c_inbox.htm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTestaInputBox_Load(object sender, EventArgs e)
        {
            string texto = InputBox("Digite um numero", "Teste de InputBox", "10");
            txtCaixaDeTexto.Text = texto;
        }
    }
}
