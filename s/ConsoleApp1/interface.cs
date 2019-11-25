using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ConsoleApp1;
class InterFace //界面
{    public void MainFace(Player A,Boss B,Mob C,Store D)
    {
        Console.WriteLine("\n\n               "+A.Getname()+'\n');
        Console.WriteLine("\t\t\t *************主界面*************\n");
        Console.WriteLine("\t\t\t\t1.角色装备");
        Console.WriteLine("\t\t\t\t2.角色状态");
        Console.WriteLine("\t\t\t\t3.角色技能");
        Console.WriteLine("\t\t\t\t4.商店");
        Console.WriteLine("\t\t\t\t5.探险模式");
        Console.WriteLine("\t\t\t\t6.Boss战\n");
        Console.WriteLine("\t\t\t\t0.退出游戏\n");
        Console.Write("\t\t\t请输入：");
        int c = Convert.ToInt32(Console.ReadLine());//玩家选择
        Console.WriteLine("                           加载中......");
        Thread.Sleep(1000);
        Console.Clear();
        if (c == 1) //显示玩家装备界面
        {
            RoleEquipment(A, B, C, D);
        }
        if (c == 2) //显示玩家状态界面
        {
            RoleCondition(A, B, C, D);
        }
        if (c == 3) //显示玩家技能界面
        {
           RoleSkill(A, B, C, D);
        }
        if (c == 4) //显示商店界面
        {
            store(A, B, C, D);
        }
        if (c == 5) //显示探险模式界面
        {
           AdventureMode(A,B, C, D);
        }
        if (c == 6) //显示Boss战界面
        {
            B.Fight(A,B,C,D);
        }
        if(c==0)
        {
            Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t**************下次再见，谢谢(^_^)************");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
    }
    public Player RoleEquipment(Player A, Boss B, Mob C, Store D) //角色装备
    {
        int i = 0,j=1;
        Console.WriteLine("\t\t\t *************角色装备界面*************\n");
        Console.WriteLine("\t\t\t{0}身着{1}，佩戴{2}，十分好看！", A.Getname(), A.GetClothes(), A.GetWeapon());
        Console.WriteLine("\n\t\t\t仓库:");
        for (i = 0; i < 15; i++)
        {
            if (A.GetHouse()[i] != null)
            {
                Console.WriteLine("\t\t\t{0}：{1}", j++, A.GetHouse()[i]);
            }
        }
        Console.Write("\n\t\t\t请输入要替换的装备的名字，按0退出到主界面，" +
            "按1回到探险模式，按2回到Boss战：");
        string c = Console.ReadLine();
        for (i=0;i<15;i++)
        {
            if (c == A.GetHouse()[i] && c.Length >4) A.ChangeClothes(c);
            if (c == A.GetHouse()[i] && c.Length <= 4) A.ChangeWeapon(c);
            else Console.WriteLine("没有当前物品!");
        }
        if(c=="0")
        {
            Console.Clear();
            MainFace(A,B,C,D);
            return A ;
        }
        else if(c=="1")
        {
            Console.Clear();
            AdventureMode (A, B, C, D);
            return A;
        }
        else if(c=="2")
        {
            Console.Clear();
            B.Fight(A, B, C, D);
            return A;
        }
        else
        {
            Console.Clear();
            RoleEquipment(A, B, C, D);
            return A;
        }
    }
    public void RoleCondition(Player A, Boss B, Mob C, Store D) //角色状态
    {
        Console.WriteLine("\n\t\t\t *************角色状态界面*************\n");
        Console.WriteLine("\t\t\t血量：{0}\n\t\t\t魔法值：{1}\n\t\t\t金币：{2}\n\t\t\t等级：{3}",
            A.ChangeHP(0), A.ChangeMP(0), A.GetMoney(0),A.ChangeLevel (0));
        Console.Write("\n\t\t\t按0退出到主界面，" +
            "按1回到探险模式，按2回到Boss战：");
        string c = Console.ReadLine();
        if (c == "0")
        {
            Console.Clear();
            MainFace(A, B, C, D);
            
        }
        else if (c == "1")
        {
            Console.Clear();
            AdventureMode(A, B, C, D);
           
        }
        else if (c == "2")
        {
            Console.Clear();
            B.Fight(A, B, C, D);
           
        }
    }
    public void RoleSkill(Player A, Boss B, Mob C, Store D)//角色技能
    {
        int i = 0;
        Console.WriteLine("\n\t\t\t *************角色技能界面*************\n");
        Console.WriteLine("\t\t\t目前使用的技能是：{0}", A.GetSki());
        Console.WriteLine("\t\t\t当前可用的技能：");
        for (i = 0; i < A.j; i++)
        {
            Console.WriteLine("\t\t\t{0}:{1}", i + 1, A.GetSkill()[i]);
        }
        Console.Write("\n\t\t\t请输入要使用的技能(ps：括号内的内容不要输入)，\n\t\t\t否则按0退出到主界面，" +
            "按1回到探险模式，按2回到Boss战：");
        string c = Console.ReadLine();
        if (c == "0")
        {
            Console.Clear();
            MainFace(A, B, C, D);

        }
        else if (c == "1")
        {
            Console.Clear();
            AdventureMode(A, B, C, D);

        }
        else if (c == "2")
        {
            Console.Clear();
            B.Fight(A, B, C, D);

        }
        else
        {
            A.ChangeSkill(c);
            Console.Clear();
            RoleSkill(A, B, C, D);
          
        }
    }
    public void store(Player A, Boss B, Mob C, Store D) //商店
    {
        int i = 0;
        Console.WriteLine("\n\t\t\t *************商店界面*************\n");
        Console.WriteLine("\t\t\t服装类：");
        for (i = 0; i < 5; i++)
        {

            Console.WriteLine("\t\t\t{0}:{1},", i + 1, D.clothes1[i]);

        }
        //Console.Write('\n');
        Console.WriteLine("\t\t\t武器类：");
        for (i = 0; i < 5; i++)
        {

            Console.WriteLine("\t\t\t{0}:{1},", i + 1, D.Weapon[i]);

        }
        Console.Write("\n\t\t\t输入0退出，输入要购买的商品的名字完成购买，请输入：");
        string c=Console.ReadLine();
        A.AddHouse(c);
        if(c== "小红帽套装"||c== "花舞精灵套装"||c=="木剑"||c=="弓箭")
        {
            A.GetMoney(-10);
            Console.WriteLine("\t\t\t你已成功购买，花费了10金币！");
            Console.Write("\t\t\t请输入0退出：");
            Console.ReadLine();
            Console.Clear();
            MainFace(A, B, C, D);
        }
        if(c== "流光背饰装"||c== "拳击手套")
        {
            A.GetMoney(-5);
            Console.WriteLine("\t\t\t你已成功购买，花费了5金币！");
            Console.Write("\t\t\t请输入0退出：");
            Console.ReadLine();
            Console.Clear();
            MainFace(A, B, C, D);

        }
        if(c== "水冰月套装"||c== "大刀")
        {
            A.GetMoney(-15);
            Console.WriteLine("\t\t\t你已成功购买，花费了15金币！");
            Console.Write("\t\t\t请输入0退出：");
            Console.ReadLine();
            Console.Clear();
            MainFace(A, B, C, D);
        }
        if(c== "雪凝冰羽套装"||c== "长剑")
        {
            if (A.GetMoney(0) > 0)
            {
                A.GetMoney(-20);
                Console.WriteLine("\t\t\t你已成功购买，花费了20金币！");
            }
            else Console.WriteLine("\t\t\t当前金币不足!");
            Console.Write("\t\t\t请输入0退出：");
            Console.ReadLine();
            Console.Clear();
            MainFace(A, B, C, D);
        }
        if(c=="0")
        {
            Console.Clear();
            MainFace(A, B, C, D);
        }
    }
    public int AdventureMode(Player A, Boss B, Mob C, Store D)  //探险模式
    {
        Console.WriteLine("\t\t\t *************探险模式*************\n");
        Random r = new Random();
        int a, flag = 0;
        int c = 1;
        while (c != 0)
        {
            if (C.HP <= 0)
            {
                Console.WriteLine("\t\t\t小怪已经全部死亡，{0}升了3级", A.Getname());
                A.ChangeLevel(3);
                Console.WriteLine("\t\t\t开始下一回合");
                C.HP = 100;
                Console.WriteLine ("\t\t\t加载中....");
                Thread.Sleep(1500);
                C.HP = 80;//恢复血量
                Console.Clear();
            }
            if(A.ChangeHP (0)<=0)
            {
                Console.WriteLine("\t\t\t你已死亡，即将退出探险模式....");
                Thread.Sleep(1500);
                A.ChangeHP(100);
                C.HP = 80;
                break;
            }
            a = r.Next(1, 56); //游戏中随机发生一些事件
                if (a < 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t小怪使用了撞击\n\t\t\t对{0}造成了5点伤害", A.Getname());
                    A.ChangeHP(-5);
                Console.ForegroundColor = ConsoleColor.White  ;
                flag = 1;//用来记录游戏发生了哪个事件
                }
                if (a >= 10 && a < 30)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t小怪使用了变硬\n\t\t\t小怪的防御力提升了");
                    Console.WriteLine("\t\t\t对{0}造成了5点伤害", A.Getname());
                    A.ChangeHP(-5);
                Console.ForegroundColor = ConsoleColor.White ;
                flag = 2;//用来记录游戏发生了哪个事件
                }
                if (a >= 30 && a < 40)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t小怪使用了眩晕\n\t\t\t{0}晕了，分不清方向\n\t\t\t小怪继续攻击", A.Getname());
                    Console.WriteLine("\t\t\t对{0}造成了5点伤害", A.Getname());
                    A.ChangeHP(-5);
                Console.ForegroundColor = ConsoleColor.White;
                flag = 3;
                }
                if (a >= 40 && a < 50)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t小怪使用了定身术\n\t\t\t{0}动不了了\n\t\t\t小怪继续攻击", A.Getname());
                    Console.WriteLine("\t\t\t对{0}造成了5点伤害", A.Getname());
                    A.ChangeHP(-5);
                Console.ForegroundColor = ConsoleColor.White ;
                flag = 4;
                }
                if (a >= 50 && a < 51)
            {
                Console.ForegroundColor = ConsoleColor.Blue ;
                Console.WriteLine("\t\t\t{0}捡到了一个宝箱，打开一看，原来是花舞精灵套装！", A.Getname());
                    A.AddHouse("花舞精灵套装");
                Console.ForegroundColor = ConsoleColor.White;
                flag = 7;
                }
                if (a >= 51 && a < 52)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\t{0}捡到了一个宝箱，打开一看，原来是25金币！", A.Getname());
                    A.GetMoney(25);
                Console.ForegroundColor = ConsoleColor.White ;
                flag = 9;
                }
                if (a >= 52 && a < 53)
            {
                Console.ForegroundColor = ConsoleColor.Blue ;
                Console.WriteLine("\t\t\t{0}捡到了一个宝箱，打开一看，恭喜你获得凝固技能！", A.Getname());
                    A.AddSkill("凝固（伤害5，消耗魔法值5）");
                Console.ForegroundColor = ConsoleColor.White;
                flag = 10;
                }
                if (a >= 53 && a < 54)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\t{0}捡到了一个宝箱，打开一看，恭喜你获得万箭齐发技能！", A.Getname());
                    A.AddSkill("万箭齐发（伤害10，消耗魔法值10）");
                Console.ForegroundColor = ConsoleColor.White;
                flag = 11;
                }
                if (a >= 54 && a < 55)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\t{0}捡到了一个宝箱，打开一看，恭喜你获得瞬间移动技能！", A.Getname());
                    A.AddSkill("瞬间移动（伤害5，消耗魔法值5）");
                Console.ForegroundColor = ConsoleColor.White;
                flag = 12;
                }
                if (a >= 55 && a < 56)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\t{0}捡到了一个宝箱，打开一看，恭喜你获得霹雳斩技能！", A.Getname());
                    A.AddSkill("霹雳斩（伤害10，消耗魔法值10）");
                Console.ForegroundColor = ConsoleColor.White;
                flag = 12;
                }
            Console.Write("\n\t\t\t按1攻击，按2切换装备，按3查看技能,按4查看状态，按5使用技能，按0退出：");
             c = Convert.ToInt32(Console.ReadLine());
            if(c==1)
            {

                if (A.GetWeapon() == "木剑" || A.GetWeapon() == "拳击手套")
                {
                    C.HP -= 5;
                    Console.ForegroundColor = ConsoleColor.Yellow ;
                    Console.WriteLine("\n\t\t\t{0}使用了{1}对小怪们造成了5点伤害\n", A.Getname(), A.GetWeapon());
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (A.GetWeapon() == "弓箭" || A.GetWeapon() == "大刀")
                {
                    C.HP -= 10;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\t\t\t{0}使用了{1}对小怪们造成了10点伤害\n", A.Getname(), A.GetWeapon());
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (A.GetWeapon() == "长剑")
                {
                    C.HP -= 20;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\t\t\t{0}使用了{1}对小怪们造成了20点伤害\n", A.Getname(), A.GetWeapon());
                    Console.ForegroundColor = ConsoleColor.White 
                        ;
                }
            }
            if(c==2)
            {
                Console.Clear();
                RoleEquipment(A, B, C, D);

            }
            if(c==3)
            {
                Console.Clear();
                RoleSkill(A, B, C, D);
            }
            if(c==4)
            {
                Console.Clear();
                RoleCondition(A, B, C, D);
            }
            if (c == 5)
            {


                if (A.GetSki() == "火焰" || A.GetSki() == "凝固" || A.GetSki() == "瞬间移动")
                {
                    if (A.ChangeMP(0) >= 5)
                    {
                        C.HP -= 5;//对小怪伤害5
                        A.ChangeMP(-5);//消耗魔法值5
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\t\t\t{0}使用了{1}对小怪们造成了5点伤害\n", A.Getname(), A.GetSki());
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else Console.WriteLine("\n\t\t\t魔法值不足，无法使用该技能！");
                }


                if (A.GetSki() == "霹雳斩" || A.GetSki() == "万箭齐发")
                {
                    if (A.ChangeMP(0) >= 10)
                    {
                        C.HP -= 10;//对小怪伤害10
                        A.ChangeMP(-10);//消耗魔法值10
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\t\t\t{0}使用了{1}对小怪们造成了10点伤害\n", A.Getname(), A.GetSki());
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else Console.WriteLine("\n\t\t\t魔法值不足，无法使用该技能！");
                }
                if (A.GetSki() == "五项全能")
                {
                    if (A.ChangeMP(0) >= 10)
                    {
                        C.HP -= 20;//对小怪伤害20
                        A.ChangeMP(-10);//消耗魔法值10
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\t\t\t{0}使用了{1}对小怪们造成了20点伤害\n", A.Getname(), A.GetSki());
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else Console.WriteLine("\n\t\t\t魔法值不足，无法使用该技能！");
                }
            }
        }
        Console.Clear();
        MainFace(A, B, C, D);
        return flag;
    }

}

