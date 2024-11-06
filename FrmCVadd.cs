using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static VoiceVoxSpeaker.VoxIf;
using System.Xml.Linq;
using static VoiceVoxSpeaker.Program;

namespace VoiceVoxSpeaker
{
    public partial class FrmCVadd : Form
    {
        public FrmCVadd()
        {
            InitializeComponent();
        }

        private void FrmCVadd_Shown(object sender, EventArgs e)
        {
            string cvname = "";

            Cmb_Type.SelectedIndex = 0;

            Cmb_CVName.Items.Clear();
            foreach (var vox in VoicevoxFunction.voxlist)
            {
                if (vox.name != cvname)
                {
                    Cmb_CVName.Items.Add(vox.name);
                    cvname = vox.name;
                }
            }

            if (Program.ParamItem.CType == CharacterTypes.Npc)
            {
                Cmb_Type.SelectedIndex = 1;
            }
            else if (Program.ParamItem.CType == CharacterTypes.User)
            {
                Cmb_Type.SelectedIndex = 0;
            }
            Txt_Name.Text = Program.ParamItem.Cn;

            string [] cvs = Program.ParamItem.CvName.Split(' ');
            Cmb_CVName.Text = cvs[0];
            Cmb_CVStyle.Text = $"{cvs[1]},{Program.ParamItem.CvId}";

            trackBar1.Value = (int)(Program.ParamItem.speedScale * 100.0);
            trackBar2.Value = (int)(Program.ParamItem.pitchScale * 100.0);
            trackBar3.Value = (int)(Program.ParamItem.intonationScale * 100.0);
            trackBar4.Value = (int)(Program.ParamItem.volumeScale * 100.0);


            double v = trackBar1.Value / 100.0;
            textBox2.Text = $"{v:0.00}";
            v = trackBar2.Value / 100.0;
            textBox3.Text = $"{v:0.00}";
            v = trackBar3.Value / 100.0;
            textBox4.Text = $"{v:0.00}";
            v = trackBar4.Value / 100.0;
            textBox5.Text = $"{v:0.00}";

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double v = trackBar1.Value / 100.0;
            textBox2.Text = $"{v:0.00}";
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            double v = trackBar2.Value / 100.0;
            textBox3.Text = $"{v:0.00}";

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            double v = trackBar3.Value / 100.0;
            textBox4.Text = $"{v:0.00}";

        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            double v = trackBar4.Value / 100.0;
            textBox5.Text = $"{v:0.00}";

        }

        private void Cmb_CVName_TextUpdate(object sender, EventArgs e)
        {
        }

        private void Cmb_CVName_TextChanged(object sender, EventArgs e)
        {
            Cmb_CVStyle.Items.Clear();
            foreach (var vox in VoicevoxFunction.voxlist)
            {
                if (vox.name == Cmb_CVName.Text)
                {
                    Cmb_CVStyle.Items.Add($"{vox.style},{vox.id}");
                }
            }
            Cmb_CVStyle.SelectedIndex = 0;
        }

        private void Btn_Play_Click(object sender, EventArgs e)
        {
            var rec = new st_ChrarCv();
            switch (Cmb_Type.Text)
            {
                case "Npc":
                    rec.CType = CharacterTypes.Npc;
                    break;
                case "User":
                    rec.CType = CharacterTypes.User;
                    break;
            }

            string[] id = Cmb_CVStyle.Text.Split(',');
            rec.Cn = Txt_Name.Text;
            rec.CvName = Cmb_CVName.Text;
            rec.CvId = int.Parse(id[1]);
            rec.Checked = true;
            rec.speedScale = Double.Parse(textBox2.Text);
            rec.pitchScale = Double.Parse(textBox3.Text);
            rec.intonationScale = Double.Parse(textBox4.Text);
            rec.volumeScale = Double.Parse(textBox5.Text);
            _ = Program.vox.MakeSound("sample", rec.Cn, true, rec.CvId, rec.speedScale, rec.pitchScale, rec.intonationScale, rec.volumeScale);

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            int n = (int)(double.Parse(textBox2.Text) * 100.0);
            trackBar1.Value = n;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            int n = (int)(double.Parse(textBox3.Text) * 100.0);
            trackBar2.Value = n;
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            int n = (int)(double.Parse(textBox4.Text) * 100.0);
            trackBar3.Value = n;
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            int n = (int)(double.Parse(textBox5.Text) * 100.0);
            trackBar4.Value = n;
        }

        private void textBox2_DoubleClick(object sender, EventArgs e)
        {
            textBox2.Text = "1.00";
        }

        private void textBox3_DoubleClick(object sender, EventArgs e)
        {
            textBox3.Text = "0.00";
        }

        private void textBox4_DoubleClick(object sender, EventArgs e)
        {
            textBox4.Text = "1.00";
        }

        private void textBox5_DoubleClick(object sender, EventArgs e)
        {
            textBox5.Text = "1.00";
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            
            var rec = new st_ChrarCv();
            switch (Cmb_Type.Text)
            {
                case "Npc":
                    rec.CType = CharacterTypes.Npc;
                    break;
                case "User":
                    rec.CType = CharacterTypes.User;
                    break;
            }

            string[] id = Cmb_CVStyle.Text.Split(',');
            rec.Cn = Txt_Name.Text;
            rec.CvName = $"{Cmb_CVName.Text} {id[0]}";
            rec.CvId = int.Parse(id[1]);
            rec.Checked = true;
            rec.speedScale = Double.Parse(textBox2.Text);
            rec.pitchScale = Double.Parse(textBox3.Text);
            rec.intonationScale = Double.Parse(textBox4.Text);
            rec.volumeScale = Double.Parse(textBox5.Text);

            Program.ParamItem = rec;
            this.Close();
        }
    }
}
