namespace Chess
{
    partial class GameForm
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
            this.gbColor = new System.Windows.Forms.GroupBox();
            this.rbWhiteOnTop = new System.Windows.Forms.RadioButton();
            this.rbBlackOnTop = new System.Windows.Forms.RadioButton();
            this.gbPlayer1 = new System.Windows.Forms.GroupBox();
            this.rbPlayer1IsComputer = new System.Windows.Forms.RadioButton();
            this.rbPlayer1IsHuman = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbPlayer2IsComputer = new System.Windows.Forms.RadioButton();
            this.rbPlayer2IsHuman = new System.Windows.Forms.RadioButton();
            this.btPlay = new System.Windows.Forms.Button();
            this.gbColor.SuspendLayout();
            this.gbPlayer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbColor
            // 
            this.gbColor.Controls.Add(this.rbBlackOnTop);
            this.gbColor.Controls.Add(this.rbWhiteOnTop);
            this.gbColor.Location = new System.Drawing.Point(533, 12);
            this.gbColor.Name = "gbColor";
            this.gbColor.Size = new System.Drawing.Size(139, 73);
            this.gbColor.TabIndex = 0;
            this.gbColor.TabStop = false;
            this.gbColor.Text = "Кто вверху?";
            // 
            // rbWhiteOnTop
            // 
            this.rbWhiteOnTop.AutoSize = true;
            this.rbWhiteOnTop.Checked = true;
            this.rbWhiteOnTop.Location = new System.Drawing.Point(7, 20);
            this.rbWhiteOnTop.Name = "rbWhiteOnTop";
            this.rbWhiteOnTop.Size = new System.Drawing.Size(95, 17);
            this.rbWhiteOnTop.TabIndex = 0;
            this.rbWhiteOnTop.TabStop = true;
            this.rbWhiteOnTop.Text = "Белые вверху";
            this.rbWhiteOnTop.UseVisualStyleBackColor = true;
            // 
            // rbBlackOnTop
            // 
            this.rbBlackOnTop.AutoSize = true;
            this.rbBlackOnTop.Location = new System.Drawing.Point(7, 43);
            this.rbBlackOnTop.Name = "rbBlackOnTop";
            this.rbBlackOnTop.Size = new System.Drawing.Size(90, 17);
            this.rbBlackOnTop.TabIndex = 1;
            this.rbBlackOnTop.Text = "Белые внизу";
            this.rbBlackOnTop.UseVisualStyleBackColor = true;
            this.rbBlackOnTop.CheckedChanged += new System.EventHandler(this.rbBlackOnTop_CheckedChanged);
            // 
            // gbPlayer1
            // 
            this.gbPlayer1.Controls.Add(this.rbPlayer1IsComputer);
            this.gbPlayer1.Controls.Add(this.rbPlayer1IsHuman);
            this.gbPlayer1.Location = new System.Drawing.Point(533, 91);
            this.gbPlayer1.Name = "gbPlayer1";
            this.gbPlayer1.Size = new System.Drawing.Size(139, 73);
            this.gbPlayer1.TabIndex = 2;
            this.gbPlayer1.TabStop = false;
            this.gbPlayer1.Text = "Первый игрок будет..";
            // 
            // rbPlayer1IsComputer
            // 
            this.rbPlayer1IsComputer.AutoSize = true;
            this.rbPlayer1IsComputer.Location = new System.Drawing.Point(7, 43);
            this.rbPlayer1IsComputer.Name = "rbPlayer1IsComputer";
            this.rbPlayer1IsComputer.Size = new System.Drawing.Size(97, 17);
            this.rbPlayer1IsComputer.TabIndex = 1;
            this.rbPlayer1IsComputer.Text = "Компьютером";
            this.rbPlayer1IsComputer.UseVisualStyleBackColor = true;
            // 
            // rbPlayer1IsHuman
            // 
            this.rbPlayer1IsHuman.AutoSize = true;
            this.rbPlayer1IsHuman.Checked = true;
            this.rbPlayer1IsHuman.Location = new System.Drawing.Point(7, 20);
            this.rbPlayer1IsHuman.Name = "rbPlayer1IsHuman";
            this.rbPlayer1IsHuman.Size = new System.Drawing.Size(83, 17);
            this.rbPlayer1IsHuman.TabIndex = 0;
            this.rbPlayer1IsHuman.TabStop = true;
            this.rbPlayer1IsHuman.Text = "Человеком";
            this.rbPlayer1IsHuman.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbPlayer2IsComputer);
            this.groupBox1.Controls.Add(this.rbPlayer2IsHuman);
            this.groupBox1.Location = new System.Drawing.Point(533, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 73);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Второй игрок будет..";
            // 
            // rbPlayer2IsComputer
            // 
            this.rbPlayer2IsComputer.AutoSize = true;
            this.rbPlayer2IsComputer.Checked = true;
            this.rbPlayer2IsComputer.Location = new System.Drawing.Point(7, 43);
            this.rbPlayer2IsComputer.Name = "rbPlayer2IsComputer";
            this.rbPlayer2IsComputer.Size = new System.Drawing.Size(97, 17);
            this.rbPlayer2IsComputer.TabIndex = 1;
            this.rbPlayer2IsComputer.TabStop = true;
            this.rbPlayer2IsComputer.Text = "Компьютером";
            this.rbPlayer2IsComputer.UseVisualStyleBackColor = true;
            // 
            // rbPlayer2IsHuman
            // 
            this.rbPlayer2IsHuman.AutoSize = true;
            this.rbPlayer2IsHuman.Location = new System.Drawing.Point(7, 20);
            this.rbPlayer2IsHuman.Name = "rbPlayer2IsHuman";
            this.rbPlayer2IsHuman.Size = new System.Drawing.Size(83, 17);
            this.rbPlayer2IsHuman.TabIndex = 0;
            this.rbPlayer2IsHuman.Text = "Человеком";
            this.rbPlayer2IsHuman.UseVisualStyleBackColor = true;
            // 
            // btPlay
            // 
            this.btPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btPlay.Location = new System.Drawing.Point(533, 304);
            this.btPlay.Name = "btPlay";
            this.btPlay.Size = new System.Drawing.Size(139, 42);
            this.btPlay.TabIndex = 4;
            this.btPlay.Text = "Играть!";
            this.btPlay.UseVisualStyleBackColor = true;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 501);
            this.Controls.Add(this.btPlay);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbPlayer1);
            this.Controls.Add(this.gbColor);
            this.Name = "GameForm";
            this.Text = "Сыграем?";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.gbColor.ResumeLayout(false);
            this.gbColor.PerformLayout();
            this.gbPlayer1.ResumeLayout(false);
            this.gbPlayer1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbColor;
        private System.Windows.Forms.RadioButton rbBlackOnTop;
        private System.Windows.Forms.RadioButton rbWhiteOnTop;
        private System.Windows.Forms.GroupBox gbPlayer1;
        private System.Windows.Forms.RadioButton rbPlayer1IsComputer;
        private System.Windows.Forms.RadioButton rbPlayer1IsHuman;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbPlayer2IsComputer;
        private System.Windows.Forms.RadioButton rbPlayer2IsHuman;
        private System.Windows.Forms.Button btPlay;
    }
}

