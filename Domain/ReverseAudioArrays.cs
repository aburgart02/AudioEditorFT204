using System;

namespace Domain
{
    public class ReverseAudioArrays
    {
        public byte[] combineArrays(byte[] forwardsArrayWithOnlyHeaders, byte[] reversedArrayWithOnlyAudioData)
        {
            var reversedWavFileStreamByteArray =
                new byte[forwardsArrayWithOnlyHeaders.Length + reversedArrayWithOnlyAudioData.Length];
            Array.Copy(forwardsArrayWithOnlyHeaders, reversedWavFileStreamByteArray,
                forwardsArrayWithOnlyHeaders.Length);
            Array.Copy(reversedArrayWithOnlyAudioData, 0, reversedWavFileStreamByteArray,
                forwardsArrayWithOnlyHeaders.Length, reversedArrayWithOnlyAudioData.Length);
            return reversedWavFileStreamByteArray;
        }

        public byte[] reverseTheForwardsArrayWithOnlyAudioData(int bytesPerSample,
            byte[] forwardsArrayWithOnlyAudioData)
        {
            var length = forwardsArrayWithOnlyAudioData.Length;
            var reversedArrayWithOnlyAudioData = new byte[length];

            var sampleIdentifier = 0;

            for (var i = 0; i < length; i++)
            {
                if (i != 0 && i % bytesPerSample == 0)
                    sampleIdentifier += 2 * bytesPerSample;
                var index = length - bytesPerSample - sampleIdentifier + i;
                reversedArrayWithOnlyAudioData[i] = forwardsArrayWithOnlyAudioData[index];
            }

            return reversedArrayWithOnlyAudioData;
        }

        public byte[] createForwardsArrayWithOnlyAudioData(byte[] forwardsWavFileStreamByteArray,
            int startIndexOfDataChunk)
        {
            var forwardsArrayWithOnlyAudioData =
                new byte[forwardsWavFileStreamByteArray.Length - startIndexOfDataChunk];
            Array.Copy(forwardsWavFileStreamByteArray, startIndexOfDataChunk, forwardsArrayWithOnlyAudioData, 0,
                forwardsWavFileStreamByteArray.Length - startIndexOfDataChunk);
            return forwardsArrayWithOnlyAudioData;
        }

        public byte[] createForwardsArrayWithOnlyHeaders(byte[] forwardsWavFileStreamByteArray,
            int startIndexOfDataChunk)
        {
            var forwardsArrayWithOnlyHeaders = new byte[startIndexOfDataChunk];
            Array.Copy(forwardsWavFileStreamByteArray, 0, forwardsArrayWithOnlyHeaders, 0, startIndexOfDataChunk);
            return forwardsArrayWithOnlyHeaders;
        }
    }
}
