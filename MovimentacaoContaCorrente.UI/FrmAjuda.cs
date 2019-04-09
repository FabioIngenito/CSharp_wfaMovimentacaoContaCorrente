using System;
using System.Windows.Forms;


namespace MovimentacaoContaCorrente.UI
{
    public partial class FrmAjuda : Form
    {
        public FrmAjuda()
        {
            InitializeComponent();
        }

        private void FrmAjuda_Load(object sender, EventArgs e)
        {
            lblProductName.Text = Application.ProductName;
            lblProductVersion.Text = Application.ProductVersion;
            lblCommonAppDataPath.Text = Application.CommonAppDataPath;
            //lblCommonAppDataRegistry.Text = Convert.ToString(Application.CommonAppDataRegistry);
            lblCompanyName.Text = Application.CompanyName;
            lblCurrentCulture.Text = Convert.ToString(Application.CurrentCulture);
            lblCurrentInputLanguage.Text = Convert.ToString(Application.CurrentInputLanguage);
            lblExecutablePath.Text = Application.ExecutablePath;
            lblLocalUserAppDataPath.Text = Application.LocalUserAppDataPath;
            lblStartupPath.Text = Application.StartupPath;
            lblUserAppDataPath.Text = Application.UserAppDataPath;
            lblUserAppDataRegistry.Text = Convert.ToString(Application.UserAppDataRegistry);
        }
    }
}
