using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 人物数据
/// </summary>
public class RoleData
{
    public int id;//人物id
    public int roleID;//人物卡ID
    public string name;//名称
    public int grade;//等级
    public int passNume;//通关数
    public Dictionary<int,int> cardConfig;//卡牌配置
    public TalentData talentConfig;//天赋配置
}

/// <summary>
/// 天赋数据
/// </summary>
public class TalentData
{
    public List<int> summon;//召唤
    public List<int> build;//建造
    public List<int> magic;//魔法
}