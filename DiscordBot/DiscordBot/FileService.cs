using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class FileService
    {
        private string videoFolderPath;
        public FileService()
        {
            SetVideoFolderPath();
        }
        public void SetVideoFolderPath()
        {
            videoFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "ylyl");
        }
        public async Task<string> GetVideoFilePath()
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(videoFolderPath);
                if (!di.Exists)
                    return null;
                var file = di.GetFiles();
                if (file.Length==0)
                    return null;
                var index = await GetRandomNumber(0, file.Length - 1);
                return file[index].FullName;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<int> GetRandomNumber(int minValue, int maxValue)
        {
            Random rng = new Random();
            await Task.CompletedTask;
            return rng.Next(minValue, maxValue + 1);
        }

    }
}
