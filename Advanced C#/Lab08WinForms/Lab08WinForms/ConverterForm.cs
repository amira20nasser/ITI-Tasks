using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lab08WinForms
{
    public partial class ConverterForm : Form
    {
        public ConverterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            WarningValueLabel.Visible = false;

            if (String.IsNullOrEmpty(ValueTextBox.Text))
            {
                isValid = false;
                WarningValueLabel.Visible = true;
            }
            if(!double.TryParse(ValueTextBox.Text,out double value))
            {
                isValid = false;
                WarningValueLabel.Text = "Enter a valid number";
                WarningValueLabel.Visible = true;
                return;
            }
            if (!isValid) return;
            var radioBox = UnitGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(e => e.Checked);
            if (radioBox == null) {
                MessageBox.Show("Please select a conversion type");
                return;
            }
            double result = 0;
            if (radioBox == MToKMRadio)
            {
                result = value / 1000.0;
            }
            else if (radioBox == MToMileRadio) 
            {
                result = value / 1609.34;
            }
            else if (radioBox == MileToMeterRadio) 
            {
                result = value * 1609.34;
            }
            ResultTextBox.Text = result.ToString("0.####");

        }
        private void ConverterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ConverterForm_Load(object sender, EventArgs e)
        {

        }

    }
}
