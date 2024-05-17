using CSW8Test;
using CSW8Test.Model.Enums;

namespace GUIWithCSW8
{
    partial class Form1
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
            MemberTbx = new TextBox();
            AddMemberBtn = new Button();
            Memberslbx = new ListBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            inverters = new ComboBox();
            label2 = new Label();
            langaugebox = new ComboBox();
            language = new Label();
            totalmembers = new Label();
            NoOfmembers = new TextBox();
            numericUpDown1 = new NumericUpDown();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // MemberTbx
            // 
            MemberTbx.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MemberTbx.Location = new Point(28, 67);
            MemberTbx.Margin = new Padding(4);
            MemberTbx.Name = "MemberTbx";
            MemberTbx.Size = new Size(296, 34);
            MemberTbx.TabIndex = 0;
            // 
            // AddMemberBtn
            // 
            AddMemberBtn.Location = new Point(348, 67);
            AddMemberBtn.Name = "AddMemberBtn";
            AddMemberBtn.Size = new Size(135, 34);
            AddMemberBtn.TabIndex = 1;
            AddMemberBtn.Text = "Add member";
            AddMemberBtn.UseVisualStyleBackColor = true;
            AddMemberBtn.Click += AddMemberBtn_Click;
            // 
            // Memberslbx
            // 
            Memberslbx.FormattingEnabled = true;
            Memberslbx.ItemHeight = 28;
            Memberslbx.Location = new Point(28, 124);
            Memberslbx.Name = "Memberslbx";
            Memberslbx.Size = new Size(399, 88);
            Memberslbx.TabIndex = 2;
            // 
            // inverters
            // 
            inverters.DropDownStyle = ComboBoxStyle.DropDownList;
            inverters.FormattingEnabled = true;            
            inverters.Items.Add(CSW8Test.Model.Enums.InverterType.MT_MWR_220_230_2F.ToString());
            inverters.Items.Add(CSW8Test.Model.Enums.InverterType.MT_MWR_110_230_2F.ToString());
            inverters.Items.Add(CSW8Test.Model.Enums.InverterType.MT_MWR_24_230_1F.ToString());
            inverters.Items.Add(CSW8Test.Model.Enums.InverterType.MT_MWR_48_230_2F.ToString());
            // TODO: Add rest

            inverters.Location = new Point(187, 264);
            inverters.Name = "inverters";
            inverters.Size = new Size(240, 36);
            inverters.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 264);
            label2.Name = "label2";
            label2.Size = new Size(123, 28);
            label2.TabIndex = 5;
            label2.Text = "Inverter type";
            // 
            // langaugebox
            // 
            langaugebox.DropDownStyle = ComboBoxStyle.DropDownList;
            langaugebox.FormattingEnabled = true;

            langaugebox.Items.Add(Language.Deutsch);
            langaugebox.Items.Add(Language.English);

            langaugebox.Location = new Point(187, 336);
            langaugebox.Name = "langaugebox";
            langaugebox.Size = new Size(240, 36);
            langaugebox.TabIndex = 6;

            langaugebox.SelectedValueChanged += Langaugebox_SelectedValueChanged;   
            // 
            // language
            // 
            language.AutoSize = true;
            language.Location = new Point(28, 336);
            language.Name = "language";
            language.Size = new Size(97, 28);
            language.TabIndex = 7;
            language.Text = "Language";
            // 
            // totalmembers
            // 
            totalmembers.AutoSize = true;
            totalmembers.Location = new Point(521, 70);
            totalmembers.Name = "totalmembers";
            totalmembers.Size = new Size(141, 28);
            totalmembers.TabIndex = 8;
            totalmembers.Text = "Total Members";
            // 
            // NoOfmembers
            // 
            NoOfmembers.Location = new Point(696, 70);
            NoOfmembers.Name = "NoOfmembers";
            NoOfmembers.Size = new Size(81, 34);
            NoOfmembers.TabIndex = 9;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(196, 403);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(128, 34);
            numericUpDown1.TabIndex = 12;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 403);
            label3.Name = "label3";
            label3.Size = new Size(110, 28);
            label3.TabIndex = 13;
            label3.Text = "DC Voltage";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(824, 745);
            Controls.Add(label3);
            Controls.Add(numericUpDown1);
            Controls.Add(NoOfmembers);
            Controls.Add(totalmembers);
            Controls.Add(language);
            Controls.Add(langaugebox);
            Controls.Add(label2);
            Controls.Add(inverters);
            Controls.Add(Memberslbx);
            Controls.Add(AddMemberBtn);
            Controls.Add(MemberTbx);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "MembersAddingTask";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox MemberTbx;
        private Button AddMemberBtn;
        private ListBox Memberslbx;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ComboBox inverters;
        private Label label2;
        private ComboBox langaugebox;
        private Label language;
        private Label totalmembers;
        private TextBox NoOfmembers;
        private NumericUpDown numericUpDown1;
        private Label label3;
    }
}
