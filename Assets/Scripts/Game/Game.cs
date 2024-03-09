using IoDeSer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game
{
    public class Game
    {
        public uint SceneNumber { get; set; }
        public string Name { get; set; }
        public int PlayerX { get; set; }
        public int PlayerY { get; set; }

        public override string ToString()
        {
            return $"Save: {SceneNumber}\t{Name}\t({PlayerX},{PlayerY})";
        }


        public static Game StartNew(string Name)
        {
            var new_game = new Game() { SceneNumber = 1, Name = Name, PlayerX = 0, PlayerY = 0 };


            var docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var game_dir = Path.Combine(docs, "CirclingDifferent");


            var splits = Name.Split(' ');
            var joined = $"{splits[0].ToLower()}{int.Parse(splits[1]) - 1}.io";

            var save_dir = Path.Combine(game_dir, joined);
            File.WriteAllText(save_dir, IoFile.WriteToString(new_game));

            return new_game;
        }
    }
}
