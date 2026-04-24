namespace DBWinFormsApp
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
            IdLabel = new Label();
            textId = new TextBox();
            textName = new TextBox();
            label1 = new Label();
            LocationLabel = new Label();
            textLoc = new TextBox();
            btnOpen = new Button();
            btnAdd = new Button();
            ListBox1 = new ListBox();
            button1 = new Button();
            label2 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // IdLabel
            // 
            IdLabel.AutoSize = true;
            IdLabel.Location = new Point(46, 78);
            IdLabel.Name = "IdLabel";
            IdLabel.Size = new Size(28, 25);
            IdLabel.TabIndex = 0;
            IdLabel.Text = "Id";
            // 
            // textId
            // 
            textId.Location = new Point(123, 75);
            textId.Name = "textId";
            textId.Size = new Size(160, 33);
            textId.TabIndex = 1;
            // 
            // textName
            // 
            textName.Location = new Point(123, 124);
            textName.Name = "textName";
            textName.Size = new Size(160, 33);
            textName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 124);
            label1.Name = "label1";
            label1.Size = new Size(62, 25);
            label1.TabIndex = 3;
            label1.Text = "Name";
            // 
            // LocationLabel
            // 
            LocationLabel.AutoSize = true;
            LocationLabel.Location = new Point(33, 177);
            LocationLabel.Name = "LocationLabel";
            LocationLabel.Size = new Size(84, 25);
            LocationLabel.TabIndex = 4;
            LocationLabel.Text = "Location";
            // 
            // textLoc
            // 
            textLoc.Location = new Point(123, 174);
            textLoc.Name = "textLoc";
            textLoc.Size = new Size(160, 33);
            textLoc.TabIndex = 5;
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(37, 12);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(190, 42);
            btnOpen.TabIndex = 6;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(250, 15);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(200, 39);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Add / Modify";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // ListBox1
            // 
            ListBox1.FormattingEnabled = true;
            ListBox1.Location = new Point(517, 97);
            ListBox1.Name = "ListBox1";
            ListBox1.Size = new Size(210, 179);
            ListBox1.TabIndex = 8;
            // 
            // button1
            // 
            button1.Location = new Point(517, 15);
            button1.Name = "button1";
            button1.Size = new Size(230, 41);
            button1.TabIndex = 9;
            button1.Text = "Get Data";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(517, 59);
            label2.Name = "label2";
            label2.Size = new Size(175, 25);
            label2.TabIndex = 10;
            label2.Text = "Department Names";
            // 
            // button2
            // 
            button2.Location = new Point(73, 283);
            button2.Name = "button2";
            button2.Size = new Size(200, 39);
            button2.TabIndex = 11;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(ListBox1);
            Controls.Add(btnAdd);
            Controls.Add(btnOpen);
            Controls.Add(textLoc);
            Controls.Add(LocationLabel);
            Controls.Add(label1);
            Controls.Add(textName);
            Controls.Add(textId);
            Controls.Add(IdLabel);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label IdLabel;
        private TextBox textId;
        private TextBox textName;
        private Label label1;
        private Label LocationLabel;
        private TextBox textLoc;
        private Button btnOpen;
        private Button btnAdd;
        private ListBox ListBox1;
        private Button button1;
        private Label label2;
        private Button button2;
    }
}
