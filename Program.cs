using System.Diagnostics;
using static VoiceVoxSpeaker.VoxIf;

namespace VoiceVoxSpeaker
{


    internal static class Program
    {
        public struct st_ChrarCv
        {
            public CharacterTypes CType ;
            public string Cn;
            public string CvName;
            public int CvId;
            public bool Checked;
            public double speedScale;
            public double pitchScale;
            public double intonationScale;
            public double volumeScale;
        }
        static public MabiPacket packets = new MabiPacket();

        public static List<st_ChrarCv> CharaCv = new List<st_ChrarCv>();
        public static st_ChrarCv ParamItem = new st_ChrarCv();


        public static void ChrarCv_Add(st_ChrarCv item)
        {
            var Fc = CharaCv.Find(x => x.Cn == item.Cn);
            if ( Fc.Cn == null )
            {
                CharaCv.Add(item);
            }
            else
            {
                Fc.CType = item.CType;
                Fc.Cn = item.Cn;
                Fc.CvName = item.CvName;
                Fc.CvId = item.CvId;
                Fc.Checked = item.Checked;
                Fc.speedScale = item.speedScale;
                Fc.pitchScale = item.pitchScale;
                Fc.intonationScale = item.intonationScale;
                Fc.volumeScale = item.volumeScale;
            }
        }

        public static void ChrarCv_upd(st_ChrarCv item)
        {
            var Fc = CharaCv.Find(x => x.Cn == item.Cn);
            if (Fc.Equals(null))
            {
                CharaCv.Add(item);
            }
            else
            {
                var i = CharaCv.IndexOf(Fc);

                Fc.CType = item.CType;
                Fc.Cn = item.Cn;
                Fc.CvName = item.CvName;
                Fc.CvId = item.CvId;
                Fc.Checked = item.Checked;
                Fc.speedScale = item.speedScale;
                Fc.pitchScale = item.pitchScale;
                Fc.intonationScale = item.intonationScale;
                Fc.volumeScale = item.volumeScale;
                CharaCv[i] = Fc;
            }
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        public static VoicevoxFunction vox = new VoicevoxFunction("127.0.0.1", "50021");

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();


            var splist = Program.vox.VoxSpeakerList();
            foreach (var s in splist)
            {
                // Debug.Print($"{s.id} {s.name} {s.style}");
            }

            Application.Run(new FrmMain());
        }
    }
}