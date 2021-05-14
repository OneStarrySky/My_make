using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 可以被共用的基本角色数值界面
/// 享元模式基类
/// </summary>
public abstract class BaseAttr
{
	public abstract int GetMaxHP();
	public abstract float GetMoveSpeed();
	public abstract string GetAttrName();
}


