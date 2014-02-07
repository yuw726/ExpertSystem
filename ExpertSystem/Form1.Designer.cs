namespace ExpertSystem
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.questionLabel1 = new System.Windows.Forms.Label();
            this.nextButton1 = new System.Windows.Forms.Button();
            this.welcomeRichTextBox1 = new System.Windows.Forms.RichTextBox();
            this.exitButton1 = new System.Windows.Forms.Button();
            this.resultsButton1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // questionLabel1
            // 
            this.questionLabel1.AutoSize = true;
            this.questionLabel1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.questionLabel1.Location = new System.Drawing.Point(37, 25);
            this.questionLabel1.Name = "questionLabel1";
            this.questionLabel1.Size = new System.Drawing.Size(76, 19);
            this.questionLabel1.TabIndex = 0;
            this.questionLabel1.Text = "Question:";
            // 
            // nextButton1
            // 
            this.nextButton1.Location = new System.Drawing.Point(561, 242);
            this.nextButton1.Name = "nextButton1";
            this.nextButton1.Size = new System.Drawing.Size(103, 40);
            this.nextButton1.TabIndex = 3;
            this.nextButton1.Text = "Далее";
            this.nextButton1.UseVisualStyleBackColor = true;
            this.nextButton1.Click += new System.EventHandler(this.nextButton1_Click);
            // 
            // welcomeRichTextBox1
            // 
            this.welcomeRichTextBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.welcomeRichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.welcomeRichTextBox1.Font = new System.Drawing.Font("Monotype Corsiva", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.welcomeRichTextBox1.Location = new System.Drawing.Point(24, 19);
            this.welcomeRichTextBox1.Name = "welcomeRichTextBox1";
            this.welcomeRichTextBox1.ReadOnly = true;
            this.welcomeRichTextBox1.Size = new System.Drawing.Size(695, 193);
            this.welcomeRichTextBox1.TabIndex = 7;
            this.welcomeRichTextBox1.Text = "Добро пожаловать! \nДанная экспертная система позволит Вам выбрать наиболее подход" +
    "ящий для Вас вид спорта";
            // 
            // exitButton1
            // 
            this.exitButton1.Location = new System.Drawing.Point(294, 242);
            this.exitButton1.Name = "exitButton1";
            this.exitButton1.Size = new System.Drawing.Size(117, 40);
            this.exitButton1.TabIndex = 8;
            this.exitButton1.Text = "Выход";
            this.exitButton1.UseVisualStyleBackColor = true;
            this.exitButton1.Visible = false;
            this.exitButton1.Click += new System.EventHandler(this.exitButton1_Click);
            // 
            // resultsButton1
            // 
            this.resultsButton1.Location = new System.Drawing.Point(549, 237);
            this.resultsButton1.Name = "resultsButton1";
            this.resultsButton1.Size = new System.Drawing.Size(124, 50);
            this.resultsButton1.TabIndex = 9;
            this.resultsButton1.Text = "Показать результаты";
            this.resultsButton1.UseVisualStyleBackColor = true;
            this.resultsButton1.Visible = false;
            this.resultsButton1.Click += new System.EventHandler(this.resultsButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 304);
            this.Controls.Add(this.resultsButton1);
            this.Controls.Add(this.exitButton1);
            this.Controls.Add(this.welcomeRichTextBox1);
            this.Controls.Add(this.nextButton1);
            this.Controls.Add(this.questionLabel1);
            this.Name = "Form1";
            this.Text = "Expert System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label questionLabel1;
        private System.Windows.Forms.Button nextButton1;
        private System.Windows.Forms.RichTextBox welcomeRichTextBox1;
        private System.Windows.Forms.Button exitButton1;
        private System.Windows.Forms.Button resultsButton1;
    }
}

