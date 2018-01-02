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
            this.button_Queen = new System.Windows.Forms.Button();
            this.button_Knight = new System.Windows.Forms.Button();
            this.button_Bishop = new System.Windows.Forms.Button();
            this.buttpn_Rook = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Queen
            // 
            this.button_Queen.Location = new System.Drawing.Point(72, 12);
            this.button_Queen.Name = "button_Queen";
            this.button_Queen.Size = new System.Drawing.Size(75, 23);
            this.button_Queen.TabIndex = 4;
            this.button_Queen.Text = "Queen";
            this.button_Queen.UseVisualStyleBackColor = true;
            this.button_Queen.Click += new System.EventHandler(this.button_Queen_Click);
            // 
            // button_Knight
            // 
            this.button_Knight.Location = new System.Drawing.Point(72, 41);
            this.button_Knight.Name = "button_Knight";
            this.button_Knight.Size = new System.Drawing.Size(75, 23);
            this.button_Knight.TabIndex = 5;
            this.button_Knight.Text = "Knight";
            this.button_Knight.UseVisualStyleBackColor = true;
            this.button_Knight.Click += new System.EventHandler(this.button_Knight_Click);
            // 
            // button_Bishop
            // 
            this.button_Bishop.Location = new System.Drawing.Point(72, 70);
            this.button_Bishop.Name = "button_Bishop";
            this.button_Bishop.Size = new System.Drawing.Size(75, 23);
            this.button_Bishop.TabIndex = 6;
            this.button_Bishop.Text = "Bishop";
            this.button_Bishop.UseCompatibleTextRendering = true;
            this.button_Bishop.UseVisualStyleBackColor = true;
            this.button_Bishop.Click += new System.EventHandler(this.button_Bishop_Click);
            // 
            // buttpn_Rook
            // 
            this.buttpn_Rook.Location = new System.Drawing.Point(72, 99);
            this.buttpn_Rook.Name = "buttpn_Rook";
            this.buttpn_Rook.Size = new System.Drawing.Size(75, 23);
            this.buttpn_Rook.TabIndex = 7;
            this.buttpn_Rook.Text = "Rook";
            this.buttpn_Rook.UseVisualStyleBackColor = true;
            this.buttpn_Rook.Click += new System.EventHandler(this.buttpn_Rook_Click);
            // 
            // Choose_Figure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 131);
            this.Controls.Add(this.buttpn_Rook);
            this.Controls.Add(this.button_Bishop);
            this.Controls.Add(this.button_Knight);
            this.Controls.Add(this.button_Queen);
            this.Name = "Choose_Figure";
            this.Text = "Choose_Figure";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Queen;
        private System.Windows.Forms.Button button_Knight;
        private System.Windows.Forms.Button button_Bishop;
        private System.Windows.Forms.Button buttpn_Rook;
    }
}