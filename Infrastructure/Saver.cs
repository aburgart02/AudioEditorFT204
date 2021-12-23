using NAudio.Wave;

namespace Infrastructure
{
    public interface ISaver
    {
        void SaveTrack(string fileName, int loopCount, Data data);
    }

    public class Saver : ISaver
    {
        public void SaveTrack(string fileName, int loopCount, Data data)
        {
            using (var rdr = new MediaFoundationReader(data.path))
            using (var waveFileWriter = new WaveFileWriter(fileName, rdr.WaveFormat))
            {
                var tracks = new MediaFoundationReader[loopCount];
                for (var i = 0; i < loopCount; i++)
                    tracks[i] = new MediaFoundationReader(data.path);
                var buffer = new byte[rdr.WaveFormat.AverageBytesPerSecond];
                int read;
                foreach (var track in tracks)
                    while ((read = track.Read(buffer, 0, buffer.Length)) > 0)
                        waveFileWriter.Write(buffer, 0, read);
            }
        }
    }
}