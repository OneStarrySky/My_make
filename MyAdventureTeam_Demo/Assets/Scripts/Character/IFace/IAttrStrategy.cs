using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  角色数值计数界面
/// </summary>
public abstract class IAttrStrategy
{
	// 初始的数值
	public abstract void InitAttr(ICharacterAttr CharacterAttr);

	// 攻击加乘
	public abstract int GetAtkPlusValue(ICharacterAttr CharacterAttr);

	// 取得减伤害值
	public abstract int GetDmgDescValue(ICharacterAttr CharacterAttr);
}

