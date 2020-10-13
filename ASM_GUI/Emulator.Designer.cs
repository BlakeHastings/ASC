namespace ASM_GUI
{
    partial class Emulator
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Output_Button = new System.Windows.Forms.Button();
            this.Input_Button = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ACC_Button = new System.Windows.Forms.Button();
            this.ACC_Label = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Register_3_Button = new System.Windows.Forms.Button();
            this.Register_2_Button = new System.Windows.Forms.Button();
            this.Register_1_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.displayBase_ComboBox = new System.Windows.Forms.ComboBox();
            this.run_Button = new System.Windows.Forms.Button();
            this.step_Button = new System.Windows.Forms.Button();
            this.memoryGrid_DataGridView = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button7 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoryGrid_DataGridView)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.displayBase_ComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 363);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registers";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.Output_Button);
            this.groupBox4.Controls.Add(this.Input_Button);
            this.groupBox4.Location = new System.Drawing.Point(6, 262);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(188, 95);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "I/O";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Out";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "In";
            // 
            // Output_Button
            // 
            this.Output_Button.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Output_Button.Location = new System.Drawing.Point(44, 54);
            this.Output_Button.Name = "Output_Button";
            this.Output_Button.Size = new System.Drawing.Size(135, 29);
            this.Output_Button.TabIndex = 3;
            this.Output_Button.UseVisualStyleBackColor = true;
            // 
            // Input_Button
            // 
            this.Input_Button.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Input_Button.Location = new System.Drawing.Point(44, 19);
            this.Input_Button.Name = "Input_Button";
            this.Input_Button.Size = new System.Drawing.Size(135, 29);
            this.Input_Button.TabIndex = 3;
            this.Input_Button.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ACC_Button);
            this.groupBox3.Controls.Add(this.ACC_Label);
            this.groupBox3.Location = new System.Drawing.Point(6, 60);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(188, 65);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Accumulator";
            // 
            // ACC_Button
            // 
            this.ACC_Button.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ACC_Button.Location = new System.Drawing.Point(44, 22);
            this.ACC_Button.Name = "ACC_Button";
            this.ACC_Button.Size = new System.Drawing.Size(135, 29);
            this.ACC_Button.TabIndex = 3;
            this.ACC_Button.Text = "0000";
            this.ACC_Button.UseVisualStyleBackColor = true;
            this.ACC_Button.Click += new System.EventHandler(this.ACC_Button_Click);
            // 
            // ACC_Label
            // 
            this.ACC_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ACC_Label.AutoSize = true;
            this.ACC_Label.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ACC_Label.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ACC_Label.Location = new System.Drawing.Point(6, 28);
            this.ACC_Label.Name = "ACC_Label";
            this.ACC_Label.Size = new System.Drawing.Size(32, 17);
            this.ACC_Label.TabIndex = 2;
            this.ACC_Label.Text = "ACC";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Register_3_Button);
            this.groupBox2.Controls.Add(this.Register_2_Button);
            this.groupBox2.Controls.Add(this.Register_1_Button);
            this.groupBox2.Location = new System.Drawing.Point(6, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 129);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Index Registers";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "1";
            // 
            // Register_3_Button
            // 
            this.Register_3_Button.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Register_3_Button.Location = new System.Drawing.Point(44, 92);
            this.Register_3_Button.Name = "Register_3_Button";
            this.Register_3_Button.Size = new System.Drawing.Size(135, 29);
            this.Register_3_Button.TabIndex = 3;
            this.Register_3_Button.Text = "0000";
            this.Register_3_Button.UseVisualStyleBackColor = true;
            this.Register_3_Button.Click += new System.EventHandler(this.Register_3_Button_Click);
            // 
            // Register_2_Button
            // 
            this.Register_2_Button.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Register_2_Button.Location = new System.Drawing.Point(44, 57);
            this.Register_2_Button.Name = "Register_2_Button";
            this.Register_2_Button.Size = new System.Drawing.Size(135, 29);
            this.Register_2_Button.TabIndex = 3;
            this.Register_2_Button.Text = "0000";
            this.Register_2_Button.UseVisualStyleBackColor = true;
            this.Register_2_Button.Click += new System.EventHandler(this.Register_2_Button_Click);
            // 
            // Register_1_Button
            // 
            this.Register_1_Button.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Register_1_Button.Location = new System.Drawing.Point(44, 22);
            this.Register_1_Button.Name = "Register_1_Button";
            this.Register_1_Button.Size = new System.Drawing.Size(135, 29);
            this.Register_1_Button.TabIndex = 3;
            this.Register_1_Button.Text = "0000";
            this.Register_1_Button.UseVisualStyleBackColor = true;
            this.Register_1_Button.Click += new System.EventHandler(this.Register_1_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Display Base";
            // 
            // displayBase_ComboBox
            // 
            this.displayBase_ComboBox.FormattingEnabled = true;
            this.displayBase_ComboBox.Items.AddRange(new object[] {
            "6",
            "2"});
            this.displayBase_ComboBox.Location = new System.Drawing.Point(147, 22);
            this.displayBase_ComboBox.Name = "displayBase_ComboBox";
            this.displayBase_ComboBox.Size = new System.Drawing.Size(47, 23);
            this.displayBase_ComboBox.TabIndex = 0;
            this.displayBase_ComboBox.SelectedIndexChanged += new System.EventHandler(this.displayBase_ComboBox_SelectedIndexChanged);
            // 
            // run_Button
            // 
            this.run_Button.Location = new System.Drawing.Point(137, 405);
            this.run_Button.Name = "run_Button";
            this.run_Button.Size = new System.Drawing.Size(75, 23);
            this.run_Button.TabIndex = 7;
            this.run_Button.Text = "Run";
            this.run_Button.UseVisualStyleBackColor = true;
            this.run_Button.Click += new System.EventHandler(this.run_Button_Click);
            // 
            // step_Button
            // 
            this.step_Button.Location = new System.Drawing.Point(12, 405);
            this.step_Button.Name = "step_Button";
            this.step_Button.Size = new System.Drawing.Size(75, 23);
            this.step_Button.TabIndex = 6;
            this.step_Button.Text = "Step";
            this.step_Button.UseVisualStyleBackColor = true;
            this.step_Button.Click += new System.EventHandler(this.step_Button_Click);
            // 
            // memoryGrid_DataGridView
            // 
            this.memoryGrid_DataGridView.AllowUserToAddRows = false;
            this.memoryGrid_DataGridView.AllowUserToDeleteRows = false;
            this.memoryGrid_DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoryGrid_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.memoryGrid_DataGridView.Location = new System.Drawing.Point(730, 58);
            this.memoryGrid_DataGridView.Name = "memoryGrid_DataGridView";
            this.memoryGrid_DataGridView.Size = new System.Drawing.Size(182, 396);
            this.memoryGrid_DataGridView.TabIndex = 2;
            this.memoryGrid_DataGridView.Text = "dataGridView1";
            this.memoryGrid_DataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.memoryGrid_DataGridView_CellClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(12, 7);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 3;
            this.button7.Text = "Load";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(218, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(506, 418);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(498, 390);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Editor";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(492, 384);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(498, 390);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(492, 384);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nothing here....Yet";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(799, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Memory";
            // 
            // Emulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(924, 466);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.run_Button);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.step_Button);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.memoryGrid_DataGridView);
            this.Controls.Add(this.groupBox1);
            this.Name = "Emulator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emulator";
            this.Load += new System.EventHandler(this.Emulator_Load);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Emulator_Scroll);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoryGrid_DataGridView)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox displayBase_ComboBox;
        private System.Windows.Forms.Button ACC_Button;
        private System.Windows.Forms.Label ACC_Label;
        private System.Windows.Forms.Button Register_1_Button;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Register_3_Button;
        private System.Windows.Forms.Button Register_2_Button;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Output_Button;
        private System.Windows.Forms.Button Input_Button;
        private System.Windows.Forms.DataGridView memoryGrid_DataGridView;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button run_Button;
        private System.Windows.Forms.Button step_Button;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

