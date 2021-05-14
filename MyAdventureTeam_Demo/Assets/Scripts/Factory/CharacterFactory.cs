using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 产生游戏角色工厂（建造者模式）
public class CharacterFactory : ICharacterFactory
{
	// 角色建立指导者
	private CharacterBuilderSystem m_BuilderDirector = new CharacterBuilderSystem(GameManage.Instance);

	// 建立Soldier
	public override Soldier CreateSoldier(CardData cardData, Vector3 SpawnPosition)
	{
		// 产生Soldier的参数
		SoldierBuildParam SoldierParam = new SoldierBuildParam();

		// 设定参数
		SoldierParam.NewCharacter = new Soldier();
		SoldierParam.SpawnPosition = SpawnPosition;
		SoldierParam.cardData = cardData;

		//  产生对应的Builder及设定参数
		SoldierBuilder theSoldierBuilder = new SoldierBuilder();
		theSoldierBuilder.SetBuildParam(SoldierParam);

		// 参数
		m_BuilderDirector.Construct(theSoldierBuilder);
		return SoldierParam.NewCharacter;
	}
}


