using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Soldier角色界面
/// </summary>
public class Soldier : ICharacter
{
	protected CardType cardType = CardType.Null;

	public Soldier()
	{
	}

	public CardType GetSoldierType()
	{
		return cardType;
	}

	// 被武器攻击
	public override void UnderAttack(ICharacter Attacker)
	{
		
	}

	// 播放音效
	public void DoPlayKilledSound()
	{

	}

	// 播放特效
	public void DoShowKilledEffect()
	{

	}

}