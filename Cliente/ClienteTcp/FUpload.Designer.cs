namespace ClienteTcp
{
    partial class FUpload
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
            this.tbFile = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btEscolher = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btClearLog = new System.Windows.Forms.Button();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbFile
            // 
            this.tbFile.Enabled = false;
            this.tbFile.Location = new System.Drawing.Point(6, 42);
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(488, 20);
            this.tbFile.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(594, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Enviar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btEscolher
            // 
            this.btEscolher.Location = new System.Drawing.Point(500, 40);
            this.btEscolher.Name = "btEscolher";
            this.btEscolher.Size = new System.Drawing.Size(100, 23);
            this.btEscolher.TabIndex = 5;
            this.btEscolher.Text = "Escolher Arquivo";
            this.btEscolher.UseVisualStyleBackColor = true;
            this.btEscolher.Click += new System.EventHandler(this.btEscolher_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nome do arquivo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbFile);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btEscolher);
            this.groupBox2.Location = new System.Drawing.Point(21, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(606, 104);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Envio de arquivo";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btClearLog);
            this.groupBox3.Controls.Add(this.lbLog);
            this.groupBox3.Location = new System.Drawing.Point(12, 122);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(615, 267);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log de envio";
            // 
            // btClearLog
            // 
            this.btClearLog.Location = new System.Drawing.Point(6, 229);
            this.btClearLog.Name = "btClearLog";
            this.btClearLog.Size = new System.Drawing.Size(124, 23);
            this.btClearLog.TabIndex = 1;
            this.btClearLog.Text = "Limpar Log";
            this.btClearLog.UseVisualStyleBackColor = true;
            // 
            // lbLog
            // 
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(9, 19);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(600, 199);
            this.lbLog.TabIndex = 0;
            // 
            // FUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 401);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "FUpload";
            this.Text = "VozãoDrive";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btEscolher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.Button btClearLog;
    }
}

