using System;
using ConsoleApp1;
class Player //玩家
{
    string name;//名称
    string sex;//性别
    int level = 1;//等级
    int HP = 100;//血量
    int MP = 100;//魔法值
    string clothes = "原始人物套装";//本游戏只提供套装
    string weapon = "木剑";//当前武器
    string ski = "火焰"; //当前技能
    string[] skill = new string[10];//角色技能库
    public int j = 1;//技能数量计数器
    public int k = 1;//仓库服装数量计数器
    public int n = 7;//仓库武器数量计数器
    string[] house = new string[15];//仓库
    int money = 100;//初始化金币为100
    public void Setname()
    {
        name = Console.ReadLine();
    }
    public string Getname()
    {
        return name;
    }
    public void SetSex()
    {
        sex = Console.ReadLine();
    }
    public string GetSex()
    {
        return sex;
    }
    public int ChangeLevel(int a)  //改变等级，当a=0时即可获取当前level
    {
        level += a;
        if (level >= 5 && level < 15)
        {
            AddSkill("凝固（伤害5，消耗魔法值5）");

        }
        if (level >= 15 && level < 30)
        {
            AddSkill("瞬间移动（伤害5，消耗魔法值5）");

        }
        if (level >= 30 && level < 60)
        {
            AddSkill("霹雳斩（伤害10，消耗魔法值10）");

        }
        if (level >= 60 && level < 99)
        {
            AddSkill("万箭齐发（伤害10，消耗魔法值10）");

        }
        if (level == 100)
        {
            AddSkill("五项全能（伤害20，消耗魔法值10）");

        }
        return level;
    }
    public int ChangeHP(int a)  //改变HP  
    {
        HP += a;
        return HP;
    }
    public int ChangeMP(int a)  //改变MP 
    {
        MP += a;
        return MP;
    }
    public void ChangeClothes(string a) //换装
    {
        clothes = a;
    }
    public string GetClothes()
    {
        return clothes;
    }
    public void ChangeWeapon(string a) //换武器
    {
        weapon = a;
    }
    public string GetWeapon()
    {
        return weapon;
    }
    public void AddHouse(string a)
    {
        int i = 0, flag = 1;
        house[0] = "原始人物套装"; //初始化仓库
        house[6] = "木剑";
        for (i = 0; i < 15; i++)
        {
            if (house[i] == a)  //如果仓库中已经有该物品则不用加入
            {
                flag = 0;
                break;
            }
        }
        if (flag == 1)
        {
            if (a.Length > 4) //说明加入的为服装
            {
                house[k] = a;
                k++;
            }
            else
            {
                house[n] = a;//说明加入的为武器
                n++;
            }
        }
    }
    public string[] GetHouse()
    {
        house[0] = "原始人物套装"; //初始化仓库
        house[6] = "木剑";
        return house;
    }
    public string[] GetSkill()
    {
        skill[0] = "火焰（伤害5，消耗魔法值5）";
        return skill;
    }
    public string ChangeSkill(string a)//换技能
    {
        ski = a;
        return ski;
    }
    public string GetSki() //获得当前技能
    {
        return ski;
    }
    public void AddSkill(string a)
    {
        int i = 0, flag = 1;
        for (i = 0; i < 10; i++)
        {
            if (skill[i] == a)  //如果已经有该技能则不用加入
            {
                flag = 0;
                break;
            }
        }
        if (flag == 1)
        {
            skill[j] = a;
            j++;
        }

    }
    public int GetMoney(int a)
    {
        money += a;
        return money;
    }
}