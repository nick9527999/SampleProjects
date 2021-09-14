using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    /// <summary>
    /// 游戏接口
    /// </summary>
    public interface IGame
    {
        bool Pick(int line, int num);
        User GetCurrentUser();
        bool Next();
    }
}
