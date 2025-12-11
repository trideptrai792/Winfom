using System;
using System.IO;

namespace FlappyBird3Layer.Data
{
    public class FileScoreRepository : IScoreRepository
    {
        private readonly string _filePath;

        public FileScoreRepository(string filePath)
        {
            _filePath = filePath;
        }

        public int GetHighScore()
        {
            try
            {
                if (!File.Exists(_filePath)) return 0;
                var text = File.ReadAllText(_filePath);
                if (int.TryParse(text, out int s)) return s;
            }
            catch { }
            return 0;
        }

        public void SaveHighScore(int score)
        {
            try
            {
                File.WriteAllText(_filePath, score.ToString());
            }
            catch { }
        }
    }
}
