namespace ASM_GUI_Old
{
    partial class InputValuePrompt
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
            this.Submit_Button = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.displayBase_ComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Submit_Button
            // 
            this.Submit_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Submit_Button.Location = new System.Drawing.Point(59, 59);
            this.Submit_Button.Name = "Submit_Button";
            this.Submit_Button.Size = new System.Drawing.Size(61, 23);
            this.Submit_Button.TabIndex = 0;
            this.Submit_Button.Text = "Submit";
            this.Submit_Button.UseVisualStyleBackColor = true;
            this.Submit_Button.Click += new System.EventHandler(this.Submit_Button_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(59, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 1;
            // 
            // displayBase_ComboBox
            // 
            this.displayBase_ComboBox.FormattingEnabled = true;
            this.displayBase_ComboBox.Location = new System.Drawing.Point(12, 30);
            this.displayBase_ComboBox.Name = "displayBase_ComboBox";
            this.displayBase_ComboBox.Size = new System.Drawing.Size(41, 23);
            this.displayBase_ComboBox.TabIndex = 2;
            this.displayBase_ComboBox.SelectedIndexChanged += new System.EventHandler(this.displayBase_ComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Input base and value.";
            // 
            // InputValuePrompt
            // 
            this.AcceptButton = this.Submit_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(171, 92);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.displayBase_ComboBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Submit_Button);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(187, 131);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(187, 131);
            this.Name = "InputValuePrompt";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InputValuePrompt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Submit_Button;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox displayBase_ComboBox;
        private System.Windows.Forms.Label label1;
    }
}