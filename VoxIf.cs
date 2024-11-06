using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections;

namespace VoiceVoxSpeaker
{
    internal class VoxIf
    {

        public class Style
        {
            [JsonPropertyName("name")]
            public string? Name { get; set; }

            [JsonPropertyName("id")]
            public int Id { get; set; }
        }

        public class SupportedFeatures
        {
            [JsonPropertyName("permitted_synthesis_morphing")]
            public string? PermittedSynthesisMorphing { get; set; }
        }

        public class Speaker
        {
            [JsonPropertyName("supported_features")]
            public SupportedFeatures? SupportedFeatures { get; set; }

            [JsonPropertyName("name")]
            public string? Name { get; set; }

            [JsonPropertyName("speaker_uuid")]
            public string? SpeakerUuid { get; set; }

            [JsonPropertyName("styles")]
            public List<Style>? Styles { get; set; }

            [JsonPropertyName("version")]
            public string? Version { get; set; }
        }
        public class VOICEVOX_query
        {
            public Accent_phrases[] accent_phrases { get; set; }
            public double speedScale { get; set; }
            public double pitchScale { get; set; }
            public double intonationScale { get; set; }
            public double volumeScale { get; set; }
            public double prePhonemeLength { get; set; }
            public double postPhonemeLength { get; set; }
            public int outputSamplingRate { get; set; }
            public bool outputStereo { get; set; }
            public string kana { get; set; }
        }

        public class Accent_phrases
        {
            public Moras[] moras { get; set; }
            public int accent { get; set; }
            public Moras? pause_mora { get; set; }
            public bool is_interrogative { get; set; }
        }

        public class Moras
        {
            public string text { get; set; }
            public string? consonant { get; set; }
            public double? consonant_length { get; set; }
            public string? vowel { get; set; }
            public double vowel_length { get; set; }
            public double pitch { get; set; }
        }

        public class VoicevoxFunction
        {
            private readonly string ipPort;
            public struct st_Speakers
            {
                public int id;
                public string name;
                public string style;
                public double speedScale;
                public double pitchScale;
                public double intonationScale;
                public double volumeScale;

            }

            static public List<st_Speakers> voxlist = new List<st_Speakers>();

            public VoicevoxFunction(string _ipAdress, string _port)
            {
                ipPort = "http://" + _ipAdress + ":" + _port;
            }

            public IEnumerable<Speaker> EnumerateSpeakers()
            {
                var jsonStr = GetSpeakersAsJson().Result;

                var deserialized = JsonSerializer.Deserialize<List<Speaker>>(jsonStr);
                if (deserialized is null)
                {
                    yield break;
                }

                foreach (var speakerInfo in deserialized)
                {
                    yield return speakerInfo;
                }
            }
            public List<st_Speakers> VoxSpeakerList()
            {
                List <st_Speakers> ret = new List<st_Speakers>();
                var jsonStr = GetSpeakersAsJson().Result;
                var deserialized = JsonSerializer.Deserialize<List<Speaker>>(jsonStr);
                if (deserialized is null)
                {
                    return (ret);
                }

                foreach (var speakerInfo in deserialized)
                {
                    foreach (var item in speakerInfo.Styles)
                    {
                        var rec = new st_Speakers();
                        rec.id = item.Id;
                        rec.name = speakerInfo.Name;
                        rec.style = item.Name;
                        rec.speedScale = 1.0;
                        rec.pitchScale = 0.0;
                        rec.intonationScale = 1.0;
                        rec.volumeScale = 1.0;
                        ret.Add(rec);
                    }
                }
                voxlist = ret;
                return (ret);
            }

            private async Task<string> GetSpeakersAsJson()
            {
                string jsonQuery;
                using (var httpClient = new HttpClient())
                {
                    string uurl = $"{ipPort}/speakers";
                    Debug.Print($"{uurl}");
                    using var requestMessage = new HttpRequestMessage(new HttpMethod("GET"), uurl);
                    { 
                    requestMessage.Headers.TryAddWithoutValidation("accept", "application/json");

                    requestMessage.Content = new StringContent("");
                    requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
                    var response = await httpClient.SendAsync(requestMessage);
                    jsonQuery = await response.Content.ReadAsStringAsync();
                    }
                }
                return jsonQuery;

            }

            //音声クエリの加工
            private async Task<string> MakeQuery(string _text, int _speakerId ,double speed,double pitch, double intonation , double volume )
            {
                string jsonQuery;
                using (var httpClient = new HttpClient())
                {
                    string url = ipPort + "/audio_query?text=" + _text + "&speaker=" + _speakerId;
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), url))
                    {
                        request.Headers.TryAddWithoutValidation("accept", "application/json");
                        request.Content = new StringContent("");
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
                        var response = await httpClient.SendAsync(request);
                        jsonQuery = await response.Content.ReadAsStringAsync();
                    }
                }
                VOICEVOX_query query2 = JsonSerializer.Deserialize<VOICEVOX_query>(jsonQuery);
                query2.speedScale = speed;
                query2.pitchScale = pitch;
                query2.intonationScale = intonation;
                query2.volumeScale = volume;
                jsonQuery = JsonSerializer.Serialize<VOICEVOX_query>(query2);
                return jsonQuery;
            }
            public async Task MakeSound(string _title, string _text, bool _upspeak, int _speakerId, double speed, double pitch, double intonation, double volume)
            {
                Debug.Print($"make {_speakerId} {_text}");
                using (var httpClient = new HttpClient())
                {
                    string url = ipPort + "/synthesis?speaker=" + _speakerId + "&enable_interrogative_upspeak=" + _upspeak;
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), url))
                    {
                        request.Headers.TryAddWithoutValidation("accept", "audio/wav");
                        request.Content = new StringContent(await MakeQuery(_text, _speakerId, speed, pitch, intonation, volume));
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                        var response = await httpClient.SendAsync(request);
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            string fileName = _title + ".wav";
                            using (var fileStream = File.Create(fileName))
                            {
                                using (var httpStream = await response.Content.ReadAsStreamAsync())
                                {
                                    httpStream.CopyTo(fileStream);
                                    fileStream.Flush();
                                }
                            }
                            var sp = new SoundPlayer(fileName);
                            Debug.Print($"play {_speakerId} {_text}");

                            sp.Play();
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                    }
                }
            }
        }

    }
}
