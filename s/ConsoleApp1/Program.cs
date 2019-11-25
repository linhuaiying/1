using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ConsoleApp1
{
    class Programs
    {
        static void Main(string[] args)
        {
            Player m_player = new Player();
            Boss m_boss = new Boss();
            Mob m_mob = new Mob();
            InterFace m_interface = new InterFace();
            Store m_store = new Store();
            if (Start(m_player))
            {
                Console.WriteLine("\t\t\t按下任意键继续");
                Console.ReadKey();
                Console.Clear();//清空屏幕
                GameBackground();//游戏背景对话
                Thread.Sleep(500);
                Console.WriteLine("按下任意键继续");
                Console.ReadKey();
                Console.Clear();
                m_interface.MainFace(m_player,m_boss ,m_mob ,m_store );
                
                
            }
            Console.ReadKey();
        }
        static bool Start(Player A)
        {
            //更改控制台 抬头
            Console.Title = "RPG-奇迹之城";
            Console.WriteLine("\n\t\t\t**************欢迎进入游戏**************");
            Thread.Sleep(1000);
            Console.Write("\n\t\t\t是否开始游戏？ Y.我已准备好了 N.我再想想看");
            Console.Write("\n\t\t\t\t\t");
            //判断玩家的按键，是否退出
            char c = Convert.ToChar(Console.Read());
            Console.Read();
            Console.Read();
            //玩家如果选择了退出游戏，就返回这个函数，退出游戏
            if (c == 'N')
            {
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t\t**************下次再见，谢谢(^_^)************");
                return false;
            }
            if (c == 'Y') ;
            {
                //玩家如果选择了继续游戏，出现一个加载画面
                Console.WriteLine("\t\t\t\t加载中......");
                //等待延时，制作游戏加载的假象
                Thread.Sleep(1000);
                //提示玩家输入一个角色的姓名
                Console.WriteLine("\n\n\t\t\t**************请输入角色姓名**************");
                Console.Write("\n\t\t\t**************角色姓名为：");
                //获取玩家输入的角色姓名，并且更改玩家角色类中的玩家角色姓名
                A.Setname();
                Console.Write("\n\t\t\t**************角色性别为：");
                A.SetSex();
                return true;
            }
        }
        static void GameBackground()
        {
            Console.WriteLine("\n\t\t\t**************游戏马上开始**************");
            //游戏背景对话
            Thread.Sleep(1000);
            Console.Write("\n\n\n\t\t\t好黑!!!");
            Thread.Sleep(400);
            Console.WriteLine("\t\t\t我这是在哪？∑(°Д°)");
            Thread.Sleep(1000);
            Console.WriteLine("\n\t\t\t嗷呜~~~嗷呜~~~");
            Thread.Sleep(1000);
            Console.WriteLine("\n\t\t\t啊！！！狼！！！！！！！！！");
            Thread.Sleep(1000);
            Console.WriteLine("\n\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Console.WriteLine("按下任意键继续");
            Console.ReadKey();
            Thread.Sleep(1000);
            Console.WriteLine("\n\n\n\t\t\t迷迷糊糊睁开眼······");
            Thread.Sleep(1000);
            Console.WriteLine("\n\t\t\t你醒了？");
            Thread.Sleep(1000);
            Console.WriteLine("\n\t\t\t我怎么了？我这是在哪？？？");
            Thread.Sleep(1000);
            Console.WriteLine("\n\t\t\t别害怕，这是我家，我在城外的森林里发现的你的时候你已经晕倒了。");
            Thread.Sleep(1000);
            Console.WriteLine("\n\t\t\t我怎么什么都不记得了？？？");
            Thread.Sleep(1000);
            Console.WriteLine("\n\n\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * ");
            Console.WriteLine("按下任意键继续");
            Console.ReadKey();
            Thread.Sleep(1000);
            Console.WriteLine("\n\n\t\t\t这是一座鬼城，让我们一起打败怪物逃出去吧 ");
            Thread.Sleep(500);
        }

    }
    
    

    
}
 


