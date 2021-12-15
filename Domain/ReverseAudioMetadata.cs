using System;

namespace Domain
{
    public class ReverseAudioMetadata
    {
        public ushort GetTypeOfFormat(byte[] forwardsWavFileStreamByteArray)
        {
            var startIndex = 20;
            var endIndex = 21;
            var typeOfFormatByteArray =
                GetRelevantBytesIntoNewArray(forwardsWavFileStreamByteArray, startIndex, endIndex);
            var typeOfFormat = BitConverter.ToUInt16(typeOfFormatByteArray, 0);
            Console.WriteLine("Type of format (1 is PCM) = {0}", typeOfFormat);
            return typeOfFormat;
        }

        public void GetFmtText(byte[] forwardsWavFileStreamByteArray)
        {
            var startIndex = 12;
            var endIndex = 15;
            GetAsciiText(forwardsWavFileStreamByteArray, startIndex, endIndex);
        }

        public string GetWaveText(byte[] forwardsWavFileStreamByteArray)
        {
            var startIndex = 8;
            var endIndex = 11;
            return GetAsciiText(forwardsWavFileStreamByteArray, startIndex, endIndex);
        }

        public string GetRiffText(byte[] forwardsWavFileStreamByteArray)
        {
            var startIndex = 0;
            var endIndex = 3;
            return GetAsciiText(forwardsWavFileStreamByteArray, startIndex, endIndex);
        }

        public uint GetLengthOfFormatData(byte[] forwardsWavFileStreamByteArray)
        {
            var startIndex = 16;
            var endIndex = 19;
            var lengthOfFormatDataByteArray =
                GetRelevantBytesIntoNewArray(forwardsWavFileStreamByteArray, startIndex, endIndex);
            var lengthOfFormatData = BitConverter.ToUInt32(lengthOfFormatDataByteArray, 0);
            Console.WriteLine("Length of format data = {0}", lengthOfFormatData);
            return lengthOfFormatData;
        }

        public byte[] GetRelevantBytesIntoNewArray(byte[] forwardsWavFileStreamByteArray, int startIndex,
            int endIndex)
        {
            var length = endIndex - startIndex + 1;
            var relevantBytesArray = new byte[length];
            Array.Copy(forwardsWavFileStreamByteArray, startIndex, relevantBytesArray, 0, length);
            return relevantBytesArray;
        }

        public uint GetFileSize(byte[] forwardsWavFileStreamByteArray)
        {
            var fileSizeStartIndex = 4;
            var fileSizeEndIndex = 7;
            var fileSizeByteArray =
                GetRelevantBytesIntoNewArray(forwardsWavFileStreamByteArray, fileSizeStartIndex, fileSizeEndIndex);
            var fileSize = BitConverter.ToUInt32(fileSizeByteArray, 0) + 8;
            Console.WriteLine("File size = {0}", fileSize);
            return fileSize;
        }

        public string GetAsciiText(byte[] forwardsWavFileStreamByteArray, int startIndex, int endIndex)
        {
            var asciiText = "";
            for (var i = startIndex; i <= endIndex; i++) asciiText += Convert.ToChar(forwardsWavFileStreamByteArray[i]);
            Console.WriteLine(asciiText);
            return asciiText;
        }

        public ushort GetNumOfChannels(byte[] forwardsWavFileStreamByteArray)
        {
            var numOfChannelsStartIndex = 22;
            var numOfChannelsEndIndex = 23;
            var numOfChannelsByteArray = GetRelevantBytesIntoNewArray(forwardsWavFileStreamByteArray,
                numOfChannelsStartIndex, numOfChannelsEndIndex);
            var numOfChannels = BitConverter.ToUInt16(numOfChannelsByteArray, 0);
            Console.WriteLine("Number Of Channels = {0}", numOfChannels);
            return numOfChannels;
        }

        public uint GetSampleRate(byte[] forwardsWavFileStreamByteArray)
        {
            var sampleRateStartIndex = 24;
            var sampleRateEndIndex = 27;
            var sampleRateByteArray = GetRelevantBytesIntoNewArray(forwardsWavFileStreamByteArray, sampleRateStartIndex,
                sampleRateEndIndex);
            var sampleRate = BitConverter.ToUInt32(sampleRateByteArray, 0);
            Console.WriteLine("Sample Rate = {0}", sampleRate);
            return sampleRate;
        }

        public uint GetBytesPerSecond(byte[] forwardsWavFileStreamByteArray)
        {
            var bytesPerSecondStartIndex = 28;
            var bytesPerSecondEndIndex = 31;
            var bytesPerSecondByteArray = GetRelevantBytesIntoNewArray(forwardsWavFileStreamByteArray,
                bytesPerSecondStartIndex, bytesPerSecondEndIndex);
            var bytesPerSecond = BitConverter.ToUInt32(bytesPerSecondByteArray, 0);
            Console.WriteLine("Bytes Per Second = {0}", bytesPerSecond);
            return bytesPerSecond;
        }

        public ushort GetBlockAlign(byte[] forwardsWavFileStreamByteArray)
        {
            var blockAlignStartIndex = 32;
            var blockAlignEndIndex = 33;
            var blockAlignByteArray = GetRelevantBytesIntoNewArray(forwardsWavFileStreamByteArray, blockAlignStartIndex,
                blockAlignEndIndex);
            var blockAlign = BitConverter.ToUInt16(blockAlignByteArray, 0);
            Console.WriteLine("Block Align = {0}", blockAlign);
            return blockAlign;
        }

        public ushort GetBitsPerSample(byte[] forwardsWavFileStreamByteArray)
        {
            var bitsPerSampleStartIndex = 34;
            var bitsPerSampleEndIndex = 35;
            var bitsPerSampleByteArray = GetRelevantBytesIntoNewArray(forwardsWavFileStreamByteArray,
                bitsPerSampleStartIndex, bitsPerSampleEndIndex);
            var bitsPerSample = BitConverter.ToUInt16(bitsPerSampleByteArray, 0);
            Console.WriteLine("Bits Per Sample = {0}", bitsPerSample);
            return bitsPerSample;
        }

        public void GetDataText(byte[] forwardsWavFileStreamByteArray)
        {
            var startIndex = 70;
            var endIndex = 73;
            GetAsciiText(forwardsWavFileStreamByteArray, startIndex, endIndex);
        }

        public void GetListText(byte[] forwardsWavFileStreamByteArray)
        {
            var startIndex = 36;
            var endIndex = 39;
            GetAsciiText(forwardsWavFileStreamByteArray, startIndex, endIndex);
        }

        public uint GetDataSize(byte[] forwardsWavFileStreamByteArray)
        {
            var dataSizeStartIndex = 70;
            var dataSizeEndIndex = 73;
            var dataSizeByteArray =
                GetRelevantBytesIntoNewArray(forwardsWavFileStreamByteArray, dataSizeStartIndex, dataSizeEndIndex);
            uint dataSize = BitConverter.ToUInt16(dataSizeByteArray, 0);
            Console.WriteLine("Data Size = {0}", dataSize);
            return dataSize;
        }
    }
}