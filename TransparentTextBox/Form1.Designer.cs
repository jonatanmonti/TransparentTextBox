namespace prueba
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
            buttonPerso1 = new TransparentTextBox();
            SuspendLayout();
            // 
            // buttonPerso1
            // 
            buttonPerso1.BackAlpha = 10;
            buttonPerso1.BackColor = Color.FromArgb(0, 0, 0);
            buttonPerso1.ForeColor = Color.White;
            buttonPerso1.Location = new Point(385, 234);
            buttonPerso1.Margin = new Padding(5);
            buttonPerso1.Name = "buttonPerso1";
            buttonPerso1.Size = new Size(428, 38);
            buttonPerso1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(1400, 698);
            Controls.Add(buttonPerso1);
            Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(5);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TransparentTextBox buttonPerso1;
    }
}
