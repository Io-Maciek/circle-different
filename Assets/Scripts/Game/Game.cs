using System;
using System.Collections.Generic;
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
    }
}
