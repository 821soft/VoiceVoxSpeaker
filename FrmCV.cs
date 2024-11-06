using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static VoiceVoxSpeaker.Program;
using static VoiceVoxSpeaker.VoxIf;
using static VoiceVoxSpeaker.VoxIf.VoicevoxFunction;

namespace VoiceVoxSpeaker
{
    public partial class FrmCV : Form
    {
        public FrmCV()
        {
            InitializeComponent();
        }
        static public ToolStripMenuItem CvMenuItem;
        private ToolStripMenuItem CnMenuItem;
        private void FrmCV_Shown(object sender, EventArgs e)
        {
            //メニュー項目の作成
            CvMenuItem = new ToolStripMenuItem();
            CvMenuItem.Text = "CV設定";
            string cvname = "";
            ToolStripMenuItem cvitem = new ToolStripMenuItem();
            foreach (var vox in VoicevoxFunction.voxlist)
            {
                if (vox.name != cvname)
                {
                    cvitem = new ToolStripMenuItem();
                    cvitem.Text = vox.name;
                    CvMenuItem.DropDownItems.Add(cvitem);
                    cvname = vox.name;
                }
                ToolStripMenuItem cvstyleitem = new ToolStripMenuItem();
                cvstyleitem.Text = vox.style;
                cvstyleitem.Tag = vox;
                cvstyleitem.Click += Cvitem_Click;
                cvitem.DropDownItems.Add(cvstyleitem);
            }

            foreach (ToolStripMenuItem item in CvMenuItem.DropDownItems)
            {
                if (item.DropDownItems.Count == 1)
                {
                    item.Tag = item.DropDownItems[0].Tag;
                    item.Click += Cvitem_Click;
                    item.DropDownItems.Clear();
                }
            }

            Lsv_CV_DataShow();
        }
        private void Lsv_CV_DataAdd(st_ChrarCv i)
        {
            var s = Lsv_CV.Items.Add($"{i.CType}");
            s.Checked = i.Checked;
            s.SubItems.Add(i.Cn);
            s.SubItems.Add(i.CvName);
            s.SubItems.Add($"{i.CvId}");
            s.SubItems.Add($"{i.speedScale:N2}");
            s.SubItems.Add($"{i.pitchScale:N2}");
            s.SubItems.Add($"{i.intonationScale:N2}");
            s.SubItems.Add($"{i.volumeScale:N2}");
            s.Tag = i;
        }

        private void Lsv_CV_DataShow()
        {
            Lsv_CV.Items.Clear();

            foreach (var i in Program.CharaCv)
            {
                if (Cmb_Filter.Text == "User")
                {
                    if (i.CType == CharacterTypes.User)
                    {
                        Lsv_CV_DataAdd(i);
                    }
                }
                else if (Cmb_Filter.Text == "Npc")
                {
                    if (i.CType != CharacterTypes.User)
                    {
                        Lsv_CV_DataAdd(i);
                    }
                }
                else
                {
                    Lsv_CV_DataAdd(i);
                }
            }
        }

        private void Cvitem_Click(object? sender, EventArgs e)
        {
            var item = (ToolStripMenuItem?)sender;
            st_Speakers vox = (st_Speakers)item.Tag;
            if (Lsv_CV.SelectedItems.Count >= 0)
            {
                var cv = Lsv_CV.SelectedItems[0];
                cv.Checked = true;
                cv.SubItems[2].Text = $"{vox.name} {vox.style}";
                cv.SubItems[3].Text = $"{vox.id}";
                var TagData = (st_ChrarCv)cv.Tag;
                TagData.CvName = $"{vox.name} {vox.style}";
                TagData.CvId = vox.id;
                Program.ChrarCv_upd(TagData);

            }

        }
        private void Cnitem_Click(object? sender, EventArgs e)
        {
            var item = (ToolStripMenuItem?)sender;
            ListViewItem rec = new ListViewItem(item.Text);
            rec.SubItems.Add("");
            rec.SubItems.Add("0");
            rec.SubItems.Add("1.00");
            rec.SubItems.Add("0.00");
            rec.SubItems.Add("1.00");
            rec.SubItems.Add("1.00");
            Lsv_CV.Items.Add(rec);
        }

        private ToolStripMenuItem parammenu(string title)
        {

            string[] sub1 = { "0.50", "0.75", "1.00", "1.25", "1.50" };
            string[] sub2 = { "-0.10", "-0.05", "0.00", "0.05", "0.10" };

            string[] sub = sub1;
            if (title == "音高")
            {
                sub = sub2;
            }

            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = title;
            foreach (string subitem in sub)
            {
                var s = new ToolStripMenuItem();
                s.Text = subitem;
                if (title == "話速")
                {
                    s.Click += ItemSpeed_Click;
                }
                else if (title == "音高")
                {
                    s.Click += ItemPitch_Click;
                }
                else if (title == "抑揚")
                {
                    s.Click += ItemIntonation_Click;
                }
                else if (title == "音量")
                {
                    s.Click += ItemVolume_Click;
                }
                item.DropDownItems.Add(s);
            }


            return (item);
        }

        private void Cmn_CV_Opening(object sender, CancelEventArgs e)
        {
            Cmn_CV.Items.Clear();
            // ListViewの選択状況判定
            if (Lsv_CV.SelectedItems.Count > 0)
            {
                //選択ありなら行削除とCVリスト
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = "削除";
                item.Click += ItemDelete_Click;

                Cmn_CV.Items.Add(item);
                Cmn_CV.Items.Add(CvMenuItem);
                Cmn_CV.Items.Add(parammenu("話速"));
                Cmn_CV.Items.Add(parammenu("音高"));
                Cmn_CV.Items.Add(parammenu("抑揚"));
                Cmn_CV.Items.Add(parammenu("音量"));

                ToolStripMenuItem itemPlay = new ToolStripMenuItem();
                itemPlay.Text = "再生";
                itemPlay.Click += ItemPlay_Click;
                Cmn_CV.Items.Add(itemPlay);
            }
            else
            {
                //選択なしなら登録候補

                //メニュー項目を追加
                //Cmn_CV.Items.Add(CnMenuItem);

            }

        }
        private void ItemSpeed_Click(object? sender, EventArgs e)
        {
            var selitem = Lsv_CV.SelectedItems;
            foreach (ListViewItem item in Lsv_CV.SelectedItems)
            {
                var val = (ToolStripMenuItem)sender;
                item.SubItems[4].Text = val.Text;
                var TagData = (st_ChrarCv)item.Tag;
                TagData.speedScale = double.Parse(val.Text);
                Program.ChrarCv_upd(TagData);
            }
        }
        private void ItemPitch_Click(object? sender, EventArgs e)
        {
            var selitem = Lsv_CV.SelectedItems;
            foreach (ListViewItem item in Lsv_CV.SelectedItems)
            {
                var val = (ToolStripMenuItem)sender;
                item.SubItems[5].Text = val.Text;
                var TagData = (st_ChrarCv)item.Tag;
                TagData.pitchScale = double.Parse(val.Text);
                Program.ChrarCv_upd(TagData);
            }
        }
        private void ItemIntonation_Click(object? sender, EventArgs e)
        {
            var selitem = Lsv_CV.SelectedItems;
            foreach (ListViewItem item in Lsv_CV.SelectedItems)
            {
                var val = (ToolStripMenuItem)sender;
                item.SubItems[6].Text = val.Text;
                var TagData = (st_ChrarCv)item.Tag;
                TagData.intonationScale = double.Parse(val.Text);
                Program.ChrarCv_upd(TagData);
            }
        }
        private void ItemVolume_Click(object? sender, EventArgs e)
        {
            var selitem = Lsv_CV.SelectedItems;
            foreach (ListViewItem item in Lsv_CV.SelectedItems)
            {
                var val = (ToolStripMenuItem)sender;
                item.SubItems[7].Text = val.Text;
                var TagData = (st_ChrarCv)item.Tag;
                TagData.volumeScale = double.Parse(val.Text);
                Program.ChrarCv_upd(TagData);
            }
        }
        private void ItemPlay_Click(object? sender, EventArgs e)
        {
            var selitem = Lsv_CV.SelectedItems;
            foreach (ListViewItem item in Lsv_CV.SelectedItems)
            {
                var rec = new st_ChrarCv();
                switch (item.Text)
                {
                    case "Npc":
                        rec.CType = CharacterTypes.Npc;
                        break;
                    case "User":
                        rec.CType = CharacterTypes.User;
                        break;
                }

                rec.Cn = item.SubItems[1].Text;
                rec.CvName = item.SubItems[2].Text;
                rec.CvId = int.Parse(item.SubItems[3].Text);
                rec.Checked = item.Checked;
                rec.speedScale = Double.Parse(item.SubItems[4].Text);
                rec.pitchScale = Double.Parse(item.SubItems[5].Text);
                rec.intonationScale = Double.Parse(item.SubItems[6].Text);
                rec.volumeScale = Double.Parse(item.SubItems[7].Text);
                _ = Program.vox.MakeSound("sample", rec.Cn, true, rec.CvId, rec.speedScale, rec.pitchScale, rec.intonationScale, rec.volumeScale);
            }
        }


        private void ItemDelete_Click(object? sender, EventArgs e)
        {
            var selitem = Lsv_CV.SelectedItems;

            foreach (ListViewItem item in Lsv_CV.SelectedItems)
            {
                var TagData = (st_ChrarCv)item.Tag;
                Program.CharaCv.Remove(TagData);
                item.Remove();
            }
        }

        private void FrmCV_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*
                        Program.CharaCv.Clear();
                        foreach (ListViewItem item in Lsv_CV.Items)
                        {
                            var rec = new st_ChrarCv();
                            switch (item.Text)
                            {
                                case "Npc":
                                    rec.CType = CharacterTypes.Npc;
                                    break;
                                case "User":
                                    rec.CType = CharacterTypes.User;
                                    break;
                            }

                            rec.Cn = item.SubItems[1].Text;
                            rec.CvName = item.SubItems[2].Text;
                            rec.CvId = int.Parse(item.SubItems[3].Text);
                            rec.Checked = item.Checked;
                            rec.speedScale = Double.Parse(item.SubItems[4].Text);
                            rec.pitchScale = Double.Parse(item.SubItems[5].Text);
                            rec.intonationScale = Double.Parse(item.SubItems[6].Text);
                            rec.volumeScale = Double.Parse(item.SubItems[7].Text);
                            Program.CharaCv.Add(rec);
                        }
            */
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            Form form = new FrmCVadd();
            Program.ParamItem.Cn = "";
            Program.ParamItem.CvId = 0 ;
            Program.ParamItem.CvName = "四国めたん ノーマル";
            Program.ParamItem.speedScale = 1.00;
            Program.ParamItem.pitchScale = 0.0;
            Program.ParamItem.intonationScale = 1.0;
            Program.ParamItem.volumeScale = 1.0;
            var ret = form.ShowDialog();
            if (ret == DialogResult.OK)
            {
                var rec = new st_ChrarCv();
                rec.Cn = Program.ParamItem.Cn;
                rec.CvId = Program.ParamItem.CvId ;
                rec.CvName =  Program.ParamItem.CvName ;
                rec.speedScale = Program.ParamItem.speedScale;
                rec.pitchScale = Program.ParamItem.pitchScale;
                rec.intonationScale = Program.ParamItem.intonationScale ;
                rec.volumeScale = Program.ParamItem.volumeScale ;
                ChrarCv_Add(rec);
                Lsv_CV_DataShow();

            }
        }

        private void Lsv_CV_Click(object sender, EventArgs e)
        {
            if ((Control.MouseButtons & MouseButtons.Right) == MouseButtons.Right)
            {
                return;
            }
            if (Lsv_CV.SelectedItems.Count == 0)
            {
                return;
            }

        }

        private void Cmb_Filter_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void Lsv_CV_ColumnClick(object sender, ColumnClickEventArgs e)
        {

        }

        private void Lsv_CV_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void Lsv_CV_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if(Lsv_CV.SelectedItems.Count <= 0)
            {
                return;
            }
            Form form = new FrmCVadd();
            Program.ParamItem = (st_ChrarCv)(Lsv_CV.SelectedItems[0].Tag);
            var res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                var item = new st_ChrarCv();
                ListViewItem s = Lsv_CV.SelectedItems[0];

                item = Program.ParamItem;
                s.Tag = item;
                s.Checked = item.Checked;
                s.SubItems[1].Text = item.Cn;
                s.SubItems[2].Text = item.CvName;
                s.SubItems[3].Text = $"{item.CvId}";
                s.SubItems[4].Text = $"{item.speedScale:N2}";
                s.SubItems[5].Text = $"{item.pitchScale:N2}";
                s.SubItems[6].Text = $"{item.intonationScale:N2}";
                s.SubItems[7].Text = $"{item.volumeScale:N2}";

                ChrarCv_upd(item);
            }

        }

        private void Cmb_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lsv_CV_DataShow();
        }
    }

}
