using System;
using System.Threading.Tasks;
using TabbedAppXamarin.Services.Networking;
using Xamarin.Forms;

namespace TabbedAppXamarin.Services.Images
{
    public class ImageService
    {
        private const string ImageURL = "http://lorempixel.com/";
        private const string ImageWidth = "400";
        private const string ImageHeight = "/400/";
        private readonly IRestClient _restClient;
        private IDownloadImage _di;

        public ImageService()
        {
            _restClient = new RestClient();
            _di = DependencyService.Get<IDownloadImage>();
        }

        public async Task<int> SaveImage(int imageNumber)
        {
            var uri = ImageURL + ImageWidth + ImageHeight;
            var t = await _restClient.GetBytes(uri);
            _di.SaveImage(t, imageNumber);
            return 0;
        }

        public static byte[] ReadToEnd(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                var readBuffer = new byte[4096];

                var totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        var nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            var temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                var buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }

        public string ShowPath()
        {
            return _di.ShowLocalFileName();
        }

        //public async Task<byte[]> ReturnResponce()
        //{
        //    var uri = ImageURL + ImageWidth + ImageHeight;
        //    var responce = await _restClient.GetAsync(uri);
        //    return responce;

        //}
    }
}
