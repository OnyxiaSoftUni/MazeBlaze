using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeBlaze.Models
{
    public class Character
    {
        public Character()
        {
        }

        public Character(string name)
        {
            this.Name = name;
            this.MaxStage = 1;
        }

        public string Name { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int MaxStage { get; set; }
    }
}