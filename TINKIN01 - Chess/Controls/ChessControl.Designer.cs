namespace TINKIN01.Controls
{
    partial class ChessControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Alert = new TINKIN01.Controls.ChessControlAlert();
            this.SuspendLayout();
            // 
            // Alert
            // 
            this.Alert.BackColor = System.Drawing.Color.Red;
            this.Alert.Location = new System.Drawing.Point(56, 87);
            this.Alert.Name = "Alert";
            this.Alert.Size = new System.Drawing.Size(292, 128);
            this.Alert.TabIndex = 0;
            this.Alert.Visible = false;
            // 
            // ChessControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Alert);
            this.Name = "ChessControl";
            this.Size = new System.Drawing.Size(415, 303);
            this.ResumeLayout(false);

        }

        #endregion

        private ChessControlAlert Alert;
    }
}
