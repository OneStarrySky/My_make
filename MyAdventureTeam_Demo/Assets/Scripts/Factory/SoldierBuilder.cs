using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 建立Soldier时所需的参数
public class SoldierBuildParam : ICharacterBuildParam
{
	public CardData cardData = null;
	public SoldierBuildParam()
	{

	}
}

/// <summary>
/// Soldier各部位的建立  （组合模式）
/// </summary>
public class SoldierBuilder : ICharacterBuilder
{
	private SoldierBuildParam m_BuildParam = null;
	private MonsterData monster = null;
	public override void SetBuildParam(ICharacterBuildParam theParam)
	{
		m_BuildParam = theParam as SoldierBuildParam;
		//monster = Deserialization.Instance.MonsterDatas[m_BuildParam.cardData.objId];
	}

	// 载入Asset中的角色模型
	public override void LoadAssetGameObject()
	{
		GameObject go = LoadAsset.Instance.LoadResources<GameObject>(LoadAssetType.Model, "Boy");
		GameObject temp = GameObject.Instantiate(go);
		temp.transform.position = Vector3.zero;
		m_BuildParam.NewCharacter.SetGameObject(go);
	}

	// 加入OnClickScript
	public override void AddOnClickScript()
	{
	
	}

	// 设定角色能力
	public override void SetCharacterAttr()
	{
		AIMonster aIMonster = new AIMonster(m_BuildParam.NewCharacter);
		PatrolAI patrolAI = new PatrolAI();
		aIMonster.ChangeAIState(patrolAI);
		m_BuildParam.NewCharacter.SetAI(aIMonster);
	}

	// 加入AI
	public override void AddAI()
	{
		
	}

	// 加入管理器
	public override void AddCharacterSystem(GameManage gameManage)
	{
		
	}
}
