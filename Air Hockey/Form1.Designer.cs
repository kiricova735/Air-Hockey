namespace Air_Hockey
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
            this.components = new System.ComponentModel.Container();
            this.playerScore1 = new System.Windows.Forms.Label();
            this.playerScore2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // playerScore1
            // 
            this.playerScore1.BackColor = System.Drawing.Color.Transparent;
            this.playerScore1.Font = new System.Drawing.Font("Millenium BdEx BT", 12F);
            this.playerScore1.Location = new System.Drawing.Point(161, 9);
            this.playerScore1.Name = "playerScore1";
            this.playerScore1.Size = new System.Drawing.Size(209, 23);
            this.playerScore1.TabIndex = 0;
            this.playerScore1.Text = "0";
            // 
            // playerScore2
            // 
            this.playerScore2.BackColor = System.Drawing.Color.Transparent;
            this.playerScore2.Font = new System.Drawing.Font("Millenium BdEx BT", 12F);
            this.playerScore2.Location = new System.Drawing.Point(590, 9);
            this.playerScore2.Name = "playerScore2";
            this.playerScore2.Size = new System.Drawing.Size(211, 23);
            this.playerScore2.TabIndex = 1;
            this.playerScore2.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.playerScore2);
            this.Controls.Add(this.playerScore1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label playerScore1;
        private System.Windows.Forms.Label playerScore2;
        private System.Windows.Forms.Timer timer1;
    }
}

