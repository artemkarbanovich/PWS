namespace Lab4_WinForm
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.a1_s = new System.Windows.Forms.TextBox();
            this.a2_s = new System.Windows.Forms.TextBox();
            this.a1_k = new System.Windows.Forms.TextBox();
            this.a2_k = new System.Windows.Forms.TextBox();
            this.a1_f = new System.Windows.Forms.TextBox();
            this.a2_f = new System.Windows.Forms.TextBox();
            this.Request_btn = new System.Windows.Forms.Button();
            this.response_text = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // a1_s
            // 
            this.a1_s.Location = new System.Drawing.Point(31, 12);
            this.a1_s.Name = "a1_s";
            this.a1_s.Size = new System.Drawing.Size(158, 22);
            this.a1_s.TabIndex = 1;
            this.a1_s.Text = "string1";
            // 
            // a2_s
            // 
            this.a2_s.Location = new System.Drawing.Point(253, 12);
            this.a2_s.Name = "a2_s";
            this.a2_s.Size = new System.Drawing.Size(158, 22);
            this.a2_s.TabIndex = 2;
            this.a2_s.Text = "string2";
            // 
            // a1_k
            // 
            this.a1_k.Location = new System.Drawing.Point(31, 62);
            this.a1_k.Name = "a1_k";
            this.a1_k.Size = new System.Drawing.Size(158, 22);
            this.a1_k.TabIndex = 3;
            this.a1_k.Text = "5";
            // 
            // a2_k
            // 
            this.a2_k.Location = new System.Drawing.Point(253, 62);
            this.a2_k.Name = "a2_k";
            this.a2_k.Size = new System.Drawing.Size(158, 22);
            this.a2_k.TabIndex = 4;
            this.a2_k.Text = "10";
            // 
            // a1_f
            // 
            this.a1_f.Location = new System.Drawing.Point(31, 119);
            this.a1_f.Name = "a1_f";
            this.a1_f.Size = new System.Drawing.Size(158, 22);
            this.a1_f.TabIndex = 5;
            this.a1_f.Text = "55,5";
            // 
            // a2_f
            // 
            this.a2_f.Location = new System.Drawing.Point(253, 119);
            this.a2_f.Name = "a2_f";
            this.a2_f.Size = new System.Drawing.Size(158, 22);
            this.a2_f.TabIndex = 6;
            this.a2_f.Text = "27,9";
            // 
            // Request_btn
            // 
            this.Request_btn.Location = new System.Drawing.Point(576, 49);
            this.Request_btn.Name = "Request_btn";
            this.Request_btn.Size = new System.Drawing.Size(97, 48);
            this.Request_btn.TabIndex = 7;
            this.Request_btn.Text = "Request";
            this.Request_btn.UseVisualStyleBackColor = true;
            this.Request_btn.Click += new System.EventHandler(this.Request_btn_Click);
            // 
            // response_text
            // 
            this.response_text.Enabled = false;
            this.response_text.Location = new System.Drawing.Point(12, 180);
            this.response_text.Multiline = true;
            this.response_text.Name = "response_text";
            this.response_text.Size = new System.Drawing.Size(776, 258);
            this.response_text.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.response_text);
            this.Controls.Add(this.Request_btn);
            this.Controls.Add(this.a2_f);
            this.Controls.Add(this.a1_f);
            this.Controls.Add(this.a2_k);
            this.Controls.Add(this.a1_k);
            this.Controls.Add(this.a2_s);
            this.Controls.Add(this.a1_s);
            this.Name = "Form1";
            this.Text = "ASMX";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox a1_s;
        private System.Windows.Forms.TextBox a2_s;
        private System.Windows.Forms.TextBox a1_k;
        private System.Windows.Forms.TextBox a2_k;
        private System.Windows.Forms.TextBox a1_f;
        private System.Windows.Forms.TextBox a2_f;
        private System.Windows.Forms.Button Request_btn;
        private System.Windows.Forms.TextBox response_text;
    }
}
