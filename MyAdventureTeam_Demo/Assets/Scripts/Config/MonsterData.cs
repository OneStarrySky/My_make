using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏棋子数据
/// </summary>
public class MonsterData
{
    public int ID;//棋子id
    public string objName;//模型
    public List<string> audioName;//音效
    public List<string> particleName;//特效
    public List<int> ai;//ai
    public float attackRange;//攻击距离
    public string anim;//Animator
    public CardType cardType;//类型
}
