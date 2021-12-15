using Infrastructure;

namespace Domain
{
    public class ReverseAudio
    {
        private const int _bitsPerByte = 8;
        private static int _bytesPerSample;
        private Data data;
        private readonly ReverseAudioFileInteraction fileInteraction;
        private readonly ReverseAudioArrays arraysInteraction;
        private readonly ReverseAudioMetadata reverseMetadata;

        public ReverseAudio(ReverseAudioFileInteraction fi, ReverseAudioArrays ai, ReverseAudioMetadata rm, Data data)
        {
            fileInteraction = fi;
            arraysInteraction = ai;
            reverseMetadata = rm;
            this.data = data;
        }

        public Data Start()
        {
            var forwardsWavFileStreamByteArray = fileInteraction.populateForwardsWavFileByteArray(data.path);
            getWavMetadata(forwardsWavFileStreamByteArray);
            var startIndexOfDataChunk = getStartIndexOfDataChunk(forwardsWavFileStreamByteArray);
            var reversedWavFileStreamByteArray = populateReversedWavFileByteArray(forwardsWavFileStreamByteArray,
                startIndexOfDataChunk, _bytesPerSample);
            return fileInteraction.writeReversedWavFileByteArrayToFile(reversedWavFileStreamByteArray, data);
        }

        private byte[] populateReversedWavFileByteArray(byte[] forwardsWavFileStreamByteArray,
            int startIndexOfDataChunk, int bytesPerSample)
        {
            var forwardsArrayWithOnlyHeaders = 
                arraysInteraction.createForwardsArrayWithOnlyHeaders(forwardsWavFileStreamByteArray, startIndexOfDataChunk);
            var forwardsArrayWithOnlyAudioData =
                arraysInteraction.createForwardsArrayWithOnlyAudioData(forwardsWavFileStreamByteArray, startIndexOfDataChunk);
            var reversedArrayWithOnlyAudioData =
                arraysInteraction.reverseTheForwardsArrayWithOnlyAudioData(bytesPerSample, forwardsArrayWithOnlyAudioData);
            var reversedWavFileStreamByteArray =
                arraysInteraction.combineArrays(forwardsArrayWithOnlyHeaders, reversedArrayWithOnlyAudioData);
            return reversedWavFileStreamByteArray;
        }

        private void getWavMetadata(byte[] forwardsWavFileStreamByteArray)
        {
            reverseMetadata.GetRiffText(forwardsWavFileStreamByteArray);
            reverseMetadata.GetFileSize(forwardsWavFileStreamByteArray);
            reverseMetadata.GetWaveText(forwardsWavFileStreamByteArray);
            reverseMetadata.GetFmtText(forwardsWavFileStreamByteArray);
            reverseMetadata.GetLengthOfFormatData(forwardsWavFileStreamByteArray);
            reverseMetadata.GetTypeOfFormat(forwardsWavFileStreamByteArray);
            reverseMetadata.GetNumOfChannels(forwardsWavFileStreamByteArray);
            reverseMetadata.GetSampleRate(forwardsWavFileStreamByteArray);
            reverseMetadata.GetBytesPerSecond(forwardsWavFileStreamByteArray);
            reverseMetadata.GetBlockAlign(forwardsWavFileStreamByteArray);
            _bytesPerSample = reverseMetadata.GetBitsPerSample(forwardsWavFileStreamByteArray) / _bitsPerByte;
            reverseMetadata.GetListText(forwardsWavFileStreamByteArray);
            reverseMetadata.GetDataText(forwardsWavFileStreamByteArray);
            reverseMetadata.GetDataSize(forwardsWavFileStreamByteArray);
        }

        private int getStartIndexOfDataChunk(byte[] forwardsWavFileStreamByteArray)
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