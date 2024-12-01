namespace AdmissionCommittee.Forms
{
    public partial class GenerateCountRequest : Form
    {
        public GenerateCountRequest()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object _, EventArgs __)
        {
            if (MessageBox.Show($"Сгенерировать {generateCount.Value} записей?", Text, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
