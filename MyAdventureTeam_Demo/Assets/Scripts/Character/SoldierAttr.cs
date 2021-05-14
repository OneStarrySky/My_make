using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Soldier数值实现
/// </summary>
public class SoldierAttr : ICharacterAttr
{
	public SoldierAttr()
	{
		UnityTool.M_Debug("角色数值类");
	}

	// 设定角色数值
	public void SetSoldierAttr(BaseAttr BaseAttr)
	{
		// 共用元件
		base.SetBaseAttr(BaseAttr);
	}

}