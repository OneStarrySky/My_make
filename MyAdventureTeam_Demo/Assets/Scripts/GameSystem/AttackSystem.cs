using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 战斗管理类
/// </summary>
public class AttackSystem : IGameSystem
{
    private List<ICharacter> m_characters = null;
    private List<ICharacter> m_enemy = null;

    public AttackSystem(GameManage gameManage) : base(gameManage)
    {
		Initialize();
	}

	public override void Initialize()
	{
		m_characters = new List<ICharacter>();
		m_enemy = new List<ICharacter>();
	}
	public void Updata()
	{
		foreach(ICharacter item in m_characters)
		{
			item.Update();
		}
	}
	// 释放
	public override void Release()
	{
		m_characters.Clear();
		m_enemy.Clear();
		base.Release();
	}

	/// <summary>
	/// 添加友方棋子
	/// </summary>
	/// <param name="character"></param>
	public void AddCharacter(ICharacter character)
	{
		m_characters.Add(character);
	}

	/// <summary>
	/// 移除友方棋子
	/// </summary>
	/// <param name="character"></param>
	public void RemoveCharacter(ICharacter character)
	{
		m_characters.Remove(character);
	}

	/// <summary>
	/// 添加敌方棋子
	/// </summary>
	/// <param name="enemy"></param>
	public void AddEnemy(ICharacter enemy)
	{
		m_enemy.Add(enemy);
	}

	/// <summary>
	/// 移除敌方棋子
	/// </summary>
	/// <param name="enemy"></param>
	public void RemoveEnemy(ICharacter enemy)
	{
		m_enemy.Remove(enemy);
	}

	/// <summary>
	/// 获得最近攻击目标
	/// </summary>
	/// <param name="character"></param>
	/// <returns></returns>
	public ICharacter GetAttackTarget(ICharacter character)
	{
		float distance = 0;
		float num = 0;
		ICharacter target = null;
		GameObject go = character.GetGameObject();
		foreach (ICharacter item in m_characters)
		{
			GameObject t = item.GetGameObject();
			num = Vector3.Distance(go.transform.position, t.transform.position);
			if (num <= distance)
			{
				target = item;
			}
		}
		return target;
	}
	
	/// <summary>
	/// 获得范围目标
	/// </summary>
	/// <param name="character"></param>
	/// <param name="scope"></param>
	/// <returns></returns>
	public List<ICharacter> GetScopeTarget(ICharacter character, int scope)
	{
		List<ICharacter> scopeTarget = new List<ICharacter>();
		GameObject go = character.GetGameObject();
		float distance = 0;
		foreach (ICharacter item in m_characters)
		{
			GameObject t = item.GetGameObject();
			distance = Vector3.Distance(go.transform.position, t.transform.position);
			if (distance <= scope)
			{
				scopeTarget.Add(item);
			}
		}
		return scopeTarget;
	}
}
