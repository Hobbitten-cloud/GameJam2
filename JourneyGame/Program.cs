using JourneyGame.Models;
using NAudio.Wave;
using System;
using System.Threading.Tasks;

namespace JourneyGame
{
    public class Program
    {
        private static WaveOutEvent? _outputDevice;
        private static AudioFileReader? _audioFile;

        static void Main(string[] args)
        {
            // Start music playback in a background thread
            Task.Run(() => PlayMusic("Resources/Music/joe-biden-you-have-two-yil.mp3"));


            // NOTES 
            // Ascii font used = Doom
            // Website = https://patorjk.com/software/taag/#p=display&f=Doom&t=John+Journey&x=none&v=4&h=4&w=80&we=false

            // Initialize game components here
            var gameMenus = new Menu();
            gameMenus.StartMenu();

            // Optionally stop music when exiting
            StopMusic();
        }

        private static void PlayMusic(string filePath)
        {
            try
            {
                _audioFile = new AudioFileReader(filePath);
                _outputDevice = new WaveOutEvent();
                _outputDevice.Init(_audioFile);
                _outputDevice.Play();

                // Keep thread alive while playing
                while (_outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    System.Threading.Thread.Sleep(500);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing music: {ex.Message}");
            }
        }

        private static void StopMusic()
        {
            if (_outputDevice != null)
            {
                _outputDevice.Stop();
                _outputDevice.Dispose();
                _audioFile?.Dispose();
            }
        }
    }
}
