namespace File_Search
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
            textBox2 = new TextBox();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label4 = new Label();
            checkBox1 = new CheckBox();
            listBox1 = new ListBox();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(24, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 17);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 1;
            label1.Text = "Файл";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(168, 40);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(189, 27);
            textBox2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(175, 12);
            label2.Name = "label2";
            label2.Size = new Size(182, 20);
            label2.TabIndex = 3;
            label2.Text = "Слово або фраза у файлі";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(379, 39);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(138, 28);
            comboBox1.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(425, 12);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 5;
            label3.Text = "Диски";
            // 
            // button1
            // 
            button1.Location = new Point(587, 38);
            button1.Name = "button1";
            button1.Size = new Size(131, 28);
            button1.TabIndex = 6;
            button1.Text = "Знайти";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Click_Search;
            // 
            // button2
            // 
            button2.Location = new Point(777, 38);
            button2.Name = "button2";
            button2.Size = new Size(123, 28);
            button2.TabIndex = 7;
            button2.Text = "Зупинити";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Click_Stop;
            // 
            // button3
            // 
            button3.Location = new Point(955, 37);
            button3.Name = "button3";
            button3.Size = new Size(122, 29);
            button3.TabIndex = 8;
            button3.Text = "Призупинити";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Click_Suspend;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(131, 75);
            label4.Name = "label4";
            label4.Size = new Size(337, 20);
            label4.TabIndex = 10;
            label4.Text = "Результати пошуку: кількість знайдених файлів:";
            // 
            // checkBox1
            // 
            checkBox1.AccessibleDescription = "";
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(677, 74);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(115, 24);
            checkBox1.TabIndex = 11;
            checkBox1.Text = "Підкаталоги";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.Click += Click_CheckBox;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(24, 107);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(1053, 284);
            listBox1.TabIndex = 12;
            // 
            // timer1
            // 
            timer1.Tick += Tick_CheckIsAlive;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1098, 409);
            Controls.Add(listBox1);
            Controls.Add(checkBox1);
            Controls.Add(label4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Пошук файлів";
            FormClosed += Form1_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
        private Label label2;
        private ComboBox comboBox1;
        private Label label3;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label4;
        private CheckBox checkBox1;
        private ListBox listBox1;
        private System.Windows.Forms.Timer timer1;
    }
}
