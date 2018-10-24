namespace Server
{
    partial class Server
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
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnBroadcast = new System.Windows.Forms.Button();
            this.lblServer = new System.Windows.Forms.Label();
            this.rtxtMessages = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 42);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(414, 20);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.Text = "Text";
            // 
            // btnBroadcast
            // 
            this.btnBroadcast.Location = new System.Drawing.Point(434, 40);
            this.btnBroadcast.Name = "btnBroadcast";
            this.btnBroadcast.Size = new System.Drawing.Size(75, 23);
            this.btnBroadcast.TabIndex = 1;
            this.btnBroadcast.Text = "Broadcast";
            this.btnBroadcast.UseVisualStyleBackColor = true;
            this.btnBroadcast.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(9, 9);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(41, 13);
            this.lblServer.TabIndex = 2;
            this.lblServer.Text = "Server:";
            // 
            // rtxtMessages
            // 
            this.rtxtMessages.Location = new System.Drawing.Point(12, 90);
            this.rtxtMessages.Name = "rtxtMessages";
            this.rtxtMessages.Size = new System.Drawing.Size(497, 159);
            this.rtxtMessages.TabIndex = 3;
            this.rtxtMessages.Text = "Messages\n";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 261);
            this.Controls.Add(this.rtxtMessages);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.btnBroadcast);
            this.Controls.Add(this.txtMessage);
            this.Name = "Server";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Server_FormClosing);
            this.Load += new System.EventHandler(this.Server_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnBroadcast;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.RichTextBox rtxtMessages;
    }
}

