using Domain;
using Infrastructure;

namespace ApplicationLayer
{
    public interface IConvert
    {
        Data Convert(Data data);
    }

    public class WavToMp3Converter : IConvert
    {
        public Data Convert(Data data)
        {
            return new WavToMp3Conversion().ConvertWavToMp3(data);
        }
    }

    public class Mp3ToWavConverter : IConvert
    {
        public Data Convert(Data data)
        {
            return new Mp3ToWavConversion().ConvertMp3ToWav(data);
        }
    }
}
