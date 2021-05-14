using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色数值抽象类
/// </summary>
public abstract class ICharacterAttr
{
	protected BaseAttr m_BaseAttr = null;   // 基本角色数值（运用到享元模式）

	public int blood; //血量
	protected MonsterData monster = null;      // 棋子
	protected IAttrStrategy m_AttrStrategy = null;// 數值的设计策略（运用到策略模式）

	public ICharacterAttr() { }

	// 设定基本属性
	public void SetBaseAttr(BaseAttr BaseAttr)
	{
		m_BaseAttr = BaseAttr;
	}

	// 取得基本属性
	public BaseAttr GetBaseAttr()
	{
		return m_BaseAttr;
	}

	// 设定数值的计算策略
	public void SetAttStrategy(IAttrStrategy theAttrStrategy)
	{
		m_AttrStrategy = theAttrStrategy;
	}

	// 取得数值的计算策略
	public IAttrStrategy GetAttStrategy()
	{
		return m_AttrStrategy;
	}

	// 目前HP
	public int GetNowHP()
	{
		return blood;
	}

	// 增加
	public void FullNowHP(int num)
	{
		blood += num;
	}

	// 移动速度
	public virtual float GetMoveSpeed()
	{
		return 3;
	}

	/// <summary>
	/// 取得数值名称
	/// </summary>
	/// <returns></returns>
	public virtual string GetAttrName()
	{
		return m_BaseAttr.GetAttrName();
	}

	/// <summary>
	/// 初始角色數值
	/// </summary>
	public virtual void InitAttr()
	{
		m_AttrStrategy.InitAttr(this);
	}

	/// <summary>
	/// 攻击加乘
	/// </summary>
	/// <returns></returns>
	public int GetAtkPlusValue()
	{
		return m_AttrStrategy.GetAtkPlusValue(this);
	}

	/// <summary>
	/// 取得被武器攻击后的伤害值
	/// </summary>
	/// <param name="Attacker"></param>
	public void CalDmgValue(ICharacter Attacker)
	{
		
	}
}
