namespace Lab08WinForms
{
    partial class ConverterForm
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
            ValueLabel = new Label();
            ValueTextBox = new TextBox();
            ResultTextBox = new TextBox();
            ResultLabel = new Label();
            UnitGroupBox = new GroupBox();
            MileToMeterRadio = new RadioButton();
            MToMileRadio = new RadioButton();
            MToKMRadio = new RadioButton();
            button1 = new Button();
            WarningValueLabel = new Label();
            UnitGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // ValueLabel
            // 
            ValueLabel.AutoSize = true;
            ValueLabel.Font = new Font("Segoe UI", 9.818182F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ValueLabel.Location = new Point(60, 264);
            ValueLabel.Name = "ValueLabel";
            ValueLabel.Size = new Size(66, 30);
            ValueLabel.TabIndex = 0;
            ValueLabel.Text = "Value";
            // 
            // ValueTextBox
            // 
            ValueTextBox.Font = new Font("Segoe UI", 12.1558447F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ValueTextBox.Location = new Point(157, 264);
            ValueTextBox.Name = "ValueTextBox";
            ValueTextBox.Size = new Size(183, 42);
            ValueTextBox.TabIndex = 1;
            // 
            // ResultTextBox
            // 
            ResultTextBox.BackColor = SystemColors.ControlLightLight;
            ResultTextBox.Cursor = Cursors.No;
            ResultTextBox.Enabled = false;
            ResultTextBox.Font = new Font("Segoe UI", 12.1558447F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ResultTextBox.Location = new Point(561, 215);
            ResultTextBox.Name = "ResultTextBox";
            ResultTextBox.ReadOnly = true;
            ResultTextBox.Size = new Size(183, 42);
            ResultTextBox.TabIndex = 3;
            // 
            // ResultLabel
            // 
            ResultLabel.AutoSize = true;
            ResultLabel.Font = new Font("Segoe UI", 9.818182F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ResultLabel.Location = new Point(617, 153);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(73, 30);
            ResultLabel.TabIndex = 2;
            ResultLabel.Text = "Result";
            // 
            // UnitGroupBox
            // 
            UnitGroupBox.Controls.Add(MileToMeterRadio);
            UnitGroupBox.Controls.Add(MToMileRadio);
            UnitGroupBox.Controls.Add(MToKMRadio);
            UnitGroupBox.Font = new Font("Segoe UI", 8.883117F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UnitGroupBox.Location = new Point(49, 42);
            UnitGroupBox.Name = "UnitGroupBox";
            UnitGroupBox.Size = new Size(321, 160);
            UnitGroupBox.TabIndex = 4;
            UnitGroupBox.TabStop = false;
            UnitGroupBox.Text = "Choose Unit ";
            // 
            // MileToMeterRadio
            // 
            MileToMeterRadio.AutoSize = true;
            MileToMeterRadio.Font = new Font("Segoe UI", 8.883117F);
            MileToMeterRadio.Location = new Point(62, 102);
            MileToMeterRadio.Name = "MileToMeterRadio";
            MileToMeterRadio.Size = new Size(151, 29);
            MileToMeterRadio.TabIndex = 2;
            MileToMeterRadio.Text = "Mile to Meter";
            MileToMeterRadio.UseVisualStyleBackColor = true;
            // 
            // MToMileRadio
            // 
            MToMileRadio.AutoSize = true;
            MToMileRadio.Font = new Font("Segoe UI", 8.883117F);
            MToMileRadio.Location = new Point(62, 67);
            MToMileRadio.Name = "MToMileRadio";
            MToMileRadio.Size = new Size(118, 29);
            MToMileRadio.TabIndex = 1;
            MToMileRadio.Text = "M to Mile";
            MToMileRadio.UseVisualStyleBackColor = true;
            // 
            // MToKMRadio
            // 
            MToKMRadio.AutoSize = true;
            MToKMRadio.Checked = true;
            MToKMRadio.Font = new Font("Segoe UI", 8.883117F);
            MToKMRadio.Location = new Point(62, 32);
            MToKMRadio.Name = "MToKMRadio";
            MToKMRadio.Size = new Size(114, 29);
            MToKMRadio.TabIndex = 0;
            MToKMRadio.TabStop = true;
            MToKMRadio.Text = "M to KM ";
            MToKMRadio.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.BackColor = Color.LightSteelBlue;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(292, 367);
            button1.Name = "button1";
            button1.Size = new Size(178, 53);
            button1.TabIndex = 5;
            button1.Text = "Convert";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // WarningValueLabel
            // 
            WarningValueLabel.AutoSize = true;
            WarningValueLabel.ForeColor = Color.IndianRed;
            WarningValueLabel.Location = new Point(366, 276);
            WarningValueLabel.Name = "WarningValueLabel";
            WarningValueLabel.Size = new Size(153, 25);
            WarningValueLabel.TabIndex = 6;
            WarningValueLabel.Text = "Must Enter value";
            WarningValueLabel.Visible = false;
            // 
            // ConverterForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(WarningValueLabel);
            Controls.Add(button1);
            Controls.Add(UnitGroupBox);
            Controls.Add(ResultTextBox);
            Controls.Add(ResultLabel);
            Controls.Add(ValueTextBox);
            Controls.Add(ValueLabel);
            Name = "ConverterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ConverterForm";
            FormClosed += ConverterForm_FormClosed;
            Load += ConverterForm_Load;
            UnitGroupBox.ResumeLayout(false);
            UnitGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ValueLabel;
        private TextBox ValueTextBox;
        private TextBox ResultTextBox;
        private Label ResultLabel;
        private GroupBox UnitGroupBox;
        private RadioButton MileToMeterRadio;
        private RadioButton MToMileRadio;
        private RadioButton MToKMRadio;
        private Button button1;
        private Label WarningValueLabel;
    }
}