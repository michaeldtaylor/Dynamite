namespace Dynamite.UI
{
    partial class DynamiteStatusForm
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
            this.ipAddressLabel = new System.Windows.Forms.Label();
            this.ipAddressTextBox = new System.Windows.Forms.TextBox();
            this.lastCheckedTextBox = new System.Windows.Forms.TextBox();
            this.lastCheckedLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ipAddressLabel
            // 
            this.ipAddressLabel.AutoSize = true;
            this.ipAddressLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipAddressLabel.Location = new System.Drawing.Point(12, 25);
            this.ipAddressLabel.Name = "ipAddressLabel";
            this.ipAddressLabel.Size = new System.Drawing.Size(70, 13);
            this.ipAddressLabel.TabIndex = 0;
            this.ipAddressLabel.Text = "IP address:";
            // 
            // ipAddressTextBox
            // 
            this.ipAddressTextBox.Enabled = false;
            this.ipAddressTextBox.Location = new System.Drawing.Point(109, 21);
            this.ipAddressTextBox.Name = "ipAddressTextBox";
            this.ipAddressTextBox.Size = new System.Drawing.Size(263, 21);
            this.ipAddressTextBox.TabIndex = 1;
            this.ipAddressTextBox.Text = "Unknown";
            // 
            // lastCheckedTextBox
            // 
            this.lastCheckedTextBox.Enabled = false;
            this.lastCheckedTextBox.Location = new System.Drawing.Point(109, 59);
            this.lastCheckedTextBox.Name = "lastCheckedTextBox";
            this.lastCheckedTextBox.Size = new System.Drawing.Size(263, 21);
            this.lastCheckedTextBox.TabIndex = 3;
            this.lastCheckedTextBox.Text = "Unknown";
            // 
            // lastCheckedLabel
            // 
            this.lastCheckedLabel.AutoSize = true;
            this.lastCheckedLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastCheckedLabel.Location = new System.Drawing.Point(12, 63);
            this.lastCheckedLabel.Name = "lastCheckedLabel";
            this.lastCheckedLabel.Size = new System.Drawing.Size(84, 13);
            this.lastCheckedLabel.TabIndex = 2;
            this.lastCheckedLabel.Text = "Last checked:";
            // 
            // DynamiteStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 111);
            this.Controls.Add(this.lastCheckedTextBox);
            this.Controls.Add(this.lastCheckedLabel);
            this.Controls.Add(this.ipAddressTextBox);
            this.Controls.Add(this.ipAddressLabel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DynamiteStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dynamite";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ipAddressLabel;
        private System.Windows.Forms.TextBox ipAddressTextBox;
        private System.Windows.Forms.TextBox lastCheckedTextBox;
        private System.Windows.Forms.Label lastCheckedLabel;
    }
}