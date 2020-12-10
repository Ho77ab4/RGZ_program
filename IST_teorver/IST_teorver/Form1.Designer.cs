namespace IST_teorver
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zedGraph = new ZedGraph.ZedGraphControl();
            this.zedGraph1 = new ZedGraph.ZedGraphControl();
            this.InputTB = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.procentTB2 = new System.Windows.Forms.TextBox();
            this.procentTB1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // zedGraph
            // 
            this.zedGraph.Location = new System.Drawing.Point(22, 13);
            this.zedGraph.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraph.Name = "zedGraph";
            this.zedGraph.ScrollGrace = 0D;
            this.zedGraph.ScrollMaxX = 0D;
            this.zedGraph.ScrollMaxY = 0D;
            this.zedGraph.ScrollMaxY2 = 0D;
            this.zedGraph.ScrollMinX = 0D;
            this.zedGraph.ScrollMinY = 0D;
            this.zedGraph.ScrollMinY2 = 0D;
            this.zedGraph.Size = new System.Drawing.Size(665, 463);
            this.zedGraph.TabIndex = 0;
            this.zedGraph.UseExtendedPrintDialog = true;
            // 
            // zedGraph1
            // 
            this.zedGraph1.Location = new System.Drawing.Point(717, 13);
            this.zedGraph1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraph1.Name = "zedGraph1";
            this.zedGraph1.ScrollGrace = 0D;
            this.zedGraph1.ScrollMaxX = 0D;
            this.zedGraph1.ScrollMaxY = 0D;
            this.zedGraph1.ScrollMaxY2 = 0D;
            this.zedGraph1.ScrollMinX = 0D;
            this.zedGraph1.ScrollMinY = 0D;
            this.zedGraph1.ScrollMinY2 = 0D;
            this.zedGraph1.Size = new System.Drawing.Size(665, 463);
            this.zedGraph1.TabIndex = 1;
            this.zedGraph1.UseExtendedPrintDialog = true;
            // 
            // InputTB
            // 
            this.InputTB.Location = new System.Drawing.Point(22, 493);
            this.InputTB.Multiline = true;
            this.InputTB.Name = "InputTB";
            this.InputTB.Size = new System.Drawing.Size(1360, 325);
            this.InputTB.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 857);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(249, 50);
            this.button1.TabIndex = 3;
            this.button1.Text = "Рассчитать принадлежность";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 862);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Вероятность принадлежности к классу 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 890);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(279, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Вероятность принадлежности к классу 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(681, 833);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Процент";
            // 
            // procentTB2
            // 
            this.procentTB2.Location = new System.Drawing.Point(605, 891);
            this.procentTB2.Name = "procentTB2";
            this.procentTB2.Size = new System.Drawing.Size(202, 22);
            this.procentTB2.TabIndex = 11;
            // 
            // procentTB1
            // 
            this.procentTB1.Location = new System.Drawing.Point(605, 863);
            this.procentTB1.Name = "procentTB1";
            this.procentTB1.Size = new System.Drawing.Size(202, 22);
            this.procentTB1.TabIndex = 10;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(1410, 61);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(485, 340);
            this.listBox1.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1519, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(257, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Таблица частотности слов в тексте 1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1519, 447);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(257, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Таблица частотности слов в тексте 2";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(1410, 478);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(485, 340);
            this.listBox2.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 926);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.procentTB2);
            this.Controls.Add(this.procentTB1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.InputTB);
            this.Controls.Add(this.zedGraph1);
            this.Controls.Add(this.zedGraph);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraph;
        private ZedGraph.ZedGraphControl zedGraph1;
        private System.Windows.Forms.TextBox InputTB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox procentTB2;
        private System.Windows.Forms.TextBox procentTB1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox2;
    }
}

