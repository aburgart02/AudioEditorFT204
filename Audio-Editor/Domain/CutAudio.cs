using System;
using Audio_Editor.Infrastructure;
using NAudio.Wave;

namespace Audio_Editor.Domain
{
    internal class CutAudio
    {
        public static void TrimWavFile(TimeSpan cutFromStart, TimeSpan cutFromEnd)
        {
            using (var rdr = Globals.reader)
            {
                using (var writer = new WaveFileWriter(
                    Environment.CurrentDirectory + @"\temp" + Globals.index + ".wav", rdr.WaveFormat))
                {
                    var bytesPerMillisecond = rdr.WaveFormat.AverageBytesPerSecond / 1000;
                    var startPos = (int) cutFromStart.TotalMilliseconds * bytesPerMillisecond;
                    startPos = startPos - startPos % rdr.WaveFormat.BlockAlign;
                    var endBytes = (int) cutFromEnd.TotalMilliseconds * bytesPerMillisecond;
                    endBytes = endBytes - endBytes % rdr.WaveFormat.BlockAlign;
                    var endPos = (int) rdr.Length - endBytes;
                    TrimWavFile(rdr, writer, startPos, endPos);
                }
            }

            var updater = new Updater();
            updater.UpdateAudio();
        }

        public static void TrimWavFile(MediaFoundationReader reader, WaveFileWriter writer,
            int startPos, int endPos)
        {
            reader.Position = startPos;
            var buffer = new byte[1024];
            while (reader.Position < endPos)
            {
                var bytesRequired = (int) (endPos - reader.Position);
                if (bytesRequired <= 0) continue;
                var bytesToRead = Math.Min(bytesRequired, buffer.Length);
                var bytesRead = reader.Read(buffer, 0, bytesToRead);
                if (bytesRead > 0) writer.Write(buffer, 0, bytesRead);
                if (bytesRead == 0) break;
            }
        }
    }
}