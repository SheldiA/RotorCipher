namespace ti3
{
    partial class FormMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtb_message = new System.Windows.Forms.RichTextBox();
            this.rtb_cipher = new System.Windows.Forms.RichTextBox();
            this.bt_do = new System.Windows.Forms.Button();
            this.bt_change = new System.Windows.Forms.Button();
            this.tb_key = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_EncrDecr = new System.Windows.Forms.ComboBox();
            this.cb_Algorithm = new System.Windows.Forms.ComboBox();
            this.bt_openFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // rtb_message
            // 
            this.rtb_message.Location = new System.Drawing.Point(24, 149);
            this.rtb_message.Name = "rtb_message";
            this.rtb_message.Size = new System.Drawing.Size(170, 203);
            this.rtb_message.TabIndex = 0;
            this.rtb_message.Text = "";
            // 
            // rtb_cipher
            // 
            this.rtb_cipher.Location = new System.Drawing.Point(327, 149);
            this.rtb_cipher.Name = "rtb_cipher";
            this.rtb_cipher.Size = new System.Drawing.Size(170, 203);
            this.rtb_cipher.TabIndex = 1;
            this.rtb_cipher.Text = "";
            // 
            // bt_do
            // 
            this.bt_do.Location = new System.Drawing.Point(216, 253);
            this.bt_do.Name = "bt_do";
            this.bt_do.Size = new System.Drawing.Size(92, 49);
            this.bt_do.TabIndex = 2;
            this.bt_do.Text = "DO";
            this.bt_do.UseVisualStyleBackColor = true;
            this.bt_do.Click += new System.EventHandler(this.bt_do_Click);
            // 
            // bt_change
            // 
            this.bt_change.Location = new System.Drawing.Point(221, 214);
            this.bt_change.Name = "bt_change";
            this.bt_change.Size = new System.Drawing.Size(87, 21);
            this.bt_change.TabIndex = 3;
            this.bt_change.Text = "<===";
            this.bt_change.UseVisualStyleBackColor = true;
            this.bt_change.Click += new System.EventHandler(this.bt_change_Click);
            // 
            // tb_key
            // 
            this.tb_key.Location = new System.Drawing.Point(24, 87);
            this.tb_key.Name = "tb_key";
            this.tb_key.Size = new System.Drawing.Size(302, 20);
            this.tb_key.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter key:";
            // 
            // cb_EncrDecr
            // 
            this.cb_EncrDecr.FormattingEnabled = true;
            this.cb_EncrDecr.Items.AddRange(new object[] {
            "Encrypt",
            "Decrypt"});
            this.cb_EncrDecr.Location = new System.Drawing.Point(369, 88);
            this.cb_EncrDecr.Name = "cb_EncrDecr";
            this.cb_EncrDecr.Size = new System.Drawing.Size(127, 21);
            this.cb_EncrDecr.TabIndex = 6;
            // 
            // cb_Algorithm
            // 
            this.cb_Algorithm.FormattingEnabled = true;
            this.cb_Algorithm.Items.AddRange(new object[] {
            "Enigma",
            "lfsrRotor"});
            this.cb_Algorithm.Location = new System.Drawing.Point(367, 34);
            this.cb_Algorithm.Name = "cb_Algorithm";
            this.cb_Algorithm.Size = new System.Drawing.Size(129, 21);
            this.cb_Algorithm.TabIndex = 7;
            // 
            // bt_openFile
            // 
            this.bt_openFile.Location = new System.Drawing.Point(207, 324);
            this.bt_openFile.Name = "bt_openFile";
            this.bt_openFile.Size = new System.Drawing.Size(109, 27);
            this.bt_openFile.TabIndex = 8;
            this.bt_openFile.Text = "Open file...";
            this.bt_openFile.UseVisualStyleBackColor = true;
            this.bt_openFile.Click += new System.EventHandler(this.bt_openFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(526, 375);
            this.Controls.Add(this.bt_openFile);
            this.Controls.Add(this.cb_Algorithm);
            this.Controls.Add(this.cb_EncrDecr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_key);
            this.Controls.Add(this.bt_change);
            this.Controls.Add(this.bt_do);
            this.Controls.Add(this.rtb_cipher);
            this.Controls.Add(this.rtb_message);
            this.Name = "FormMain";
            this.Text = "Rotor cipher machines";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_message;
        private System.Windows.Forms.RichTextBox rtb_cipher;
        private System.Windows.Forms.Button bt_do;
        private System.Windows.Forms.Button bt_change;
        private System.Windows.Forms.TextBox tb_key;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_EncrDecr;
        private System.Windows.Forms.ComboBox cb_Algorithm;
        private System.Windows.Forms.Button bt_openFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

