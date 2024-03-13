using IoDeSer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public int CheckPointNumber { get; set; }

        public override string ToString()
        {
            return $"Save: {SceneNumber}\t{Name}\t({CheckPointNumber})";
        }


        public static Game StartNew(string SaveFileNumber)
        {
            var splits = SaveFileNumber.Split(' ');
            var joined = $"{splits[0].ToLower()}{int.Parse(splits[1]) - 1}.io";

            var new_game = new Game() { SceneNumber = 1, Name = joined, CheckPointNumber = 0 };
            new_game.Save();

            return new_game;
        }

        public void Save()
        {
            try
            {
                var docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var game_dir = Path.Combine(docs, "CirclingDifferent");
                var save_dir = Path.Combine(game_dir, Name);

                File.WriteAllText(save_dir, IoFile.WriteToString(this));
            }
            catch (Exception) { }
        }

        internal void Delete()
        {
            try
            {
                var docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var game_dir = Path.Combine(docs, "CirclingDifferent");
                var save_dir = Path.Combine(game_dir, Name);

                File.Delete(save_dir);
            }
            catch (Exception) { }
        }
    }
}
