using System;
using NAudio.Wave;
using Audio_Editor.Infrastructure;

namespace Audio_Editor.Domain
{
    class CutFile
    {
        public static void TrimWavFile(TimeSpan cutFromStart, TimeSpan cutFromEnd)
        {
            using (var rdr = Globals.reader)
            {
                using (var writer = new WaveFileWriter(
                    Environment.CurrentDirectory + @"\temp" + Globals.index + ".wav", rdr.WaveFormat))
                {
                    int bytesPerMillisecond = rdr.WaveFormat.AverageBytesPerSecond / 1000;
                    int startPos = (int)cutFromStart.TotalMilliseconds * bytesPerMillisecond;
                    startPos = startPos - startPos % rdr.WaveFormat.BlockAlign;
                    int endBytes = (int)cutFromEnd.TotalMilliseconds * bytesPerMillisecond;
                    endBytes = endBytes - endBytes % rdr.WaveFormat.BlockAlign;
                    int endPos = (int)rdr.Length - endBytes;
                    TrimWavFile(rdr, writer, startPos, endPos);
                }
            }
            Globals.reader = new MediaFoundationReader(Environment.CurrentDirectory + @"\temp" + Globals.index + ".wav");
            Globals.player.Open(new Uri(Environment.CurrentDirectory + @"\temp" + Globals.index + ".wav"));
            Globals.path = Environment.CurrentDirectory + @"\temp" + Globals.index + ".wav";
            Globals.index += 1;
        }

        public static void TrimWavFile(MediaFoundationReader reader, WaveFileWriter writer,
            int startPos, int endPos)
        {
            reader.Position = startPos;
            byte[] buffer = new byte[1024];
            while (reader.Position < endPos)
            {
                int bytesRequired = (int)(endPos - reader.Position);
                if (bytesRequired > 0)
                {
                    int bytesToRead = Math.Min(bytesRequired, buffer.Length);
                    int bytesRead = reader.Read(buffer, 0, bytesToRead);
                    if (bytesRead > 0)
                    {
                        writer.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
}
