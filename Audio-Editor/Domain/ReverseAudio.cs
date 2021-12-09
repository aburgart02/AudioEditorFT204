using System;
using System.IO;
using Audio_Editor.Infrastructure;
using NAudio.Wave;

namespace Audio_Editor.Domain
{
    public class ReverseAudio
    {
        private const int _bitsPerByte = 8;
        private static int _bytesPerSample;

        public static void Start(string forwardsWavFilePath)
        {
            var forwardsWavFileStreamByteArray = populateForwardsWavFileByteArray(forwardsWavFilePath);
            getWavMetadata(forwardsWavFileStreamByteArray);
            var startIndexOfDataChunk = getStartIndexOfDataChunk(forwardsWavFileStreamByteArray);
            var reversedWavFileStreamByteArray = populateReversedWavFileByteArray(forwardsWavFileStreamByteArray,
                startIndexOfDataChunk, _bytesPerSample);
            writeReversedWavFileByteArrayToFile(reversedWavFileStreamByteArray);
        }

        private static void getWavMetadata(byte[] forwardsWavFileStreamByteArray)
        {
            ReverseMetadata.GetRiffText(forwardsWavFileStreamByteArray);
            ReverseMetadata.GetFileSize(forwardsWavFileStreamByteArray);
            ReverseMetadata.GetWaveText(forwardsWavFileStreamByteArray);
            ReverseMetadata.GetFmtText(forwardsWavFileStreamByteArray);
            ReverseMetadata.GetLengthOfFormatData(forwardsWavFileStreamByteArray);
            ReverseMetadata.GetTypeOfFormat(forwardsWavFileStreamByteArray);
            ReverseMetadata.GetNumOfChannels(forwardsWavFileStreamByteArray);
            ReverseMetadata.GetSampleRate(forwardsWavFileStreamByteArray);
            ReverseMetadata.GetBytesPerSecond(forwardsWavFileStreamByteArray);
            ReverseMetadata.GetBlockAlign(forwardsWavFileStreamByteArray);
            _bytesPerSample = ReverseMetadata.GetBitsPerSample(forwardsWavFileStreamByteArray) / _bitsPerByte;
            ReverseMetadata.GetListText(forwardsWavFileStreamByteArray);
            ReverseMetadata.GetDataText(forwardsWavFileStreamByteArray);
            ReverseMetadata.GetDataSize(forwardsWavFileStreamByteArray);
        }

        private static void writeReversedWavFileByteArrayToFile(byte[] reversedWavFileStreamByteArray)
        {
            using (var reversedFileStream =
                new FileStream(Environment.CurrentDirectory + @"\temp" + Globals.index + ".wav", FileMode.Create,
                    FileAccess.Write, FileShare.Write))
            {
                reversedFileStream.Write(reversedWavFileStreamByteArray, 0, reversedWavFileStreamByteArray.Length);
            }

            var updater = new Updater();
            updater.UpdateAudio();
        }

        private static byte[] populateReversedWavFileByteArray(byte[] forwardsWavFileStreamByteArray,
            int startIndexOfDataChunk, int bytesPerSample)
        {
            var forwardsArrayWithOnlyHeaders =
                createForwardsArrayWithOnlyHeaders(forwardsWavFileStreamByteArray, startIndexOfDataChunk);

            var forwardsArrayWithOnlyAudioData =
                createForwardsArrayWithOnlyAudioData(forwardsWavFileStreamByteArray, startIndexOfDataChunk);

            var reversedArrayWithOnlyAudioData =
                reverseTheForwardsArrayWithOnlyAudioData(bytesPerSample, forwardsArrayWithOnlyAudioData);

            var reversedWavFileStreamByteArray =
                combineArrays(forwardsArrayWithOnlyHeaders, reversedArrayWithOnlyAudioData);

            return reversedWavFileStreamByteArray;
        }

        private static byte[] combineArrays(byte[] forwardsArrayWithOnlyHeaders, byte[] reversedArrayWithOnlyAudioData)
        {
            var reversedWavFileStreamByteArray =
                new byte[forwardsArrayWithOnlyHeaders.Length + reversedArrayWithOnlyAudioData.Length];
            Array.Copy(forwardsArrayWithOnlyHeaders, reversedWavFileStreamByteArray,
                forwardsArrayWithOnlyHeaders.Length);
            Array.Copy(reversedArrayWithOnlyAudioData, 0, reversedWavFileStreamByteArray,
                forwardsArrayWithOnlyHeaders.Length, reversedArrayWithOnlyAudioData.Length);
            return reversedWavFileStreamByteArray;
        }

        private static byte[] reverseTheForwardsArrayWithOnlyAudioData(int bytesPerSample,
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

        private static byte[] createForwardsArrayWithOnlyAudioData(byte[] forwardsWavFileStreamByteArray,
            int startIndexOfDataChunk)
        {
            var forwardsArrayWithOnlyAudioData =
                new byte[forwardsWavFileStreamByteArray.Length - startIndexOfDataChunk];
            Array.Copy(forwardsWavFileStreamByteArray, startIndexOfDataChunk, forwardsArrayWithOnlyAudioData, 0,
                forwardsWavFileStreamByteArray.Length - startIndexOfDataChunk);
            return forwardsArrayWithOnlyAudioData;
        }

        private static byte[] createForwardsArrayWithOnlyHeaders(byte[] forwardsWavFileStreamByteArray,
            int startIndexOfDataChunk)
        {
            var forwardsArrayWithOnlyHeaders = new byte[startIndexOfDataChunk];
            Array.Copy(forwardsWavFileStreamByteArray, 0, forwardsArrayWithOnlyHeaders, 0, startIndexOfDataChunk);
            return forwardsArrayWithOnlyHeaders;
        }

        private static byte[] populateForwardsWavFileByteArray(string forwardsWavFilePath)
        {
            var forwardsWavFileStream =
                new FileStream(forwardsWavFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var forwardsWavFileStreamByteArray = new byte[forwardsWavFileStream.Length];
            forwardsWavFileStream.Read(forwardsWavFileStreamByteArray, 0, (int) forwardsWavFileStream.Length);
            return forwardsWavFileStreamByteArray;
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