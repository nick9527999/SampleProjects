using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameCenter gameCenter = new GameCenter();
            bool again = true;
            while (again)
            {
                gameCenter.pareperNewGame();
                gameCenter.StartGame();
                Tools.ShowLine("再玩一遍？请输入y");
                again = Tools.GetInput() == "y";
            }
            Tools.ShowLine("游戏结束，按回车键退出");
            Tools.GetInput();

        }
    }
}
