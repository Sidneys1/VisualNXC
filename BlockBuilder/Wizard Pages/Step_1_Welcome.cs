using System;
using System.Windows.Forms;

namespace BlockBuilder.Wizard_Pages
{
    public partial class Step_1_Welcome : UserControl, IWizardStep
    {
        public Step_1_Welcome()
        {
            InitializeComponent();
        }

        string IWizardStep.ButtonTextNext
        {
            get { return "Let's Get Started >"; }
        }

        string IWizardStep.ButtonTextPrev
        {
            get { return null; }
        }
    }
}
