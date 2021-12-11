using NAudio.Wave;
using Domain;
using Infrastructure;

namespace ApplicationLayer
{
    public interface IConverter
    {
        void ConvertMp3ToWav();
        void ConvertWavToMp3();
    }

    public class FormatConverter
    {
        public void ConvertMp3ToWav(Data data)
        {
            Mp3ToWavConversion.ConvertMp3ToWav(data);
        }

        public void ConvertWavToMp3()
        {
            WavToMp3Conversion.ConvertWavToMp3();
        }
    }
}
