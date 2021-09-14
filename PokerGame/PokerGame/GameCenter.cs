using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    /// <summary>
    /// 游戏管理中心，可以添加方法保存和显示游戏历史
    /// </summary>
    public class GameCenter
    {
        /// <summary>
        /// 初始化游戏
        /// </summary>
        /// <param name="pokers">牙签集合数，对应每一行的牙签数</param>
        /// <param name="users">玩家集合</param>
        private void InitGame(List<int> pokers , List<User> users )
        {

            currentGame = new Game(pokers, users);
            
        }
        /// <summary>
        /// 当前游戏
        /// </summary>
        private IGame currentGame;

        /// <summary>
        /// 准备新游戏
        /// </summary>
        public void pareperNewGame()
        {
            var users = Tools.getValue<List<User>>("请输入玩家名字，以逗号隔开,最少两个玩家，如：Nick,Frankie,TT", 
                (string input,out List<User> o_users) => 
                {
                    o_users = new List<User>();
                    try
                    {
                        var usersname = input.Split(',').ToList();
                        if(usersname.Count<=1)
                        {
                            return false;
                        }
                        for(int i=0; i<usersname.Count; i++)
                        {
                            o_users.Add(new User(usersname[i]));
                        }
                        return true;
                    }
                    catch(Exception ex)
                    {
                        Tools.ShowLine(ex.Message);
                    }
                    return false;
                },
                "输入错误，请重新输入：");
            Tools.ShowLine("是否按默认3行3，5，7跟牙签开始游戏？（y/n）");
            if(Tools.GetInput()=="y")
            {
                InitGame(new List<int> { 3, 5, 7 }, users);
            }
            else
            {
                int lines = Tools.getValue<int>("请输入行数，数量在1-10之间", int.TryParse, 
                    "输入错误，请重新输入行数", n => n > 0 && n < 100);
                List<int> numPerLine = new List<int>();
                for(int line=0; line < lines; line++)
                {
                    numPerLine.Add(Tools.getValue<int>("请输入第" + (line+1).ToString() + "行牙签数,数量在1-100之间", 
                        int.TryParse, "输入错误，请重新输入", n => n > 0 && n < 100));
                }
                InitGame(numPerLine, users);
            }
        }

        /// <summary>
        /// 开始游戏
        /// </summary>
        public void StartGame()
        {
            while(currentGame.Next())
            {
                Tools.ShowLine("-------------------------------------------------");
            }
            Tools.ShowLine(currentGame.GetCurrentUser().Name+",您输了！");
        }
    }
}
