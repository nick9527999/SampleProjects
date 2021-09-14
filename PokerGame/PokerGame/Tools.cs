using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    public class Tools
    {
        public static void ShowLine(string msg)
        {
            Console.WriteLine(msg);
        }
        public static string GetInput()
        {
            return Console.ReadLine();
        }

        public delegate bool transform<T>(string s_value, out T value);
        public delegate bool condition<T>(T value);

        /// <summary>
        /// 从输入获取值
        /// </summary>
        /// <typeparam name="T">希望获取的值的类型</typeparam>
        /// <param name="msg">输入前的提示信息</param>
        /// <param name="tran">转换操作，会把输入的string转化为T类型</param>
        /// <param name="errorMsg">出错时显示信息</param>
        /// <param name="cond">获取的值是否符合要求的判断条件</param>
        /// <returns>获取期望的输入值</returns>
        static public T getValue<T>(string msg, transform<T> tran, string errorMsg, condition<T> cond = null)
        {
             
            Tools.ShowLine(msg);
            string value = Tools.GetInput();
            T result;
            while (!tran(value, out result) || (cond != null && !cond(result) ))
            {
                Tools.ShowLine(errorMsg);
                value = Tools.GetInput();
            }
            return result;
        }
    }
}
