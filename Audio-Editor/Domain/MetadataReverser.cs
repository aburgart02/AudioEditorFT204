using System;

namespace Audio_Editor.Domain
{
    static class MetadataReverser
    {
        internal static ushort GetTypeOfFormat(byte[] forwardsWavFileStreamByteArray)
        {
            int startIndex = 20;
            int endIndex = 21;
            byte[] typeOfFormatByteArray = GetRelevantBytesIntoNewArray(forwardsWavFileStreamByteArray, startIndex, endIndex);
            ushort typeOfFormat = BitConverter.ToUInt16(typeOfFormatByteArray, 0);
            Console.WriteLine("Type of format (1 is PCM) = {0}", typeOfFormat);
            return typeOfFormat;
        }

        internal static void GetFmtText(byte[] forwardsWavFileStreamByteArray)
        {
            int startIndex = 12;
            int endIndex = 15;
            GetAsciiText(forwardsWavFileStreamByteArray, startIndex, endIndex);
        }

        internal static string GetWaveText(byte[] forwardsWavFileStreamByteArray)
        {
            int startIndex = 8;
            int endIndex = 11;
            return GetAsciiText(forwardsWavFileStreamByteArray, startIndex, endIndex);
        }

        internal static string GetRiffText(byte[] forwardsWavFileStreamByteArray)
        {
            int startIndex = 0;
            int endIndex = 3;
            return GetAsciiText(forwardsWavFileStreamByteArray, startIndex, endIndex);
        }

        internal static uint GetLengthOfFormatData(byte[] forwardsWavFileStreamByteArray)
        {
            int startIndex = 16;
            int endIndex = 19;
            byte[] lengthOfFormatDataByteArray = GetRelevantBytesIntoNewArray(forwardsWavFileStreamByteArray, startIndex, endIndex);
            uint lengthOfFormatData = BitConverter.ToUInt32(lengthOfFormatDataByteArray, 0);
            Console.WriteLine("Length of format data = {0}", lengthOfFormatData);
            return lengthOfFormatData;
        }

        internal static byte[] GetRelevantBytesIntoNewArray(byte[] forwardsWavFileStreamByteArray, int startIndex, int endIndex)
        {
            int length = endIndex - startIndex + 1;
            byte[] relevantBytesArray = new byte[length];
            Array.Copy(forwardsWavFileStreamByteArray, startIndex, relevantBytesArray, 0, length);
            return relevantBytesArray;
        }

        internal static uint GetFileSize(byte[] forwardsWavFileStreamByteArray)
        {
            int fileSizeStartIndex = 4;
            int fileSizeEndIndex = 7;
            byte[] fileSizeByteArray = GetRelevantBytesIntoNewArray(forwardsWavFileStreamByteArray, fileSizeStartIndex, fileSizeEndIndex);
            uint fileSize = BitConverter.ToUInt32(fileSizeByteArray, 0) + 8;
            Console.WriteLine("File size = {0}", fileSize);
            return fileSize;
        }

        internal static string GetAsciiText(byte[] forwardsWavFileStreamByteArray, int startIndex, int endIndex)
        {
            string asciiText = "";
            for (int i = startIndex; i <= endIndex; i++)
            {
                asciiText += Convert.ToChar(forwardsWavFileStreamByteArray[i]);
            }
            Console.WriteLine(asciiText);
            return asciiText;
        }

        internal static ushort GetNumOfChannels(byte[] forwardsWavFileStreamByteArray)
        {
            int numOfChannelsStartIndex = 22;
            int numOfChannelsEndIndex = 23;
            byte[] numOfChannelsByteArray = GetRelevantBytesIntoNewArray(forwardsWavFileStreamByteArray, numOfChannelsStartIndex, numOfChannelsEndIndex);
            ushort numOfChannels = BitConverter.ToUInt16(numOfChannelsByteArray, 0);
            Console.WriteLine("Number Of Channels = {0}", numOfChannels);
            return numOfChannels;
        }

        internal static uint GetSampleRate(byte[] forwardsWavFileStreamByteArray)
        {
            int sampleRateStartIndex = 24;
            int sampleRateEndIndex = 27;
            byte[] sampleRateByteArray = GetRelevantBytesIntoNewArray(forwardsWavFileStreamByteArray, sampleRateStartIndex, sampleRateEndIndex);
            uint sampleRate = BitConverter.ToUInt32(sampleRateByteArray, 0);
            Console.WriteLine("Sample Rate = {0}", sampleRate);
            return sampleRate;
        }

        internal static uint GetBytesPerSecond(byte[] forwardsWavFileStreamByteArray)
        {
            int bytesPerSecondStartIndex = 28;
            int bytesPerSecondEndIndex = 31;
            byte[] bytesPerSecondByteArray = GetRelevantBytesIntoNewArray(forwardsWavFileStreamByteArray, bytesPerSecondStartIndex, bytesPerSecondEndIndex);
            uint bytesPerSecond = BitConverter.ToUInt32(bytesPerSecondByteArray, 0);
            Console.WriteLine("Bytes Per Second = {0}", bytesPerSecond);
            return bytesPerSecond;
        }

        internal static ushort GetBlockAlign(byte[] forwardsWavFileStreamByteArray)
        {
            int blockAlignStartIndex = 32;
            int blockAlignEndIndex = 33;
            byte[] blockAlignByteArray = GetRelevantBytesIntoNewArray(forwardsWavFileStreamByteArray, blockAlignStartIndex, blockAlignEndIndex);
            ushort blockAlign = BitConverter.ToUInt16(blockAlignByteArray, 0);
            Console.WriteLine("Block Align = {0}", blockAlign);
            return blockAlign;
        }

        internal static ushort GetBitsPerSample(byte[] forwardsWavFileStreamByteArray)
        {
            int bitsPerSampleStartIndex = 34;
            int bitsPerSampleEndIndex = 35;
            byte[] bitsPerSampleByteArray = GetRelevantBytesIntoNewArray(forwardsWavFileStreamByteArray, bitsPerSampleStartIndex, bitsPerSampleEndIndex);
            ushort bitsPerSample = BitConverter.ToUInt16(bitsPerSampleByteArray, 0); 
            Console.WriteLine("Bits Per Sample = {0}", bitsPerSample);
            return bitsPerSample;
        }

        internal static void GetDataText(byte[] forwardsWavFileStreamByteArray)
        {
            int startIndex = 70;
            int endIndex = 73;
            GetAsciiText(forwardsWavFileStreamByteArray, startIndex, endIndex);
        }

        internal static void GetListText(byte[] forwardsWavFileStreamByteArray)
        {
            int startIndex = 36;
            int endIndex = 39;
            GetAsciiText(forwardsWavFileStreamByteArray, startIndex, endIndex);
        }

        internal static uint GetDataSize(byte[] forwardsWavFileStreamByteArray)
        {
            int dataSizeStartIndex = 70;
            int dataSizeEndIndex = 73;
            byte[] dataSizeByteArray = GetRelevantBytesIntoNewArray(forwardsWavFileStreamByteArray, dataSizeStartIndex, dataSizeEndIndex);
            uint dataSize = BitConverter.ToUInt16(dataSizeByteArray, 0);
            Console.WriteLine("Data Size = {0}", dataSize);
            return dataSize;
        }
    }
}