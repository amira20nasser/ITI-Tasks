using System.Text.RegularExpressions;

namespace Lab08WinForms
{
    public partial class RegisterationForm : Form
    {
        public RegisterationForm()
        {
            InitializeComponent();
        }
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            WarningNameLabel.Text = "";
            WarningEmailLabel.Text = "";
            WarningHobbiesLabel.Text = "";
            if (String.IsNullOrEmpty(NameTextBox.Text))
            {
                isValid = false;
                WarningNameLabel.Text = "Name must contain at least 5 characters";
            }
            if (String.IsNullOrEmpty(EmailTextBox.Text) || !Regex.IsMatch(EmailTextBox.Text, "^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$"))
            {
                isValid = false;
                WarningEmailLabel.Text = "Email must contain @";
            }
            if (!HobbiesGroupBox.Controls.OfType<CheckBox>().Any(e => e.Checked))
            {
                isValid = false;
                WarningHobbiesLabel.Text = "Choose at least one hoppy";
            }
            if (isValid)
            {
                ConverterForm converterForm = new ConverterForm();
                converterForm.Show();
                this.Hide();
            }
        }
        private void GenderGroupBox_Enter(object sender, EventArgs e)
        {

        }

        void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    

        private void RegisterationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
