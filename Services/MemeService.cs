using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GodotDiscordBot.Services
{
    public class MemeService
    {
        private const string MemeListFile = "MemeList.txt";
        private const string MemeFolderPath = "Memes";
        
        private readonly Dictionary<string, string> _memes= new Dictionary<string, string>();
        private readonly Random _rnd;

        public MemeService(
            Random rnd)
        {
            _rnd = rnd;
        }
        
        public void Initialize()
        {
            LoadMemes();
        }
        
        public KeyValuePair<string, string> GetRandomMeme()
        {
            return _memes.Count > 0 ? 
                _memes.ElementAt(_rnd.Next(0, _memes.Count)) : new KeyValuePair<string, string>("", "");
        }

        private void LoadMemes()
        {
            if (!File.Exists(MemeListFile))
            {
                // Todo: log error here
                return;
            }

            var lines = File.ReadAllLines(MemeListFile);
            foreach (var line in lines)
            {
                // File Line Format:
                // Meme, Authors 
                var memeAndAuthors = line.Split(new[] {','}, 2);
                if (memeAndAuthors.Length == 2 && File.Exists($"{MemeFolderPath}/{memeAndAuthors[0]}"))
                {
                    _memes.Add(memeAndAuthors[0], memeAndAuthors[1]);
                }
                else
                {
                    // Todo: Log error here.
                }
            }
        }
    }
}