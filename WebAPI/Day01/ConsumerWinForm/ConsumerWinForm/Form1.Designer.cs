namespace ConsumerWinForm
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            richTextBox1 = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(165, 38);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(160, 33);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 38);
            label1.Name = "label1";
            label1.Size = new Size(62, 25);
            label1.TabIndex = 1;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 166);
            label2.Name = "label2";
            label2.Size = new Size(108, 25);
            label2.TabIndex = 3;
            label2.Text = "Description";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(165, 166);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(160, 33);
            textBox2.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 109);
            label3.Name = "label3";
            label3.Size = new Size(86, 25);
            label3.TabIndex = 5;
            label3.Text = "Duration";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(165, 106);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(160, 33);
            textBox3.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(111, 245);
            button1.Name = "button1";
            button1.Size = new Size(120, 37);
            button1.TabIndex = 6;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(441, 38);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 66;
            dataGridView1.Size = new Size(616, 462);
            dataGridView1.TabIndex = 7;
            // 
            // button2
            // 
            button2.Location = new Point(720, 542);
            button2.Name = "button2";
            button2.Size = new Size(120, 37);
            button2.TabIndex = 8;
            button2.Text = "Get All";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(26, 26);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(27, 300);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(344, 263);
            richTextBox1.TabIndex = 9;
            richTextBox1.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1098, 591);
            Controls.Add(richTextBox1);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Button button1;
        private DataGridView dataGridView1;
        private Button button2;
        private ContextMenuStrip contextMenuStrip1;
        private RichTextBox richTextBox1;
    }
}
