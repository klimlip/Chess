namespace Chess
{
    partial class Choose_Figure
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
            this.radioButton_Queen = new System.Windows.Forms.RadioButton();
            this.radioButton_Knight = new System.Windows.Forms.RadioButton();
            this.radioButton_Bishop = new System.Windows.Forms.RadioButton();
            this.radioButton_Rook = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // radioButton_Queen
            // 
            this.radioButton_Queen.AutoSize = true;
            this.radioButton_Queen.Location = new System.Drawing.Point(83, 12);
            this.radioButton_Queen.Name = "radioButton_Queen";
            this.radioButton_Queen.Size = new System.Drawing.Size(57, 17);
            this.radioButton_Queen.TabIndex = 0;
            this.radioButton_Queen.TabStop = true;
            this.radioButton_Queen.Text = "Queen";
            this.radioButton_Queen.UseVisualStyleBackColor = true;
            this.radioButton_Queen.CheckedChanged += new System.EventHandler(this.radioButton_Queen_CheckedChanged);
            // 
            // radioButton_Knight
            // 
            this.radioButton_Knight.AutoSize = true;
            this.radioButton_Knight.Location = new System.Drawing.Point(83, 35);
            this.radioButton_Knight.Name = "radioButton_Knight";
            this.radioButton_Knight.Size = new System.Drawing.Size(55, 17);
            this.radioButton_Knight.TabIndex = 1;
            this.radioButton_Knight.TabStop = true;
            this.radioButton_Knight.Text = "Knight";
            this.radioButton_Knight.UseVisualStyleBackColor = true;
            this.radioButton_Knight.CheckedChanged += new System.EventHandler(this.radioButton_Queen_CheckedChanged);
            // 
            // radioButton_Bishop
            // 
            this.radioButton_Bishop.AutoSize = true;
            this.radioButton_Bishop.Location = new System.Drawing.Point(83, 58);
            this.radioButton_Bishop.Name = "radioButton_Bishop";
            this.radioButton_Bishop.Size = new System.Drawing.Size(57, 17);
            this.radioButton_Bishop.TabIndex = 2;
            this.radioButton_Bishop.TabStop = true;
            this.radioButton_Bishop.Text = "Bishop";
            this.radioButton_Bishop.UseVisualStyleBackColor = true;
            this.radioButton_Bishop.CheckedChanged += new System.EventHandler(this.radioButton_Queen_CheckedChanged);
            // 
            // radioButton_Rook
            // 
            this.radioButton_Rook.AutoSize = true;
            this.radioButton_Rook.Location = new System.Drawing.Point(83, 81);
            this.radioButton_Rook.Name = "radioButton_Rook";
            this.radioButton_Rook.Size = new System.Drawing.Size(51, 17);
            this.radioButton_Rook.TabIndex = 3;
            this.radioButton_Rook.TabStop = true;
            this.radioButton_Rook.Text = "Rook";
            this.radioButton_Rook.UseVisualStyleBackColor = true;
            this.radioButton_Rook.CheckedChanged += new System.EventHandler(this.radioButton_Queen_CheckedChanged);
            // 
            // Choose_Figure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 104);
            this.Controls.Add(this.radioButton_Rook);
            this.Controls.Add(this.radioButton_Bishop);
            this.Controls.Add(this.radioButton_Knight);
            this.Controls.Add(this.radioButton_Queen);
            this.Name = "Choose_Figure";
            this.Text = "Choose_Figure";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton_Queen;
        private System.Windows.Forms.RadioButton radioButton_Knight;
        private System.Windows.Forms.RadioButton radioButton_Bishop;
        private System.Windows.Forms.RadioButton radioButton_Rook;
    }
}