namespace VoiceVoxSpeaker
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            statusStrip1 = new StatusStrip();
            toolStrip1 = new ToolStrip();
            Btn_CV = new ToolStripButton();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            Btn_Mute = new ToolStripButton();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 210);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(617, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { Btn_CV, Btn_Mute });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(617, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // Btn_CV
            // 
            Btn_CV.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Btn_CV.Font = new Font("ＭＳ ゴシック", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            Btn_CV.Image = (Image)resources.GetObject("Btn_CV.Image");
            Btn_CV.ImageTransparentColor = Color.Magenta;
            Btn_CV.Name = "Btn_CV";
            Btn_CV.Size = new Size(27, 22);
            Btn_CV.Text = "CV";
            Btn_CV.Click += Btn_CV_Click;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Bottom;
            textBox1.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            textBox1.Location = new Point(0, 183);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(617, 27);
            textBox1.TabIndex = 2;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Fill;
            textBox2.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            textBox2.Location = new Point(0, 25);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.Size = new Size(617, 158);
            textBox2.TabIndex = 3;
            // 
            // Btn_Mute
            // 
            Btn_Mute.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Btn_Mute.Image = (Image)resources.GetObject("Btn_Mute.Image");
            Btn_Mute.ImageTransparentColor = Color.Magenta;
            Btn_Mute.Name = "Btn_Mute";
            Btn_Mute.Size = new Size(42, 22);
            Btn_Mute.Text = "ミュート";
            Btn_Mute.Click += Btn_Mute_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(617, 232);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            Font = new Font("ＭＳ ゴシック", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            Name = "FrmMain";
            Text = "Form1";
            FormClosing += FrmMain_FormClosing;
            Shown += FrmMain_Shown;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStrip toolStrip1;
        private TextBox textBox1;
        private TextBox textBox2;
        private ToolStripButton Btn_CV;
        private ToolStripButton Btn_Mute;
    }
}
