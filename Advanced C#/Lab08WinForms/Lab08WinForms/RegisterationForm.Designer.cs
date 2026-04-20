namespace Lab08WinForms
{
    partial class RegisterationForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            NameLabel = new Label();
            GenderGroupBox = new GroupBox();
            FemaleRadioButton = new RadioButton();
            GenderLabel = new Label();
            MaleRadioButton = new RadioButton();
            EmailLabel = new Label();
            HobbiesLabel = new Label();
            HobbiesGroupBox = new GroupBox();
            SwimmingCheckBox = new CheckBox();
            TennisCheckBox = new CheckBox();
            FootballCheckBox = new CheckBox();
            NameTextBox = new TextBox();
            EmailTextBox = new TextBox();
            RegisterButton = new Button();
            WarningNameLabel = new Label();
            WarningEmailLabel = new Label();
            label1 = new Label();
            WarningHobbiesLabel = new Label();
            GenderGroupBox.SuspendLayout();
            HobbiesGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Arial", 14.0259743F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameLabel.Location = new Point(67, 60);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(97, 35);
            NameLabel.TabIndex = 0;
            NameLabel.Text = "Name";
            // 
            // GenderGroupBox
            // 
            GenderGroupBox.Controls.Add(FemaleRadioButton);
            GenderGroupBox.Controls.Add(GenderLabel);
            GenderGroupBox.Controls.Add(MaleRadioButton);
            GenderGroupBox.Location = new Point(67, 189);
            GenderGroupBox.Name = "GenderGroupBox";
            GenderGroupBox.Size = new Size(334, 119);
            GenderGroupBox.TabIndex = 4;
            GenderGroupBox.TabStop = false;
            GenderGroupBox.Enter += GenderGroupBox_Enter;
            // 
            // FemaleRadioButton
            // 
            FemaleRadioButton.AutoSize = true;
            FemaleRadioButton.Location = new Point(155, 75);
            FemaleRadioButton.Name = "FemaleRadioButton";
            FemaleRadioButton.Size = new Size(138, 39);
            FemaleRadioButton.TabIndex = 1;
            FemaleRadioButton.TabStop = true;
            FemaleRadioButton.Text = "Female";
            FemaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // GenderLabel
            // 
            GenderLabel.AutoSize = true;
            GenderLabel.Font = new Font("Arial", 14.0259743F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GenderLabel.Location = new Point(0, 38);
            GenderLabel.Name = "GenderLabel";
            GenderLabel.Size = new Size(120, 35);
            GenderLabel.TabIndex = 6;
            GenderLabel.Text = "Gender";
            // 
            // MaleRadioButton
            // 
            MaleRadioButton.AutoSize = true;
            MaleRadioButton.Location = new Point(155, 13);
            MaleRadioButton.Name = "MaleRadioButton";
            MaleRadioButton.Size = new Size(104, 39);
            MaleRadioButton.TabIndex = 0;
            MaleRadioButton.TabStop = true;
            MaleRadioButton.Text = "Male";
            MaleRadioButton.UseVisualStyleBackColor = true;
            MaleRadioButton.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Font = new Font("Arial", 14.0259743F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EmailLabel.Location = new Point(67, 123);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(94, 35);
            EmailLabel.TabIndex = 5;
            EmailLabel.Text = "Email";
            // 
            // HobbiesLabel
            // 
            HobbiesLabel.AutoSize = true;
            HobbiesLabel.Font = new Font("Arial", 14.0259743F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HobbiesLabel.Location = new Point(0, 0);
            HobbiesLabel.Name = "HobbiesLabel";
            HobbiesLabel.Size = new Size(133, 35);
            HobbiesLabel.TabIndex = 7;
            HobbiesLabel.Text = "Hobbies";
            HobbiesLabel.Click += label2_Click;
            // 
            // HobbiesGroupBox
            // 
            HobbiesGroupBox.Controls.Add(SwimmingCheckBox);
            HobbiesGroupBox.Controls.Add(TennisCheckBox);
            HobbiesGroupBox.Controls.Add(FootballCheckBox);
            HobbiesGroupBox.Controls.Add(HobbiesLabel);
            HobbiesGroupBox.Location = new Point(53, 356);
            HobbiesGroupBox.Name = "HobbiesGroupBox";
            HobbiesGroupBox.Size = new Size(1008, 160);
            HobbiesGroupBox.TabIndex = 8;
            HobbiesGroupBox.TabStop = false;
            // 
            // SwimmingCheckBox
            // 
            SwimmingCheckBox.AutoSize = true;
            SwimmingCheckBox.Location = new Point(523, 52);
            SwimmingCheckBox.Name = "SwimmingCheckBox";
            SwimmingCheckBox.Size = new Size(180, 39);
            SwimmingCheckBox.TabIndex = 10;
            SwimmingCheckBox.Text = "Swimming";
            SwimmingCheckBox.UseVisualStyleBackColor = true;
            // 
            // TennisCheckBox
            // 
            TennisCheckBox.AutoSize = true;
            TennisCheckBox.Location = new Point(306, 52);
            TennisCheckBox.Name = "TennisCheckBox";
            TennisCheckBox.Size = new Size(129, 39);
            TennisCheckBox.TabIndex = 9;
            TennisCheckBox.Text = "Tennis";
            TennisCheckBox.UseVisualStyleBackColor = true;
            // 
            // FootballCheckBox
            // 
            FootballCheckBox.AutoSize = true;
            FootballCheckBox.Location = new Point(86, 52);
            FootballCheckBox.Name = "FootballCheckBox";
            FootballCheckBox.Size = new Size(146, 39);
            FootballCheckBox.TabIndex = 8;
            FootballCheckBox.Text = "Football";
            FootballCheckBox.UseVisualStyleBackColor = true;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(187, 60);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(255, 42);
            NameTextBox.TabIndex = 9;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(187, 123);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(255, 42);
            EmailTextBox.TabIndex = 10;
            // 
            // RegisterButton
            // 
            RegisterButton.BackColor = SystemColors.ActiveCaption;
            RegisterButton.Cursor = Cursors.Hand;
            RegisterButton.FlatAppearance.BorderColor = Color.Gray;
            RegisterButton.FlatAppearance.BorderSize = 2;
            RegisterButton.FlatStyle = FlatStyle.Popup;
            RegisterButton.Location = new Point(389, 580);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(335, 64);
            RegisterButton.TabIndex = 11;
            RegisterButton.Text = "Register";
            RegisterButton.UseVisualStyleBackColor = false;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // WarningNameLabel
            // 
            WarningNameLabel.AutoSize = true;
            WarningNameLabel.ForeColor = Color.Tomato;
            WarningNameLabel.Location = new Point(486, 67);
            WarningNameLabel.Name = "WarningNameLabel";
            WarningNameLabel.Size = new Size(0, 35);
            WarningNameLabel.TabIndex = 12;
            // 
            // WarningEmailLabel
            // 
            WarningEmailLabel.AutoSize = true;
            WarningEmailLabel.Font = new Font("Arial", 12.1558447F, FontStyle.Regular, GraphicsUnit.Point, 0);
            WarningEmailLabel.ForeColor = Color.Tomato;
            WarningEmailLabel.Location = new Point(472, 126);
            WarningEmailLabel.Name = "WarningEmailLabel";
            WarningEmailLabel.Size = new Size(0, 32);
            WarningEmailLabel.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12.1558447F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Tomato;
            label1.Location = new Point(804, 412);
            label1.Name = "label1";
            label1.Size = new Size(0, 32);
            label1.TabIndex = 14;
            // 
            // WarningHobbiesLabel
            // 
            WarningHobbiesLabel.AutoSize = true;
            WarningHobbiesLabel.Font = new Font("Arial", 12.1558447F, FontStyle.Regular, GraphicsUnit.Point, 0);
            WarningHobbiesLabel.ForeColor = Color.Tomato;
            WarningHobbiesLabel.Location = new Point(793, 412);
            WarningHobbiesLabel.Name = "WarningHobbiesLabel";
            WarningHobbiesLabel.Size = new Size(0, 32);
            WarningHobbiesLabel.TabIndex = 15;
            // 
            // RegisterationForm
            // 
            AutoScaleDimensions = new SizeF(17F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1169, 703);
            Controls.Add(WarningHobbiesLabel);
            Controls.Add(label1);
            Controls.Add(WarningEmailLabel);
            Controls.Add(WarningNameLabel);
            Controls.Add(RegisterButton);
            Controls.Add(EmailTextBox);
            Controls.Add(NameTextBox);
            Controls.Add(HobbiesGroupBox);
            Controls.Add(EmailLabel);
            Controls.Add(GenderGroupBox);
            Controls.Add(NameLabel);
            Font = new Font("Arial", 14.0259743F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 4, 5, 4);
            Name = "RegisterationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registeration";
            Load += RegisterationForm_Load;
            GenderGroupBox.ResumeLayout(false);
            GenderGroupBox.PerformLayout();
            HobbiesGroupBox.ResumeLayout(false);
            HobbiesGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NameLabel;
        private Label label3;
        private Label label4;
        private GroupBox GenderGroupBox;
        private Label EmailLabel;
        private Label GenderLabel;
        private Label HobbiesLabel;
        private RadioButton MaleRadioButton;
        private RadioButton FemaleRadioButton;
        private GroupBox HobbiesGroupBox;
        private CheckBox SwimmingCheckBox;
        private CheckBox TennisCheckBox;
        private CheckBox FootballCheckBox;
        private TextBox NameTextBox;
        private TextBox EmailTextBox;
        private Button RegisterButton;
        private Label WarningNameLabel;
        private Label WarningEmailLabel;
        private Label label1;
        private Label WarningHobbiesLabel;
    }
}
