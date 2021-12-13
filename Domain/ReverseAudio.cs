using Infrastructure;

namespace Domain
{
    public class ReverseAudio : ReverseAudioFileInteraction
    {
        private const int _bitsPerByte = 8;
        private static int _bytesPerSample;

        public static void Start(Data data)
        {
            var forwardsWavFileStreamByteArray = populateForwardsWavFileByteArray(data.path);
            getWavMetadata(forwardsWavFileStreamByteArray);
            var startIndexOfDataChunk = getStartIndexOfDataChunk(forwardsWavFileStreamByteArray);
            var reversedWavFileStreamByteArray = populateReversedWavFileByteArray(forwardsWavFileStreamByteArray,
                startIndexOfDataChunk, _bytesPerSample);
            writeReversedWavFileByteArrayToFile(reversedWavFileStreamByteArray, data);
        }

        private static byte[] populateReversedWavFileByteArray(byte[] forwardsWavFileStreamByteArray,
            int startIndexOfDataChunk, int bytesPerSample)
        {
            var forwardsArrayWithOnlyHeaders =
                ReverseAudioArrays.createForwardsArrayWithOnlyHeaders(forwardsWavFileStreamByteArray, startIndexOfDataChunk);
            var forwardsArrayWithOnlyAudioData =
                ReverseAudioArrays.createForwardsArrayWithOnlyAudioData(forwardsWavFileStreamByteArray, startIndexOfDataChunk);
            var reversedArrayWithOnlyAudioData =
                ReverseAudioArrays.reverseTheForwardsArrayWithOnlyAudioData(bytesPerSample, forwardsArrayWithOnlyAudioData);
            var reversedWavFileStreamByteArray =
                ReverseAudioArrays.combineArrays(forwardsArrayWithOnlyHeaders, reversedArrayWithOnlyAudioData);
            return reversedWavFileStreamByteArray;
        }

        private static void getWavMetadata(byte[] forwardsWavFileStreamByteArray)
        {
            ReverseAudioMetadata.GetRiffText(forwardsWavFileStreamByteArray);
            ReverseAudioMetadata.GetFileSize(forwardsWavFileStreamByteArray);
            ReverseAudioMetadata.GetWaveText(forwardsWavFileStreamByteArray);
            ReverseAudioMetadata.GetFmtText(forwardsWavFileStreamByteArray);
            ReverseAudioMetadata.GetLengthOfFormatData(forwardsWavFileStreamByteArray);
            ReverseAudioMetadata.GetTypeOfFormat(forwardsWavFileStreamByteArray);
            ReverseAudioMetadata.GetNumOfChannels(forwardsWavFileStreamByteArray);
            ReverseAudioMetadata.GetSampleRate(forwardsWavFileStreamByteArray);
            ReverseAudioMetadata.GetBytesPerSecond(forwardsWavFileStreamByteArray);
            ReverseAudioMetadata.GetBlockAlign(forwardsWavFileStreamByteArray);
            _bytesPerSample = ReverseAudioMetadata.GetBitsPerSample(forwardsWavFileStreamByteArray) / _bitsPerByte;
            ReverseAudioMetadata.GetListText(forwardsWavFileStreamByteArray);
            ReverseAudioMetadata.GetDataText(forwardsWavFileStreamByteArray);
            ReverseAudioMetadata.GetDataSize(forwardsWavFileStreamByteArray);
        }

        private static int getStartIndexOfDataChunk(byte[] forwardsWavFileStreamByteArray)
        {
            var startIndexOfAudioData = 12;
            var charDAsciiDecimalCode = 100;
            var charAAsciiDecimalCode = 97;
            var charTAsciiDecimalCode = 116;
            int chunkSize;
            while (!(forwardsWavFileStreamByteArray[startIndexOfAudioData] == charDAsciiDecimalCode &&
                     forwardsWavFileStreamByteArray[startIndexOfAudioData + 1] == charAAsciiDecimalCode &&
                     forwardsWavFileStreamByteArray[startIndexOfAudioData + 2] == charTAsciiDecimalCode &&
                     forwardsWavFileStreamByteArray[startIndexOfAudioData + 3] == charAAsciiDecimalCode))
            {
                startIndexOfAudioData += 4;
                chunkSize = forwardsWavFileStreamByteArray[startIndexOfAudioData] +
                            forwardsWavFileStreamByteArray[startIndexOfAudioData + 1] * 256 +
                            forwardsWavFileStreamByteArray[startIndexOfAudioData + 2] * 65536 +
                            forwardsWavFileStreamByteArray[startIndexOfAudioData + 3] * 16777216;
                startIndexOfAudioData += 4 + chunkSize;
            }

            startIndexOfAudioData += 8;
            return startIndexOfAudioData;
        }
    }
}