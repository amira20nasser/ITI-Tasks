namespace Lab08WinForms
{
    partial class DrawingForm
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
            colorDialog1 = new ColorDialog();
            SuspendLayout();
            // 
            // DrawingForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1070, 658);
            Name = "DrawingForm";
            Text = "DrawingForm";
            Paint += DrawingForm_Paint;
            MouseDown += DrawingForm_MouseDown;
            MouseMove += DrawingForm_MouseMove;
            MouseUp += DrawingForm_MouseUp;
            ResumeLayout(false);
        }

        #endregion

        private ColorDialog colorDialog1;
    }
}