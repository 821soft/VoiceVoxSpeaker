namespace VoiceVoxSpeaker
{
    partial class FrmCV
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
            components = new System.ComponentModel.Container();
            ListViewItem listViewItem1 = new ListViewItem(new string[] { "NPC", "キャラ名", "もち子さん セクシー／あん子", "", "" }, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCV));
            Lsv_CV = new ListView();
            columnHeader8 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            Cmn_CV = new ContextMenuStrip(components);
            キャラ追加ToolStripMenuItem = new ToolStripMenuItem();
            cV設定ToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            Cmb_Filter = new ToolStripComboBox();
            toolStripSeparator1 = new ToolStripSeparator();
            Btn_Add = new ToolStripButton();
            panel1 = new Panel();
            Cmn_CV.SuspendLayout();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Lsv_CV
            // 
            Lsv_CV.CheckBoxes = true;
            Lsv_CV.Columns.AddRange(new ColumnHeader[] { columnHeader8, columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
            Lsv_CV.ContextMenuStrip = Cmn_CV;
            Lsv_CV.Dock = DockStyle.Fill;
            Lsv_CV.Font = new Font("ＭＳ ゴシック", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            Lsv_CV.FullRowSelect = true;
            Lsv_CV.GridLines = true;
            listViewItem1.StateImageIndex = 0;
            Lsv_CV.Items.AddRange(new ListViewItem[] { listViewItem1 });
            Lsv_CV.Location = new Point(0, 0);
            Lsv_CV.Margin = new Padding(3, 4, 3, 4);
            Lsv_CV.MultiSelect = false;
            Lsv_CV.Name = "Lsv_CV";
            Lsv_CV.Size = new Size(773, 388);
            Lsv_CV.TabIndex = 0;
            Lsv_CV.UseCompatibleStateImageBehavior = false;
            Lsv_CV.View = View.Details;
            Lsv_CV.ColumnClick += Lsv_CV_ColumnClick;
            Lsv_CV.Click += Lsv_CV_Click;
            Lsv_CV.MouseClick += Lsv_CV_MouseClick;
            Lsv_CV.MouseDoubleClick += Lsv_CV_MouseDoubleClick;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "タイプ";
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "キャラ名";
            columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "CV";
            columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "ID";
            columnHeader3.Width = 40;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "話速";
            columnHeader4.Width = 50;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "音高";
            columnHeader5.Width = 50;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "抑揚";
            columnHeader6.Width = 50;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "音量";
            columnHeader7.Width = 50;
            // 
            // Cmn_CV
            // 
            Cmn_CV.Items.AddRange(new ToolStripItem[] { キャラ追加ToolStripMenuItem, cV設定ToolStripMenuItem });
            Cmn_CV.Name = "Cmn_CV";
            Cmn_CV.Size = new Size(124, 48);
            Cmn_CV.Opening += Cmn_CV_Opening;
            // 
            // キャラ追加ToolStripMenuItem
            // 
            キャラ追加ToolStripMenuItem.Name = "キャラ追加ToolStripMenuItem";
            キャラ追加ToolStripMenuItem.Size = new Size(123, 22);
            キャラ追加ToolStripMenuItem.Text = "キャラ追加";
            // 
            // cV設定ToolStripMenuItem
            // 
            cV設定ToolStripMenuItem.Name = "cV設定ToolStripMenuItem";
            cV設定ToolStripMenuItem.Size = new Size(123, 22);
            cV設定ToolStripMenuItem.Text = "CV設定";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { Cmb_Filter, toolStripSeparator1, Btn_Add });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(773, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // Cmb_Filter
            // 
            Cmb_Filter.DropDownStyle = ComboBoxStyle.DropDownList;
            Cmb_Filter.FlatStyle = FlatStyle.Standard;
            Cmb_Filter.Items.AddRange(new object[] { "All", "User", "Npc" });
            Cmb_Filter.Name = "Cmb_Filter";
            Cmb_Filter.Size = new Size(121, 25);
            Cmb_Filter.DropDownClosed += Cmb_Filter_DropDownClosed;
            Cmb_Filter.SelectedIndexChanged += Cmb_Filter_SelectedIndexChanged;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // Btn_Add
            // 
            Btn_Add.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Btn_Add.Image = (Image)resources.GetObject("Btn_Add.Image");
            Btn_Add.ImageTransparentColor = Color.Magenta;
            Btn_Add.Name = "Btn_Add";
            Btn_Add.Size = new Size(33, 22);
            Btn_Add.Text = "Add";
            Btn_Add.Click += Btn_Add_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(Lsv_CV);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(773, 388);
            panel1.TabIndex = 2;
            // 
            // FrmCV
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(773, 413);
            Controls.Add(panel1);
            Controls.Add(toolStrip1);
            Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCV";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "CV";
            FormClosing += FrmCV_FormClosing;
            Shown += FrmCV_Shown;
            Cmn_CV.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView Lsv_CV;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ContextMenuStrip Cmn_CV;
        private ToolStripMenuItem キャラ追加ToolStripMenuItem;
        private ToolStripMenuItem cV設定ToolStripMenuItem;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ToolStrip toolStrip1;
        private ToolStripButton Btn_Add;
        private Panel panel1;
        private ToolStripComboBox Cmb_Filter;
        private ToolStripSeparator toolStripSeparator1;
    }
}