namespace FlappyBird3Layer.Data
{
    public interface IScoreRepository
    {
        int GetHighScore();
        void SaveHighScore(int score);
    }
}
