namespace Recearch_Pow
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
            this.checkedListBoxClassic = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxModified = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxRandomNumbers = new System.Windows.Forms.TextBox();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.radioButtonRand = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLength = new System.Windows.Forms.TextBox();
            this.textBoxBits = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonCompare = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBoxClassic
            // 
            this.checkedListBoxClassic.FormattingEnabled = true;
            this.checkedListBoxClassic.Location = new System.Drawing.Point(12, 42);
            this.checkedListBoxClassic.Name = "checkedListBoxClassic";
            this.checkedListBoxClassic.Size = new System.Drawing.Size(172, 319);
            this.checkedListBoxClassic.TabIndex = 0;
            // 
            // checkedListBoxModified
            // 
            this.checkedListBoxModified.FormattingEnabled = true;
            this.checkedListBoxModified.Location = new System.Drawing.Point(200, 42);
            this.checkedListBoxModified.Name = "checkedListBoxModified";
            this.checkedListBoxModified.Size = new System.Drawing.Size(172, 319);
            this.checkedListBoxModified.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Classic Methods";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Modified Methods";
            // 
            // textBoxRandomNumbers
            // 
            this.textBoxRandomNumbers.Location = new System.Drawing.Point(3, 49);
            this.textBoxRandomNumbers.Name = "textBoxRandomNumbers";
            this.textBoxRandomNumbers.Size = new System.Drawing.Size(100, 20);
            this.textBoxRandomNumbers.TabIndex = 4;
            this.textBoxRandomNumbers.Text = "10";
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Location = new System.Drawing.Point(3, 3);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(79, 17);
            this.radioButtonAll.TabIndex = 5;
            this.radioButtonAll.Text = "All numbers";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            // 
            // radioButtonRand
            // 
            this.radioButtonRand.AutoSize = true;
            this.radioButtonRand.Checked = true;
            this.radioButtonRand.Location = new System.Drawing.Point(3, 26);
            this.radioButtonRand.Name = "radioButtonRand";
            this.radioButtonRand.Size = new System.Drawing.Size(108, 17);
            this.radioButtonRand.TabIndex = 6;
            this.radioButtonRand.TabStop = true;
            this.radioButtonRand.Text = "Random numbers";
            this.radioButtonRand.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.radioButtonAll);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonRand);
            this.flowLayoutPanel1.Controls.Add(this.textBoxRandomNumbers);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(381, 90);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(183, 83);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Max length";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Number of bits";
            // 
            // textBoxLength
            // 
            this.textBoxLength.Location = new System.Drawing.Point(464, 35);
            this.textBoxLength.Name = "textBoxLength";
            this.textBoxLength.Size = new System.Drawing.Size(100, 20);
            this.textBoxLength.TabIndex = 10;
            this.textBoxLength.Text = "3-15-4";
            // 
            // textBoxBits
            // 
            this.textBoxBits.Location = new System.Drawing.Point(464, 64);
            this.textBoxBits.Name = "textBoxBits";
            this.textBoxBits.Size = new System.Drawing.Size(100, 20);
            this.textBoxBits.TabIndex = 11;
            this.textBoxBits.Text = "40,60,80";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(384, 180);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 38);
            this.buttonStart.TabIndex = 12;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonCompare
            // 
            this.buttonCompare.Location = new System.Drawing.Point(465, 180);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(99, 38);
            this.buttonCompare.TabIndex = 13;
            this.buttonCompare.Text = "Compare Classic and Modified";
            this.buttonCompare.UseVisualStyleBackColor = true;
            this.buttonCompare.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 372);
            this.Controls.Add(this.buttonCompare);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxBits);
            this.Controls.Add(this.textBoxLength);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBoxModified);
            this.Controls.Add(this.checkedListBoxClassic);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxClassic;
        private System.Windows.Forms.CheckedListBox checkedListBoxModified;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxRandomNumbers;
        private System.Windows.Forms.RadioButton radioButtonAll;
        private System.Windows.Forms.RadioButton radioButtonRand;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLength;
        private System.Windows.Forms.TextBox textBoxBits;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonCompare;
    }
}

