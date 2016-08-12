namespace VS2010.Winform.Vsintlpack2
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.imeAwareAutoCompleteTextBox1 = new Microsoft.International.ImeAwareAutoComplete.WinForm.ImeAwareAutoCompleteTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imeAwareAutoCompleteTextBox1
            // 
            this.imeAwareAutoCompleteTextBox1.Location = new System.Drawing.Point(74, 24);
            this.imeAwareAutoCompleteTextBox1.Name = "imeAwareAutoCompleteTextBox1";
            this.imeAwareAutoCompleteTextBox1.Size = new System.Drawing.Size(100, 21);
            this.imeAwareAutoCompleteTextBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(74, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "历史输入提示";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.imeAwareAutoCompleteTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.International.ImeAwareAutoComplete.WinForm.ImeAwareAutoCompleteTextBox imeAwareAutoCompleteTextBox1;
        private System.Windows.Forms.Button button1;
    }
}

