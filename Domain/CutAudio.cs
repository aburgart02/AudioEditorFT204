using System;
using Infrastructure;
using NAudio.Wave;

namespace Domain
{
    public class CutAudio
    {
        public static void TrimWavFile(TimeSpan cutFromStart, TimeSpan cutFromEnd, Data data, WaveFileWriter fileWriter)
        {
            using (var rdr = data.reader)
            {
                using (var writer = fileWriter)
                {
                    var bytesPerMillisecond = rdr.WaveFormat.AverageBytesPerSecond / 1000;
                    var startPos = (int)cutFromStart.TotalMilliseconds * bytesPerMillisecond;
                    startPos = startPos - startPos % rdr.WaveFormat.BlockAlign;
                    var endBytes = (int)cutFromEnd.TotalMilliseconds * bytesPerMillisecond;
                    endBytes = endBytes - endBytes % rdr.WaveFormat.BlockAlign;
                    var endPos = (int)rdr.Length - endBytes;
                    TrimWavFile(writer, startPos, endPos, data.reader);
                }
            }

            var updater = new Updater();
            updater.UpdateAudio(data);
            var saver = new Saver();
            saver.SaveTrack(Environment.CurrentDirectory + @"\temp" + data.index + data.extension, 1, data);
            updater.UpdateAudio(data);
        }

        public static void TrimWavFile(WaveFileWriter writer,
            int startPos, int endPos, MediaFoundationReader reader)
        {
            reader.Position = startPos;
            var buffer = new byte[1024];
            while (reader.Position < endPos)
            {
                var bytesRequired = (int)(endPos - reader.Position);
                if (bytesRequired <= 0) continue;
                var bytesToRead = Math.Min(bytesRequired, buffer.Length);
                var bytesRead = reader.Read(buffer, 0, bytesToRead);
                if (bytesRead > 0) writer.Write(buffer, 0, bytesRead);
                if (bytesRead == 0)
                    break;
            }
        }
    }
}