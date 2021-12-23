using Infrastructure;
using System.IO;
using NAudio.Lame;
using System;
using System.Linq;
using NAudio.Wave;

namespace Domain
{
    public class Converter
    {
        public Data ConvertMp3ToWav(Data data)
        {
            using (var rdr = new MediaFoundationReader(data.path))
            {
                WaveFileWriter.CreateWaveFile(Environment.CurrentDirectory + @"\temp" + data.index + ".wav", rdr);
            }
            data.extension = ".wav";
            var updater = new Updater();
            return updater.UpdateAudio(data);
        }

        public static byte[] arr;

        public Data ConvertWavToMp3(Data data)
        {
            CheckAddBinPath();
            using (var retMs = new MemoryStream())
            using (var rdr = new MediaFoundationReader(data.path))
            using (var wtr = new LameMP3FileWriter(retMs, rdr.WaveFormat, 128))
            {
                rdr.CopyTo(wtr);
                arr = retMs.ToArray();
            }
            using (var reversedFileStream =
                new FileStream(Environment.CurrentDirectory + @"\temp" + data.index + ".mp3", FileMode.Create,
                    FileAccess.Write, FileShare.Write))
            {
                reversedFileStream.Write(arr, 0, arr.Length);
            }
            data.extension = ".mp3";
            var updater = new Updater();
            return updater.UpdateAudio(data);
        }

        public void CheckAddBinPath()
        {
            var binPath = Path.Combine(new string[] { AppDomain.CurrentDomain.BaseDirectory, "bin" });
            var path = Environment.GetEnvironmentVariable("PATH") ?? "";
            if (!path.Split(Path.PathSeparator).Contains(binPath, StringComparer.CurrentCultureIgnoreCase))
            {
                path = string.Join(Path.PathSeparator.ToString(), new string[] { path, binPath });
                Environment.SetEnvironmentVariable("PATH", path);
            }
        }
    }
}
