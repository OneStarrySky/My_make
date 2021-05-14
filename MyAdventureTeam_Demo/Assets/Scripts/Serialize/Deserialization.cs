using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

/// <summary>
/// 反序列化
/// </summary>
public class Deserialization
{
    // Singleton模版
    private static Deserialization _instance;
    public static Deserialization Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Deserialization();
            return _instance;
        }
    }

    //人物数据
    private List<RoleData> roleDatas = null;
    public List<RoleData> RoleDatas
    {
        get { return roleDatas; }
    }

    //关卡数据
    private List<StageData> stageDatas = null;
    public List<StageData> StageDatas
    {
        get { return stageDatas; }
    }

    //卡牌数据
    private List<CardData> cardDatas = null;
    public List<CardData> CardDatas
    {
        get { return cardDatas; }
    }

    //棋子数据
    private List<MonsterData> monsterDatas = null;
    public List<MonsterData> MonsterDatas
    {
        get { return monsterDatas; }
    }

    //Boos数据
    private List<BoosData> boosDatas = null;
    public List<BoosData> BoosDatas
    {
        get { return boosDatas; }
    }

    //人物卡数据
    private List<RoleCard> roleCards = null;
    public List<RoleCard> RoleCards
    {
        get { return roleCards; }
    }


    private Deserialization()
    {
        Initialize();
    }

    private void Initialize()
    {
        AnalysisRoleDatas();
        AnalysisCardDatas();
    }

    /// <summary>
    /// 解析人物数据
    /// </summary>
    private void AnalysisRoleDatas()
    {
        string path = Application.dataPath + "/Data/role.josn";
        if (File.Exists(path))
        {
            roleDatas = JsonConvert.DeserializeObject<List<RoleData>>(path);
        }
        roleDatas = new List<RoleData>();
    }

    /// <summary>
    /// 解析卡牌数据
    /// </summary>
    private void AnalysisCardDatas()
    {
        string path = Application.dataPath + "/Data/card.csv";
        if (!File.Exists(path))
        {
            return;
        }
        string[] arr = File.ReadAllLines(path);
        cardDatas = new List<CardData>();
        for (int i = 2; i < arr.Length; i++)
        {
            CardData card = new CardData();
            string[] temp = arr[i].Split(',');
            card.ID = int.Parse(temp[0]);
            card.name = temp[1];
            card.cardType = (CardType)int.Parse(temp[2]);
            card.cost = int.Parse(temp[3]);
            card.costPlace = int.Parse(temp[4]);
            card.blood = int.Parse(temp[5]);
            card.atk = int.Parse(temp[6]);
            card.sprite = temp[7];
            card.describe = temp[8];
            card.objId = int.Parse(temp[9]);

            cardDatas.Add(card);
        }
    }

}
