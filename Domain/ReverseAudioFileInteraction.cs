using System;
using System.IO;
using Infrastructure;

namespace Domain
{
    public class ReverseAudioFileInteraction
    {
        public Data writeReversedWavFileByteArrayToFile(byte[] reversedWavFileStreamByteArray, Data data)
        {
            using (var reversedFileStream =
                new FileStream(Environment.CurrentDirectory + @"\temp" + data.index + data.extension, FileMode.Create,
                    FileAccess.Write, FileShare.Write))
            {
                reversedFileStream.Write(reversedWavFileStreamByteArray, 0, reversedWavFileStreamByteArray.Length);
            }

            var updater = new Updater();
            return updater.UpdateAudio(data);
        }

        public byte[] populateForwardsWavFileByteArray(string forwardsWavFilePath)
        {
            var forwardsWavFileStream =
                new FileStream(forwardsWavFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var forwardsWavFileStreamByteArray = new byte[forwardsWavFileStream.Length];
            forwardsWavFileStream.Read(forwardsWavFileStreamByteArray, 0, (int)forwardsWavFileStream.Length);
            return forwardsWavFileStreamByteArray;
        }
    }
}
