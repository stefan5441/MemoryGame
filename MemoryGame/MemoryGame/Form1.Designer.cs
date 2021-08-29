
namespace MemoryGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnEasy = new System.Windows.Forms.Button();
            this.btnMedium = new System.Windows.Forms.Button();
            this.btnHard = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEasy
            // 
            this.btnEasy.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnEasy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEasy.Font = new System.Drawing.Font("Kepler 296", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEasy.Location = new System.Drawing.Point(334, 161);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Padding = new System.Windows.Forms.Padding(1);
            this.btnEasy.Size = new System.Drawing.Size(254, 51);
            this.btnEasy.TabIndex = 0;
            this.btnEasy.Text = "Easy Mode";
            this.btnEasy.UseVisualStyleBackColor = false;
            this.btnEasy.Click += new System.EventHandler(this.btnEasy_Click);
            // 
            // btnMedium
            // 
            this.btnMedium.BackColor = System.Drawing.Color.Gold;
            this.btnMedium.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMedium.Font = new System.Drawing.Font("Kepler 296", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMedium.Location = new System.Drawing.Point(334, 234);
            this.btnMedium.Name = "btnMedium";
            this.btnMedium.Padding = new System.Windows.Forms.Padding(1);
            this.btnMedium.Size = new System.Drawing.Size(254, 53);
            this.btnMedium.TabIndex = 1;
            this.btnMedium.Text = "Medium Mode";
            this.btnMedium.UseVisualStyleBackColor = false;
            this.btnMedium.Click += new System.EventHandler(this.btnMedium_Click);
            // 
            // btnHard
            // 
            this.btnHard.BackColor = System.Drawing.Color.DarkRed;
            this.btnHard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHard.Font = new System.Drawing.Font("Kepler 296", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnHard.Location = new System.Drawing.Point(334, 316);
            this.btnHard.Name = "btnHard";
            this.btnHard.Size = new System.Drawing.Size(254, 57);
            this.btnHard.TabIndex = 2;
            this.btnHard.Text = "Hard Mode";
            this.btnHard.UseVisualStyleBackColor = false;
            this.btnHard.Click += new System.EventHandler(this.btnHard_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuit.BackgroundImage")));
            this.btnQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuit.Location = new System.Drawing.Point(770, 431);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(132, 49);
            this.btnQuit.TabIndex = 3;
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(926, 503);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnHard);
            this.Controls.Add(this.btnMedium);
            this.Controls.Add(this.btnEasy);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEasy;
        private System.Windows.Forms.Button btnMedium;
        private System.Windows.Forms.Button btnHard;
        private System.Windows.Forms.Button btnQuit;
    }
}

