#nullable disable
using System.IO;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace FlappyBird3Layer.Business
{
    public static class Audio
    {
        private static IWavePlayer _dieOut;
        private static AudioFileReader _dieReader;

        private static IWavePlayer _jumpOut;
        private static AudioFileReader _jumpReader;

        public static void PlayDie()
        {
            Play(ref _dieOut, ref _dieReader, "die.mp3", 1.0f);
        }

        public static void PlayJump()
        {
            Play(ref _jumpOut, ref _jumpReader, "jump.mp3", 1.0f);
        }

        private static void Play(ref IWavePlayer output, ref AudioFileReader reader, string fileName, float volume)
        {
            string path = Path.Combine(Application.StartupPath, "Assets", "Sounds", fileName);
            if (!File.Exists(path)) return;

            output?.Stop();
            output?.Dispose();
            reader?.Dispose();

            reader = new AudioFileReader(path);
            reader.Volume = volume;

            output = new WasapiOut(AudioClientShareMode.Shared, 50);
            output.Init(reader);
            output.Play();
        }
    }
}
