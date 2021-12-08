using NAudio.Wave;

namespace Audio_Editor.ApplicationLayer
{
    public interface IConverter
    {
        void ConvertMp3ToWav();
        void ConvertWavToMp3();
    }

    class FormatConverter
    {
        public void ConvertMp3ToWav()
        {
            Domain.Mp3ToWavConversion.ConvertMp3ToWav();
        }

        public void ConvertWavToMp3()
        {
            Domain.WavToMp3Conversion.ConvertWavToMp3();
        }
    }
}
