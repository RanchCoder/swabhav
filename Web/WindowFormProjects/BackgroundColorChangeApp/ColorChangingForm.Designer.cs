
namespace BackgroundColorChangeApp
{
    partial class ColorChangingForm
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
            this.redButton = new System.Windows.Forms.Button();
            this.blueButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // redButton
            // 
            this.redButton.Location = new System.Drawing.Point(257, 112);
            this.redButton.Name = "redButton";
            this.redButton.Size = new System.Drawing.Size(75, 23);
            this.redButton.TabIndex = 0;
            this.redButton.Text = "Red";
            this.redButton.UseVisualStyleBackColor = true;
            this.redButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // blueButton
            // 
            this.blueButton.Location = new System.Drawing.Point(445, 112);
            this.blueButton.Name = "blueButton";
            this.blueButton.Size = new System.Drawing.Size(75, 23);
            this.blueButton.TabIndex = 1;
            this.blueButton.Text = "Blue";
            this.blueButton.UseVisualStyleBackColor = true;
            this.blueButton.Click += new System.EventHandler(this.blueButton_Click);
            // 
            // ColorChangingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.blueButton);
            this.Controls.Add(this.redButton);
            this.Name = "ColorChangingForm";
            this.Text = "ColorChangingForm";
            this.Load += new System.EventHandler(this.ColorChangingForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button redButton;
        private System.Windows.Forms.Button blueButton;
    }
}