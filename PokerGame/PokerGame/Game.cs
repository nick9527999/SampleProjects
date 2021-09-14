using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    /// <summary>
    /// 单个游戏
    /// </summary>
    public class Game:IGame
    {
        private List<int> pokers;       //牙签集合数，对应每一行的牙签数量
        private List<User> users;      //玩家集合
        private User currentUser;      //当前玩家
        private int currentUserIndex;  //当前玩家索引

        /// <summary>
        /// 创建游戏
        /// </summary>
        /// <param name="pokers">牙签集合</param>
        /// <param name="users">玩家集合</param>
        public Game(List<int> pokers, List<User> users)
        {
            this.pokers = pokers;
            this.users  = users;
            currentUser = users[0];
            currentUserIndex = 0;
        }

        /// <summary>
        /// 当前用户
        /// </summary>
        public User GetCurrentUser()
        {
              return currentUser;  
            
        }

        /// <summary>
        /// 抽牙签，返回false即抽取了最后的牙签
        /// </summary>
        /// <param name="line">抽第几行</param>
        /// <param name="num">抽取多少数量</param>
        /// <returns></returns>
        public bool Pick(int line, int num)
        {

            pokers[line - 1] -= num;
            return pokers[line - 1] > 0;
        }

        /// <summary>
        /// 游戏的下一步
        /// </summary>
        /// <returns>若返回false则输了</returns>
        public bool Next()
        {
            Tools.ShowLine("现在轮到"+currentUser.Name);
            int line = getLineNumber();
            int num  = getPickNumber();
            bool iswin =currentUser.Play(this,line, num);
            if(iswin)
            {
                currentUserIndex = (currentUserIndex + 1) % users.Count;
                currentUser = users[currentUserIndex];
            }
            return iswin;

        }

        /// <summary>
        /// 获取行数
        /// </summary>
        /// <returns></returns>
        private int getLineNumber()
        {
            int linenum = Tools.getValue<int>("请输入您要抽取的行数，以1为第1行...", int.TryParse, 
                "输入错误，请重新输入您要抽取的行数，以1为第1行...");
            while(linenum < 1 || linenum > pokers.Count)
            {
                Tools.ShowLine("抽取行数必须在1-"+pokers.Count.ToString()+"之内，请重新输入");
                linenum = Tools.getValue<int>("", int.TryParse,
                "输入错误，请重新输入您要抽取的行数，以1为第1行...");
            }
            return linenum;
        }

        /// <summary>
        /// 获取行内牙签数
        /// </summary>
        /// <returns></returns>
        private int getPickNumber()
        {
            int num = Tools.getValue<int>("请输入您要抽取的牙签数...", int.TryParse,
                "输入错误，请重新输入您要抽取的牙签数...");
            while(num < 1)
            {
                Tools.ShowLine("抽取牙签数必须大于0，请重新输入");
                num = Tools.getValue<int>("请输入您要抽取的牙签数...", int.TryParse,
                "输入错误，请重新输入您要抽取的牙签数...");
            }
            return num;
        }
        
        
    }
}
