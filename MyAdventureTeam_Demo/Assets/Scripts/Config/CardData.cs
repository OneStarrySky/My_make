using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 卡牌数据
/// </summary>
public class CardData
{
    public int ID;//id
    public string name;//名称
    public CardType cardType;//卡牌类型
    public int cost;//费用
    public int costPlace;//放置费用
    public int blood;//血量
    public int atk;//攻击力
    public string sprite;//图片
    public string describe;//描述
    public int objId;//3D模型配置表
}
/// <summary>
/// 卡牌类型
/// </summary>
public enum CardType
{
    Null = 0,
    Summon = 1,
    Build,
    Magic
}