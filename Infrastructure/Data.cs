using NAudio.Wave;

namespace Infrastructure
{
    public class Data
    {
        public MediaFoundationReader reader;
        public string path;
        public int index;
        public string extension;

        public Data(MediaFoundationReader rdr, string pth, int indx, string ext)
        {
            reader = rdr;
            path = pth;
            index = indx;
            extension = ext;
        }
    }
}
