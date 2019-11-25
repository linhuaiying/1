using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ConsoleApp1;
class Boss //Boss 类
{
    public int HP = 120;
    public void Fight(Player A, Boss B, Mob C, Store D) //战斗
    {
        Console.WriteLine("\t\t\t *************Boss战*************\n");
        InterFace M = new InterFace();
        Random r = new Random();
        int a, flag = 0;
        int c = 1;
        while (c != 0)
        {
            if (HP <= 0)
            {
                Console.WriteLine("\t\t\t恭喜！你打败了食人花！{0}成功升了20级", A.Getname());
                A.ChangeLevel(20);
                Console.WriteLine("\t\t\t即将退出Boss战");
                Thread.Sleep(1500);
                HP = 120;//恢复血量
                break;
            }
            if (A.ChangeHP(0) <= 0)
            {
                Console.WriteLine("\t\t\t你已死亡，即将退出Boss战....");
                Thread.Sleep(1500);
                A.ChangeHP(100);//恢复血量
                HP = 120;
                break;
            }
            a = r.Next(1, 30);
            if (a < 10  ) 
            {
                Console.WriteLine("\t\t\t食人花发动了百花齐放功能，小心！");
                Console.WriteLine("\t\t\t{0}被花击中，受到了20点伤害", A.Getname());
                A.ChangeHP(-20);
                flag = 1;//用来记录游戏发生的事件;
            }
            if (a >= 10 && a < 20 ) 
            {
                Console.WriteLine("\t\t\t食人花休眠中，这是攻击的好机会！");
                flag = 2;
            }
            if (a >= 20 && a < 30 )
            {
                Console.WriteLine("\t\t\t食人花发动了迷惑技能，{0}晕了过去\n\t\t\t受到了20点伤害",
                    A.Getname());
                A.ChangeHP(-20);
                flag = 3;
            }
            Console.Write("\n\t\t\t按1攻击，按2切换装备，按3查看技能,按4查看状态，按5使用技能，按0退出：");
            c = Convert.ToInt32(Console.ReadLine());
            if (c == 1)
            {

                if (A.GetWeapon() == "木剑" || A.GetWeapon() == "拳击手套")
                {
                    HP -= 5;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\t\t\t{0}使用了{1}对食人花造成了5点伤害\n", A.Getname(), A.GetWeapon());
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (A.GetWeapon() == "弓箭" || A.GetWeapon() == "大刀")
                {
                    HP -= 10;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\t\t\t{0}使用了{1}对食人花造成了10点伤害\n", A.Getname(), A.GetWeapon());
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (A.GetWeapon() == "长剑")
                {
                    HP -= 20;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\t\t\t{0}使用了{1}对食人花造成了20点伤害\n", A.Getname(), A.GetWeapon());
                    Console.ForegroundColor = ConsoleColor.White
                        ;
                }
            }
            if (c == 2)
            {
                Console.Clear();
                M.RoleEquipment(A, B, C, D);

            }
            if (c == 3)
            {
                Console.Clear();
                M.RoleSkill(A, B, C, D);
            }
            if (c == 4)
            {
                Console.Clear();
                M.RoleCondition(A, B, C, D);
            }
            if (c == 5)
            {
                if (A.GetSki() == "火焰" || A.GetSki() == "凝固" || A.GetSki() == "瞬间移动")
                {
                    HP -= 5;
                    A.ChangeMP(-5);//消耗魔法值5
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\t\t\t{0}使用了{1}对食人花造成了5点伤害\n", A.Getname(), A.GetSki());
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (A.GetSki() == "霹雳斩" || A.GetSki() == "万箭齐发")
                {
                    HP -= 10;
                    A.ChangeMP(-10);//消耗魔法值10
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\t\t\t{0}使用了{1}对食人花造成了10点伤害\n", A.Getname(), A.GetSki());
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (A.GetSki() == "五项全能")
                {
                    HP -= 20;
                    A.ChangeMP(-10);//消耗魔法值10
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\t\t\t{0}使用了{1}对食人花造成了20点伤害\n", A.Getname(), A.GetSki());
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        Console.Clear();
        M.MainFace(A, B, C, D);
    }
   
}
class Mob  //小怪
{
    public int HP = 80;
}