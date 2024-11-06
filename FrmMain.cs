using System.Diagnostics;
using static VoiceVoxSpeaker.Program;
using static VoiceVoxSpeaker.VoxIf;

namespace VoiceVoxSpeaker
{
    public partial class FrmMain : Form
    {

        public FrmMain()
        {
            InitializeComponent();
        }
        delegate void deg_TxtChat_Text(string text);
        public void TxtChatWriteLine(string sx)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    Invoke(new deg_TxtChat_Text(TxtChatWriteLine), sx);
                }
                else
                {
                    textBox2.AppendText(sx);

                }
            }
            catch
            {
            }
        }

        private void onChat(object sender, EventArgs e)
        {
            var c = (MabiPacketEventArgs)e;


            Debug.Print($"{c.CharacterName} {c.CharacterType} {c.ChatWord}");
            var b1 = c.ChatWord.IndexOf("(");
            var b2 = c.ChatWord.IndexOf(")");
            var b3 = b2 - b1;
            if (b3 == 2)
            {
                c.ChatWord = c.ChatWord.Substring(0, b1);
                Debug.Print($"split {c.ChatWord}");
            }
            if (c.CharacterType == CharacterTypes.Npc || c.CharacterType == CharacterTypes.User)
            {
                string cn = c.CharacterName;
                string cw = c.ChatWord;
                string info = "";
                var a = Program.CharaCv.Find(x => x.Cn == cn);
                if ((a.Cn == cn) && (a.Checked == true))
                {
                    if ( !Btn_Mute.Checked )
                    {
                        _ = Program.vox.MakeSound($"voice_{cn}", cw, true, a.CvId, a.speedScale, a.pitchScale, a.intonationScale, a.volumeScale);
                        info = $"{cn} : {cw} C.V.({a.CvName})" + Environment.NewLine;
                        TxtChatWriteLine(info);
                    }
                    else
                    {
                        info = $"{cn} : {cw} (Mute)" + Environment.NewLine;
                        TxtChatWriteLine(info);
                    }
                }
                else
                {
                    info = $"{cn} : {cw}" + Environment.NewLine;
                }
            }
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            Program.packets.ChatEvent += onChat;

            CharaCv.Clear();
            if (File.Exists(@"C:\Users\MINI_S12\Documents\821Soft\CVDATA.txt") == false)
            {
                return;
            }
            using (StreamReader reader = new StreamReader(@"C:\Users\MINI_S12\Documents\821Soft\CVDATA.txt"))
            {
                Debug.Print("Show s");
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    var rec = new st_ChrarCv();

                    switch (values[0])
                    {
                        case "Npc":
                            rec.CType = CharacterTypes.Npc;
                            break;
                        case "User":
                            rec.CType = CharacterTypes.User;
                            break;
                    }

                    rec.Cn = values[1];
                    rec.CvName = values[2];
                    rec.CvId = int.Parse(values[3]);
                    rec.Checked = bool.Parse(values[4]);
                    rec.speedScale = double.Parse(values[5]);
                    rec.pitchScale = double.Parse(values[6]);
                    rec.intonationScale = double.Parse(values[7]);
                    rec.volumeScale = double.Parse(values[8]);
                    CharaCv.Add(rec);
                    Debug.Print(line);
                }
                Debug.Print("Show e");
            }

            Program.CharaCv.Sort((a, b) => a.Cn.CompareTo(b.Cn));
            string textdata = "";
            foreach (var c in Program.CharaCv)
            {
                textdata += $"{c.Cn},{c.CvName},{c.CvId},{c.Checked},{c.speedScale},{c.pitchScale},{c.intonationScale},{c.volumeScale}" + Environment.NewLine;
            }
            Debug.Print("Load Data");
            Debug.Print(textdata);

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //EnterやEscapeキーでビープ音が鳴らないようにする
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                var st = textBox1.Text.Split(' ');
                string cn = "";
                string cw = "";
                int cv = 3;
                if (st.Length > 2)
                {
                    cn = st[0];
                    cw = st[2];
                    //　担当CV
                    cv = cvSpkId(cn);
                }
                else
                {
                    cw = textBox1.Text;
                }
                textBox1.Text = "";


                _ = Program.vox.MakeSound("sample", cw, true, cv, 1.0, 0.0, 1.0, 1.0);
                var cvinfo = VoicevoxFunction.voxlist.Find(x => x.id == cv);

                textBox2.AppendText($"{cn} : {cw} C.V.({cvinfo.name}{cvinfo.style})" + Environment.NewLine);
            }
        }
        private int cvSpkId(string cn)
        {
            int SpkId = -1;

            var a = Program.CharaCv.Find(x => x.Cn == cn);
            if (a.Cn == null)
            {

            }
            else
            {
                if (a.Checked)
                {
                    SpkId = a.CvId;
                }
            }

            return (SpkId);
        }

        private void Btn_CV_Click(object sender, EventArgs e)
        {
            FrmCV form = new FrmCV();
            form.ShowDialog();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.CharaCv.Count >= 0)
            {
                string textdata = "";
                foreach (var c in Program.CharaCv)
                {
                    textdata += $"{c.CType},{c.Cn},{c.CvName},{c.CvId},{c.Checked},{c.speedScale},{c.pitchScale},{c.intonationScale},{c.volumeScale}" + Environment.NewLine;
                }
                Debug.Print("Write Data");
                Debug.Print(textdata);

                File.WriteAllText(@"C:\Users\MINI_S12\Documents\821Soft\CVDATA.txt", textdata);
            }
        }

        private void Btn_Mute_Click(object sender, EventArgs e)
        {
            Btn_Mute.Checked = !(Btn_Mute.Checked);
        }
    }
}
