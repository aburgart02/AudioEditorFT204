using Domain;
using Infrastructure;

namespace ApplicationLayer
{
    public interface IConverter
    {
        Data ConvertMp3ToWav();
        Data ConvertWavToMp3();
    }

    public class FormatConverter : IConverter
    {
        private Data data;

        public FormatConverter(Data data)
        {
            this.data = data;
        }

        public Data ConvertMp3ToWav()
        {
            return new Mp3ToWavConversion(data).ConvertMp3ToWav();
        }

        public Data ConvertWavToMp3()
        {
            return new WavToMp3Conversion(data).ConvertWavToMp3();
        }
    }
}
