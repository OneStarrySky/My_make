using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 可以被共用的基本角色数值
/// </summary>
public class CharacterBaseAttr : BaseAttr
{
	private int m_MaxHP;        // 初始HP值
	private float m_MoveSpeed;  // 初始移动速度
	private string m_AttrName;      // 数值的名称	

	public CharacterBaseAttr(int MaxHP, float MoveSpeed, string AttrName)
	{
		m_MaxHP = MaxHP;
		m_MoveSpeed = MoveSpeed;
		m_AttrName = AttrName;
	}
	/// <summary>
	/// 获得初始HP
	/// </summary>
	/// <returns></returns>
	public override int GetMaxHP()
	{
		UnityTool.M_Debug("享元模式获得最大血量");
		return m_MaxHP;
	}
	/// <summary>
	/// 获得初始速度
	/// </summary>
	/// <returns></returns>
	public override float GetMoveSpeed()
	{
		return m_MoveSpeed;
	}
	/// <summary>
	/// 数值名称
	/// </summary>
	/// <returns></returns>
	public override string GetAttrName()
	{
		return m_AttrName;
	}
}