using NAudio.Wave;

namespace Infrastructure
{
    public class Data
    {
        public string path;
        public int index;
        public string extension;

        public Data(string pth, int indx, string ext)
        {
            path = pth;
            index = indx;
            extension = ext;
        }
    }
}
