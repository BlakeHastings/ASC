namespace ASM_GUI
{
    partial class DecodeInstructionTool
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
            this.label1 = new System.Windows.Forms.Label();
            this.address_TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.indexFlag_TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.indirectFlag_TextBox = new System.Windows.Forms.TextBox();
            this.extensionBit_TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.opCode_TextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.instructionEntry_TextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Address";
            // 
            // address_TextBox
            // 
            this.address_TextBox.Enabled = false;
            this.address_TextBox.Location = new System.Drawing.Point(94, 176);
            this.address_TextBox.Name = "address_TextBox";
            this.address_TextBox.Size = new System.Drawing.Size(100, 23);
            this.address_TextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Index Flag";
            // 
            // indexFlag_TextBox
            // 
            this.indexFlag_TextBox.Enabled = false;
            this.indexFlag_TextBox.Location = new System.Drawing.Point(94, 147);
            this.indexFlag_TextBox.Name = "indexFlag_TextBox";
            this.indexFlag_TextBox.Size = new System.Drawing.Size(100, 23);
            this.indexFlag_TextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Indirect Flag";
            // 
            // indirectFlag_TextBox
            // 
            this.indirectFlag_TextBox.Enabled = false;
            this.indirectFlag_TextBox.Location = new System.Drawing.Point(94, 118);
            this.indirectFlag_TextBox.Name = "indirectFlag_TextBox";
            this.indirectFlag_TextBox.Size = new System.Drawing.Size(100, 23);
            this.indirectFlag_TextBox.TabIndex = 3;
            // 
            // extensionBit_TextBox
            // 
            this.extensionBit_TextBox.Enabled = false;
            this.extensionBit_TextBox.Location = new System.Drawing.Point(94, 89);
            this.extensionBit_TextBox.Name = "extensionBit_TextBox";
            this.extensionBit_TextBox.Size = new System.Drawing.Size(100, 23);
            this.extensionBit_TextBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Exension Bit";
            // 
            // opCode_TextBox
            // 
            this.opCode_TextBox.Enabled = false;
            this.opCode_TextBox.Location = new System.Drawing.Point(94, 60);
            this.opCode_TextBox.Name = "opCode_TextBox";
            this.opCode_TextBox.Size = new System.Drawing.Size(100, 23);
            this.opCode_TextBox.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(120, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = " Decode";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // instructionEntry_TextBox
            // 
            this.instructionEntry_TextBox.Location = new System.Drawing.Point(14, 31);
            this.instructionEntry_TextBox.Name = "instructionEntry_TextBox";
            this.instructionEntry_TextBox.Size = new System.Drawing.Size(100, 23);
            this.instructionEntry_TextBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.address_TextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.indexFlag_TextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.indirectFlag_TextBox);
            this.groupBox1.Controls.Add(this.extensionBit_TextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.opCode_TextBox);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.instructionEntry_TextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 215);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Decode Instruction";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Opcode";
            // 
            // DecodeInstructionTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 236);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(241, 275);
            this.MinimumSize = new System.Drawing.Size(241, 275);
            this.Name = "DecodeInstructionTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DecodeInstructionTool";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox address_TextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox indexFlag_TextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox indirectFlag_TextBox;
        private System.Windows.Forms.TextBox extensionBit_TextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox opCode_TextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox instructionEntry_TextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}