using TINKIN01.Chess;

namespace TINKIN01
{
    partial class Form1
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
            this.chessComponent1 = new TINKIN01.Controls.ChessComponent();
            this.SuspendLayout();
            // 
            // chessComponent1
            // 
            this.chessComponent1.Board = Chessboard.StartPosition(); ;
            this.chessComponent1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chessComponent1.Location = new System.Drawing.Point(0, 0);
            this.chessComponent1.Name = "chessComponent1";
            this.chessComponent1.Size = new System.Drawing.Size(284, 261);
            this.chessComponent1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.chessComponent1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ChessComponent chessComponent1;
    }
}

