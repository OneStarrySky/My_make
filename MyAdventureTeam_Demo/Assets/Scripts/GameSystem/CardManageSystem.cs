using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 卡牌管理系统
/// </summary>
public class CardManageSystem : IGameSystem
{
    private Dictionary<int, CardData> m_cardAll = null;//储存所有卡牌数据
    private Dictionary<int, CardData> m_cardDic = null;//储存拥有卡牌数据

    public CardManageSystem(GameManage gameManage) : base(gameManage)
    {
        Initialize();
    }

    public override void Initialize()
    {
        m_cardAll = new Dictionary<int, CardData>();
        m_cardDic = new Dictionary<int, CardData>();
        base.Initialize();
    }

    /// <summary>
    /// 拥有卡牌种类数量
    /// </summary>
    /// <returns></returns>
    public int GetCardCount()
    {
        return m_cardDic.Count;
    }

    /// <summary>
    /// 获得卡牌数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public CardData GetCard(int id)
    {
        if (m_cardAll.ContainsKey(id))
        {
            return m_cardAll[id];
        }
        return null;
    }

    /// <summary>
    /// 获得所有的卡牌
    /// </summary>
    /// <returns></returns>
    public Dictionary<int, CardData> GetCardAll()
    {
        return m_cardAll;
    }

    /// <summary>
    /// 获得所有以拥有的卡牌
    /// </summary>
    /// <returns></returns>
    public Dictionary<int, CardData> GetOwnCard()
    {
        return m_cardDic;
    }

    /// <summary>
    /// 添加卡牌
    /// </summary>
    /// <param name="card"></param>
    public void AddCard(CardData card)
    {
        if (m_cardDic.ContainsKey(card.ID))
        {
            m_cardDic.Add(card.ID, card);
        }
    }
    /// <summary>
    /// 移除卡牌
    /// </summary>
    /// <param name="id"></param>
    public void RemoveCard(int id)
    {
        if (m_cardDic.ContainsKey(id))
        {
            m_cardDic.Remove(id);
        }
    }

    public override void Release()
    {
        m_cardAll.Clear();
        m_cardDic.Clear();
        base.Release();
    }
}
