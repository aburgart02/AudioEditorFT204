using Domain;
using Infrastructure;

namespace ApplicationLayer
{
    public interface IConvert
    {
        Data Convert(Data data, Converter converter);
    }

    public class WavToMp3Converter : IConvert
    {
        public Data Convert(Data data, Converter converter)
        {
            return converter.ConvertWavToMp3(data);
        }
    }

    public class Mp3ToWavConverter : IConvert
    {
        public Data Convert(Data data, Converter converter)
        {
            return converter.ConvertMp3ToWav(data);
        }
    }
}
