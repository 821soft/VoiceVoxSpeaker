namespace VoiceVoxSpeaker
{
    partial class FrmCVadd
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
            Cmb_Type = new ComboBox();
            Txt_Name = new TextBox();
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            trackBar3 = new TrackBar();
            trackBar4 = new TrackBar();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            Cmb_CVName = new ComboBox();
            Cmb_CVStyle = new ComboBox();
            Btn_Play = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            Btn_Ok = new Button();
            Btn_Cancel = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).BeginInit();
            SuspendLayout();
            // 
            // Cmb_Type
            // 
            Cmb_Type.FormattingEnabled = true;
            Cmb_Type.Items.AddRange(new object[] { "User", "Npc" });
            Cmb_Type.Location = new Point(24, 32);
            Cmb_Type.Margin = new Padding(3, 4, 3, 4);
            Cmb_Type.Name = "Cmb_Type";
            Cmb_Type.Size = new Size(89, 28);
            Cmb_Type.TabIndex = 0;
            // 
            // Txt_Name
            // 
            Txt_Name.Location = new Point(140, 33);
            Txt_Name.Margin = new Padding(3, 4, 3, 4);
            Txt_Name.Name = "Txt_Name";
            Txt_Name.Size = new Size(246, 27);
            Txt_Name.TabIndex = 1;
            // 
            // trackBar1
            // 
            trackBar1.LargeChange = 10;
            trackBar1.Location = new Point(67, 142);
            trackBar1.Margin = new Padding(3, 4, 3, 4);
            trackBar1.Maximum = 200;
            trackBar1.Minimum = 50;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(256, 45);
            trackBar1.SmallChange = 5;
            trackBar1.TabIndex = 2;
            trackBar1.TickFrequency = 10;
            trackBar1.Value = 100;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(67, 186);
            trackBar2.Margin = new Padding(3, 4, 3, 4);
            trackBar2.Maximum = 15;
            trackBar2.Minimum = -15;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(256, 45);
            trackBar2.TabIndex = 3;
            trackBar2.Scroll += trackBar2_Scroll;
            // 
            // trackBar3
            // 
            trackBar3.LargeChange = 10;
            trackBar3.Location = new Point(67, 239);
            trackBar3.Margin = new Padding(3, 4, 3, 4);
            trackBar3.Maximum = 200;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(256, 45);
            trackBar3.SmallChange = 5;
            trackBar3.TabIndex = 4;
            trackBar3.TickFrequency = 10;
            trackBar3.Value = 100;
            trackBar3.Scroll += trackBar3_Scroll;
            // 
            // trackBar4
            // 
            trackBar4.LargeChange = 10;
            trackBar4.Location = new Point(67, 292);
            trackBar4.Margin = new Padding(3, 4, 3, 4);
            trackBar4.Maximum = 200;
            trackBar4.Name = "trackBar4";
            trackBar4.Size = new Size(256, 45);
            trackBar4.SmallChange = 5;
            trackBar4.TabIndex = 5;
            trackBar4.TickFrequency = 10;
            trackBar4.Value = 100;
            trackBar4.Scroll += trackBar4_Scroll;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(338, 142);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(56, 27);
            textBox2.TabIndex = 6;
            textBox2.DoubleClick += textBox2_DoubleClick;
            textBox2.Leave += textBox2_Leave;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(338, 186);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(56, 27);
            textBox3.TabIndex = 7;
            textBox3.DoubleClick += textBox3_DoubleClick;
            textBox3.Leave += textBox3_Leave;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(338, 239);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(54, 27);
            textBox4.TabIndex = 8;
            textBox4.DoubleClick += textBox4_DoubleClick;
            textBox4.Leave += textBox4_Leave;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(338, 292);
            textBox5.Margin = new Padding(3, 4, 3, 4);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(54, 27);
            textBox5.TabIndex = 9;
            textBox5.DoubleClick += textBox5_DoubleClick;
            textBox5.Leave += textBox5_Leave;
            // 
            // Cmb_CVName
            // 
            Cmb_CVName.FormattingEnabled = true;
            Cmb_CVName.Location = new Point(24, 93);
            Cmb_CVName.Name = "Cmb_CVName";
            Cmb_CVName.Size = new Size(147, 28);
            Cmb_CVName.TabIndex = 10;
            Cmb_CVName.TextUpdate += Cmb_CVName_TextUpdate;
            Cmb_CVName.TextChanged += Cmb_CVName_TextChanged;
            // 
            // Cmb_CVStyle
            // 
            Cmb_CVStyle.FormattingEnabled = true;
            Cmb_CVStyle.Location = new Point(194, 93);
            Cmb_CVStyle.Name = "Cmb_CVStyle";
            Cmb_CVStyle.Size = new Size(129, 28);
            Cmb_CVStyle.TabIndex = 11;
            // 
            // Btn_Play
            // 
            Btn_Play.Location = new Point(66, 344);
            Btn_Play.Name = "Btn_Play";
            Btn_Play.Size = new Size(91, 29);
            Btn_Play.TabIndex = 12;
            Btn_Play.Text = "テスト再生";
            Btn_Play.UseVisualStyleBackColor = true;
            Btn_Play.Click += Btn_Play_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 8);
            label1.Name = "label1";
            label1.Size = new Size(40, 20);
            label1.TabIndex = 13;
            label1.Text = "Type";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(131, 9);
            label2.Name = "label2";
            label2.Size = new Size(112, 20);
            label2.TabIndex = 14;
            label2.Text = "CharacterName";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 70);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 15;
            label3.Text = "CVName";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(182, 70);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 16;
            label4.Text = "Style";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 142);
            label5.Name = "label5";
            label5.Size = new Size(39, 20);
            label5.TabIndex = 17;
            label5.Text = "話速";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 186);
            label6.Name = "label6";
            label6.Size = new Size(39, 20);
            label6.TabIndex = 18;
            label6.Text = "音高";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 239);
            label7.Name = "label7";
            label7.Size = new Size(39, 20);
            label7.TabIndex = 19;
            label7.Text = "抑揚";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 292);
            label8.Name = "label8";
            label8.Size = new Size(39, 20);
            label8.TabIndex = 20;
            label8.Text = "音量";
            // 
            // Btn_Ok
            // 
            Btn_Ok.DialogResult = DialogResult.OK;
            Btn_Ok.Location = new Point(247, 344);
            Btn_Ok.Name = "Btn_Ok";
            Btn_Ok.Size = new Size(75, 31);
            Btn_Ok.TabIndex = 21;
            Btn_Ok.Text = "Ok";
            Btn_Ok.UseVisualStyleBackColor = true;
            Btn_Ok.Click += Btn_Ok_Click;
            // 
            // Btn_Cancel
            // 
            Btn_Cancel.DialogResult = DialogResult.Cancel;
            Btn_Cancel.Location = new Point(343, 344);
            Btn_Cancel.Name = "Btn_Cancel";
            Btn_Cancel.Size = new Size(75, 31);
            Btn_Cancel.TabIndex = 22;
            Btn_Cancel.Text = "Cancel";
            Btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // FrmCVadd
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 387);
            Controls.Add(Btn_Cancel);
            Controls.Add(Btn_Ok);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Btn_Play);
            Controls.Add(Cmb_CVStyle);
            Controls.Add(Cmb_CVName);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(trackBar4);
            Controls.Add(trackBar3);
            Controls.Add(trackBar2);
            Controls.Add(trackBar1);
            Controls.Add(Txt_Name);
            Controls.Add(Cmb_Type);
            Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmCVadd";
            Text = "FrmCVadd";
            Shown += FrmCVadd_Shown;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox Cmb_Type;
        private TextBox Txt_Name;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private TrackBar trackBar3;
        private TrackBar trackBar4;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private ComboBox Cmb_CVName;
        private ComboBox Cmb_CVStyle;
        private Button Btn_Play;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button Btn_Ok;
        private Button Btn_Cancel;
    }
}