using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    public class User
    {
        private string name;


        public string Name
        {
            get { return name; }
            
        }
        
        public User(string name)
        {
            this.name = name;
        }

        public bool Play(IGame game, int line, int num)
        {
            return game.Pick(line, num);
        }
    }
}
